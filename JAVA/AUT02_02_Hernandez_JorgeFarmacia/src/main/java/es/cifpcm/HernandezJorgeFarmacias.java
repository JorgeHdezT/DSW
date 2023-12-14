package es.cifpcm;

import java.io.PrintStream;
import java.util.Scanner;

public class HernandezJorgeFarmacias {

    public static void main(String[] args) {

        //Variables
        ConsoleUtils consoleUtils = new ConsoleUtils();
        int option = -1;

        //Métodos
        do {
            printMainMenu(option, consoleUtils);
            option = getOpcion(option, consoleUtils); //que bobo soy
            evaluarOpcionMain(option, consoleUtils);
        } while (option != 0);

    }

    public static void printMainMenu(int option, ConsoleUtils consoleUtils) {

        consoleUtils.clearConsole(); //Limpiamos consola

        System.out.println("================ Farmacias de mi ciudad ==================");
        System.out.println("-- Espero no tener que usar este programa.\n");
        StringBuilder sb = new StringBuilder();
        sb.append("1. Busque por nombre\n");
        sb.append("2. Lista de farmacias disponibles\n");
        sb.append("0. Salir\n");
        sb.append("--------------------------------\n");
        sb.append("9. Admin\n");
        sb.append("--------------------------------\n");
        sb.append("Inserte una opcion: ");

        System.out.println(sb.toString());


    }

    public static int getOpcion(int option, ConsoleUtils consoleUtils) {

        Scanner recoger = new Scanner(System.in);
        option = recoger.nextInt();

        if (option != 1 && option != 2 && option != 0 && option != 9) {

            consoleUtils.clearConsole(); //Limpiamos consola

            System.out.println("Opcion incorrecta\nPulse ENTER para continuar....");
            Scanner scanner = new Scanner(System.in);
            scanner.nextLine();

            consoleUtils.clearConsole(); //llamo al metodo de la clase y limpio la consola.
            printMainMenu(option, consoleUtils); //vuelvo a imprimir el menu
            return option = 5;
        } else {
            return option; //Devuelvo la opcion y listo
        }

    }

    public static void evaluarOpcionMain(int option, ConsoleUtils consoleUtils) {


        switch (option) {
            case 1:
                // Lógica para la opción 1
                consoleUtils.clearConsole(); //Limpiamos consola
                buscarFarmacia(consoleUtils); // Llamar recursivamente con la nueva opción

                break;
            case 2:
                // Lógica para la opción 2
                System.out.println("Seleccionó la opción 2.");
                break;
            case 0:
                // Lógica para la opción 0
                System.out.println("Saliendo del programa.");
                break;
            case 9:
                // Lógica para la opción 9 (Admin)
                System.out.println("Accediendo al modo de administrador.");
                option = printAdminMenu(); // Actualizar option con la opción elegida del menú de administrador
                evaluarOpcionAdmin(option, consoleUtils); // Llamar recursivamente con la nueva opción
                break;
            default:
                System.out.println("Opción no válida. Inténtelo de nuevo.");
                evaluarOpcionMain(option, consoleUtils);
        }


    }

    public static int printAdminMenu() {
        StringBuilder sb = new StringBuilder();
        sb.append("1. Añadir farmacias\n");
        sb.append("2. Borrar farmacias\n");
        sb.append("3. Listar farmacias\n");
        sb.append("0. Salir\n");
        sb.append("--------------------------------");
        sb.append("Inserte una opción: ");

        System.out.println(sb.toString());
        Scanner scanner = new Scanner(System.in);
        return scanner.nextInt(); // Devolver la opción elegida por el usuario
    }

    public static void evaluarOpcionAdmin(int option, ConsoleUtils consoleUtils) {
        switch (option) {
            case 1:
                // Lógica para la opción 1
                System.out.println("Seleccionó la opción 1.");
                break;
            case 2:
                // Lógica para la opción 2
                System.out.println("Seleccionó la opción 2.");
                break;

            case 3:
                // Lógica para la opción 3
                System.out.println("Seleccionó la opción 3.");
                break;
            case 0:
                // Lógica para la opción 0
                System.out.println("Saliendo del menú  de administrador.");
                printMainMenu(option, consoleUtils);
//                option = getOpcion(option, consoleUtils);
                break;

            default:
                System.out.println("Opción no válida. Inténtelo de nuevo.");
                evaluarOpcionAdmin(option, consoleUtils);
        }
    }


//FUNCIONES DE ACCIÓN JSON

    public static void buscarFarmacia(ConsoleUtils consoleUtils) {

        String web = "null";
        String horario = "null";
        String nombreFarmacia = "null";
        String telefono = "null";

        //Aqui deben ir los datos de la farmacia accediendo al objeto encontrado a raiz
        // de una lista de farmacias creada en la clase farmacia.

        // Farmacias[] = lista de farmacias.
        // Farmacias.FindbyName(nombreFarmacia) y almacena su posicion en la lista.
        // web = FarmaciaSeleccionada.web;
        // horario = FarmaciaSeleccionada.Lunes;
        // telefono = FarmaciaSeleccionada.Telefono;

        System.out.println("Ingrese el nombre de la farmacia que desea buscar: ");
        Scanner scanner = new Scanner(System.in);
        nombreFarmacia = scanner.nextLine();

        consoleUtils.clearConsole(); //Limpiamos consola

        System.out.println("Información de la farmacia: " + nombreFarmacia);
        System.out.println("--------------------------------");

        StringBuilder sb = new StringBuilder();
        sb.append("Nombre : ");
        sb.append(nombreFarmacia + "\n");
        sb.append("Web : ");
        sb.append(web + "\n");
        sb.append("Horario : ");
        sb.append(horario + "\n");
        sb.append("Telefono : ");
        sb.append(telefono + "\n");
        sb.append("--------------------------------\n");
        sb.append("Desea volver al menu principal?\n");
        sb.append("1) Sí\n");
        sb.append("2) No\n");
        sb.append("Inserte una opción: ");
        System.out.println(sb.toString());

        scanner = new Scanner(System.in);
        int opcion = scanner.nextInt();

        if (opcion != 1) {
            buscarFarmacia(consoleUtils); //Soy recursiva!

        }

    }

}
