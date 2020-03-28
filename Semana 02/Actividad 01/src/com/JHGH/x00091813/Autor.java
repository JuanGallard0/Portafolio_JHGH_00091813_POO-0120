package com.JHGH.x00091813;

public class Autor {
    //atributos
    private String nombre;
    private String email;
    private char genero;

    //constructores
    public Autor(String nombre, String email, char genero) {
        this.nombre = nombre;
        this.email = email;
        this.genero = genero;
    }

    //getters
    public String getNombre() {
        return nombre;
    }

    public String getEmail() {
        return email;
    }

    public char getGenero() {
        return genero;
    }

    //setters
    public void setEmail(String email) {
        this.email = email;
    }

    //metodos
    @Override
    public String toString() {
        return "Autor{" +
                "nombre='" + nombre + '\'' +
                ", email='" + email + '\'' +
                ", genero=" + genero +
                '}';
    }
}