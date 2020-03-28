package com.JHGH.x00091813;

import java.util.ArrayList;

public class Main {

    public static void main(String[] args) {
        ArrayList<Libro> listaLibros = new ArrayList<>();
        listaLibros.add(new Libro("Harry Potter", 500));
        listaLibros.add(new Libro("The witcher", 200));
        listaLibros.add(new Libro("Fisica 2", 1000));
        listaLibros.add(new Libro("Larousse", 700));
        listaLibros.add(new Libro("Odisea", 2000));
        listaLibros.forEach(s -> System.out.println(s.toString()));
    }
}
