using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista_Simple
{
    internal class Program
    {
        class SimpleLinkedList<T>
        {
            private class Node
            {
                public T Value { get; set; }
                public Node Next { get; set; }
                public Node(T value)
                {
                    this.Value = value;
                    Next = null;
                }
            }
            private Node Head {  get; set; }
            public int Lenght { get; set; }

            public void InsertNodeAtStart(T value)
            {
                if (Head == null)
                {
                    Node newNode = new Node(value);
                    Head = newNode;
                    Lenght = Lenght + 1;
                }
                else
                {
                    Node newNode = new Node(value);
                    newNode.Next = Head;
                    Head = newNode;
                    Lenght = Lenght + 1;
                }
            }
            public void InsertNodeAtEnd(T value)
            {
                if (Head == null)
                {
                    InsertNodeAtStart(value);
                }
                else
                {
                    Node last = SearchLastNode();
                    while (last.Next != null)
                    {
                        last = last.Next;
                    }
                    Node newNode = new Node(value);
                    last.Next = newNode;
                    Lenght = Lenght + 1;
                }
            }  
            public void InsertNodeAtPosition(T value, int position)
            {
                if (position == 0)
                {
                    InsertNodeAtStart(value);
                }

                else if (position == Lenght)
                {
                    InsertNodeAtEnd(value);
                }

                else if (position > Lenght)
                {
                    Console.WriteLine("No existe esa posicion.");
                }

                else
                {
                    Node newNode = new Node(value);
                    Node previusNode = Head;
                    Node positionNode;
                    int iterator = 0;

                    while (iterator < position - 1)
                    {
                        previusNode = previusNode.Next;
                        iterator = iterator + 1;
                    }
                    positionNode = previusNode.Next;
                    previusNode.Next = null;
                    previusNode.Next = newNode;
                    newNode.Next = positionNode;
                    Lenght = Lenght + 1;
                }
            }
            public void ModifyAtStart(T newValue)
            {
                if (Head == null)
                {
                    throw new NullReferenceException("No hay elementos en la Lista");
                }
                else
                {
                    Head.Value = newValue;
                }
            }

            public void ModifyAtEnd(T newValue)
            {
                if (Head == null)
                {
                    throw new NullReferenceException("No hay elementos en la Lista");
                }
                else
                {
                    Node lastNode = SearchLastNode();
                    lastNode.Value = newValue;
                }
            }

            public void ModifyAtPosition(T newValue, int position)
            {
                if (position == 0)
                {
                    ModifyAtStart(newValue);
                }
                else if (position == Lenght)
                {
                    ModifyAtEnd(newValue);
                }
                else if (position > Lenght)
                {
                    Console.WriteLine("No existe esa posicion.");
                }
                else
                {
                    Node nodePosition = Head;
                    int iterator = 0;
                    while (iterator < position)
                    {
                        nodePosition = nodePosition.Next;
                        iterator++;
                    }
                    nodePosition.Value = newValue;
                }
            }

            public T GetNodeAtStart()
            {
                if (Head == null)
                {
                    throw new Exception("No hay elementos en la Lista");
                }
                else
                {
                    return Head.Value;
                }
            }

            public T GetNodeAtEnd()
            {
                if (Head == null)
                {
                    return GetNodeAtStart();
                }
                else
                {
                    Node classNode = SearchLastNode();
                    return classNode.Value; 
                }
            }

            public T GetNodeAtPosition(int position)
            {
                if (position == 0)
                {
                    return GetNodeAtStart();
                }
                else if (position == Lenght)
                {
                    return GetNodeAtEnd();
                }
                else if (position > Lenght)
                {
                    throw new Exception("No existe esa posicion.");
                }
                else
                {
                    Node nodePosition = Head;
                    int iterator = 0;
                    while (iterator < position)
                    {
                        nodePosition = nodePosition.Next;
                        iterator++;
                    }
                    return nodePosition.Value;
                }
            }

            public void DeleteAtStart()
            {
                if (Head == null)
                {
                    throw new Exception("No hay elementos en la Lista");
                }
                else
                {
                    Node newHead = Head;
                    Head = newHead.Next;
                    newHead.Next = null;
                    Lenght = Lenght - 1;
                }
            }

            public void DeleteAtEnd()
            {
                if (Head == null)
                {
                    DeleteAtStart();
                }
                else
                {
                    Node previusLastNode = Head;
                    while (previusLastNode.Next.Next != null)
                    {
                        previusLastNode = previusLastNode.Next;
                    }
                    Node lastNode = previusLastNode.Next;
                    previusLastNode.Next = null;
                    lastNode = null;               
                    Lenght = Lenght - 1;
                }
            }

            public void DeleteNodeAtPosition(int position)
            {
                if (position == 0)
                {
                    DeleteAtStart();
                }
                else if (position == Lenght)
                {
                    DeleteAtEnd();
                }
                else if (position >= Lenght)
                {
                    throw new Exception("No existe esa posicion.");
                }
                else
                {
                    Node previous = Head;
                    int iterator = 0;
                    while (iterator < position - 1)
                    {
                        previous = previous.Next;
                        iterator++;
                    }             
                    Node nodePosition = previous.Next;
                    Node next = nodePosition.Next;
                    previous.Next = null;
                    nodePosition = null;
                    previous.Next = next;
                    nodePosition = null;                
                    Lenght = Lenght - 1;
                }
            }

            //METODO PARA BUSCAR UN VALOR EN LA LISTA
            public void SearchValue(T value)
            {
                Node current = Head;

                while (current != null)
                {
                    dynamic nodeValue = current.Value;
                    dynamic searchValue = value;

                    if (nodeValue == searchValue)
                    {
                        Console.WriteLine("Se encontró el elemento.");
                        return;
                    }

                    current = current.Next;
                }
                Console.WriteLine("No se encontró el elemento.");
            }

            //METODO PARA SABER LA CAPACIDAD ACTUAL DE LA LISTA
            public int CapacityList()
            {
                return Lenght;
            }
            //METODO PARA OBTENER EL SIGUIENTE NODO
            public T GetNextNode(T value)
            {
                Node current = Head;
                while (current != null)
                {
                    dynamic currentValue = current.Value;
                    dynamic searchedValue = value;
                    if (currentValue == searchedValue && current.Next != null)
                    {
                        return current.Next.Value;
                    }
                    current = current.Next;
                }
                throw new Exception("No esta el valor en mi Lista pipipi");
            }
            private Node SearchLastNode()
            {
                if (Head == null)
                {
                    throw new InvalidOperationException("La lista está vacía.");
                }
                Node lastNode = Head;
                while (lastNode.Next != null)
                {
                    lastNode = lastNode.Next;
                }
                return lastNode;
            }          
            public void PrintAllNodes()
            {   
                Node tmp = Head;
                while (tmp != null)
                {
                    Console.Write(tmp.Value + " - ");
                    tmp = tmp.Next;
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            SimpleLinkedList<int> simpleLinkedList = new SimpleLinkedList<int>();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Metodos Hechos en Clase: ");
            simpleLinkedList.InsertNodeAtStart(10);
            simpleLinkedList.InsertNodeAtStart(3);
            simpleLinkedList.InsertNodeAtEnd(5);
            simpleLinkedList.InsertNodeAtPosition(7,3);
            simpleLinkedList.PrintAllNodes();

            simpleLinkedList.ModifyAtStart(5);
            simpleLinkedList.ModifyAtEnd(2);
            simpleLinkedList.ModifyAtPosition(6, 1);
            simpleLinkedList.PrintAllNodes();

            Console.WriteLine("Inicio: " + simpleLinkedList.GetNodeAtStart());
            Console.WriteLine("Final: " + simpleLinkedList.GetNodeAtEnd());
            Console.WriteLine("La Posicion 4: " + "Es " + simpleLinkedList.GetNodeAtPosition(4))
                ;
            simpleLinkedList.InsertNodeAtEnd(3);
            simpleLinkedList.InsertNodeAtPosition(7, 1);
            simpleLinkedList.PrintAllNodes();

            simpleLinkedList.DeleteAtStart();
            simpleLinkedList.DeleteAtEnd();
            simpleLinkedList.DeleteNodeAtPosition(2);
            simpleLinkedList.PrintAllNodes();

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Metodos de Tarea: ");
            Console.WriteLine("La Capacidad de la Lista es: " + simpleLinkedList.CapacityList());         
            Console.WriteLine("Valor despues del 6: " + "Es el " + simpleLinkedList.GetNextNode(6));
            simpleLinkedList.SearchValue(2);


            Console.ReadLine();

        }
    }
}
