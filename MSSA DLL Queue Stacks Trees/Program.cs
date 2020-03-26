using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSA_DLL_Queue_Stacks_Trees
{
    class Program
    {

        static int Factorial(int n)
        {
            int ret = 1;
            for (int i = n; i >= 1; i--)
                ret = ret * i;
            return ret;
        }

        static int FactorialRec(int n)
        {
            if (n > 1)         //recursion
                return n * FactorialRec(n - 1);
            else              //base case
                return 1;
        }
        //Console.WriteLine("A->C");  N = 3, A,   C,    B
        //Console.WriteLine("A->B");
        //Console.WriteLine("C->B");
        //Console.WriteLine("A->C");
        //Console.WriteLine("B->A");
        //Console.WriteLine("B->C");
        //Console.WriteLine("A->C");

        static void Hanoi(int n, string from, string to, string middle)
        {
            if(n>=1)
            {
                Hanoi(n - 1, from, middle, to);
                Console.WriteLine("move tile: {0},  {1} => {2}", n, from, to);//only this does the actual move
                Hanoi(n - 1, middle, to, from);
            }
        }

        static void Main(string[] args)
        {
            Hanoi(10, "A", "C", "B");

            Console.WriteLine();
            Console.WriteLine("5! = {0}", FactorialRec(5));

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            ///////////////////////
            LinkedList2<int> myList = new LinkedList2<int>();
            myList.AddFirst(1);
            myList.AddFirst(2);
            myList.AddFirst(3);

            Console.WriteLine(myList);
            //Stack<int> mystack3 = new Stack<int>();  ///doesn't work properly yet!!!!
            //while (mystack3.Peek() != null)
            //{
            //    Console.WriteLine(mystack3.Pop());
            //}

            Stack<string> mystack = new Stack<string>();
            mystack.Push("Saint");
            mystack.Push("Martin");
            mystack.Push("2020");
            mystack.Pop();
            //Console.WriteLine(mystack.Pop());
            //Console.WriteLine(mystack.Pop());
            //Console.WriteLine(mystack.Pop());

            Console.WriteLine(mystack);


            //application for queues: reverse the contents of a file
            StreamReader inFile = new StreamReader("input.txt");
            Stack<string> myStack2 = new Stack<string>();

            //read every line from the file
            string line = inFile.ReadLine();
            while(line!=null)
            {
                myStack2.Push(line);
                line = inFile.ReadLine();
            }
            Console.WriteLine(myStack2);
            inFile.Close();

            StreamWriter outFile = new StreamWriter("ouput.txt");
            while(myStack2.Peek()!=null)
            {
                outFile.WriteLine(myStack2.Pop());
            }
            outFile.Close();



            Queue myQueue = new Queue();
            myQueue.Enqueue(10);
            myQueue.Enqueue(20);
            myQueue.Enqueue(30);
            myQueue.Enqueue(40);
            Console.WriteLine(myQueue.Dequeue());
            Console.WriteLine(myQueue.Dequeue());
            Console.WriteLine(myQueue.Dequeue());
            Console.WriteLine(myQueue.Dequeue());


            Stack<int> myStack4 = new Stack<int>();
            myStack4.Push(10);
            myStack4.Push(20);
            myStack4.Push(30);
            myStack4.Push(40);
            Console.WriteLine(myStack4.Pop());
            Console.WriteLine(myStack4.Pop());
            Console.WriteLine(myStack4.Pop());
            Console.WriteLine(myStack4.Pop());

            BinarySearchTree myTree = new BinarySearchTree();
            myTree.Insert(10);
            myTree.Insert(5);
            myTree.Insert(3);
            myTree.Insert(15);
            myTree.Insert(12);
            myTree.Insert(20);
            myTree.Insert(30);
            myTree.Insert(13);

            Console.WriteLine(myTree.GetMaxValue()) ;

            myTree.PrintPreOrder();
            myTree.PrintInOrder();
            myTree.DisplayHeight();
            myTree.DisplayNumLeaves();
        }

      

    }

    class LinkedList2<T> : LinkedList<T> //inheritance
    {
        public override string ToString()
        {
            string ret = "";
            foreach (var value in this)
            {
                ret += value + " ";
            }
            //ret = string.Join(",", this);
            return ret;
        }
    }

    class Stack<T> 
    {
        //data
        LinkedList<T> allValues;

        //methods
        public void Push(T newValue)
        {
            allValues.AddFirst(newValue);
        }
        public T Pop()
        {
            if(allValues.Count>0)
            {
                T first = Peek();
                allValues.RemoveFirst();
                return first;
            }
            else
            {
                throw new Exception("the stack is empty ... you can't pop elements from it");
            }
        }
        public T Peek()
        {
            if (allValues.Count > 0)
                return allValues.First();
            else
            {
                Object result = null;
                return default(T);

            }
        }

        //ctor
        public Stack()
        {
            allValues = new LinkedList<T>();
        }

        public override string ToString()
        {
            string ret="";
            foreach(var val in allValues)
            {
                ret = ret+ val +"\n";
            }
            return ret;
        }
    }

    class Queue
    {
        //data
        LinkedList<int> allValues;

        //methods
        public void Enqueue(int value)
        {
            allValues.AddFirst(value);
        }

        public int Dequeue()
        {
            int lastValue = Peek();
            allValues.RemoveLast();
            return lastValue;
        }


        public int Peek()
        {
            return allValues.Last();
        }

        //ctor
        public Queue()
        {
            allValues = new LinkedList<int>();
        }
    }

    class Node
    {
        public int Value;
        public Node left, right;

        public Node(int newVal)
        {
            Value = newVal;
        }
    }

    class BinarySearchTree
    {
        //data
        Node root;

        //methods
        //isEmpty
        public bool IsEmpty()
        {
            return root == null;
        }

        //Insert
        public void Insert(int newValue)
        {
            //create node
            Node newNode = new Node(newValue);

            //if the tree is empty
            if (IsEmpty())
                root = newNode;
            else
            {
                Node finger = root;
                while(true)
                {
                    if(newValue<=finger.Value)
                    {
                        if(finger.left!=null)
                            finger = finger.left;
                        else
                        {
                            finger.left = newNode;
                            break;
                        }
                    }
                    else
                    {
                        if (finger.right != null)
                            finger = finger.right;
                        else
                        {
                            finger.right = newNode;
                            break;
                        }
                    }
                }
            }
        }

        //Delete
        //Traversals
        

        //GetMaxValue
        public int GetMaxValue()
        {
            if (IsEmpty())
                throw new Exception("no max can be found in an empty tree!");

            Node finger = root;
            while (finger.right != null)
                finger = finger.right;
            return finger.Value;
        }

        //GetMinValue

        //Traverse a tree
        public void PrintPreOrder()
        {
            Console.Write("\nPrintPreOrder: The values in the tree are: ");
            PrintPreOrderHelper(root);
        }

        public void PrintPreOrderHelper(Node n)
        {
           if(n!=null)
            {
                Console.Write(n.Value + " ");   //N
                PrintPreOrderHelper(n.left);    //L
                PrintPreOrderHelper(n.right);   //R
            }
        }




        //Traverse a tree
        public void PrintInOrder()
        {
            Console.Write("\nPrintInOrder: The values in the tree are: ");
            PrintInOrderHelper(root);
        }

        public void PrintInOrderHelper(Node n)
        {
            if (n != null)
            {
                PrintInOrderHelper(n.left);     //L
                Console.Write(n.Value + " ");   //N
                PrintInOrderHelper(n.right);    //R
            }
        }


        //Traverse a tree
        public void DisplayNumLeaves()
        {
            Console.WriteLine("\nNumber of leaf nodes: {0}",  CountNumLeavesHelper(root));
        }

        public int CountNumLeavesHelper(Node n)
        {
            if (n == null)
                return 0;
            else if (n.left == null && n.right == null)
                return 1;
            else
            {
                return CountNumLeavesHelper(n.left) + CountNumLeavesHelper(n.right);
            }


        }


        //Traverse a tree
        public void DisplayHeight()
        {
            Console.WriteLine("\nHeight: {0}", DisplayHeightHelper(root));
        }

        public int DisplayHeightHelper(Node n)
        {
            if (n == null)
                return -1;
            else
                return 1 + Math.Max(DisplayHeightHelper(n.left), DisplayHeightHelper(n.right));

        }
        //ctor
        public BinarySearchTree()
        {
            root = null;
        }
    }

}
