using System;

// Node class
class Node
{
    public int id;
    public string name;
    public Node next;

    public Node(int id, string name)
    {
        this.id = id;
        this.name = name;
        this.next = null;
    }
}

// Linked List class
class EmployeeList
{
    Node head;

    // Insert at end
    public void InsertEnd(int id, string name)
    {
        Node newNode = new Node(id, name);

        if (head == null)
        {
            head = newNode;
            return;
        }

        Node temp = head;
        while (temp.next != null)
        {
            temp = temp.next;
        }

        temp.next = newNode;
    }

    // Delete by ID
    public void Delete(int id)
    {
        if (head == null) return;

        // If head needs to be deleted
        if (head.id == id)
        {
            head = head.next;
            return;
        }

        Node temp = head;
        while (temp.next != null && temp.next.id != id)
        {
            temp = temp.next;
        }

        if (temp.next != null)
        {
            temp.next = temp.next.next;
        }
        else
        {
            Console.WriteLine("Employee not found!");
        }
    }

    // Display list
    public void Display()
    {
        Node temp = head;

        while (temp != null)
        {
            Console.WriteLine(temp.id + " - " + temp.name);
            temp = temp.next;
        }
    }
}

class Program
{
    static void Main()
    {
        EmployeeList list = new EmployeeList();

        // Insert sample data
        list.InsertEnd(101, "John");
        list.InsertEnd(102, "Sara");
        list.InsertEnd(103, "Mike");

        // Delete employee with ID 102
        list.Delete(102);

        Console.WriteLine("Employee List After Deletion:");
        list.Display();
    }
}