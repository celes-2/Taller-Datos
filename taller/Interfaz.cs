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
    static int totalPruebas = 0;
    static int pruebasPasadas = 0;

    // Compara lo esperado contra lo real e imprime PASA o FALLA
    static void Verificar(string idPrueba, string descripcion, bool condicion)
    {
        totalPruebas++;
        if (condicion)
        {
            pruebasPasadas++;
            Console.WriteLine("  [" + idPrueba + "] PASA - " + descripcion);
        }
        else
        {
            Console.WriteLine("  [" + idPrueba + "] FALLA - " + descripcion);
        }
    }

    static void Main()
    {
        RatingRecord registro1 = new RatingRecord(1, 101, 50, 5, 1700000000);
        RatingRecord registro2 = new RatingRecord(2, 102, 30, 4, 1700000100);
        RatingRecord registro3 = new RatingRecord(3, 103, 20, 3, 1700000200);
        RatingRecord registro4 = new RatingRecord(4, 104, 40, 5, 1700000300);
        RatingRecord registro5 = new RatingRecord(5, 105, 25, 4, 1700000400);


        Console.WriteLine("Parte de las pruebas de la lista simple");

        ListaSimple lista1 = new ListaSimple();


        // Prueba 1 (P1): Lista vacía
        Console.WriteLine("Count inicial: " + lista1.Count);
        Verificar("P1.1", "Count = 0 en lista vacía", lista1.Count == 0);

        RatingRecord? encontrado = lista1.FindById(5);
        Verificar("P1.2", "FindById devuelve null en lista vacía", encontrado == null);

        bool eliminado = lista1.RemoveById(5);
        Console.WriteLine("RemoveById: " + eliminado);
        Verificar("P1.3", "RemoveById devuelve false en lista vacía", eliminado == false);


        // Prueba 2 (P2): Inserción al inicio
        lista1.AddFirst(registro1);
        lista1.AddFirst(registro2);
        lista1.AddFirst(registro3);

        lista1.MostrarLista();
        Console.WriteLine("Count: " + lista1.Count);

        Verificar("P2.1", "Count = 3 tras 3 inserciones", lista1.Count == 3);
        Verificar("P2.2", "Orden correcto: posición 0 = id 3", lista1.GetAt(0).RecordId == 3);
        Verificar("P2.3", "Orden correcto: posición 1 = id 2", lista1.GetAt(1).RecordId == 2);
        Verificar("P2.4", "Orden correcto: posición 2 = id 1", lista1.GetAt(2).RecordId == 1);


        // Prueba 3 (P3): Inserción al final
        lista1.AddAtIndex(registro4, lista1.Count);

        lista1.MostrarLista();
        Console.WriteLine("Count: " + lista1.Count);

        Verificar("P3.1", "Count = 4 tras insertar al final", lista1.Count == 4);
        Verificar("P3.2", "El nuevo elemento quedó al final", lista1.GetAt(lista1.Count - 1).RecordId == 4);


        // Prueba 4 (P4): Eliminación
        Console.WriteLine("Eliminar primero:");
        eliminado = lista1.RemoveById(3);
        lista1.MostrarLista();
        Verificar("P4.1", "RemoveById(primero) devuelve true", eliminado == true);
        Verificar("P4.2", "Count = 3 tras eliminar el primero", lista1.Count == 3);

        Console.WriteLine("Eliminar medio:");
        eliminado = lista1.RemoveById(1);
        lista1.MostrarLista();
        Verificar("P4.3", "RemoveById(medio) devuelve true", eliminado == true);
        Verificar("P4.4", "Count = 2 tras eliminar el medio", lista1.Count == 2);

        Console.WriteLine("Eliminar último:");
        eliminado = lista1.RemoveById(4);
        lista1.MostrarLista();
        Verificar("P4.5", "RemoveById(ultimo) devuelve true", eliminado == true);
        Verificar("P4.6", "Count = 1 tras eliminar el ultimo", lista1.Count == 1);

        Console.WriteLine("Eliminar inexistente:");
        eliminado = lista1.RemoveById(10);
        lista1.MostrarLista();
        Verificar("P4.7", "RemoveById(inexistente) devuelve false", eliminado == false);
        Verificar("P4.8", "Count no cambia al eliminar inexistente", lista1.Count == 1);

        Console.WriteLine("Eliminar único:");
        eliminado = lista1.RemoveById(2);
        lista1.MostrarLista();
        Console.WriteLine("Count después de eliminar el único: " + lista1.Count);
        Verificar("P4.9", "RemoveById(unico) devuelve true", eliminado == true);
        Verificar("P4.10", "Count = 0 tras eliminar el unico", lista1.Count == 0);


        // Prueba 5 (P5): Acceso por posición
        lista1.AddFirst(registro1);
        lista1.AddFirst(registro2);
        lista1.AddFirst(registro3);

        lista1.MostrarLista();

        Console.WriteLine("Posición 0:");
        Console.WriteLine(lista1.GetAt(0).RecordId);
        Verificar("P5.1", "GetAt(0) = id 3", lista1.GetAt(0).RecordId == 3);

        Console.WriteLine("Posición media:");
        Console.WriteLine(lista1.GetAt(1).RecordId);
        Verificar("P5.2", "GetAt(media) = id 2", lista1.GetAt(1).RecordId == 2);

        Console.WriteLine("Posición Count - 1:");
        Console.WriteLine(lista1.GetAt(lista1.Count - 1).RecordId);
        Verificar("P5.3", "GetAt(Count-1) = id 1", lista1.GetAt(lista1.Count - 1).RecordId == 1);

        bool exceptionLanzada = false;
        try
        {
            lista1.GetAt(-1);
        }
        catch (ArgumentOutOfRangeException)
        {
            exceptionLanzada = true;
            Console.WriteLine("GetAt(-1): error correctamente detectado.");
        }
        Verificar("P5.4", "GetAt(-1) lanza excepción", exceptionLanzada);

        exceptionLanzada = false;
        try
        {
            lista1.GetAt(lista1.Count);
        }
        catch (ArgumentOutOfRangeException)
        {
            exceptionLanzada = true;
            Console.WriteLine("GetAt(Count): error correctamente detectado.");
        }
        Verificar("P5.5", "GetAt(Count) lanza excepción", exceptionLanzada);


        Console.WriteLine();
        Console.WriteLine("Pruebas de la lista dinámica");

        ListaArreglo lista2 = new ListaArreglo();


        // P1 sobre lista2
        Console.WriteLine("Count inicial: " + lista2.Count);
        Verificar("P1.1-arreglo", "Count = 0 en lista vacía", lista2.Count == 0);

        encontrado = lista2.FindById(5);
        Verificar("P1.2-arreglo", "FindById devuelve null en lista vacía", encontrado == null);

        eliminado = lista2.RemoveById(5);
        Console.WriteLine("RemoveById: " + eliminado);
        Verificar("P1.3-arreglo", "RemoveById devuelve false en lista vacía", eliminado == false);


        // P2 sobre lista2
        lista2.AddFirst(registro1);
        lista2.AddFirst(registro2);
        lista2.AddFirst(registro3);

        lista2.MostrarLista();
        Console.WriteLine("Count: " + lista2.Count);

        Verificar("P2.1-arreglo", "Count = 3 tras 3 inserciones", lista2.Count == 3);
        Verificar("P2.2-arreglo", "Orden correcto: posición 0 = id 3", lista2.GetAt(0).RecordId == 3);


        // P3 sobre lista2
        lista2.AddAtIndex(registro4, lista2.Count);

        lista2.MostrarLista();
        Console.WriteLine("Count: " + lista2.Count);

        Verificar("P3.1-arreglo", "Count = 4 tras insertar al final", lista2.Count == 4);
        Verificar("P3.2-arreglo", "El nuevo elemento quedó al final", lista2.GetAt(lista2.Count - 1).RecordId == 4);


        // P4 sobre lista2
        Console.WriteLine("Eliminar primero:");
        eliminado = lista2.RemoveById(3);
        lista2.MostrarLista();
        Verificar("P4.1-arreglo", "RemoveById(primero) devuelve true", eliminado == true);

        Console.WriteLine("Eliminar medio:");
        eliminado = lista2.RemoveById(1);
        lista2.MostrarLista();
        Verificar("P4.2-arreglo", "RemoveById(medio) devuelve true", eliminado == true);

        Console.WriteLine("Eliminar último:");
        eliminado = lista2.RemoveById(4);
        lista2.MostrarLista();
        Verificar("P4.3-arreglo", "RemoveById(ultimo) devuelve true", eliminado == true);

        Console.WriteLine("Eliminar inexistente:");
        eliminado = lista2.RemoveById(10);
        lista2.MostrarLista();
        Verificar("P4.4-arreglo", "RemoveById(inexistente) devuelve false", eliminado == false);

        Console.WriteLine("Eliminar único:");
        eliminado = lista2.RemoveById(2);
        lista2.MostrarLista();
        Console.WriteLine("Count después de eliminar el único: " + lista2.Count);
        Verificar("P4.5-arreglo", "Count = 0 tras eliminar el unico", lista2.Count == 0);


        // P5 sobre lista2
        lista2.AddFirst(registro1);
        lista2.AddFirst(registro2);
        lista2.AddFirst(registro3);

        lista2.MostrarLista();

        Console.WriteLine("Posición 0:");
        Console.WriteLine(lista2.GetAt(0).RecordId);
        Verificar("P5.1-arreglo", "GetAt(0) = id 3", lista2.GetAt(0).RecordId == 3);

        Console.WriteLine("Posición media:");
        Console.WriteLine(lista2.GetAt(1).RecordId);
        Verificar("P5.2-arreglo", "GetAt(media) = id 2", lista2.GetAt(1).RecordId == 2);

        Console.WriteLine("Posición Count - 1:");
        Console.WriteLine(lista2.GetAt(lista2.Count - 1).RecordId);
        Verificar("P5.3-arreglo", "GetAt(Count-1) = id 1", lista2.GetAt(lista2.Count - 1).RecordId == 1);

        exceptionLanzada = false;
        try
        {
            lista2.GetAt(-1);
        }
        catch (ArgumentOutOfRangeException)
        {
            exceptionLanzada = true;
            Console.WriteLine("GetAt(-1): error correctamente detectado.");
        }
        Verificar("P5.4-arreglo", "GetAt(-1) lanza excepción", exceptionLanzada);

        exceptionLanzada = false;
        try
        {
            lista2.GetAt(lista2.Count);
        }
        catch (ArgumentOutOfRangeException)
        {
            exceptionLanzada = true;
            Console.WriteLine("GetAt(Count): error correctamente detectado.");
        }
        Verificar("P5.5-arreglo", "GetAt(Count) lanza excepción", exceptionLanzada);


        // Prueba 6 (P6): Crecimiento de capacidad
        Console.WriteLine();
        Console.WriteLine("P6: Crecimiento de capacidad");

        ListaArreglo lista3 = new ListaArreglo();

        lista3.AddFirst(registro1);
        lista3.AddFirst(registro2);
        lista3.AddFirst(registro3);
        lista3.AddFirst(registro4);

        Console.WriteLine("Después de insertar 4 elementos:");
        lista3.MostrarLista();
        Console.WriteLine("Count: " + lista3.Count);
        Verificar("P6.1", "Capacidad = 4 tras insertar 4 elementos", lista3.Capacidad == 4);

        Console.WriteLine("Insertando quinto elemento:");
        lista3.AddFirst(registro5);
        lista3.MostrarLista();
        Console.WriteLine("Count: " + lista3.Count);
        Verificar("P6.2", "Capacidad = 8 tras insertar el 5to elemento", lista3.Capacidad == 8);


        // Prueba 7 (P7): Reducción de capacidad
        Console.WriteLine();
        Console.WriteLine("P7: Reducción de capacidad");

        lista3.RemoveById(1);
        lista3.MostrarLista();
        Verificar("P7.1", "Capacidad sigue en 8 con 4/8 = 50% ocupacion", lista3.Capacidad == 8);

        lista3.RemoveById(2);
        lista3.MostrarLista();
        Verificar("P7.2", "Capacidad sigue en 8 con 3/8 = 37.5% ocupacion", lista3.Capacidad == 8);

        lista3.RemoveById(4);
        lista3.MostrarLista();
        Verificar("P7.3", "Capacidad se reduce a 4 al llegar a 2/8 = 25% ocupacion", lista3.Capacidad == 4);

        lista3.RemoveById(5);
        lista3.MostrarLista();
        Verificar("P7.4", "Capacidad no baja de 4 (piso minimo)", lista3.Capacidad == 4);


        Console.WriteLine();
        Console.WriteLine("========================================");
        Console.WriteLine("RESUMEN: " + pruebasPasadas + "/" + totalPruebas + " pruebas pasaron");
        Console.WriteLine("========================================");
        //Acá está lo agregado
        Console.WriteLine();
        Console.WriteLine("========================================");
        Console.WriteLine("PRUEBA DE LECTURA DE u.data");
        Console.WriteLine("========================================");

        RatingRecord[] datos = LectorDatos.LeerArchivo("u.data");

        Console.WriteLine("Total de registros leídos: " + datos.Length);
        Console.WriteLine("Primeras 5 filas:");
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine(
                "RecordId=" + datos[i].RecordId +
                " UserId=" + datos[i].UserId +
                " MovieId=" + datos[i].MovieId +
                " Rating=" + datos[i].Rating +
                " Timestamp=" + datos[i].Timestamp);
        }
        Console.WriteLine();
        Console.WriteLine("========================================");
        Console.WriteLine("ESQUELETO DEL BENCHMARK");
        Console.WriteLine("========================================");
        List<Medicion> resultados = Benchmark.Ejecutar(datos);
        Console.WriteLine("Total de mediciones generadas: " + resultados.Count);
        LectorDatos.EscribirCsv(resultados, @"..\..\..\results.csv");
        Console.WriteLine("Archivo results.csv generado correctamente.");
    }
    
}