namespace BinaryTreeLesson;

public class BFS
{
    /// <summary>
    /// Итеративный подход
    /// </summary>
    public void BFSUsingQueue(Person root)
    {
        if (root == null) return;

        Queue<Person> queue = new Queue<Person>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            Person current = queue.Dequeue();
            Console.WriteLine(current.Name);

            if (current.LeftChild != null)
            {
                queue.Enqueue(current.LeftChild);
            }
            if (current.RightChild != null)
            {
                queue.Enqueue(current.RightChild);
            }
        }
    }
    
    /// <summary>
    /// Рекурсивный подход
    /// </summary>
    public void BFSTraversal(Person root)
    {
        if (root == null) return;

        int height = GetHeight(root);

        for (int level = 1; level <= height; level++)
        {
            BFSTraversalRecursive(root, level);
        }
        
        int GetHeight(Person node)
        {
            if (node == null) return 0;

            int leftHeight = GetHeight(node.LeftChild);
            int rightHeight = GetHeight(node.RightChild);

            return Math.Max(leftHeight, rightHeight) + 1;
        }

        void BFSTraversalRecursive(Person node, int level)
        {
            if (node == null) return;

            if (level == 1)
            {
                Console.WriteLine(node.Name);
            }
            else if (level > 1)
            {
                BFSTraversalRecursive(node.LeftChild, level - 1);
                BFSTraversalRecursive(node.RightChild, level - 1);
            }
        }
    }

}