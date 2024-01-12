package es.cifpcm.AUT04_05_WebVersionJorgeFroiadd.model;

import jakarta.validation.constraints.Pattern;
import jakarta.validation.constraints.Size;

public class Farmacia {
    //@Pattern(regexp = "www\\..+\\..+", message = "El formato de la web no es válido. Debe ser www.loquesea.loquesea")
    private String web;
    private String lunes;
    @Size(min = 9, max = 9, message = "El tamaño del teléfono debe ser 9")
    private String telefono;
    //@Pattern(regexp = "^FARMACIA\\s.*", message = "El nombre debe comenzar con 'FARMACIA'")
    private String nombre;
    private float utmX;
    private float utmY;

    // Constructor
    public Farmacia(String web, String lunes, String telefono, String nombre, float utmX, float utmY) {
        this.web = web;
        this.lunes = lunes;
        this.telefono = telefono;
        this.nombre = nombre;
        this.utmX = utmX;
        this.utmY = utmY;
    }
    //servicio que verifica los datos
    public Farmacia() {//vacío
        //valores por defecto o predeterminados
        //lanzar excepciones
    }

    // Getters y Setters
    public String getWeb() {
        return web;
    }

    public void setWeb(String web) {
            this.web = web;
    }

    public String getLunes() {
        return lunes;
    }

    public void setLunes(String lunes) {
        this.lunes = lunes;
    }

    public String getTelefono() {
        return telefono;
    }

    public void setTelefono(String telefono) {
        this.telefono = telefono;
    }

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public float getUtmX() {
        return utmX;
    }

    public void setUtmX(float utmX) {
        this.utmX = utmX;
    }

    public float getUtmY() {
        return utmY;
    }

    public void setUtmY(float utmY) {
        this.utmY = utmY;
    }

    private boolean esNumeroEntero(String str) {
        if (str == null || str.isEmpty()) {
            return false;
        }
        try {
            Integer.parseInt(str);
            return true;
        } catch (NumberFormatException e) {
            return false;
        }
    }

    @Override
    public String toString() {
        return "Nombre: " + nombre + "\n" +
                "Lunes: " + lunes + "\n" +
                "UTM_X: " + utmX + "\n" +
                "UTM_Y: " + utmY + "\n" +
                "Teléfono: " + telefono + "\n" +
                "Web: " + web + "\n";
    }
}