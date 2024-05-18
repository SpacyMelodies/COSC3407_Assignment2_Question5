﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Random;
/*
 * COSC3407 Assignment 2 Question 5
 *
 *  by Mitchell Plunket
 *  Student ID : 239499150
 *  
 *  custom linked list data structure class for our threads in Program.cs to operate on
 */
namespace LinkedListLib
{
    public class LinkedList
    {
        const int capacity = 150;
        int size;
        public Node? head = null;
        public LinkedList()
        {

        }

        public bool Add(int item)
        {

            if (head == null)
            {
                head = new Node(item);
            }
            else
            {
                if (Size() == capacity)
                {
                    return false;
                }
                else
                {
                    Node currNode = head;
                    Node addNode = new Node(item);
                    for (int j = 0; j < Size(); j++)
                    {
                        if (currNode.next == null)
                        {
                            addNode.next = currNode.next;
                            currNode.next = addNode;
                            return true;
                        }
                        else
                        {
                            currNode = currNode.next;
                        }
                    }
                }
            }
            return true;
        }
        public bool IsFull()
        {
            return Size() == capacity;
        }

        public bool IsEmpty()
        {
            return head == null;
        }
        public int Size()
        {
            int counter = 0; //initializes a counter to 0

            if (head == null) //if the head is null, returns the initial 0 of the counter
            {
                return counter;
            }
            else
            {
                Node curr = head; //sets the curr points to the head and the counter to 1
                counter = 1;

                while (curr.next != null) // while the next value in the list is not null, its adds one to the counter, then increases the curr pointer 1 spot.
                {
                    counter += 1;
                    curr = curr.next;
                }
            }
            return counter;
        }
        public int Remove()
        {
            int saveVal;
            if (IsEmpty())
            {
                return -1;
            }
            else
            {
                Node? currNode = head;
                for (int i = 0; i < Size(); i++) //iterates through the list with the currNode. 
                {
                    if (head.next == null)
                    {
                        saveVal = currNode.value;
                        head = null;
                        return saveVal;
                    }
                    else if (currNode.next.next == null)
                    {
                        saveVal = currNode.next.value;
                        currNode.next = null;
                        return saveVal;
                    }
                    else
                    {
                        currNode = currNode?.next;
                    }
                }
            }
            return -1;
        }

        public void PrintLinkedList()
        {
            Node currNode = head;
            for (int i = 0; i < Size();i++)
            {   
                Console.Write(currNode.value + ",");
                if (currNode.next != null)
                {
                    currNode = currNode.next;
                }
                else
                {
                    break;
                }
            }
        }
    }
}

