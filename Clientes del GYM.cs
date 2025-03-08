using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Gymnasio
{
    static Dictionary<int, Cliente> clientes = new Dictionary<int, Cliente>();

    static void Main()
    {
        Console.BackgroundColor = ConsoleColor.Gray; // Azul agradable jaja
        Console.ForegroundColor = ConsoleColor.Black; // Texto blanco
        Console.Clear(); // Aplicar colores a toda la consola

        while (true)
        {
            Console.WriteLine("\n Registro de clientes del Gimnasio");
            Console.WriteLine("\n 1. Dar de alta un cliente");
            Console.WriteLine("2. Mostrar detalles de un cliente");
            Console.WriteLine("3. Listar clientes");
            Console.WriteLine("4. Buscar cliente (Nombre)");
            Console.WriteLine("5. Dar de baja un cliente");
            Console.WriteLine("6. Modificar un cliente");
            Console.WriteLine("7. Salir");
            Console.Write("\n Opción: ");

            string opcion = Console.ReadLine();
            switch (opcion)
            {
                case "1": AltaCliente(); break;
                case "2": MostrarCliente(); break;
                case "3": ListarClientes(); break;
                case "4": BuscarCliente(); break;
                case "5": BajaCliente(); break;
                case "6": ModificarCliente(); break;
                case "7": return;
                default: Console.WriteLine("Opción no válida. Intente de nuevo."); break;
            }
        }
    }

    static void AltaCliente()
    {
        int id;
        while (true)
        {
            Console.Write("Ingrese ID del cliente: ");
            if (int.TryParse(Console.ReadLine(), out id)) break;
            Console.WriteLine("Error: Ingrese un número válido.");
        }
        if (clientes.ContainsKey(id))
        {
            Console.WriteLine("Cliente ya registrado.");
            return;
        }
        Console.Write("Ingrese nombre del cliente: ");
        string nombre = Console.ReadLine();
        int edad;
        while (true)
        {
            Console.Write("Ingrese edad del cliente: ");
            if (int.TryParse(Console.ReadLine(), out edad)) break;
            Console.WriteLine("Error: Ingrese un número válido.");
        }
        Console.Write("Ingrese teléfono del cliente: ");
        string telefono = Console.ReadLine();

        clientes[id] = new Cliente(nombre, edad, telefono);
        Console.WriteLine("Cliente registrado exitosamente.");
    }

    static void MostrarCliente()
    {
        Console.Write("Ingrese ID del cliente: ");
        if (int.TryParse(Console.ReadLine(), out int id) && clientes.ContainsKey(id))
            Console.WriteLine(clientes[id]);
        else
            Console.WriteLine("Cliente no encontrado o ID inválido.");
    }

    static void ListarClientes()
    {
        if (clientes.Count == 0)
        {
            Console.WriteLine("No hay clientes registrados.");
            return;
        }
        foreach (var cliente in clientes)
            Console.WriteLine($"ID: {cliente.Key} - {cliente.Value}");
    }

    static void BuscarCliente()
    {
        Console.Write("Ingrese el nombre del cliente a buscar: ");
        string nombre = Console.ReadLine().ToLower();
        bool encontrado = false;
        foreach (var cliente in clientes.Values)
        {
            if (cliente.Nombre.ToLower() == nombre)
            {
                Console.WriteLine(cliente);
                encontrado = true;
            }
        }
        if (!encontrado) Console.WriteLine("Cliente no encontrado.");
    }

    static void BajaCliente()
    {
        Console.Write("Ingrese ID del cliente a eliminar: ");
        if (int.TryParse(Console.ReadLine(), out int id) && clientes.Remove(id))
            Console.WriteLine("Cliente eliminado exitosamente.");
        else
            Console.WriteLine("Cliente no encontrado o ID inválido.");
    }

    static void ModificarCliente()
    {
        Console.Write("Ingrese ID del cliente a modificar: ");
        if (int.TryParse(Console.ReadLine(), out int id) && clientes.ContainsKey(id))
        {
            Console.Write("Nuevo nombre (dejar vacío para no cambiar): ");
            string nombre = Console.ReadLine();
            Console.Write("Nueva edad (dejar vacío para no cambiar): ");
            string edadStr = Console.ReadLine();
            Console.Write("Nuevo teléfono (dejar vacío para no cambiar): ");
            string telefono = Console.ReadLine();

            if (!string.IsNullOrEmpty(nombre)) clientes[id].Nombre = nombre;
            if (int.TryParse(edadStr, out int edad)) clientes[id].Edad = edad;
            if (!string.IsNullOrEmpty(telefono)) clientes[id].Telefono = telefono;

            Console.WriteLine("Cliente modificado exitosamente.");
        }
        else
            Console.WriteLine("Cliente no encontrado o ID inválido.");
    }
}

class Cliente
{
    public string Nombre { get; set; }
    public int Edad { get; set; }
    public string Telefono { get; set; }

    public Cliente(string nombre, int edad, string telefono)
    {
        Nombre = nombre;
        Edad = edad;
        Telefono = telefono;
    }

    public override string ToString()
    {
        return $"Nombre: {Nombre}, Edad: {Edad}, Teléfono: {Telefono}";
    }
}
