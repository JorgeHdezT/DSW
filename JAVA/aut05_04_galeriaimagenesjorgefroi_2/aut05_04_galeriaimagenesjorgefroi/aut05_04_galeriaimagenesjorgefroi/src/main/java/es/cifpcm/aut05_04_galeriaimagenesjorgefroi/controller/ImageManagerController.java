package es.cifpcm.aut05_04_galeriaimagenesjorgefroi.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpHeaders;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.multipart.MultipartFile;
import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.support.ServletUriComponentsBuilder;
import org.springframework.core.io.Resource;
import es.cifpcm.aut05_04_galeriaimagenesjorgefroi.storageService;
import org.springframework.web.servlet.mvc.support.RedirectAttributes;


import java.io.File;
import java.io.IOException;
import java.util.Arrays;
import java.util.List;
import java.util.Objects;
import java.util.stream.Collectors;

@Controller
public class ImageManagerController {

    private final storageService storageService;

    @Autowired
    public ImageManagerController(storageService storageService) {
        this.storageService = storageService;
    }

    private static final String UPLOAD_FOLDER = "src/main/resources/static/uploadsjorgefroi/images";

    @GetMapping(value = "/index")
    public ModelAndView index() {
        ModelAndView modelAndView = new ModelAndView();
        modelAndView.setViewName("index");
        return modelAndView;
    }

    @PostMapping("/imageManager")
    public ModelAndView handleFileUpload(@RequestPart("file") MultipartFile file,
                                         RedirectAttributes redirectAttributes) {
        ModelAndView modelAndView = new ModelAndView();
        if (file.isEmpty()) {
            redirectAttributes.addFlashAttribute("message", "Por favor selecciona un archivo");
            modelAndView.setViewName("index");
            return modelAndView;
        }
        String message = "";

        try {
            byte[] bytes = file.getBytes();
            File uploadDir = new File(UPLOAD_FOLDER);
            if (!uploadDir.exists()) {
                uploadDir.mkdirs();
            }
            File uploadedFile = new File(uploadDir.getAbsolutePath() + File.separator + Objects.requireNonNull(file.getOriginalFilename()));
            file.transferTo(uploadedFile);
            // Obtener la lista actualizada de imágenes
            List<String> images = getImagesList();
            modelAndView.addObject("images", images);
            message = "Imagen subida con éxito.";
            modelAndView.addObject("message", message);
            //redirectAttributes.addFlashAttribute("message", "¡Imagen subida con éxito!");
        } catch (IOException e) {
            e.printStackTrace();
            message = "No se pudo subir esa imagen.";
            modelAndView.addObject("message", message);
            //redirectAttributes.addFlashAttribute("message", "¡Error al subir la imagen!");
        }
        modelAndView.setViewName("index");
        return modelAndView;
    }

    @GetMapping("/images")
    public ModelAndView showImages(Model model) {
        ModelAndView modelAndView = new ModelAndView();
        File uploadDir = new File(UPLOAD_FOLDER);
        String[] files = uploadDir.list();
        modelAndView.addObject("files", files);
        modelAndView.addObject("timestamp", System.currentTimeMillis());  // Agregar timestamp
        modelAndView.setViewName("imagenes");
        return modelAndView;
    }

    @GetMapping("/image/{imageName}")
    public ResponseEntity<Resource> serveFile(@PathVariable String imageName) {
        Resource resource = storageService.loadAsResource(imageName);

        // Agregar timestamp como parámetro para evitar el caché del navegador
        String cacheBuster = "ts=" + System.currentTimeMillis();
        String url = ServletUriComponentsBuilder.fromCurrentContextPath()
                .path("/uploadsjorgefroi/images/" + imageName)
                .queryParam(cacheBuster)
                .toUriString();

        return ResponseEntity.ok()
                .header(HttpHeaders.CONTENT_DISPOSITION, "inline;filename=" + resource.getFilename())
                .header(HttpHeaders.CACHE_CONTROL, "no-cache, no-store, must-revalidate")
                .header(HttpHeaders.PRAGMA, "no-cache")
                .header(HttpHeaders.EXPIRES, "0")
                .header(HttpHeaders.LOCATION, url)
                .body(resource);
    }

    private List<String> getImagesList() {
        File uploadDir = new File(UPLOAD_FOLDER);
        if (uploadDir.exists()) {
            return Arrays.stream(Objects.requireNonNull(uploadDir.list()))
                    .collect(Collectors.toList());
        } else {
            return null;
        }
    }
}
