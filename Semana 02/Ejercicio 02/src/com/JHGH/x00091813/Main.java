package com.JHGH.x00091813;

import javax.swing.*;
import java.util.ArrayList;

public class Main {

    public static void main(String[] args) {
        //Instancias
        ArrayList<Articulo> Inventario = new ArrayList<>();
        Inventario.add(new Articulo("leche", 2.00f, true));
        Inventario.add(new Articulo("pollo", 4.00f, true));
        Inventario.add(new Articulo("licuadora", 30.00f, true));
        Inventario.add(new Articulo());
        Inventario.add(new Articulo());

        //uso de metodos, getters/setters
        Inventario.get(2).productoAgotado();
        Inventario.get(1).oferta(10.00f);
        System.out.println("Precio del pollo: " + Inventario.get(1).getPrecio());
        Inventario.get(4).setProducto("Arroz");

        //output
        Inventario.forEach(s -> System.out.println(s.toString()));
    }
}