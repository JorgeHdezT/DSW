package es.cifpcm.aut04_03_HernandezJorgeFarmacias.controller;

import es.cifpcm.aut04_03_HernandezJorgeFarmacias.model.Farmacia;
import es.cifpcm.aut04_03_HernandezJorgeFarmacias.model.ImplementsPersistence;
import es.cifpcm.aut04_03_HernandezJorgeFarmacias.model.Persistence;
import org.springframework.stereotype.Controller;

import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

@Controller
public class HernandezJorge_Farmacias_Controller {

    @GetMapping("/lista")

    public String mostrarFarmacias(Model model) {



        List<Farmacia> farmacias = new ArrayList<>();


       farmacias.add(new Farmacia(null, "08:30, , ,20:00", "922597722",
                "FARMACIA LUÑO", 378901.39636f, 3151710.14449f));

        farmacias.add(new Farmacia("http://www.farmaciacampitosifara.es", "09:00,14:00,17:00,20:30", "922281323",
                "FARMACIA LOS CAMPITOS", 376481.901533f, 3151614.6634f));

       farmacias.add(new Farmacia("http://www.farmaciatrivino.com", "08:30, , ,21:30", "922537179",
                "FARMACIA TRIVIÑO", 370786.589416f, 3146161.33643f));

        farmacias.add(new Farmacia(null, "09:00, , ,21:00", "922629609",
                "FARMACIA BUENO-FELIPE", 370645.7078f, 3145768.15526f));

        farmacias.add(new Farmacia(null, "08:30,,,21:00", "922213070",
                "FARMACIA GONZALEZ ARQUEROS", 377328.383805f, 3149220.56944f));

        farmacias.add(new Farmacia( null, "09:00,15:00,16:00,21:00", "922221434",
                "FARMACIA MONJE", 376814.751654f, 3149083.43488f));

        farmacias.add(new Farmacia( "http://www.farmaciaferia.org", "08:15, , ,20:15", "922229206",
                "FARMACIA FERIA", 376311.531285f, 3148666.25951f));

        farmacias.add(new Farmacia(null, "09:00,13:30,16:30,20:00", "922226412",
                "FARMACIA DURANA", 376510.764009f, 3148989.27321f));

        farmacias.add(new Farmacia(null, "08:30,,,22:00", "922220379",
                "FARMACIA LA SALLE", 376909.315286f, 3148841.95302f));



        model.addAttribute("farmacias", farmacias);
        return "listaFarmacias";
    }


//    public String mostrarfarmacias(Model model) {
//        Persistencia.open();
//        List<Farmacia> farmacias = Persistencia.list();
//        model.addAttribute("farmacias", farmacias);
//        return "listaFarmacias";
//    }


}
