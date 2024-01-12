package es.cifpcm.AUT04_05_WebVersionJorgeFroiadd.data;
import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;
import es.cifpcm.AUT04_05_WebVersionJorgeFroiadd.model.Farmacia;

import java.io.*;
import java.lang.reflect.Type;
import java.nio.charset.StandardCharsets;
import java.util.ArrayList;
import java.util.List;

public class ImplementsPersistence implements Persistence{
    private List<Farmacia>farmacias=new ArrayList<>();
    String filePath="C:\\Users\\Hache\\Desktop\\AUT04_05_WebVersionJorgeFroiadd_2\\AUT04_05_WebVersionJorgeFroiadd\\AUT04_05_WebVersionJorgeFroiadd\\src\\main\\resources\\json\\farmacias_web.json";
    File file = new File(filePath);
    private FileReader reader;

    {
        try {
            reader = new FileReader(filePath);
        } catch (FileNotFoundException e) {
            throw new RuntimeException(e);
        }
    }
    private final Gson gson = new Gson();
    @Override
    public void readJSON() {
        String jsonContent = openJSON(); // Llamamos al método openJSON para obtener el contenido del JSON
        if (!jsonContent.isEmpty()) {
            Type listType = new TypeToken<List<Farmacia>>() {}.getType();
            farmacias = gson.fromJson(jsonContent, listType);
            System.out.println("Current content of JSON file: " + gson.toJson(farmacias));
        }
    }

    @Override
    public List<Farmacia> farmacias() {
        return farmacias;
    }

    @Override
    public void add(Farmacia farmacia) {
        try (FileReader fileReader = new FileReader(filePath)) {
            Type type = new TypeToken<ArrayList<Farmacia>>() {}.getType();
            farmacias = gson.fromJson(fileReader, type);

            if (farmacias == null) {
                farmacias = new ArrayList<>(); // Inicializar si es null
            }

            farmacias.add(farmacia);
            updateJSON();
            readJSON(); // Actualiza la lista después de agregar la nueva farmacia
        } catch (IOException e) {
            e.printStackTrace(); // Manejo del error
        }
    }




    @Override
    public void updateJSON() {
        try (FileOutputStream fileOutputStream = new FileOutputStream(filePath);
             OutputStreamWriter writer = new OutputStreamWriter(fileOutputStream, StandardCharsets.UTF_8)) {
            gson.toJson(farmacias, writer);
            writer.close();
            System.out.println("JSON updated");
        } catch (IOException e) {
            e.printStackTrace();
        }
    }


    @Override
    public String openJSON() {
        StringBuilder jsonContent = new StringBuilder();
        try (BufferedReader br = new BufferedReader(new FileReader(filePath))) {
            String line;
            while ((line = br.readLine()) != null) {
                jsonContent.append(line);
            }
            System.out.println("JSON Content: " + jsonContent.toString());
        } catch (IOException e) {
            e.printStackTrace(); // Manejo del error
        }
        return jsonContent.toString();
    }


}
