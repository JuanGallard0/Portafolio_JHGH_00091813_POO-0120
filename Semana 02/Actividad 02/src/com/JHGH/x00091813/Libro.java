package com.JHGH.x00091813;

public class Libro {
    //atributos
    private int ISBN;
    private String nombre;
    private int paginas;

    //constructores
    public Libro(String nombre, int paginas) {
        this.nombre = nombre;
        this.paginas = paginas;
        this.ISBN = GeneradorISBN.nuevoID();
    }

    //getters
    public int getISBN() {
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
                "ISBN=" + ISBN +
                ", nombre='" + nombre + '\'' +
                ", paginas=" + paginas +
                '}';
    }
}
