namespace Problem02.Stack
{
    public class Node<T>
    {
        public Node(T element)
        {
            this.Data = element;
        }
        public T Data { get; set; }
        public Node<T> NextNode { get; set; }
        
    }
}