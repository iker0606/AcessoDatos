using System;
using System.IO;

string fichero = "";
int opcion = 0;

void crearFichero() {
    try {
        Console.Write("Nombre del fichero: ");
        string nombre = Console.ReadLine();

        if (File.Exists(nombre)) {
            Console.WriteLine("Ese fichero ya existe.");
            return;
        }

        File.Create(nombre).Close();
        fichero = nombre;
        Console.WriteLine("Fichero creado.");
    } catch (Exception ex) {
        Console.WriteLine("Error: " + ex.Message);
    }
}

while (opcion != 6) {
    Console.WriteLine();
    Console.WriteLine("1. Crear un nuevo fichero");
    Console.WriteLine("2. Añadir registros");
    Console.WriteLine("3. Eliminar todos los registros");
    Console.WriteLine("4. Eliminar el fichero");
    Console.WriteLine("5. Visualizar los registros");
    Console.WriteLine("6. Cerrar la aplicación");
    Console.Write("Opción: ");

    try {
        opcion = int.Parse(Console.ReadLine());
    } catch (Exception ex) {
        Console.WriteLine("Error: " + ex.Message);
        opcion = 0;
        continue;
    }

    if (opcion == 1) {
        crearFichero();
    } else if (opcion >= 2 && opcion <= 5 && !File.Exists(fichero)) {
        Console.WriteLine("Primero se debe crear el fichero.");
        Console.WriteLine("Creando...");
        crearFichero();
    } else if (opcion == 2) {
        try {
            Console.Write("Registro a añadir: ");
            string registro = Console.ReadLine();
            File.AppendAllText(fichero, registro + Environment.NewLine);
            Console.WriteLine("Registro añadido.");
        } catch (Exception ex) {
            Console.WriteLine("Error: " + ex.Message);
        }
    } else if (opcion == 3) {
        try {
            File.WriteAllText(fichero, "");
            Console.WriteLine("Registros eliminados.");
        } catch (Exception ex) {
            Console.WriteLine("Error: " + ex.Message);
        }
    } else if (opcion == 4) {
        try {
            File.Delete(fichero);
            Console.WriteLine("Fichero eliminado.");
        } catch (Exception ex) {
            Console.WriteLine("Error: " + ex.Message);
        }
    } else if (opcion == 5) {
        try {
            string[] lineas = File.ReadAllLines(fichero);

            if (lineas.Length == 0) {
                Console.WriteLine("El fichero no tiene registros.");
            } else {
                Console.Write("Desde el registro número: ");
                int desde = int.Parse(Console.ReadLine());
                Console.Write("Hasta el registro número (máximo " + lineas.Length + "): ");
                int hasta = int.Parse(Console.ReadLine());

                if (desde < 1 || hasta > lineas.Length || desde > hasta) {
                    Console.WriteLine("Rango no válido.");
                } else {
                    for (int i = desde; i <= hasta; i++) {
                        Console.WriteLine(i + ": " + lineas[i - 1]);
                    }
                }
            }
        } catch (Exception ex) {
            Console.WriteLine("Error: " + ex.Message);
        }
    } else if (opcion == 6) {
        Console.WriteLine("Agur.");
    } else {
        Console.WriteLine("Opción no válida.");
    }
}