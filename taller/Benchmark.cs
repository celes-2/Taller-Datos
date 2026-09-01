using System.Diagnostics;

class Benchmark
{
    static int[] tamanos = { 100, 500, 1000, 2500, 5000, 7500, 10000 };
    static int repeticiones = 10;

    public static List<Medicion> Ejecutar(RatingRecord[] datosCompletos)
    {
        List<Medicion> resultados = new List<Medicion>();

        for (int r = 0; r < repeticiones; r++)
        {
            Console.WriteLine("Ejecutando repetición " + (r + 1) + " de " + repeticiones + "...");

            foreach (int n in tamanos)
            {
                if (r % 2 == 0)
                {
                    resultados.Add(MedirAddFirstSimple(datosCompletos, n, r + 1));
                    resultados.Add(MedirAddFirstArreglo(datosCompletos, n, r + 1));
                    resultados.Add(MedirAddAtIndexSimple(datosCompletos, n, r + 1));
                    resultados.Add(MedirAddAtIndexArreglo(datosCompletos, n, r + 1));
                    resultados.Add(MedirRemoveByIdSimple(datosCompletos, n, r + 1));
                    resultados.Add(MedirRemoveByIdArreglo(datosCompletos, n, r + 1));
                    resultados.Add(MedirFindByIdSimple(datosCompletos, n, r + 1));
                    resultados.Add(MedirFindByIdArreglo(datosCompletos, n, r + 1));
                    resultados.Add(MedirGetAtSimple(datosCompletos, n, r + 1));
                    resultados.Add(MedirGetAtArreglo(datosCompletos, n, r + 1));
                }
                else
                {
                    resultados.Add(MedirAddFirstArreglo(datosCompletos, n, r + 1));
                    resultados.Add(MedirAddFirstSimple(datosCompletos, n, r + 1));
                    resultados.Add(MedirAddAtIndexArreglo(datosCompletos, n, r + 1));
                    resultados.Add(MedirAddAtIndexSimple(datosCompletos, n, r + 1));
                    resultados.Add(MedirRemoveByIdArreglo(datosCompletos, n, r + 1));
                    resultados.Add(MedirRemoveByIdSimple(datosCompletos, n, r + 1));
                    resultados.Add(MedirFindByIdArreglo(datosCompletos, n, r + 1));
                    resultados.Add(MedirFindByIdSimple(datosCompletos, n, r + 1));
                    resultados.Add(MedirGetAtArreglo(datosCompletos, n, r + 1));
                    resultados.Add(MedirGetAtSimple(datosCompletos, n, r + 1));
                }
            }
        }

        return resultados;
    }

    static Medicion MedirAddFirstSimple(RatingRecord[] datosCompletos, int n, int repeticion)
    {
        ListaSimple lista = new ListaSimple();

        Stopwatch cronometro = Stopwatch.StartNew();
        for (int i = 0; i < n; i++)
        {
            lista.AddFirst(datosCompletos[i]);
        }
        cronometro.Stop();

        long ticks = cronometro.ElapsedTicks;
        double microsegundosTotal = (ticks / (double)Stopwatch.Frequency) * 1_000_000;
        double microsegundosPorOperacion = microsegundosTotal / n;

        return new Medicion("SinglyLinked", "AddFirst", n, repeticion, ticks, microsegundosPorOperacion, 0);
    }

    static Medicion MedirAddFirstArreglo(RatingRecord[] datosCompletos, int n, int repeticion)
    {
        ListaArreglo lista = new ListaArreglo();

        Stopwatch cronometro = Stopwatch.StartNew();
        for (int i = 0; i < n; i++)
        {
            lista.AddFirst(datosCompletos[i]);
        }
        cronometro.Stop();

        long ticks = cronometro.ElapsedTicks;
        double microsegundosTotal = (ticks / (double)Stopwatch.Frequency) * 1_000_000;
        double microsegundosPorOperacion = microsegundosTotal / n;

        return new Medicion("DynamicArray", "AddFirst", n, repeticion, ticks, microsegundosPorOperacion, 0);
    }

    static Medicion MedirAddAtIndexSimple(RatingRecord[] datosCompletos, int n, int repeticion)
    {
        ListaSimple lista = new ListaSimple();
        for (int i = 0; i < n; i++)
        {
            lista.AddFirst(datosCompletos[i]);
        }

        RatingRecord nuevoRegistro = datosCompletos[n];
        int indice = (int)(0.75 * (n - 1));

        Stopwatch cronometro = Stopwatch.StartNew();
        lista.AddAtIndex(nuevoRegistro, indice);
        cronometro.Stop();

        long ticks = cronometro.ElapsedTicks;
        double microsegundos = (ticks / (double)Stopwatch.Frequency) * 1_000_000;

        return new Medicion("SinglyLinked", "AddAtIndex", n, repeticion, ticks, microsegundos, 0);
    }

    static Medicion MedirAddAtIndexArreglo(RatingRecord[] datosCompletos, int n, int repeticion)
    {
        ListaArreglo lista = new ListaArreglo();
        for (int i = 0; i < n; i++)
        {
            lista.AddFirst(datosCompletos[i]);
        }

        RatingRecord nuevoRegistro = datosCompletos[n];
        int indice = (int)(0.75 * (n - 1));

        Stopwatch cronometro = Stopwatch.StartNew();
        lista.AddAtIndex(nuevoRegistro, indice);
        cronometro.Stop();

        long ticks = cronometro.ElapsedTicks;
        double microsegundos = (ticks / (double)Stopwatch.Frequency) * 1_000_000;

        return new Medicion("DynamicArray", "AddAtIndex", n, repeticion, ticks, microsegundos, 0);
    }
    static Medicion MedirRemoveByIdSimple(RatingRecord[] datosCompletos, int n, int repeticion)
    {
        // PREPARACIÓN - fuera del cronómetro: reconstruir la lista completa
        ListaSimple lista = new ListaSimple();
        for (int i = 0; i < n; i++)
        {
            lista.AddFirst(datosCompletos[i]);
        }

        int indice = (int)(0.75 * (n - 1));
        int recordIdAEliminar = lista.GetAt(indice).RecordId;

        // MEDICIÓN - una sola eliminación
        Stopwatch cronometro = Stopwatch.StartNew();
        lista.RemoveById(recordIdAEliminar);
        cronometro.Stop();

        long ticks = cronometro.ElapsedTicks;
        double microsegundos = (ticks / (double)Stopwatch.Frequency) * 1_000_000;

        return new Medicion("SinglyLinked", "RemoveById", n, repeticion, ticks, microsegundos, 0);
    }

    static Medicion MedirRemoveByIdArreglo(RatingRecord[] datosCompletos, int n, int repeticion)
    {
        // PREPARACIÓN - fuera del cronómetro: reconstruir la lista completa
        ListaArreglo lista = new ListaArreglo();
        for (int i = 0; i < n; i++)
        {
            lista.AddFirst(datosCompletos[i]);
        }

        int indice = (int)(0.75 * (n - 1));
        int recordIdAEliminar = lista.GetAt(indice).RecordId;

        // MEDICIÓN - una sola eliminación
        Stopwatch cronometro = Stopwatch.StartNew();
        lista.RemoveById(recordIdAEliminar);
        cronometro.Stop();

        long ticks = cronometro.ElapsedTicks;
        double microsegundos = (ticks / (double)Stopwatch.Frequency) * 1_000_000;

        return new Medicion("DynamicArray", "RemoveById", n, repeticion, ticks, microsegundos, 0);
    }
    static Medicion MedirFindByIdSimple(RatingRecord[] datosCompletos, int n, int repeticion)
    {
        // PREPARACIÓN - fuera del cronómetro
        ListaSimple lista = new ListaSimple();
        for (int i = 0; i < n; i++)
        {
            lista.AddFirst(datosCompletos[i]);
        }

        int indice = (int)(0.75 * (n - 1));
        int recordIdABuscar = lista.GetAt(indice).RecordId;

        // MEDICIÓN - 1000 búsquedas, acumulando checksum
        long checksum = 0;
        Stopwatch cronometro = Stopwatch.StartNew();

        for (int i = 0; i < 1000; i++)
        {
            RatingRecord? encontrado = lista.FindById(recordIdABuscar);
            checksum += encontrado!.RecordId;
        }

        cronometro.Stop();

        long ticks = cronometro.ElapsedTicks;
        double microsegundosTotal = (ticks / (double)Stopwatch.Frequency) * 1_000_000;
        double microsegundosPorOperacion = microsegundosTotal / 1000;

        return new Medicion("SinglyLinked", "FindById", n, repeticion, ticks, microsegundosPorOperacion, checksum);
    }

    static Medicion MedirFindByIdArreglo(RatingRecord[] datosCompletos, int n, int repeticion)
    {
        // PREPARACIÓN - fuera del cronómetro
        ListaArreglo lista = new ListaArreglo();
        for (int i = 0; i < n; i++)
        {
            lista.AddFirst(datosCompletos[i]);
        }

        int indice = (int)(0.75 * (n - 1));
        int recordIdABuscar = lista.GetAt(indice).RecordId;

        // MEDICIÓN - 1000 búsquedas, acumulando checksum
        long checksum = 0;
        Stopwatch cronometro = Stopwatch.StartNew();

        for (int i = 0; i < 1000; i++)
        {
            RatingRecord? encontrado = lista.FindById(recordIdABuscar);
            checksum += encontrado!.RecordId;
        }

        cronometro.Stop();

        long ticks = cronometro.ElapsedTicks;
        double microsegundosTotal = (ticks / (double)Stopwatch.Frequency) * 1_000_000;
        double microsegundosPorOperacion = microsegundosTotal / 1000;

        return new Medicion("DynamicArray", "FindById", n, repeticion, ticks, microsegundosPorOperacion, checksum);
    }
    static Medicion MedirGetAtSimple(RatingRecord[] datosCompletos, int n, int repeticion)
    {
        // PREPARACIÓN - fuera del cronómetro
        ListaSimple lista = new ListaSimple();
        for (int i = 0; i < n; i++)
        {
            lista.AddFirst(datosCompletos[i]);
        }

        int indice = (int)(0.75 * (n - 1));

        // MEDICIÓN - 1000 accesos, acumulando checksum
        long checksum = 0;
        Stopwatch cronometro = Stopwatch.StartNew();

        for (int i = 0; i < 1000; i++)
        {
            RatingRecord registro = lista.GetAt(indice);
            checksum += registro.RecordId;
        }

        cronometro.Stop();

        long ticks = cronometro.ElapsedTicks;
        double microsegundosTotal = (ticks / (double)Stopwatch.Frequency) * 1_000_000;
        double microsegundosPorOperacion = microsegundosTotal / 1000;

        return new Medicion("SinglyLinked", "GetAt", n, repeticion, ticks, microsegundosPorOperacion, checksum);
    }

    static Medicion MedirGetAtArreglo(RatingRecord[] datosCompletos, int n, int repeticion)
    {
        // PREPARACIÓN - fuera del cronómetro
        ListaArreglo lista = new ListaArreglo();
        for (int i = 0; i < n; i++)
        {
            lista.AddFirst(datosCompletos[i]);
        }

        int indice = (int)(0.75 * (n - 1));

        // MEDICIÓN - 1000 accesos, acumulando checksum
        long checksum = 0;
        Stopwatch cronometro = Stopwatch.StartNew();

        for (int i = 0; i < 1000; i++)
        {
            RatingRecord registro = lista.GetAt(indice);
            checksum += registro.RecordId;
        }

        cronometro.Stop();

        long ticks = cronometro.ElapsedTicks;
        double microsegundosTotal = (ticks / (double)Stopwatch.Frequency) * 1_000_000;
        double microsegundosPorOperacion = microsegundosTotal / 1000;

        return new Medicion("DynamicArray", "GetAt", n, repeticion, ticks, microsegundosPorOperacion, checksum);
    }
}