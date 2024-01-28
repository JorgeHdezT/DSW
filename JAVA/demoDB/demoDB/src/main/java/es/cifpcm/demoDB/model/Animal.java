package es.cifpcm.demoDB.model;

import jakarta.persistence.*;

import java.io.Serializable;

@Entity
@Table(name = "animales")
public class Animal implements Serializable {

    private static final long serialVersionUID = 1L;

    @Id
    @Column(name = "Id", nullable = false)
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer id;

    @Column(name = "Nombre", nullable = false)
    private String nombre;

    @Column(name = "VidaMedia", nullable = false)
    private Integer vidaMedia;

    @Column(name = "Extinto", nullable = false)
    private Boolean extinto;

    public void setId(Integer id) {
        this.id = id;
    }

    public Integer getId() {
        return id;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public String getNombre() {
        return nombre;
    }

    public void setVidaMedia(Integer vidaMedia) {
        this.vidaMedia = vidaMedia;
    }

    public Integer getVidaMedia() {
        return vidaMedia;
    }

    public void setExtinto(Boolean extinto) {
        this.extinto = extinto;
    }

    public Boolean isExtinto() {
        return extinto;
    }

    @Override
    public String toString() {
        return "Animal{" +
                "id=" + id + '\'' +
                "nombre=" + nombre + '\'' +
                "vidaMedia=" + vidaMedia + '\'' +
                "extinto=" + extinto + '\'' +
                '}';
    }
}
