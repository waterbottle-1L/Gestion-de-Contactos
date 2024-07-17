using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestion_de_Contactos.Contacto;

public class Program
{
        public static void Main()
        {
            
            Console.WriteLine("----------------------------------");
            Console.WriteLine("|------- Menu de Contactos --------|");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("|  1. Agregar contacto             |");
            Console.WriteLine("|  2. Buscar contacto              |");
            Console.WriteLine("|  3. Listar contactos             |");
            Console.WriteLine("|  4. Eliminar contacto            |");
            Console.WriteLine("|  5. Guardar contactos            |");
            Console.WriteLine("|  6. Cargar contactos             |");
            Console.WriteLine("|  7. Salir                        |");
            Console.WriteLine(" ---------------------------------");
            Console.WriteLine("|---Ingrese el numero de opcion----|");
            Console.WriteLine("----------------------------------");

        string opcion = Console.ReadLine();
        Console.WriteLine("------------------------------------------------------------------");
        GestorDeContactos gestor = new GestorDeContactos();
        if (int.TryParse(opcion, out int numero))
            {
                switch (numero)
                {
                    case 1:
                        Console.WriteLine("Agregar contacto");
                        Console.WriteLine("Ingrese el nombre del contacto");
                        string nombre = Console.ReadLine();
                        Console.WriteLine("Ingrese el telefono del contacto");
                        string telefonoString = Console.ReadLine();
                        int telefono = int.Parse(telefonoString);
                        Console.WriteLine("Ingrese el email del contacto");
                        string email = Console.ReadLine();
                        int id = GestorDeContactos.contactoLista.Count;
                        gestor.Agregar(++id, nombre, telefono, email);

                        break;
                    case 2:
                        
                        gestor.buscar();
                        break;
                    case 3:
                        
                        gestor.listar();
                        break;
                    case 4:
                        
                        gestor.eliminar();
                        break;
                    case 5:
                        
                         gestor.guardar();
                        break;
                    case 6:
                        
                        gestor.cargarContactos();
                        break;
                    case 7:
                        
                        gestor.Salir();
                        break;
                    default:
                        Console.WriteLine("Ingrese un valor dentro del rango especificado");
                        gestor.Volver();
                    break;
                }
            }
            else
            {
                Console.WriteLine("El valor " + numero + " introducido es una cadena de texto");
            }
        }
    


    
}


