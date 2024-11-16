using System;

public class NodoDoble
{
    public int Valor { get; set; }
    public NodoDoble Anterior { get; set; }
    public NodoDoble Siguiente { get; set; }

    public NodoDoble(int valor)
    {
        Valor = valor;
        Anterior = null;
        Siguiente = null;
    }
}

public class ListaDobleEnlazada
{
    private NodoDoble cabeza;
    private NodoDoble cola;

    public ListaDobleEnlazada()
    {
        cabeza = null;
        cola = null;
    }

    public void Agregar(int valor)
    {
        NodoDoble nuevoNodo = new NodoDoble(valor);
        if (cabeza == null)
        {
            cabeza = nuevoNodo;
            cola = nuevoNodo;
        }
        else
        {
            cola.Siguiente = nuevoNodo;
            nuevoNodo.Anterior = cola;
            cola = nuevoNodo;
        }
    }

    public void Eliminar(int valor)
    {
        NodoDoble actual = cabeza;
        while (actual != null)
        {
            if (actual.Valor == valor)
            {
                if (actual.Anterior != null)
                {
                    actual.Anterior.Siguiente = actual.Siguiente;
                }
                else
                {
                    cabeza = actual.Siguiente;
                }

                if (actual.Siguiente != null)
                {
                    actual.Siguiente.Anterior = actual.Anterior;
                }
                else
                {
                    cola = actual.Anterior;
                }
                return;
            }
            actual = actual.Siguiente;
        }
    }

    public NodoDoble Buscar(int valor)
    {
        NodoDoble actual = cabeza;
        while (actual != null)
        {
            if (actual.Valor == valor)
            {
                return actual;
            }
            actual = actual.Siguiente;
        }
        return null;
    }

    public bool Modificar(int valorViejo, int valorNuevo)
    {
        NodoDoble nodoEncontrado = Buscar(valorViejo);
        if (nodoEncontrado != null)
        {
            nodoEncontrado.Valor = valorNuevo;
            return true;
        }
        return false;
    }

    public void ImprimirAdelante()
    {
        NodoDoble actual = cabeza;
        while (actual != null)
        {
            Console.Write(actual.Valor + " ");
            actual = actual.Siguiente;
        }
        Console.WriteLine();
    }

    public void ImprimirAtras()
    {
        NodoDoble actual = cola;
        while (actual != null)
        {
            Console.Write(actual.Valor + " ");
            actual = actual.Anterior;
        }
        Console.WriteLine();
    }
}

public class NodoCircular
{
    public int Valor { get; set; }
    public NodoCircular Siguiente { get; set; }

    public NodoCircular(int valor)
    {
        Valor = valor;
        Siguiente = null;
    }
}

public class ListaCircular
{
    private NodoCircular cabeza;

    public ListaCircular()
    {
        cabeza = null;
    }

    public void Agregar(int valor)
    {
        NodoCircular nuevoNodo = new NodoCircular(valor);
        if (cabeza == null)
        {
            cabeza = nuevoNodo;
            cabeza.Siguiente = cabeza;
        }
        else
        {
            NodoCircular actual = cabeza;
            while (actual.Siguiente != cabeza)
            {
                actual = actual.Siguiente;
            }
            actual.Siguiente = nuevoNodo;
            nuevoNodo.Siguiente = cabeza;
        }
    }

    public void Eliminar(int valor)
    {
        if (cabeza == null) return;

        if (cabeza.Valor == valor && cabeza.Siguiente == cabeza)
        {
            cabeza = null;
            return;
        }

        NodoCircular actual = cabeza;
        NodoCircular anterior = null;

        do
        {
            if (actual.Valor == valor)
            {
                if (anterior != null)
                {
                    anterior.Siguiente = actual.Siguiente;
                }
                else
                {
                    NodoCircular ultimo = cabeza;
                    while (ultimo.Siguiente != cabeza)
                    {
                        ultimo = ultimo.Siguiente;
                    }
                    cabeza = cabeza.Siguiente;
                    ultimo.Siguiente = cabeza;
                }
                return;
            }
            anterior = actual;
            actual = actual.Siguiente;
        } while (actual != cabeza);
    }

    public NodoCircular Buscar(int valor)
    {
        if (cabeza == null) return null;

        NodoCircular actual = cabeza;
        do
        {
            if (actual.Valor == valor)
            {
                return actual;
            }
            actual = actual.Siguiente;
        } while (actual != cabeza);
        return null;
    }

    public bool Modificar(int valorViejo, int valorNuevo)
    {
        NodoCircular nodoEncontrado = Buscar(valorViejo);
        if (nodoEncontrado != null)
        {
            nodoEncontrado.Valor = valorNuevo;
            return true;
        }
        return false;
    }

    public void Imprimir()
    {
        if (cabeza == null) return;

        NodoCircular actual = cabeza;
        do
        {
            Console.Write(actual.Valor + " ");
            actual = actual.Siguiente;
        } while (actual != cabeza);
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        ListaDobleEnlazada listaDoble = new ListaDobleEnlazada();
        listaDoble.Agregar(1);
        listaDoble.Agregar(2);
        listaDoble.Agregar(3);
        listaDoble.ImprimirAdelante();
        listaDoble.ImprimirAtras();
        listaDoble.Modificar(2, 4);
        listaDoble.ImprimirAdelante();
        listaDoble.Eliminar(3);
        listaDoble.ImprimirAdelante();

        ListaCircular listaCircular = new ListaCircular();
        listaCircular.Agregar(5);
        listaCircular.Agregar(6);
        listaCircular.Agregar(7);
        listaCircular.Imprimir();
        listaCircular.Modificar(6, 8);
        listaCircular.Imprimir();
        listaCircular.Eliminar(7);
        listaCircular.Imprimir();
    }
}
