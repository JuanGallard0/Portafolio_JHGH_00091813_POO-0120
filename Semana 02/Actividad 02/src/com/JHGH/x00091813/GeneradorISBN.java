package com.JHGH.x00091813;

public final class GeneradorISBN {
    //atributos estaticos
    private static int contador;

    //constructor privado
    private GeneradorISBN() {};

    //metodos estaticos
    public static int nuevoID() {
        contador++;
        return contador;
    }
}
