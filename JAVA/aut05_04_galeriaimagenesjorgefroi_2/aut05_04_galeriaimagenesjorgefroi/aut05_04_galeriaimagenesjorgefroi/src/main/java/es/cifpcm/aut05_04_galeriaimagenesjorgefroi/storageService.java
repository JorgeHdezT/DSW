package es.cifpcm.aut05_04_galeriaimagenesjorgefroi;

import org.springframework.core.io.Resource;
import org.springframework.web.multipart.MultipartFile;

public interface storageService {
    void init();

    void store(MultipartFile file);

    Resource loadAsResource(String filename);

    void deleteAll();
}
