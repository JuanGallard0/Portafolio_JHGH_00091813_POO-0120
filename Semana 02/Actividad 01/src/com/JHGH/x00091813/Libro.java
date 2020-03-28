package com.JHGH.x00091813;

public class Libro {
    //atributos
    private String ISBN;
    private String nombre;
    private int paginas;

    //constructores
    public Libro(String ISBN, String nombre, int paginas) {
        this.ISBN = ISBN;
        this.nombre = nombre;
        this.paginas = paginas;
    }

    //getters
    public String getISBN() {
        return ISBN;
    }

    public String getNombre() {
        return nombre;
    }

    public int getPaginas() {
        return paginas;
    }

    //metodos
    @Override
    public String toString() {
        return "Libro{" +
                "ISBN='" + ISBN + '\'' +
                ", nombre='" + nombre + '\'' +
                ", paginas=" + paginas +
                '}';
    }
}
