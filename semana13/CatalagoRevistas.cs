using System; // Importo System para funcionalidades básicas
using System.Collections.Generic;

namespace SEMANA_13 
{
    class CatalogoRevistas // Creé esta clase  catálogo de revistas
    {
        private List<string> catalogo; // Declaro mi lista donde guardaré los títulos de las revistas
        
        public CatalogoRevistas() // En mi constructor inicializo todo lo que necesito
        {
            catalogo = new List<string>(); // Creo mi lista vacía
            InicializarCatalogo(); // Llamo al método que llenará mi catálogo con revistas
        }
        
        private void InicializarCatalogo() // Aquí agrego las 10 revistas que me pidieron
        {
            catalogo.Add("National Geographic"); 
            catalogo.Add("Time Magazine"); 
            catalogo.Add("Forbes"); 
            catalogo.Add("Vogue"); 
            catalogo.Add("Scientific American"); 
            catalogo.Add("The Economist"); 
            catalogo.Add("Sports Illustrated"); 
            catalogo.Add("Popular Science"); 
            catalogo.Add("Cosmopolitan"); 
            catalogo.Add("Reader's Digest"); 
        }
        
        public bool BusquedaRecursiva(string titulo) // Elegí usar búsqueda recursiva 
        {
            return BusquedaRecursivaAuxiliar(titulo, 0); // Llamo a mi método auxiliar empezando en índice 0
        }
        
        private bool BusquedaRecursivaAuxiliar(string titulo, int indice) 
        {
            if (indice >= catalogo.Count) // si llegué al final de la lista
            {
                return false; // No encontré el título, devuelvo false
            }
            
            if (catalogo[indice].Equals(titulo, StringComparison.OrdinalIgnoreCase)) //  si encontré el título
            {
                return true; // Devuelvo true porque lo encontré
            }
            
            return BusquedaRecursivaAuxiliar(titulo, indice + 1); //  busco en el siguiente índice
        }
        
        public void MostrarMenu() // Mi método principal para mostrar el menú interactivo
        {
            int opcion; // Variable para guardar la opción que elija el usuario
            
            do // Uso do-while para que el menú se ejecute al menos una vez
            {
                Console.WriteLine("=== SISTEMA DE BÚSQUEDA DE REVISTAS ==="); 
                Console.WriteLine("1. Buscar revista"); 
                Console.WriteLine("2. Salir"); 
                Console.Write("Seleccione una opción: "); 
                
                string entrada = Console.ReadLine(); // Leo la entrada del usuario
                int.TryParse(entrada, out opcion); // Convierto a entero de forma segura
                
                switch (opcion) // Evalúo qué opción eligió el usuario
                {
                    case 1: // Si eligió buscar revista
                        Console.Write("Ingrese el título de la revista a buscar: "); // Pido el título
                        string titulo = Console.ReadLine(); // Leo el título completo
                        
                        if (BusquedaRecursiva(titulo)) // Llamo a mi método recursivo
                        {
                            Console.WriteLine("Resultado: Encontrado\n"); // Muestro que sí existe
                        }
                        else
                        {
                            Console.WriteLine("Resultado: No encontrado\n"); // Muestro que no existe
                        }
                        break; // Salgo de este case
                        
                    case 2: // Si eligió salir
                        Console.WriteLine("¡Gracias por usar el sistema!"); // Mensaje de despedida
                        break; // Salgo de este case
                        
                    default: // Si eligió una opción inválida
                        Console.WriteLine("Opción inválida. Intente nuevamente.\n"); // Mensaje de error
                        break;
                }
                
            } while (opcion != 2); // Repito mientras no elija salir
        }
        
        static void Main(string[] args) // creo el metodo  Main para ejecutar el programa
        {
            CatalogoRevistas catalogo = new CatalogoRevistas(); // Creo una instancia de mi clase
            catalogo.MostrarMenu(); // Ejecuto el menú principal
        }
    }
}