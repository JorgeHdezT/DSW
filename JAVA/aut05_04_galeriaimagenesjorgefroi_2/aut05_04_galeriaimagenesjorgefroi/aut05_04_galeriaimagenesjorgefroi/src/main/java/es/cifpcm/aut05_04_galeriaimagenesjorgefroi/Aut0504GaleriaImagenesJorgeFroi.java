package es.cifpcm.aut05_04_galeriaimagenesjorgefroi;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.Bean;
import org.springframework.web.servlet.config.annotation.ResourceHandlerRegistry;
import org.springframework.web.servlet.config.annotation.WebMvcConfigurer;

@SpringBootApplication
public class Aut0504GaleriaImagenesJorgeFroi {

	public static void main(String[] args) {
		SpringApplication.run(Aut0504GaleriaImagenesJorgeFroi.class, args);
	}

	@Bean
	public WebMvcConfigurer webMvcConfigurer() {
		return new WebMvcConfigurer() {
			@Override
			public void addResourceHandlers(ResourceHandlerRegistry registry) {
				registry.addResourceHandler("/uploadsjorgefroi/images/**")
						.addResourceLocations("file:src/main/resources/static/uploadsjorgefroi/images/")
						.setCachePeriod(0); // Desactivar la caché
			}
		};
	}

}
