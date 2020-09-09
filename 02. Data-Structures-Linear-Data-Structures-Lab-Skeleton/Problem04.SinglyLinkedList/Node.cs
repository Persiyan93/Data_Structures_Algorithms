namespace Problem04.SinglyLinkedList
{
    public class Node<T>
    {
        public Node(T item)
        {
            this.Data = item;
        }
        public Node<T> NextNode { get; set; }
        public T Data { get; set; }
        public Node<T> Previous { get; set; }
    }
}