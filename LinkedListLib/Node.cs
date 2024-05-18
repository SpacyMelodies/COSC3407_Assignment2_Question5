using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * COSC3407 Assignment 2 Question 5
 *
 *  by Mitchell Plunket
 *  Student ID : 239499150
 *  
 *  Node class for the custom linked List
 */

namespace LinkedListLib
{
    public class Node
    {
       public int value;
       public Node? next;
        
        public Node(int value, Node? next)
        {
            this.value = value;
            this.next = next;
        }

        public Node(int value)
        {
            this.value = value; 
            this.next = null;
        }
    }
}
