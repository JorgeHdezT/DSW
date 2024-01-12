package es.cifpcm.AUT04_05_WebVersionJorgeFroiadd;

import org.springframework.boot.builder.SpringApplicationBuilder;
import org.springframework.boot.web.servlet.support.SpringBootServletInitializer;

public class ServletInitializer extends SpringBootServletInitializer {

	@Override
	protected SpringApplicationBuilder configure(SpringApplicationBuilder application) {
		return application.sources(Aut0405WebVersionJorgeFroiaddApplication.class);
	}

}
