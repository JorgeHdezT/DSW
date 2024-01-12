package es.cifpcm.AUT04_05_WebVersionJorgeFroiadd.data;
import es.cifpcm.AUT04_05_WebVersionJorgeFroiadd.model.Farmacia;

import java.util.List;

public interface Persistence {
    Persistence pst=  new ImplementsPersistence();
    public void readJSON();
    public List<Farmacia> farmacias();
    public void add(Farmacia farmacia);
    public void updateJSON();

    String openJSON();
}
