package es.cifpcm.AUT04_05_WebVersionJorgeFroiadd;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import com.fasterxml.jackson.databind.ObjectMapper;
import org.springframework.boot.web.server.WebServerFactoryCustomizer;
import org.springframework.boot.web.servlet.server.ConfigurableServletWebServerFactory;
import org.springframework.context.annotation.Bean;
@SpringBootApplication
public class Aut0405WebVersionJorgeFroiaddApplication {

	public static void main(String[] args) {

		SpringApplication.run(Aut0405WebVersionJorgeFroiaddApplication.class, args);
	}
	@Bean
	public WebServerFactoryCustomizer<ConfigurableServletWebServerFactory> enableDefaultServlet() {
		return factory -> factory.setRegisterDefaultServlet(true);
	}

	@Bean
	public ObjectMapper objectMapper() {
		return new ObjectMapper();
	}
}
