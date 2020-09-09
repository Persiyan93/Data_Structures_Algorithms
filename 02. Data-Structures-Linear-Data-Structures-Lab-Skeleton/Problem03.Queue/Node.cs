namespace Problem03.Queue
{
    public class Node<T>
    {
        public Node(T item)
        {
            this.Data = item;
        }
        public Node<T> NextNode { get; set; }
        public T Data { get; set; }

    }
}