package es.cifpcm;

public class ConsoleUtils {
    final void clearConsole() {
//        System.out.print("\033[H\033[2J");
//        System.out.flush();
        try {
            new ProcessBuilder("cmd", "/c", "cls").inheritIO().start().waitFor();
        } catch (Exception e) {
            /*No hacer nada*/
        }
    }
}
