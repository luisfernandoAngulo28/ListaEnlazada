using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CApp
{
    public class clsLista
    {
        class Nodo
        {
            public int info;
            public Nodo sig;
        }
        //Atributos de la clase 
        // Se define los nodos tope (primero) y rear (ultimo)
        private Nodo tope, rear;
        //constructor
        public clsLista()
        {
            tope = null;
            rear = null;
        }
        //lista vacia
        public bool Vacia()
        {
            return tope == null;
        }
        public clsLista AddPrimero(int elemento)
        {
            clsLista L = new clsLista();
            Nodo nuevo;
            nuevo = new Nodo();
            nuevo.info = elemento;
            nuevo.sig = tope;
            if (Vacia())  //caso1 si la lista esta vacia
            {
                tope = nuevo;
                rear = nuevo;
            }
            else// caso 2 si no esta vacia
            {
                tope = nuevo;
            }
            L.tope = tope;
            L.rear = rear;
            return L;
        }

        public  clsLista AddUltimo(int elemento)
        {
            clsLista L = new clsLista();
            Nodo nuevo = new Nodo();
            nuevo.info = elemento;
            nuevo.sig = null;
            if (Vacia())//caso1 si la lista esta vacia
            {
                tope = nuevo;
                rear = nuevo;
            }
            else// caso 2 si no esta vacia
            {
                rear.sig = nuevo;
                rear = nuevo;
            }
            L.tope = tope;
            L.rear = rear;
            return L;
        }

         public clsLista AddAntes(int info,int infox)
        {
            clsLista L = new clsLista();
            Nodo anterior = null;
            Nodo actual = tope;
            while (actual != null)
            {
                if (actual.info==infox)
                {
                    Nodo nuevo = new Nodo();
                    nuevo.info = info;
                    nuevo.sig = actual;
                    anterior.sig = nuevo;

                }
                anterior = actual; 
                actual = actual.sig;
            }
            L.tope = tope;
            L.rear = rear;
            return L;

        }

        // Borrar un nodo dado X
       public clsLista Delete(int elemento)
        {
            clsLista L = new clsLista();
            Nodo anterior, actual;
            anterior = null;
            actual = tope;
            bool existe = false;
            while (actual != null && existe==false)
            {
                if (actual.info == elemento)
                {
                    existe = true;
                }
                else
                {
                    anterior = actual;
                    actual = actual.sig;
                }    
            }
            if (existe == false) //si no existe el valor
            {
                L.tope = tope;
                L.rear = rear;
                return L;
            }
            if (actual == tope)//si eliminamos el primero
            {
                tope = actual.sig;
                actual = null;
                L.tope = tope;
                L.rear = rear;
                return L;
            }
            if (actual == rear)//si eliminamos el ultimo
            {
                anterior.sig = null;
                rear = anterior;
                actual = null;
                L.tope = tope;
                L.rear = rear;
                return L;

            }

            //si el valor esta entre el medio
            anterior.sig = actual.sig;
            actual.sig = null;
            L.tope = tope;
            L.rear = rear;
            return L;
        } 

        public clsLista DelPrimero()
        {
            clsLista L = new clsLista();
            Nodo actual = tope;
            if (actual == null)
            {
                L.tope = tope;
                L.rear = rear;
                return L;
            }
            tope = actual.sig;
            actual.sig= null;//actual=null;
            L.tope = tope;
            L.rear = rear;
            return L;
        }

        public Boolean Buscar(int info)
        {
            Nodo reco = tope;
            while (reco != null)
            {

                if (reco.info == info)
                    return true;
                reco = reco.sig;
            }
            return false;
        }

        // ==========================  PARA DESARROLLAR =============================

        // Adiciona el nodo con valor info después del nodo con valor infox dado

        public clsLista AddDespues(int info, int infoX)
        {
            clsLista L = new clsLista();
            Nodo actual = tope;
            Nodo siguiente = tope.sig;
            bool existe = false;
            if (!Vacia()) 
            {
                  while((siguiente!=null)&& (existe == false))
                {
                    if (actual.info==infoX)
                    {
                        existe = true;
                        Nodo nuevo = new Nodo();
                        nuevo.info = info;
                        nuevo.sig = siguiente;
                        actual.sig = nuevo;

                    }
                    actual = siguiente;
                    siguiente = siguiente.sig;
                }
            }

            L.tope = tope;
            L.rear = rear;
            return L;
        }

        // Borrar el ultimo nodo de la lista
        public clsLista DelUltimo()
        {
            clsLista L = new clsLista();
            Nodo anterior = null;
            Nodo actual = tope;
            Nodo siguiente = tope.sig;
            if (!Vacia() && (tope==rear))
            {
                tope = null;
                rear = null;
            }
            else
            {
                if (!Vacia())
                {
                    while (siguiente != null)
                    {
                        anterior = actual;
                        actual = siguiente;
                        siguiente = siguiente.sig;
                    }
                    anterior.sig = null;
                    actual = null;
                    rear = anterior;

                }
            }
            L.tope = tope;
            L.rear = rear;
            return L;
        }

        // Retorna una lista con los elemento ordenados de forma ascendente o descennte 


        public int mayor()
        {
            Nodo actual = tope;
            int mayor = 0;
            while (actual!=null)
            {
                if (actual.info>=mayor)
                {
                    mayor = actual.info;
                }
                actual = actual.sig;
            }
            return mayor;
        }
        public int menor()
        {
            Nodo actual = tope;
            int menor = mayor();
            while (actual != null)
            {
                if (actual.info <= menor)
                {
                    menor = actual.info;
                }
                actual = actual.sig;
            }
            return menor;
        }
        public clsLista Ordenar(int Orden)
        {
            // if Orden=1 ascendente   if Oden=2 descendente
            clsLista L = new clsLista();
            int elemento = 0;
            if (!Vacia())
            {
                if (Orden==1)//Orden=1 ascendente 
                {
                    while (Vacia()==false)
                    {
                        elemento = menor();
                        L.AddUltimo(elemento);
                        Delete(elemento);
                    }     
                }
                if (Orden == 2) //Oden = 2 descendente
                {
                    while (Vacia() == false)
                    {
                        elemento = mayor();
                        L.AddUltimo(elemento);
                        Delete(elemento);
                    }
                }
            }
            return L;
        }








        public String View()
        {
            String cad = "";
            Nodo pos = tope;//puntero
            while (pos != null)//recorrer una lista
            {
                cad = cad + "[" + pos.info + "| ]->";
                pos = pos.sig;//cambiamos de nodo
            }
            return cad + "null";
        }

    }
}
