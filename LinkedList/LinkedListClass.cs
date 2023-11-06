namespace LinkedList
{
    public class LinkedListClass
    {
        private int size;

        public int Count() {

            return size; 
        }

        public void Linked_List()
        {
            LinkedList nodes = new LinkedList();
            var node = nodes.Count();
        }
    }
        

    public class Node
    {
        public int element;
        public Node next;
        public Node(int e, Node n)
        {
            element = e;
            next = n;
        }
    }

    public class LinkedList : LinkedList<Node> 
    {

    }
}