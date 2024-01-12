package es.cifpcm.aut04_03_HernandezJorgeFarmacias.model;

public class Farmacia {

        private String WEB;
        private String LUNES;
        private String TELEFONO;
        private String NOMBRE;
        private float UTM_X;
        private float UTM_Y;

    // Constructor

    // Constructor vacío requerido por Jackson
    public Farmacia() {
    }
    public Farmacia(String WEB, String LUNES, String TELEFONO, String NOMBRE, float UTM_X, float UTM_Y) {
        this.WEB = WEB;
        this.LUNES = LUNES;
        this.TELEFONO = TELEFONO;
        this.NOMBRE = NOMBRE;
        this.UTM_X = UTM_X;
        this.UTM_Y = UTM_Y;
    }

    // Métodos toString
    @Override
    public String toString() {
        return "Farmacia{" +
                "WEB='" + WEB + '\n' +
                ", LUNES='" + LUNES + '\n' +
                ", TELEFONO='" + TELEFONO + '\n' +
                ", NOMBRE='" + NOMBRE + '\n' +
                ", UTM_X=" + UTM_X + '\n' +
                ", UTM_Y=" + UTM_Y +
                '}' + '\n'+
                "==============================" + '\n';
    }

    // Métodos get y set para UTM_X
    public float getUtmx() {
        return UTM_X;
    }

    public void setUtmx(float UTM_X) {
        this.UTM_X = UTM_X;
    }

    // Métodos get y set para UTM_Y
    public float getUtmy() {
        return UTM_Y;
    }

    public void setUtmy(float UTM_Y) {
        this.UTM_Y = UTM_Y;
    }

    // Métodos get y set para WEB
    public String getWEB() {
        return WEB;
    }

    public void setWEB(String WEB) {
        this.WEB = WEB;
    }

    public String getLUNES() {
        return LUNES;
    }

    public void setLUNES(String LUNES) {
        this.LUNES = LUNES;
    }

    // Getter y Setter para TELEFONO
    public String getTELEFONO() {
        return TELEFONO;
    }

    public void setTELEFONO(String TELEFONO) {
        this.TELEFONO = TELEFONO;
    }

    // Getter y Setter para NOMBRE
    public String getNOMBRE() {
        return NOMBRE;
    }

    public void setNOMBRE(String NOMBRE) {
        this.NOMBRE = NOMBRE;
    }

}