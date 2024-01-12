package es.cifpcm.AUT04_05_WebVersionJorgeFroiadd.controller;
import ch.qos.logback.core.model.Model;
import com.google.gson.Gson;
import es.cifpcm.AUT04_05_WebVersionJorgeFroiadd.data.Persistence;
import es.cifpcm.AUT04_05_WebVersionJorgeFroiadd.data.ImplementsPersistence;
import es.cifpcm.AUT04_05_WebVersionJorgeFroiadd.model.Farmacia;
import javassist.compiler.Parser;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.servlet.ModelAndView;

import java.io.FileWriter;
import java.io.IOException;
import java.sql.SQLOutput;
import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

@Controller
public class FarmaciaController {
    private static Persistence pst=new ImplementsPersistence();
    private final Gson gson = new Gson();
    private  List<Farmacia> farmacias;
    @GetMapping(value = "/index")
    public ModelAndView index(){
        ModelAndView modelAndView=new ModelAndView();
        modelAndView.setViewName("index");
        return modelAndView;
    }
    @GetMapping(value = "/farmacias")
    public ModelAndView mostrarFarmacias() {


        pst.openJSON();
        System.out.println("Se abrio el json");
        pst.readJSON(); // Asegura que la lista de farmacias esté actualizada
        System.out.println("Se leyo el json");


        ModelAndView modelAndView = new ModelAndView("farmacias");
        modelAndView.addObject("farmacias", pst.farmacias());

        return modelAndView;
    }

    /*private void printFarmacias() {
        if (farmacias != null && !farmacias.isEmpty()) {
            for (Farmacia farmacia : farmacias) {
                System.out.println(farmacia.toString());//el método que imprime todos los datos
            }
        } else {
            System.out.println("La lista de farmacias está vacía o no se cargó correctamente.");
        }
    }
    @GetMapping(value = "/near-pharmacies/withjs")
    public ResponseEntity<?> searchNearPharmacies(@RequestParam String nombreFarmacia) {
        loadPharmaciesJson();
        Farmacia pharmacyFound = searchByName(nombreFarmacia);
        if (pharmacyFound != null) {
            List<Farmacia> nearPharmacies = findNear(pharmacyFound);//en esta función hará el filtro
            if (!nearPharmacies.isEmpty()) {
                return ResponseEntity.ok(nearPharmacies);
            } else {
                return ResponseEntity.status(HttpStatus.NOT_FOUND).body("No hay farmacias cercanas para la que buscas.");
            }
        } else {
            return ResponseEntity.status(HttpStatus.NOT_FOUND).body("La farmacia buscada no fue encontrada.");
        }
    }*/
    @GetMapping(value = "/near-pharmacies")
    public ModelAndView searchNearPharmacies(@RequestParam String nombreFarmacia) {
        ModelAndView modelAndView=new ModelAndView();//instancia de modelandview a la que le puedes añadir los datos a devolver
        boolean farmaciasEncontradas=false;
        pst.readJSON();
        List<Farmacia> nearPharmacies=new ArrayList<>();
        Optional<Farmacia> pharmacyFound = searchByName(nombreFarmacia);
        if (pharmacyFound .isPresent()) {
            nearPharmacies = findNear(pharmacyFound.get());//optional con el get solo pasará cuando esté presente
            farmaciasEncontradas= !nearPharmacies.isEmpty();
        }

        modelAndView.addObject("farmaciasEncontradas",farmaciasEncontradas);
        modelAndView.addObject("nearPharmacies",nearPharmacies);
        modelAndView.addObject("nombreFarmacia",nombreFarmacia);
        int tamano= nearPharmacies.size();
        //Da error al devolver el tamaño. Probablemente porque no es un objeto, sino un numero y ya.
        modelAndView.addObject("tamano", tamano);
        modelAndView.setViewName("index");//que vista devuelve
        return modelAndView;
    }

    private List<Farmacia> findNear(Farmacia pharmacyFound) {
        List<Farmacia> nearPharmacies = new ArrayList<>();
        // Coordinates of the found pharmacy
        double utmX = pharmacyFound.getUtmX();
        double utmY = pharmacyFound.getUtmY();

        // Define proximity thresholds
        double proximityThresholdX = 1600.0;
        double proximityThresholdY = 16000.0;

        if (pst.farmacias() != null && !pst.farmacias().isEmpty()) {//exists list
            for (Farmacia farmacia : pst.farmacias()) {
                if (farmacia != null&& !farmacia.getNombre().equals(pharmacyFound.getNombre())) {
                    // Calculate the distance in X and Y coordinates
                    double distanceX = Math.abs(farmacia.getUtmX() - utmX);
                    double distanceY = Math.abs(farmacia.getUtmY() - utmY);

                    // Check if the pharmacy is within the proximity thresholds
                    if (distanceX <= proximityThresholdX && distanceY <= proximityThresholdY) {
                        nearPharmacies.add(farmacia);
                    }
                }
            }
        }

        return nearPharmacies;
    }


    private Optional<Farmacia> searchByName(String nombreFarmacia) {
        if (nombreFarmacia == null || nombreFarmacia.isEmpty()) {
            return Optional.empty();
        }

        for (Farmacia farmacia : pst.farmacias()) {
            if (farmacia.getNombre().equalsIgnoreCase(nombreFarmacia)) {
                return Optional.of(farmacia);
            }
        }
        return Optional.empty(); // Si no se encuentra ninguna farmacia con ese nombre
    }

    // Vista del formulario:
    @GetMapping(value = "/crearfarmacias")
    public ModelAndView añadirFarmaciasVista() {
        Farmacia farmacia=new Farmacia();
        ModelAndView modelAndView2 = new ModelAndView("crearfarmacias"); // Nombre de la vista (crearfarmacias.html)
        modelAndView2.addObject("farmacia",farmacia);//objeto entero
        return modelAndView2;//retorna la instancia del form
    }

    // Metodo para crear la farmacia;
    @PostMapping(value = "/addPharmacy")
    public ModelAndView addPharmacy(Farmacia farmacia) {
        String msg = "";
        ModelAndView modelAndView = new ModelAndView("crearfarmacias");

        try {
            pst.add(farmacia);
            msg = "Farmacia creada correctamente";
        } catch (NumberFormatException e) {
            msg = "Los valores de UTM_X o UTM_Y no son números válidos";
        } catch (Exception e) {
            msg = "No se pudo crear la farmacia";
        }

        modelAndView.addObject("msg", msg);
        modelAndView.addObject("farmacia", new Farmacia()); // Limpiar el objeto farmacia en el modelo

        return modelAndView;
    }



}