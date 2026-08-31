class ListaArreglo: IRatingList
{
    private RatingRecord[] elementos;
    public int count;
    private int capacidad = 4;

    public int Count
    {
    get { return count; }
    }

    public ListaArreglo()
    {
        elementos = new RatingRecord[capacidad];
        count = 0;
    }

    public void AddFirst(RatingRecord value)
    {
        if (count == capacidad)
        {
            capacidad = capacidad * 2;

            RatingRecord[] nuevoArreglo = new RatingRecord[capacidad];

            for (int i = 0; i < count; i++)
            {
                nuevoArreglo[i] = elementos[i];
            }

            elementos = nuevoArreglo;
            Console.WriteLine("Capacidad del arreglo aumento a: " + capacidad);
        }

        for (int i = count; i > 0; i--)
        {
            elementos[i] = elementos[i - 1];
        }

        elementos[0] = value;

        count++;
    }
    public void AddAtIndex(RatingRecord value, int index)
    {
        if (index < 0 || index > count)
        {
            Console.WriteLine("Fuera de rango.");
            return;
        }

        if (count == capacidad)
        {
            capacidad = capacidad * 2;

            RatingRecord[] nuevoArreglo = new RatingRecord[capacidad];

            for (int i = 0; i < count; i++)
            {
                nuevoArreglo[i] = elementos[i];
            }

            elementos = nuevoArreglo;
            Console.WriteLine("Capacidad del arreglo aumento a: " + capacidad);
        }

        for (int i = count; i > index; i--)
        {
            elementos[i] = elementos[i - 1];
        }

        elementos[index] = value;

        count++;
    }
    public bool RemoveById(int recordId)
{
    for (int i = 0; i < count; i++)
    {
        if (elementos[i].RecordId == recordId)
        {
            for (int j = i; j < count - 1; j++)
            {
                elementos[j] = elementos[j + 1];
            }

            elementos[count - 1] = null;
            count--;

            if (count <= capacidad / 4 && capacidad / 2 >= 4)
            {
                int nuevaCapacidad = capacidad / 2;

                if (nuevaCapacidad < count)
                {
                    nuevaCapacidad = count;
                }

                RatingRecord[] nuevoArreglo = new RatingRecord[nuevaCapacidad];

                for (int j = 0; j < count; j++)
                {
                    nuevoArreglo[j] = elementos[j];
                }

                elementos = nuevoArreglo;
                capacidad = nuevaCapacidad;
                Console.WriteLine("Capacidad del arreglo reducida a: " + capacidad);
            }

            return true;
        }
    }
    return false;
}
    public RatingRecord? FindById(int recordId)
    {
        for (int i = 0; i < count; i++)
        {
            if (elementos[i].RecordId == recordId)
            {
                return elementos[i];

            }
        }
        return null;
    }
    public RatingRecord GetAt(int position)
    {
        if (position < 0 || position >= count)
        {
            throw new ArgumentOutOfRangeException("Posición fuera de rango.");
        }
        return elementos[position];
    }
    public void MostrarLista()
    {
    Console.Write("Lista: ");

    for (int i = 0; i < count; i++)
    {
        Console.Write(elementos[i].RecordId + " ");
    }

    Console.WriteLine();
    }

}