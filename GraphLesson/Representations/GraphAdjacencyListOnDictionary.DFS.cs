namespace GraphLesson.Representations;

public partial class GraphAdjacencyListOnDictionary
{
    public static void DFS(Dictionary<string, List<string>> adjacencyList, string vertex)
    {
        var visited = new HashSet<string>();
        var stack = new Stack<string>();
        stack.Push(vertex);
        while (stack.Count > 0)
        {
            var current = stack.Pop();
            if (visited.Contains(current)) continue;
            visited.Add(current);
            Console.WriteLine(current);
            foreach (var neighbor in adjacencyList[current])
            {
                stack.Push(neighbor);
            }
        }
    }
}