package com.JHGH.x00091813;

import java.util.ArrayList;
import java.util.Scanner;

public class Main {

    static Scanner in = new Scanner(System.in);

    public static void main(String[] args) {
        ArrayList<Autor> listaAutores = new ArrayList<>();
        ArrayList<Libro> listaLibros = new ArrayList<>();
        byte choice;
        boolean menuSwitch = true;
        do {
            menuPrincipal();
            choice = in.nextByte();in.nextLine();
            switch (choice) {
                case 1:
                    agregarAutor(listaAutores);
                    break;
                case 2:
                    agregarLibro(listaLibros);
                    break;
                case 3:
                    borrarAutor(listaAutores);
                    break;
                case 4:
                    borrarLibro(listaLibros);
                    break;
                case 5:
                    listaAutores.forEach(s -> System.out.println(s.toString()));
                    break;
                case 6:
                    listaLibros.forEach(s -> System.out.println(s.toString()));
                    break;
                case 7:
                    menuSwitch = false;
                    break;
                default:
                    throw new IllegalStateException("Unexpected value: " + choice);
            }
        } while (menuSwitch);
    }

    static public void menuPrincipal() {
        System.out.print("\tMENU: \n1) Agregar autor.\n2) Agregar libro.\n" +
                "3) Borrar autor.\n4) Borrar libro.\n5) Mostrar autores.\n" +
                "6) Mostrar libros.\n7) SALIR\n\tEscoja una opcion: ");
    }

    static public void agregarAutor(ArrayList<Autor> lista) {
        System.out.print("Nombre: ");
        String nombre = in.nextLine();
        System.out.print("Email: ");
        String email = in.nextLine();
        System.out.print("Genero: ");
        char genero = in.next().charAt(0); in.nextLine();
        lista.add(new Autor(nombre, email, genero));
    }

    static public void agregarLibro(ArrayList<Libro> lista) {
        System.out.print("ISBN: ");
        String ISBN = in.nextLine();
        System.out.print("Nombre: ");
        String nombre = in.nextLine();
        System.out.print("Paginas: ");
        int paginas = in.nextInt(); in.nextLine();
        lista.add(new Libro(ISBN, nombre, paginas));
    }

    static public void borrarAutor(ArrayList<Autor>lista) {
        System.out.print("Nombre del autor que desea borrar: ");
        String nombre = in.nextLine();
        for (int i = 0; i < lista.size(); i++) {
            if (lista.get(i).getNombre().equals(nombre))
                lista.remove(i);
        }
    }

    static public void borrarLibro(ArrayList<Libro>lista) {
        System.out.print("Nombre del libro que desea borrar: ");
        String nombre = in.nextLine();
        for (int i = 0; i < lista.size(); i++) {
            if (lista.get(i).getNombre().equals(nombre))
                lista.remove(i);
        }
    }
}
