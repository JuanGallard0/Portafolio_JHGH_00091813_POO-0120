package com.JHGH.x00091813;

import java.util.ArrayList;

public class Main {

    public static void main(String[] args) {
        //Clase Laptop

        //Instancias
        ArrayList<Laptop> listaLaptops = new ArrayList<>();
        listaLaptops.add(new Laptop("Toshiba", true, 50));
        listaLaptops.add(new Laptop("Dell", false, 80));
        listaLaptops.add(new Laptop("Sony", true, 20));
        listaLaptops.add(new Laptop());
        listaLaptops.add(new Laptop());

        //uso de metodos, getters/setters
        listaLaptops.get(0).apagar();
        listaLaptops.get(1).encender();
        System.out.println("Nivel de bateria de laptop " + listaLaptops.get(2).getMarca() + ": " +
                listaLaptops.get(2).nivelBateria() + "%");
        listaLaptops.get(4).setBateria(40);

        //output
        listaLaptops.forEach(s -> System.out.println(s.toString()));
        System.out.println();

        //Clase Articulo

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
