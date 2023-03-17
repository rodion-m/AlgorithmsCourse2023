// Создаем членов семьи
var aleksey = new Person("Алексей");
var olga = new Person("Ольга");
var ivan = new Person("Иван");
var elena = new Person("Елена");
var dmitriy = new Person("Дмитрий");
var anna = new Person("Анна");

// Связываем членов семьи в бинарное дерево
aleksey.LeftChild = ivan;
aleksey.RightChild = olga;
ivan.LeftChild = dmitriy;
ivan.RightChild = elena;
dmitriy.RightChild = anna;

// Создаем дерево родословной и устанавливаем корень
var familyTree = new FamilyTree(aleksey);

Console.WriteLine(familyTree.GetDepthOfTree());

familyTree.BFSUsingQueue(familyTree.Root);

// Выводим структуру дерева на экран
//familyTree.PrintTree(familyTree.Root);

record Person
{
    public string Name { get; set; }
    public Person? LeftChild { get; set; }
    public Person? RightChild { get; set; }

    public Person(string name)
    {
        Name = name;
    }
}

class FamilyTree
{
    public Person Root { get; set; }

    public FamilyTree(Person root)
    {
        Root = root;
    }

    // Метод для печати дерева (для проверки структуры)
    public void PrintTree(Person node, string indent = "")
    {
        if (node == null) return;

        Console.WriteLine($"{indent}{node.Name}");
        PrintTree(node.LeftChild, indent + "  ");
        PrintTree(node.RightChild, indent + "  ");
    }

    public int GetDepthOfTree()
    {
        if (Root is null) return 0;
        var stack = new Stack<(Person node, int depth)>();
        stack.Push((node: Root, depth: 1)); //Алексей

        int maxDepth = 1;
        while (stack.Count > 0)
        {
            var (current, depth) = stack.Pop();
            maxDepth = int.Max(depth, maxDepth);

            if (current.RightChild != null)
            {
                stack.Push((current.RightChild, depth + 1));
            }
            if (current.LeftChild != null)
            {
                stack.Push((current.LeftChild, depth + 1));
            }
        }

        return maxDepth;
    }
    
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
}
