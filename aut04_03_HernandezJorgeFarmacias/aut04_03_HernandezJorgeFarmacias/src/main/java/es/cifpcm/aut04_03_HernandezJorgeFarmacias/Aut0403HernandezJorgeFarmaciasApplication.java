package es.cifpcm.aut04_03_HernandezJorgeFarmacias;

import com.fasterxml.jackson.databind.ObjectMapper;
import es.cifpcm.aut04_03_HernandezJorgeFarmacias.controller.HernandezJorge_Farmacias_Controller;
import es.cifpcm.aut04_03_HernandezJorgeFarmacias.model.ImplementsPersistence;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.boot.web.server.WebServerFactoryCustomizer;
import org.springframework.boot.web.servlet.server.ConfigurableServletWebServerFactory;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.ComponentScan;
import org.springframework.web.servlet.config.annotation.ViewControllerRegistry;
import org.springframework.web.servlet.config.annotation.WebMvcConfigurer;




@SpringBootApplication
@ComponentScan(basePackages = "es.cifpcm.aut04_03_HernandezJorgeFarmacias")
public class Aut0403HernandezJorgeFarmaciasApplication {

	public static void main(String[] args) {
		SpringApplication.run(Aut0403HernandezJorgeFarmaciasApplication.class, args);
		HernandezJorge_Farmacias_Controller controller = new HernandezJorge_Farmacias_Controller();
		//ImplementsPersistence.openJson();
	}

//	@Bean
//	public WebMvcConfigurer forwardToIndex() {
//		return new WebMvcConfigurer() {
//
//			public void addViewControllers(ViewControllerRegistry registry) {
//				registry.addViewController("/").setViewName(
//						"forward:/index.html");
//			}
//		};
//
//	}
	@Bean
	public WebServerFactoryCustomizer<ConfigurableServletWebServerFactory> enableDefaultServlet() {
		return factory -> factory.setRegisterDefaultServlet(true);
	}

	@Bean
	public ObjectMapper objectMapper() {
		return new ObjectMapper();
	}


}
