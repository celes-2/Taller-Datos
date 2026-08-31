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
            count--;
            return true;
        }

        anterior = actual;
        actual = actual.Next;
    }
    return false;
}

    public RatingRecord? FindById(int recordId)
    {
        NodoSimple actual = Head;

        while (actual != null)
        {
            if (actual.Value.RecordId == recordId)
            {
                return actual.Value;

            }
            actual = actual.Next;

        }

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