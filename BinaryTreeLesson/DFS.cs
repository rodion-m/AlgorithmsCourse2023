namespace BinaryTreeLesson;

public class DFS
{
    public void DFSUsingStack(Person? root)
    {
        if (root == null) return;

        Stack<Person> stack = new Stack<Person>();
        stack.Push(root); //Алексей

        while (stack.Count > 0)
        {
            Person current = stack.Pop(); //1: Алексей, 2: Иван
            Console.WriteLine(current.Name);

            if (current.RightChild != null)
            {
                stack.Push(current.RightChild);
            }
            if (current.LeftChild != null)
            {
                stack.Push(current.LeftChild);
            }
        }
    }
    
    public void DFSTraversal(Person root)
    {
        if (root == null) return;

        Console.WriteLine(root.Name);
        DFSTraversal(root.LeftChild);
        DFSTraversal(root.RightChild);
    }
}