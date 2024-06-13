/*
You are developing a program to manage a call queue of customers using the Queue in C#. 
The program creates a queue of callers and demonstrates the functionality of enqueueing elements into the queue and iterating over the elements and dequeuing.
Use linked lists.
*/

using static Assignment_6._3._1.Program;

namespace Assignment_6._3._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            QueueLinkedList queueLinkedList = new QueueLinkedList(); // create an instance of QueueLinkedList /instantiate the class

            Customer customer1 = new Customer {Id = "1234", Name = "John" }; // create customer object then pass them into the queue through the IncomingCall() method
            queueLinkedList.IncomingCall(customer1);

            Customer customer2 = new Customer { Id = "5678", Name = "Alice" };
            queueLinkedList.IncomingCall(customer2);

            Customer customer3 = new Customer { Id = "1468", Name = "Mike" };
            queueLinkedList.IncomingCall(customer3);

            Console.WriteLine("Customers in the call queue: "); // print the current state of the queue using the CallLogs() method
            queueLinkedList.CallLogs();

            Console.WriteLine("Removing call queue: ");

            // Do it individually
            if (!queueLinkedList.IsEmpty()) // Checks if queue is empty, if not then dequeues first customer using the EndCall() method
            {
                Customer dequeueCustomer1 = queueLinkedList.EndCall();
                Console.WriteLine($"Removed Call: {dequeueCustomer1.Name} (ID: {dequeueCustomer1.Id}) at {DateTime.Now}");
            }

            Console.WriteLine("Do you want to dequeue the rest of the customers (yes / no): "); // Added to show delay in dequeue process with DateTiime.Now struct
            string input = Console.ReadLine();

            //Do it all at once
           if ( input == "yes" ) 
            {
                while (!queueLinkedList.IsEmpty()) // Checks if queue is empty, if not then as long as the linked list has customers in the queue it will dequeue them.
                {
                    Customer customer = queueLinkedList.EndCall();
                    Console.WriteLine($"Removed Call: {customer.Name} (ID: {customer.Id}) at {DateTime.Now}");
                }

            }
           else
            {
                Console.WriteLine("Have a great day!"); // if user chooses no to dequeue the rest of the customers the program is complete.
            }

           

        }

        public class Customer // Defines the properties of the customer class
        {
            public string Id { get; set; }
            public string Name { get; set; }
            
        }

        public class QueueNode // Establish a node for the queue containing customer data and reference to next node.
        {
            public Customer Data { get; set; }
            public QueueNode Next { get; set; }

            public QueueNode(Customer data)
            {
                Data = data;
                Next = null;
            }
        }

        public class QueueLinkedList
        {
            
            private QueueNode front; //field which is the front node of the queue
            private QueueNode rear; //field which is the rear node of the queue

            public bool IsEmpty() // checks to see if the queue is empty when the method is called
            { 
                return front == null; 
            }


            public QueueLinkedList() // Here is the initialization an empty queue with the constructor QueueLinkedList()
            {
                front = null;
                rear = null;
                
            }
            public void IncomingCall(Customer newData) // adds new customer to the rear of the queue
            {
                QueueNode queueNode = new QueueNode(newData); // queuenode is created with the Customer data as the object and QueueNode(newData) initializes the Data property with Customer object and sets Next to null

                if (rear == null) //if queue is empty both front and rear are set to new node. 
                {
                    front = queueNode;
                    rear = queueNode;
                }
                else // if not empty the new node is set to rear.Next pointing to the new node and the new node is added to rear
                {
                    rear.Next = queueNode;
                    rear = queueNode;
                }

            }

            public Customer EndCall() // removes and returns the customer at the front of the queue
            {
                if (IsEmpty())
                {
                    throw new InvalidOperationException("Queue is empty"); //if the queue is empty there is no customer to dequeue and returns empty statement.
                }

                Customer dequeueCustomer = front.Data; // the customer data at the front is stored in a variable
                front = front.Next; // front data is updated to point to the next node in the queue

                if (front == null) // if the front becomes null then the rear becomes null meaning the queue is empty
                {
                    rear = null;
                }
                return dequeueCustomer; 
            }

            public void CallLogs()
            {
                QueueNode current = front;
                while (current != null)
                {
                    Console.WriteLine($"Caller: {current.Data.Name} (ID: {current.Data.Id})");
                    current = current.Next;
                }

            }


        }

               
    }
}
