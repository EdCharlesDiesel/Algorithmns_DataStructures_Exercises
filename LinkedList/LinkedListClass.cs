namespace LinkedList
{
    public class LinkedListClass
    {
        private class Node
        {
            public int element;
            public Node next;
            public Node(int e, Node n)
            {
                element = e;
                next = n;
            }
        }
        private Node? first;
        private Node? last;
        private int size;

        public LinkedListClass()
        {
            first = null;
            last = null;
            size = 0;
        }

        public int Count()
        {
            return size;
        }

        public bool isEmpty()
        {
            return size == 0;
        }

        public void AddLast(int e)
        {
            Node newest = new Node(e, null);
            if (isEmpty())
                first = newest;
            else
                last.next = newest;
            last = newest;
            size = size + 1;
        }

        public void AddFirst(int e)
        {
            Node newest = new Node(e, null);
            if (isEmpty())
            {
                first = newest;
                last = newest;
            }
            else
            {
                newest.next = first;
                first = newest;
            }
            size = size + 1;
        }

        public void AddAny(int e, int position)
        {
            if (position <= 0 || position >= size)
            {
                Console.WriteLine("Invalid Position");
                return;
            }
            Node newest = new Node(e, null);
            Node p = first;
            int i = 1;
            while (i < position - 1)
            {
                p = p.next;
                i = i + 1;
            }
            newest.next = p.next;
            p.next = newest;
            size = size + 1;
        }

        public int RemoveFirst()
        {
            if (isEmpty())
            {
                Console.WriteLine("List is Empty");
                return -1;
            }
            else
            {
                int e = first.element;
                first = first.next;
                size = size - 1;
                if (isEmpty())
                    last = null;
                return e;
            }
        }

        public int RemoveLast()
        {
            if (isEmpty())
            {
                Console.WriteLine("List is Empty");
                return -1;
            }
            Node p = first;
            int i = 1;
            while (i < size - 1)
            {
                p = p.next;
                i = i + 1;
            }
            last = p;
            p = p.next;
            int e = p.element;
            last.next = null;
            size = size - 1;
            return e;
        }

        public int RemoveAny(int position)
        {
            if (position <= 0 || position >= size - 1)
            {
                Console.WriteLine("Invalid Position");
                return -1;
            }
            Node p = first;
            int i = 1;
            while (i < position - 1)
            {
                p = p.next;
                i = i + 1;
            }
            int e = p.next.element;
            p.next = p.next.next;
            size = size - 1;
            return e;
        }

        public int Search(int key)
        {
            Node p = first;
            int index = 0;
            while (p != null)
            {
                if (p.element == key)
                    return index;
                p = p.next;
                index = index + 1;
            }
            return -1;
        }
    }
}