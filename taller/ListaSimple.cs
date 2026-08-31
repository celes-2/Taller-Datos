class NodoSimple
{
    public RatingRecord Value { get; }
    public NodoSimple Next { get; set; }

    public NodoSimple(RatingRecord value)
    {
        Value = value;
        Next = null;
    }
}


class ListaSimple: IRatingList
{
    private NodoSimple Head;
    private NodoSimple Tail;
    private int count;

    public int Count
    {
    get { return count; }
    }

    public void AddFirst(RatingRecord value)
    {
        NodoSimple nuevoNodo = new NodoSimple(value);
        if (Head == null)
        {
            Head = nuevoNodo;
            Tail = nuevoNodo;
    
        }
        else
        {
            nuevoNodo.Next = Head;
            Head = nuevoNodo;
        
        }
        count++;
        Console.WriteLine("Id de elemento agregado al inicio: " + value.RecordId);
    }
    public void AddAtIndex(RatingRecord value, int index)
    {
        if (index < 0 || index > count)
        {
            Console.WriteLine("Fuera de rango");
            return;
        }

        NodoSimple nuevoNodo = new NodoSimple(value);

        if (index == 0)
        {
            AddFirst(value);
            return;
        }

        NodoSimple actual = Head;
        int i = 0;
        while (i < index - 1)
        {
            actual = actual.Next;
            i++;
        }

        nuevoNodo.Next = actual.Next;
        actual.Next = nuevoNodo;
        if (nuevoNodo.Next == null)
        {
            Tail=nuevoNodo;
        }
        count++;
        Console.WriteLine("Id de elemento agregado en la posición " + index + ": " + value.RecordId);
    }
    
      public bool RemoveById(int recordId)
{
    if (Head == null)
    {
        return false;
    }

    if (Head.Value.RecordId == recordId)
    {
        NodoSimple siguiente = Head.Next;
        Head = siguiente;

        if (Head == null)
        {
            Tail = null;
        }

        count--;
        Console.WriteLine("Elemento eliminado: " + recordId);
        return true;
    }

    NodoSimple anterior = Head;
    NodoSimple actual = Head.Next;

    while (actual != null)
    {
        if (actual.Value.RecordId == recordId)
        {
            anterior.Next = actual.Next;

            if (actual == Tail)
            {
                Tail = anterior;
            }
            Console.WriteLine("Elemento eliminado: " + recordId);
            count--;
            return true;
        }

        anterior = actual;
        actual = actual.Next;
    }
    Console.WriteLine("No se encontró el elemento con RecordId: " + recordId);
    return false;
}

    public RatingRecord? FindById(int recordId)
    {
        NodoSimple actual = Head;

        while (actual != null)
        {
            if (actual.Value.RecordId == recordId)
            {
                Console.WriteLine("Id de elemento encontrado: " + recordId);
                return actual.Value;

            }
            actual = actual.Next;

        }
        Console.WriteLine("No se encontró el elemento con Id: " + recordId);

        return null;
    }

    public RatingRecord GetAt(int position)
    {
        if (position < 0 || position >= count)
        {
            throw new ArgumentOutOfRangeException("Posición fuera de rango.");
        }

        NodoSimple actual = Head;
        int i = 0;
        while (i < position)
        {
            actual = actual.Next;
            i++;
        }
        Console.WriteLine("Elemento en la posición " + position + "ID: " + actual.Value.RecordId);
        return actual.Value;
    }
    public void MostrarLista()
{
    NodoSimple? actual = Head;

    Console.Write("Lista: ");

    while (actual != null)
    {
        Console.Write(actual.Value.RecordId + " ");
        actual = actual.Next;
    }

    Console.WriteLine();
}
}