package es.cifpcm.aut05_04_galeriaimagenesjorgefroi;

import org.springframework.boot.builder.SpringApplicationBuilder;
import org.springframework.boot.web.servlet.support.SpringBootServletInitializer;

public class ServletInitializer extends SpringBootServletInitializer {

	@Override
	protected SpringApplicationBuilder configure(SpringApplicationBuilder application) {
		return application.sources(Aut0504GaleriaImagenesJorgeFroi.class);
	}

}
