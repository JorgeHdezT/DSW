package es.cifpcm.aut04_03_HernandezJorgeFarmacias.model;

import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;

import java.io.File;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.lang.reflect.Type;
import java.util.ArrayList;
import java.util.List;


public class ImplementsPersistence implements Persistence {

    String json = "[\n" +
            "    {\n" +
            "        \"WEB\": null,\n" +
            "        \"LUNES\": \"08:30, , ,20:00\",\n" +
            "        \"TELEFONO\": \"922597722\",\n" +
            "        \"NOMBRE\": \"FARMACIA LUÑO\",\n" +
            "        \"UTM_X\": 378901.39636,\n" +
            "        \"UTM_Y\": 3151710.14449\n" +
            "    },\n" +
            "    {\n" +
            "        \"WEB\": \"http://www.farmaciacampitosifara.es\",\n" +
            "        \"LUNES\": \"09:00,14:00,17:00,20:30\",\n" +
            "        \"TELEFONO\": \"922281323\",\n" +
            "        \"NOMBRE\": \"FARMACIA LOS CAMPITOS\",\n" +
            "        \"UTM_X\": 376481.901533,\n" +
            "        \"UTM_Y\": 3151614.6634\n" +
            "    },\n" +
            "    {\n" +
            "        \"WEB\": \"http://www.farmaciatrivino.com\",\n" +
            "        \"LUNES\": \"08:30, , ,21:30\",\n" +
            "        \"TELEFONO\": \"922537179\",\n" +
            "        \"NOMBRE\": \"FARMACIA TRIVIÑO\",\n" +
            "        \"UTM_X\": 370786.589416,\n" +
            "        \"UTM_Y\": 3146161.33643\n" +
            "    },\n" +
            "    {\n" +
            "        \"WEB\": null,\n" +
            "        \"LUNES\": \"09:00, , ,21:00\",\n" +
            "        \"TELEFONO\": \"922629609\",\n" +
            "        \"NOMBRE\": \"FARMACIA BUENO-FELIPE\",\n" +
            "        \"UTM_X\": 370645.7078,\n" +
            "        \"UTM_Y\": 3145768.15526\n" +
            "    },\n" +
            "    {\n" +
            "        \"WEB\": null,\n" +
            "        \"LUNES\": \"08:30,,,21:00\",\n" +
            "        \"TELEFONO\": \"922213070\",\n" +
            "        \"NOMBRE\": \"FARMACIA GONZALEZ ARQUEROS\",\n" +
            "        \"UTM_X\": 377328.383805,\n" +
            "        \"UTM_Y\": 3149220.56944\n" +
            "    },\n" +
            "    {\n" +
            "        \"WEB\": null,\n" +
            "        \"LUNES\": \"09:00,15:00,16:00,21:00\",\n" +
            "        \"TELEFONO\": \"922221434\",\n" +
            "        \"NOMBRE\": \"FARMACIA MONJE\",\n" +
            "        \"UTM_X\": 376814.751654,\n" +
            "        \"UTM_Y\": 3149083.43488\n" +
            "    },\n" +
            "    {\n" +
            "        \"WEB\": \"http://www.farmaciaferia.org\",\n" +
            "        \"LUNES\": \"08:15, , ,20:15\",\n" +
            "        \"TELEFONO\": \"922229206\",\n" +
            "        \"NOMBRE\": \"FARMACIA FERIA\",\n" +
            "        \"UTM_X\": 376311.531285,\n" +
            "        \"UTM_Y\": 3148666.25951\n" +
            "    },\n" +
            "    {\n" +
            "        \"WEB\": null,\n" +
            "        \"LUNES\": \"09:00,13:30,16:30,20:00\",\n" +
            "        \"TELEFONO\": \"922226412\",\n" +
            "        \"NOMBRE\": \"FARMACIA DURANA\",\n" +
            "        \"UTM_X\": 376510.764009,\n" +
            "        \"UTM_Y\": 3148989.27321\n" +
            "    },\n" +
            "    {\n" +
            "        \"WEB\": null,\n" +
            "        \"LUNES\": \"08:30,,,22:00\",\n" +
            "        \"TELEFONO\": \"922220379\",\n" +
            "        \"NOMBRE\": \"FARMACIA LA SALLE\",\n" +
            "        \"UTM_X\": 376909.315286,\n" +
            "        \"UTM_Y\": 3148841.95302\n" +
            "    },\n" +
            "    {\n" +
            "        \"WEB\": null,\n" +
            "        \"LUNES\": \"08:00, , ,21:00\",\n" +
            "        \"TELEFONO\": \"922222125\",\n" +
            "        \"NOMBRE\": \"FARMACIA GONZALEZ\",\n" +
            "        \"UTM_X\": 376439.246709,\n" +
            "        \"UTM_Y\": 3148627.61447\n" +
            "    },\n" +
            "    {\n" +
            "        \"WEB\": null,\n" +
            "        \"LUNES\": \"09:00,13:30,16:45,19:30\",\n" +
            "        \"TELEFONO\": \"922270417\",\n" +
            "        \"NOMBRE\": \"FARMACIA GONZALEZ ARROYO\",\n" +
            "        \"UTM_X\": 376594.505589,\n" +
            "        \"UTM_Y\": 3149655.97708\n" +
            "    },\n" +
            "    {\n" +
            "        \"WEB\": \"http://www.farmaciaelchinito.com/\",\n" +
            "        \"LUNES\": \"09:00,13:30,16:45,20:15\",\n" +
            "        \"TELEFONO\": \"922275719\",\n" +
            "        \"NOMBRE\": \"FARMACIA EL CHINITO\",\n" +
            "        \"UTM_X\": 376826.406998,\n" +
            "        \"UTM_Y\": 3149630.423\n" +
            "    },\n" +
            "    {\n" +
            "        \"WEB\": \"http://www.farmaciaduggi.com/\",\n" +
            "        \"LUNES\": \"09:00, , ,20:30\",\n" +
            "        \"TELEFONO\": \"922289806\",\n" +
            "        \"NOMBRE\": \"FARMACIA DUGGI\",\n" +
            "        \"UTM_X\": 376713.183678,\n" +
            "        \"UTM_Y\": 3149492.92425\n" +
            "    },\n" +
            "    {\n" +
            "        \"WEB\": null,\n" +
            "        \"LUNES\": \"09:00,13:00,16:30,20:00\",\n" +
            "        \"TELEFONO\": \"922614101\",\n" +
            "        \"NOMBRE\": \"FARMACIA BENCOMO DUQUE\",\n" +
            "        \"UTM_X\": 369430.316439,\n" +
            "        \"UTM_Y\": 3144840.08494\n" +
            "    },\n" +
            "    {\n" +
            "        \"WEB\": null,\n" +
            "        \"LUNES\": \"09:00, , ,20:30\",\n" +
            "        \"TELEFONO\": \"922612915\",\n" +
            "        \"NOMBRE\": \"FARMACIA LAS MORADITAS\",\n" +
            "        \"UTM_X\": 373607.806499,\n" +
            "        \"UTM_Y\": 3147304.15303\n" +
            "    }\n" +
            "]\n";
    private static List<Farmacia> memStorage; //Lista de farmacias.
    private final Gson gson = new Gson(); // Interpretador de json

    String rutaTemp = System.getProperty("java.io.tmpdir");
    String rutaArchivo = rutaTemp + "/" + "hernandezJorge_farmacias.json";

    File archivoJson = new File(rutaArchivo);

    private FileReader reader;
    {
//        try {
//            reader = new FileReader(rutaArchivo);
//            System.out.println("Archivo leido con exito");
//        }
//        catch (IOException e) {
//            throw new RuntimeException("No se ha podido leer el archivo");
//        }
    }

    @Override
    public void openJson() {

//        createJson();
//
//
//        try (FileReader listReader = new FileReader(String.valueOf(reader))){
//            Type listType = new TypeToken<ArrayList<Farmacia>>() {}.getType();
//            memStorage = gson.fromJson(listReader, listType);
//            System.out.println("Se ha creado el json");
//        }
//        catch (IOException e) {
//            throw new RuntimeException("No se ha podido crear el json");
//        }
    }

    @Override
    public void createJson() {

//        if (!archivoJson.exists()) {
//            try (FileWriter writer = new FileWriter(String.valueOf(reader))){
//                writer.write(json);
//                System.out.println("Json escrito con exito");
//            }
//
//            catch (IOException e) {
//                throw new RuntimeException("No se ha podido escribir en el json");
//            }
//        }

    }


    public void setFarmacia(List<Farmacia> farmacias) {
        this.memStorage = farmacias;
    }

    @Override
    public List<Farmacia> list() {
        return memStorage;
    }

    public void open() {
        memStorage.add(new Farmacia(null, "08:30, , ,20:00", "922597722",
                "FARMACIA LUÑO", 378901.39636f, 3151710.14449f));

        memStorage.add(new Farmacia("http://www.farmaciacampitosifara.es", "09:00,14:00,17:00,20:30", "922281323",
                "FARMACIA LOS CAMPITOS", 376481.901533f, 3151614.6634f));

        memStorage.add(new Farmacia("http://www.farmaciatrivino.com", "08:30, , ,21:30", "922537179",
                "FARMACIA TRIVIÑO", 370786.589416f, 3146161.33643f));

        memStorage.add(new Farmacia(null, "09:00, , ,21:00", "922629609",
                "FARMACIA BUENO-FELIPE", 370645.7078f, 3145768.15526f));

        memStorage.add(new Farmacia(null, "08:30,,,21:00", "922213070",
                "FARMACIA GONZALEZ ARQUEROS", 377328.383805f, 3149220.56944f));

        memStorage.add(new Farmacia( null, "09:00,15:00,16:00,21:00", "922221434",
                "FARMACIA MONJE", 376814.751654f, 3149083.43488f));

        memStorage.add(new Farmacia( "http://www.farmaciaferia.org", "08:15, , ,20:15", "922229206",
                "FARMACIA FERIA", 376311.531285f, 3148666.25951f));

        memStorage.add(new Farmacia(null, "09:00,13:30,16:30,20:00", "922226412",
                "FARMACIA DURANA", 376510.764009f, 3148989.27321f));

        memStorage.add(new Farmacia(null, "08:30,,,22:00", "922220379",
                "FARMACIA LA SALLE", 376909.315286f, 3148841.95302f));

        memStorage.add(new Farmacia( null, "08:00, , ,21:00",  "922222125",
                "FARMACIA GONZALEZ", 376439.246709f, 3148627.61447f));

        memStorage.add(new Farmacia( null, "09:00,13:30,16:45,19:30", "922270417",
                "FARMACIA GONZALEZ ARROYO", 376594.505589f, 3149655.97708f));

        memStorage.add(new Farmacia( "http://www.farmaciaelchinito.com/", "09:00,13:30,16:45,20:15", "922275719",
                "FARMACIA EL CHINITO", 376826.406998f, 3149630.423f));

        memStorage.add(new Farmacia( "http://www.farmaciaduggi.com/", "09:00, , ,20:30", "922289806",
                "FARMACIA DUGGI", 376713.183678f, 3149492.92425f));

        memStorage.add(new Farmacia( null, "09:00,13:00,16:30,20:00", "922614101",
                "FARMACIA BENCOMO DUQUE", 369430.316439f, 3144840.08494f));

        memStorage.add(new Farmacia( null, "09:00, , ,20:30", "922612915",
                "FARMACIA LAS MORADITAS", 373607.806499f, 3147304.15303f));

    }

    @Override
    public void close() {
        // Sacar Lista por pantalla
        memStorage.forEach(x -> System.out.println(x.toString()));
    }



    @Override
    public void closeJson() {

    }

    @Override
    public void add(Farmacia farmacia) {
        memStorage.add(farmacia);
    }

    @Override
    public void delete(int posicion) {
        memStorage.remove(posicion);
    }


}

