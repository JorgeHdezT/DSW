package es.cifpcm.aut04_03_HernandezJorgeFarmacias.model;

import java.util.List;

public interface Persistence {
    void createJson();

    void open();
    void close();
    void openJson();
    void closeJson();
    void add(Farmacia farmacia);

    void delete(int posicion);

    List<Farmacia> list();

}
