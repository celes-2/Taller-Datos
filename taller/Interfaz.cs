public interface IRatingList
{
    int Count { get; }

    void AddFirst(RatingRecord value);

    void AddAtIndex(RatingRecord value, int index);

    bool RemoveById(int recordId);

    RatingRecord? FindById(int recordId);

    RatingRecord GetAt(int position);
}

class Program
{
    static void Main()
    {
        RatingRecord registro1 = new RatingRecord(1, 101, 50, 5, 1700000000);

        RatingRecord registro2 = new RatingRecord(2, 102, 30, 4, 1700000100);

        RatingRecord registro3 = new RatingRecord(3, 103, 20, 3, 1700000200);

        RatingRecord registro4 = new RatingRecord(4, 104, 40, 5, 1700000300);

        RatingRecord registro5 = new RatingRecord(5, 105, 25, 4, 1700000400);


        Console.WriteLine("Parte pruebas de la lista simple");

        ListaSimple lista1 = new ListaSimple();


        // Prueba 1

        Console.WriteLine("Count inicial: " + lista1.Count);

        lista1.FindById(5);

        lista1.RemoveById(5);


        // Prueba 2

        lista1.AddFirst(registro1);
        lista1.AddFirst(registro2);
        lista1.AddFirst(registro3);
        lista1.MostrarLista();

        Console.WriteLine("Count: " + lista1.Count);


        // P3rueba 3

        lista1.AddAtIndex(registro4, lista1.Count);

        lista1.MostrarLista();

        Console.WriteLine("Count: " + lista1.Count);


        // Prueba 4

        Console.WriteLine("Eliminar primero:");
        lista1.RemoveById(3);
        lista1.MostrarLista();

        Console.WriteLine("Eliminar medio:");
        lista1.RemoveById(1);
        lista1.MostrarLista();

        Console.WriteLine("Eliminar último:");
        lista1.RemoveById(4);
        lista1.MostrarLista();

        Console.WriteLine("Eliminar inexistente:");
        lista1.RemoveById(10);
        lista1.MostrarLista();

        Console.WriteLine("Eliminar único:");
        lista1.RemoveById(2);
        lista1.MostrarLista();


        // Prueba 5

        lista1.AddFirst(registro1);
        lista1.AddFirst(registro2);
        lista1.AddFirst(registro3);

        lista1.MostrarLista();

        Console.WriteLine("Posición 0:");
        lista1.GetAt(0);

        Console.WriteLine("Posición media:");
        lista1.GetAt(1);

        Console.WriteLine("Posición Count - 1:");
        lista1.GetAt(lista1.Count - 1);

        try
        {
            lista1.GetAt(-1);
        }
        catch (ArgumentOutOfRangeException)  //Para que el codigo no se caiga se espera la excepcion
        {
            Console.WriteLine("GetAt(-1): error correctamente detectado.");
        }

        try
        {
            lista1.GetAt(lista1.Count);
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("GetAt(Count): error correctamente detectado.");
        }


        Console.WriteLine("Pruebas lista dinámica");

        ListaArreglo lista2 = new ListaArreglo();


        
        // Prueba 1

        Console.WriteLine("Count inicial: " + lista2.Count);

        lista2.FindById(5);

        lista2.RemoveById(5);


        // Prueba 2

        lista2.AddFirst(registro1);
        lista2.AddFirst(registro2);
        lista2.AddFirst(registro3);
        lista2.MostrarLista();

        Console.WriteLine("Count: " + lista2.Count);


        // P3rueba 3

        lista2.AddAtIndex(registro4, lista2.Count);

        lista2.MostrarLista();

        Console.WriteLine("Count: " + lista2.Count);


        // Prueba 4

        Console.WriteLine("Eliminar primero:");
        lista2.RemoveById(3);
        lista2.MostrarLista();

        Console.WriteLine("Eliminar medio:");
        lista2.RemoveById(1);
        lista2.MostrarLista();

        Console.WriteLine("Eliminar último:");
        lista2.RemoveById(4);
        lista2.MostrarLista();

        Console.WriteLine("Eliminar inexistente:");
        lista2.RemoveById(10);
        lista2.MostrarLista();

        Console.WriteLine("Eliminar único:");
        lista2.RemoveById(2);
        lista2.MostrarLista();


        // Prueba 5

        lista2.AddFirst(registro1);
        lista2.AddFirst(registro2);
        lista2.AddFirst(registro3);

        lista2.MostrarLista();

        Console.WriteLine("Posición 0:");
        lista2.GetAt(0);

        Console.WriteLine("Posición media:");
        lista2  .GetAt(1);

        Console.WriteLine("Posición Count - 1:");
        lista2.GetAt(lista2.Count - 1);

        try
        {
            lista2.GetAt(-1);
        }
        catch (ArgumentOutOfRangeException)  //Para que el codigo no se caiga se espera la excepcion
        {
            Console.WriteLine("GetAt(-1): error correctamente detectado.");
        }

        try
        {
            lista2.GetAt(lista2.Count);
        }
        catch (ArgumentOutOfRangeException)// Aqui igual
        {
            Console.WriteLine("GetAt(Count): error correctamente detectado.");
        }


        // Prueba 6
        ListaArreglo lista3 = new ListaArreglo();

        lista3.AddFirst(registro1);
        lista3.AddFirst(registro2);
        lista3.AddFirst(registro3);
        lista3.AddFirst(registro4);

        Console.WriteLine("Despues de insertar 4 elementos:");
        lista3.MostrarLista();

        Console.WriteLine("Count: " + lista3.Count);

        lista3.AddFirst(registro5);

        lista3  .MostrarLista();

        Console.WriteLine("Count: " + lista3.Count);


        // Prueba 7

        lista3.RemoveById(1);
        lista3.MostrarLista();

        lista3.RemoveById(2);
        lista3.MostrarLista();

        lista3.RemoveById(4);
        lista3.MostrarLista();

        lista3.RemoveById(5);
        lista3.MostrarLista();

    }
}