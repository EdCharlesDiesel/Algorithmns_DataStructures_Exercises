﻿namespace DoublyLinkedList
{
    public class DoublyLinkedListClass
    {

        public Node Head;
        public Node Tail;
        // O(1) time | O(1) space
        public void SetHead(Node node)
        {
            if (Head == null)
            {
                Head = node;
                Tail = node;
                return;
            }
            InsertBefore(Head, node);
        }
        // O(1) time | O(1) space
        public void SetTail(Node node)
        {
            if (Tail == null)
            {
                SetHead(node);
                return;
            }
            InsertAfter(Tail, node);
        }
        // O(1) time | O(1) space
        public void InsertBefore(Node node, Node nodeToInsert)
        {
            if (nodeToInsert == Head && nodeToInsert == Tail) return;
            Remove(nodeToInsert);
            nodeToInsert.Prev = node.Prev;
            nodeToInsert.Next = node;
            if (node.Prev == null)
            {
                Head = nodeToInsert;
            }
            else
            {
              //  node.Prev.Next = nodeToInsert;
            }
            node.Prev = nodeToInsert;
        }

        private void Remove(Node nodeToInsert)
        {
            throw new NotImplementedException();
        }

        // O(1) time | O(1) space
        public void InsertAfter(Node node, Node nodeToInsert)
        {
            if (nodeToInsert == Head && nodeToInsert == Tail) return;
            Remove(nodeToInsert);
            nodeToInsert.Prev = node;
            nodeToInsert.Next = node.Next;
            if (node.Next == null)
            {
                Tail = nodeToInsert;
            }
            else
            {
                node.Next.Prev = nodeToInsert;
            }
            node.Next = nodeToInsert;
        }
        // O(p) time | O(1) space
        public void InsertAtPosition(int position, Node nodeToInsert)
        {
            if (position == 1)
            {
                SetHead(nodeToInsert);
                return;
            }
        }
    }
}