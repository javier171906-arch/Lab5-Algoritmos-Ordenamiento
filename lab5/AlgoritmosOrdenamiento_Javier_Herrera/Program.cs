namespace AlgoritmosOrdenamiento_Javier_Herrera
{
    class Program
    {
        // Lista de numeros a guardar
        static List<int> numeros = new List<int>();

        static void Main(string[] args)
        {
            int opcion = 0;

            while (opcion != 6)
            {
                
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("       ALGORITMOS DE ORDENAMIENTO");
                Console.WriteLine();
                Console.WriteLine("1. Registrar Números");
                Console.WriteLine("2. Mostrar Lista Actual");
                Console.WriteLine("3. Bubble Sort");
                Console.WriteLine("4. Insertion Sort");
                Console.WriteLine("5. Merge Sort");
                Console.WriteLine("6. Salir");
                Console.WriteLine();
                Console.Write("Seleccione una opción: ");

                Console.WriteLine();

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    opcion = 0;
                }

                switch (opcion)
                {
                    case 1:
                        Registrar();
                    break;

                    case 2:
                        Lista();
                    break;

                    case 3:
                        Ordenamiento("Bubble");
                    break;

                    case 4:
                        Ordenamiento("Insertion");
                    break;

                    case 5:
                        Ordenamiento("");
                    break;

                    case 6:
                        Console.WriteLine("Programa finalizado.");
                    break;

                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
                }

                if (opcion != 6)
                {
                    Console.WriteLine();
                    Console.WriteLine("Presione ENTER para regresar al menú...");
                    Console.ReadLine();
                }
            }
        }

        // Registrar numeros
        static void Registrar()
        {
            Console.WriteLine("--- REGISTRAR NÚMEROS ---");
            Console.WriteLine("Ingrese números enteros.");
            Console.WriteLine("Escriba . para terminar de registrar.");
            Console.WriteLine();

            string registro = "";

            while (registro != ".")
            {
                Console.Write("Número: ");
                registro = Console.ReadLine();

                if (registro != ".")
                {
                    int numero;

                    if (int.TryParse(registro, out numero))
                    {
                        numeros.Add(numero);
                        Console.WriteLine("Número " + numero + " agregado.");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("Entrada no válida. ");
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine("Total de números registrados: " + numeros.Count);
        }

        // Lista normal
        static void Lista()
        {
            Console.WriteLine("--- LISTA ---");

            if (numeros.Count == 0)
            {
                Console.WriteLine("La lista está vacía.");
            }
            else
            {
                foreach (var lista in numeros)
                {
                    Console.WriteLine(lista);
                }
                Console.WriteLine();
                Console.WriteLine("Cantidad de elementos: " + numeros.Count);
            }
        }

        // Algoritmo a usar
        static void Ordenamiento(string tipo)
        {
            
            if (numeros.Count == 0)
            {
                Console.WriteLine("La lista está vacía. ");
                return;
            }

            // Se ordena una copia
            List<int> copia = new List<int>(numeros);

            if (tipo == "Bubble")
            {
                Console.WriteLine("--- BUBBLE SORT ---");
                Console.WriteLine("Lista original:");
                foreach (var original in numeros){Console.WriteLine(original);}
                Console.WriteLine();
                BubbleSort(copia);
                Console.WriteLine("Lista ordenada:");
            }
            else if (tipo == "Insertion")
            {
                Console.WriteLine("--- INSERTION SORT ---");
                Console.WriteLine("Lista original:");
                foreach (var original in numeros){Console.WriteLine(original);}
                Console.WriteLine();
                InsertionSort(copia);
                Console.WriteLine("Lista ordenada:");
            }
            else
            {
                Console.WriteLine("--- MERGE SORT ---");
                Console.WriteLine("Lista original:");
                foreach (var original in numeros){Console.WriteLine(original);}
                Console.WriteLine();
                MergeSort(copia, 0, copia.Count - 1);
                Console.WriteLine("Lista ordenada:");
            }

            foreach (var num in copia)
            {
                Console.WriteLine(num);
            }
        }

        // Bubble sort
        static void BubbleSort(List<int> lista)
        {
            int n = lista.Count;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    // Si el elemento actual es mayor que el siguiente, se intercambian
                    if (lista[j] > lista[j + 1])
                    {
                        int temporal = lista[j];
                        lista[j] = lista[j + 1];
                        lista[j + 1] = temporal;
                    }
                }
            }
        }

        // Insertion sort
        static void InsertionSort(List<int> lista)
        {
            for (int i = 1; i < lista.Count; i++)
            {
                int actual = lista[i]; // elemento que se va a insertar
                int j = i - 1;

                // Se mueven a la derecha los mayores
                while (j >= 0 && lista[j] > actual)
                {
                    lista[j + 1] = lista[j];
                    j--;
                }

                lista[j + 1] = actual;
            }
        }

        // Merge sort
        static void MergeSort(List<int> lista, int inicio, int fin)
        {
            if (inicio < fin)
            {
                int medio = (inicio + fin) / 2;

                MergeSort(lista, inicio, medio);
                MergeSort(lista, medio + 1, fin);  
                Unir(lista, inicio, medio, fin); 
            }
        }

        // Une dos partes ordenadas de la lista
        static void Unir(List<int> lista, int inicio, int medio, int fin)
        {
            // Se copian las dos mitades
            List<int> izquierda = new List<int>();
            List<int> derecha = new List<int>();

            for (int i = inicio; i <= medio; i++)
            {
                izquierda.Add(lista[i]);
            }
            for (int i = medio + 1; i <= fin; i++)
            {
                derecha.Add(lista[i]);
            }

            int elemento1 = 0;        
            int elemento2 = 0;        
            int elemento3 = inicio;   

            // Se toma el menor de los dos elementos
            while (elemento1 < izquierda.Count && elemento2 < derecha.Count)
            {
                if (izquierda[elemento1] <= derecha[elemento2])
                {
                    lista[elemento3] = izquierda[elemento1];
                    elemento1++;
                }
                else
                {
                    lista[elemento3] = derecha[elemento2];
                    elemento2++;
                }
                elemento3++;
            }

            // se copian elementos a la izquierda
            while (elemento1 < izquierda.Count)
            {
                lista[elemento3] = izquierda[elemento1];
                elemento1++;
                elemento3++;
            }

            // se copian elementos a la derecha
            while (elemento2 < derecha.Count)
            {
                lista[elemento3] = derecha[elemento2];
                elemento2++;
                elemento3++;
            }
        }
    }
}