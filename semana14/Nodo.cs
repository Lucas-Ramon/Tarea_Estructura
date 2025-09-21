using System;

class Nodo // Aquí defino la clase Nodo
{
    public int dato; // Este campo almacena el valor del nodo
    public Nodo izquierdo; // Referencia al hijo izquierdo
    public Nodo derecho; // Referencia al hijo derecho

    public Nodo(int dato) // En el constructor inicializo el nodo con un valor
    {
        this.dato = dato;
        izquierdo = null;
        derecho = null;
    }
}

class ArbolBinario  //creo la clase de arbolbinario
{
    public Nodo raiz; // La raíz del árbol, desde donde todo comienza

    public void Insertar(int dato)  // Método público para insertar un nuevo valor
    {
        raiz = InsertarRec(raiz, dato); // Llamo al método recursivo 
    }

    private Nodo InsertarRec(Nodo raiz, int dato)  // Este método recursivo busca la posición correcta para insertar el nuevo nodo
    {
        if (raiz == null) // Si llego a una posición vacía, creo el nuevo nodo
        {
            return new Nodo(dato); // Retorno el nuevo nodo creado
        }
        if (dato < raiz.dato) 
         // Si el dato es menor, lo inserto en el subárbol izquierdo
            raiz.izquierdo = InsertarRec(raiz.izquierdo, dato);
        else if (dato > raiz.dato)
        // Si el dato es mayor, lo inserto en el subárbol derecho
            raiz.derecho = InsertarRec(raiz.derecho, dato);
        // Si es igual, no se inserta (opcional)
        return raiz; // Si el dato ya existe, no lo inserto
    }

    public void Inorden() // Método para recorrer el árbol en orden (izquierda, raíz, derecha)
    {
        InordenRec(raiz);
        Console.WriteLine();
    }

    private void InordenRec(Nodo raiz) // Recorrido inorden recursivo
    {
        if (raiz != null) // Si el nodo no es nulo
        {
            InordenRec(raiz.izquierdo); // Recorro primero el subárbol izquierdo
            Console.Write(raiz.dato + " "); // Imprimo el valor del nodo actual
            InordenRec(raiz.derecho); // Recorro luego el subárbol derecho
        }
    }

    public void Preorden() // Método para recorrer el árbol en preorden (raíz, izquierda, derecha)
    {
        PreordenRec(raiz); // Llamo al método recursivo
        Console.WriteLine();
    }

    private void PreordenRec(Nodo raiz) // Método para recorrer el árbol en postorden (izquierda, derecha, raíz)
    {
        if (raiz != null) // Verifico que el nodo no sea nulo
        {
            Console.Write(raiz.dato + " "); // Imprimo el valor del nodo actual
            PreordenRec(raiz.izquierdo); // Recorro el subárbol izquierdo
            PreordenRec(raiz.derecho); // Recorro el subárbol derecho
        }
    }

    public void Postorden() // Método para buscar un valor en el árbol
    {
        PostordenRec(raiz); // Llamo al método recursivo
        Console.WriteLine(); // Salto de línea al final
    }

    private void PostordenRec(Nodo raiz) // Método recursivo para recorrido postorden
    {
        if (raiz != null) // Verifico que el nodo no sea nulo
        {
            PostordenRec(raiz.izquierdo); // Recorro el subárbol izquierdo
            PostordenRec(raiz.derecho); // Recorro el subárbol izquierdo
            Console.Write(raiz.dato + " "); // Imprimo el valor del nodo actual
        }
    }

    public bool Buscar(int dato)  // Método para buscar un valor en el árbol
    {
        return BuscarRec(raiz, dato);
    }

    private bool BuscarRec(Nodo raiz, int dato) // Método recursivo para búsqueda
    {
        if (raiz == null) return false;
        if (dato == raiz.dato) return true; // Si el valor coincide, lo encontré
        if (dato < raiz.dato) // Si es menor, busco en el subárbol izquierdo
            return BuscarRec(raiz.izquierdo, dato);
        else // Si es mayor, busco en el subárbol derecho
            return BuscarRec(raiz.derecho, dato);
    }

    public void Eliminar(int dato) // Método público para eliminar un nodo
    {
        raiz = EliminarRec(raiz, dato);
    }

    private Nodo EliminarRec(Nodo raiz, int dato) // Método recursivo para eliminar un nodo
    {
        if (raiz == null) return raiz;

        if (dato < raiz.dato) // Si el valor es menor, voy al subárbol izquierdo
            raiz.izquierdo = EliminarRec(raiz.izquierdo, dato);
        else if (dato > raiz.dato) // Si es mayor, voy al subárbol derecho
            raiz.derecho = EliminarRec(raiz.derecho, dato);
        else
        {
            // Nodo con solo un hijo o sin hijos
            if (raiz.izquierdo == null)
                return raiz.derecho;
            else if (raiz.derecho == null)
                return raiz.izquierdo;

            // Nodo con dos hijos: obtener el menor del subárbol derecho
            raiz.dato = MinValor(raiz.derecho);
            raiz.derecho = EliminarRec(raiz.derecho, raiz.dato);
        }
        return raiz; // Retorno la raíz actualizada
    }

    private int MinValor(Nodo nodo) // Método para encontrar el valor mínimo en un subárbol
    {
        int minv = nodo.dato; // Inicializo el mínimo con el valor actual
        while (nodo.izquierdo != null)
        {
            minv = nodo.izquierdo.dato; // Actualizo el mínimo
            nodo = nodo.izquierdo;
        }
        return minv; // Retorno el valor mínimo encontrado
    }
}

class Program // Clase principal del programa
{
    static void Main(string[] args) // Método principal
    {
        ArbolBinario arbol = new ArbolBinario(); // Creo una instancia del árbol
        int opcion, valor;

        do
        {
            // Muestro el menú
            Console.WriteLine("\n--- Menú Árbol Binario ---");
            Console.WriteLine("1. Insertar nodo");
            Console.WriteLine("2. Recorrido Inorden");
            Console.WriteLine("3. Recorrido Preorden");
            Console.WriteLine("4. Recorrido Postorden");
            Console.WriteLine("5. Buscar elemento");
            Console.WriteLine("6. Eliminar nodo");
            Console.WriteLine("0. Salir");
            Console.Write("Elige una opción: ");
            opcion = int.Parse(Console.ReadLine()); // Leo la opción del usuario
 
            switch (opcion)  // Evaluo la opción seleccionada
            {
                case 1:
                    Console.Write("Introduce el valor a insertar: ");
                    valor = int.Parse(Console.ReadLine());
                    arbol.Insertar(valor);
                    Console.WriteLine("Nodo insertado.");
                    break;
                case 2:
                    Console.WriteLine("Recorrido Inorden:");
                    arbol.Inorden();
                    break;
                case 3:
                    Console.WriteLine("Recorrido Preorden:");
                    arbol.Preorden();
                    break;
                case 4:
                    Console.WriteLine("Recorrido Postorden:");
                    arbol.Postorden();
                    break;
                case 5:
                    Console.Write("Introduce el valor a buscar: ");
                    valor = int.Parse(Console.ReadLine());
                    if (arbol.Buscar(valor))
                        Console.WriteLine("Elemento encontrado.");
                    else
                        Console.WriteLine("Elemento no encontrado.");
                    break;
                case 6:
                    Console.Write("Introduce el valor a eliminar: ");
                    valor = int.Parse(Console.ReadLine());
                    arbol.Eliminar(valor);
                    Console.WriteLine("Nodo eliminado (si existía).");
                    break;
                case 0:
                    Console.WriteLine("Adiós.");
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        } while (opcion != 0);
    }
}