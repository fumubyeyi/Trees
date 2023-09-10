namespace Tree.lib;
public class Node<T>
{
    public T data;
    public Node<T> left;
    public Node<T> right;

    public Node<T>(T data){
        this.data = data;
        left = null;
        right = null;
    }
}
