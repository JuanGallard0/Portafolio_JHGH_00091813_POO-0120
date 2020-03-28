package com.JHGH.x00091813;

public class Articulo {
    //atributos
    private String producto;
    private float precio;
    private Boolean disponible;

    //constructores
    public Articulo(String articulo, float precio, Boolean disponible) {
        this.producto = articulo;
        this.precio = precio;
        this.disponible = disponible;
    }

    public Articulo() {
        producto = "indefinido";
        precio = 0.0f;
        disponible = false;
    }

    //getters
    public String getArticulo() {
        return producto;
    }

    public float getPrecio() {
        return precio;
    }

    public Boolean getDisponible() {
        return disponible;
    }

    //setters
    public void setProducto(String producto) {
        this.producto = producto;
    }

    public void setPrecio(float precio) {
        this.precio = precio;
    }

    public void setDisponible(Boolean disponible) {
        this.disponible = disponible;
    }

    //metodos
    @Override
    public String toString() {
        return "Articulo{" +
                "producto='" + producto + '\'' +
                ", precio=" + precio +
                ", disponible=" + disponible +
                '}';
    }

    public void oferta(float porciento) {
        precio -= precio * porciento / 100.00f;
    }

    public void productoAgotado() {
        disponible = false;
    }
}