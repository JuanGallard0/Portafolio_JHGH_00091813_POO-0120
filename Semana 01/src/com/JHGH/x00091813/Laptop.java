package com.JHGH.x00091813;

public class Laptop {
    //atributos
    private String marca;
    private Boolean indicadorEncendido;
    private int bateria;

    //constructores
    public Laptop(String marca, Boolean indicadorEncendido, int bateria) {
        this.marca = marca;
        this.indicadorEncendido = indicadorEncendido;
        this.bateria = bateria;
    }

    public Laptop() {
        marca = "Indefinido";
        indicadorEncendido = false;
        bateria = 100;
    }

    //getters
    public String getMarca() {
        return marca;
    }

    public Boolean getIndicadorEncendido() {
        return indicadorEncendido;
    }

    public int getBateria() {
        return bateria;
    }

    //setters
    public void setMarca(String marca) {
        this.marca = marca;
    }

    public void setIndicadorEncendido(Boolean indicadorEncendido) {
        this.indicadorEncendido = indicadorEncendido;
    }

    public void setBateria(int bateria) {
        this.bateria = bateria;
    }

    //metodos
    @Override
    public String toString() {
        return "Laptop{" +
                "marca='" + marca + '\'' +
                ", indicadorEncendido=" + indicadorEncendido +
                ", bateria=" + bateria +
                '}';
    }

    public void encender() {
        indicadorEncendido = true;
    }

    public void apagar() {
        indicadorEncendido = false;
    }

    public int nivelBateria() {
        return bateria;
    }
}