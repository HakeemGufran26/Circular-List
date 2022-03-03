using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assigment_Linked_List
{
    /// <summary>
    /// main class
    /// </summary>
    class Node
    {
        //Create Nodes for the circular nexted list
        public int roll_Number;
        public string name;
        public Node next;
        public Node prev;
    }
    /// <summary>
    /// class circular list
    /// </summary>
    class CircularList
    {
        Node last;
        /// <summary>
        /// Method untuk menampilkan data yang kosong
        /// </summary>
        public CircularList()
        {
            last = null;
        }
        /// <summary>
        /// method untuk menambahkan data
        /// </summary>
        public void addNode() //adds a new node
        {
            int rollNo;
            string nm;
            Console.Write("\nEnter the roll number of the student : ");
            rollNo = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nEnter the name of the student : ");
            nm = Console.ReadLine();
            Node Newnode = new Node();
            Newnode.roll_Number = rollNo;
            Newnode.name = nm;
            if (last == null || rollNo <= last.roll_Number)
            {
                if ((last != null) && (rollNo == last.roll_Number))
                {
                    Console.WriteLine("\nDupplicate roll numbers not allowed");
                    return;
                }
                Newnode.next = last;
                if (last != null)
                    last.prev = Newnode;
                Newnode.prev = null;
                last = Newnode;
                return;
            }
            Node previous, current;
            for (current = previous = last; current != null && rollNo >= current.roll_Number; previous = current, current = current.next)
            {
                if (rollNo == current.roll_Number)
                {
                    Console.WriteLine("\nDuplicate roll numbers not allowed\n");
                    return;
                }

            }
            /*On the execution of the above for loop, prev and
             *  Current will point to those nodes between which the new node is to be inserted.*/
            Newnode.next = current;
            Newnode.prev = previous;

            //If the node is to be inserted at the end of the list.
            if (current == null)
            {
                Newnode.next = null;
                previous.next = Newnode;
                return;
            }
            current.prev = Newnode;
            previous.next = Newnode;
        }
        /// <summary>
        /// Searches for the specified node
        /// </summary>
        /// <param name="rollNo"></param>
        /// <param name="previous"></param>
        /// <param name="current"></param>
        /// <returns></returns>
        public bool Search(int rollNo, ref Node previous, ref Node current)
        //Searches for the specified node
        {
            for (previous = current = last.next; current != last; previous = current, current = current.next)
            {
                if (rollNo == current.roll_Number)
                    return (true);//returns true if the node is found
            }
            if (rollNo == last.roll_Number)//if the npde is present at the end
                return true;
            else
                return (false);//returns false if the node is not found
        }
        /// <summary>
        /// Kondisi apa bila list yang di tampilkan kosong
        /// </summary>
        /// <returns></returns>

        public bool listEmpty()
        {
            if (last == null)
                return true;
            else
                return false;
        }
        /// <summary>
        /// delete the specified node
        /// </summary>
        /// <param name="rollNo"></param>
        /// <returns></returns>
        public bool delNode(int rollNo) /* Deletes the specified node*/
        {
            Node previous, current;
            previous = current = null;
            if (Search(rollNo, ref previous, ref current) == false)
                return false;
            if (current == last) // If the first node is to be deleted
            {
                last = last.next;
                if (last != null)
                    last.prev = null;
                return true;
            }
            if (current.next == null) // If the last node is to be deleted 
            {
                previous.next = null;
                return true;
            }
            //If the node to be deleted is in between the list then the following lines of code is executed.
            previous.next = current.next;
            current.next.prev = previous;
            return true;
        }
        /// <summary>
        /// traverses all the nodes of the list 
        /// </summary>
        public void Traverse()
        {
            if (listEmpty())
                Console.WriteLine("\nList is empty");
            else
            {
                Console.WriteLine("\nRecords in the list are : \n");
                Node currentNode;
                currentNode = last.next;
                while (currentNode != last)
                {
                    Console.Write(currentNode.roll_Number + " " + currentNode.name + "\n");
                    currentNode = currentNode.next;
                }
                Console.Write(last.roll_Number + " " + last.name + "\n");
            }
        }
        /// <summary>
        /// method untuk menampilkan data yang tidak ada
        /// </summary>
        public void FirstNode()
        {
            if (listEmpty())
                Console.WriteLine("\nList is empty");
            else
                Console.WriteLine("\nThe first record in the list is: \n\n" + last.next.roll_Number + " " + last.next.name);
        }
        /// <summary>
        /// menu switch
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            CircularList obj = new CircularList();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. Add a record to the list ");
                    Console.WriteLine("2. Delete a record from the list");
                    Console.WriteLine("3. View all the records in the list");
                    Console.WriteLine("4. Search for a record in the list");
                    Console.WriteLine("5. Display the first record in the list");
                    Console.WriteLine("6. Exit");
                    Console.Write("\nEnter your choice (1-6): ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.addNode();
                            }
                            break;
                        case '2':
                            {
                                if (obj.listEmpty())
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                Console.Write("\nEnter the roll number of the student" + " whose record is to be deleted : ");
                                int rollNo = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (obj.delNode(rollNo) == false)
                                    Console.WriteLine("Record with roll number" + rollNo + "deleted");
                                else
                                    Console.WriteLine("record not found");
                            }
                            break;

                        case '3':
                            {
                                obj.Traverse();
                            }
                            break;
                        case '4':
                            {
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                Node prev, curr;
                                prev = curr = null;
                                Console.Write("\nEnter the roll number of the student whose record is to be searched: ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.Search(num, ref prev, ref curr) == false)
                                    Console.WriteLine("\nRecord not found");
                                else
                                {
                                    Console.WriteLine("\nRecord found");
                                    Console.WriteLine("\nRoll number: " + curr.roll_Number);
                                    Console.WriteLine("\nName: " + curr.name);
                                }
                            }
                            break;
                        case '5':
                            {
                                obj.FirstNode();
                            }
                            break;
                        case '6':
                            return;
                        default:
                            {
                                Console.WriteLine("Invalid option");
                                break;
                            }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

        }

    }




}