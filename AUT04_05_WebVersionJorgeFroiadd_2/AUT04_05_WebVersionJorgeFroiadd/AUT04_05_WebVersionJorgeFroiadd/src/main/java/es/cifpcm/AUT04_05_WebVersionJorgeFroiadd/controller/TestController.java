package es.cifpcm.AUT04_05_WebVersionJorgeFroiadd.controller;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.servlet.ModelAndView;

@Controller
@RequestMapping(value = "/")
public class TestController {


    @GetMapping
    public ModelAndView test() {
        ModelAndView test = new ModelAndView();
        test.setViewName("index");
        return test;
    }

}
