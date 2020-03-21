package com.JHGH.x00091813;

import java.util.ArrayList;

public class Main {

    public static void main(String[] args) {
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
        System.out.println("Nivel de bateria de laptop " + listaLaptops.get(2).getMarca() + " " +
                listaLaptops.get(2).nivelBateria() + "\n");
        listaLaptops.get(4).setBateria(40);

        //output
        listaLaptops.forEach(s -> System.out.println(s.toString()));
    }
}
