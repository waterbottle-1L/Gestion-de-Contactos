using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Collections;

namespace Gestion_de_Contactos.Contacto
{
    class GestorDeContactos
    {

        public static List<Contacto> contactoLista = new List<Contacto>();
        string archivo = "miLista.json";

        public void Agregar(int id, string nombre, int telefono, string email)
        {
            contactoLista.Add(new Contacto(id, nombre, telefono, email));
            Console.WriteLine("Contacto agregado!!");
            Console.WriteLine("Longitud de la lista actual: " + contactoLista.Count);
            Program.Main();
        }
        public void buscar()
        {
            Console.WriteLine("Escriba el nombre del contacto");
            string nombre = Console.ReadLine();
            Contacto contactoBuscado = contactoLista.Find(p => p.Nombre == nombre);
            if (contactoBuscado != null)
            {
                Console.WriteLine($"Id: {contactoBuscado.Id}, Nombre: {contactoBuscado.Nombre}, Telefono: {contactoBuscado.Telefono}, Email: {contactoBuscado.Email}");
            }
            else
            {
                Console.WriteLine($"No se encontró ninguna persona de nombre: {nombre}");
            }
            Program.Main();
        }
        public void listar()
        {
            Console.WriteLine("|---------Lista de Contactos-----------|");
            foreach (Contacto contacto in contactoLista)
            {
                
                Console.WriteLine("  -----------------------------------");
                Console.WriteLine($"|    ID: {contacto.Id}              |");
                Console.WriteLine($"|    Nombre: {contacto.Nombre}      |");
                Console.WriteLine($"|    Telefono: {contacto.Telefono}  |");
                Console.WriteLine($"|    Email: {contacto.Email}        |");
                Console.WriteLine("  -----------------------------------");
            }
            Program.Main();
        }
        public void eliminar()
        {
            Console.WriteLine(" ----------------------------------------------");
            Console.WriteLine("|-Digite el numero de fila que quiere eliminar-|");
            Console.WriteLine(" ----------------------------------------------");
            foreach (Contacto contacto in contactoLista)
            {
                Console.WriteLine("  --------------------------------------");
                Console.WriteLine($"|    ID: {contacto.Id}                 |");
                Console.WriteLine($"|    Nombre: {contacto.Nombre}         |");
                Console.WriteLine($"|    Telefono: {contacto.Telefono}     |");
                Console.WriteLine($"|    Email: {contacto.Email}           |");
                Console.WriteLine("  --------------------------------------");
            }
            string numeroFila = Console.ReadLine();
            int fila = int.Parse(numeroFila);
            contactoLista.RemoveAt(fila-1);
            Program.Main();

        }
        public void guardar()
        {
            Console.WriteLine("Longitud de la lista a agregar: " + contactoLista.Count);
            
            string jsonString = JsonSerializer.Serialize(contactoLista);
            File.WriteAllText(archivo, jsonString);
            Console.WriteLine("Lista guardada en el archivo.");
        }
        public void cargarContactos()
        {
            

            if (File.Exists(archivo))
            {
                // Leer y deserializar la lista desde el archivo
                string jsonString = File.ReadAllText(archivo);
                List<Contacto> listaGuardada = JsonSerializer.Deserialize<List<Contacto>>(jsonString);

                Console.WriteLine("Lista cargada desde el archivo:");
                contactoLista.AddRange(listaGuardada);
                foreach (var item in listaGuardada)
                {
                    Console.WriteLine(" ------------------ ");
                    Console.WriteLine("|"+item.Id+"       |");
                    Console.WriteLine("|"+item.Nombre+"   |");
                    Console.WriteLine("|"+item.Email+"    |");
                    Console.WriteLine("|"+item.Telefono+" |");
                    Console.WriteLine(" ------------------ ");
                }
            }
            else
            {
                Console.WriteLine("El archivo no existe.");
            }
            
            Program.Main();
        }
        public void Salir()
        {
            Console.WriteLine("Presiona cualquier tecla para cerrar la aplicación...");
            Console.ReadKey();
            Environment.Exit(0);
        }
        public void Volver()
        {
            Program.Main();
        }
         
    }
}
