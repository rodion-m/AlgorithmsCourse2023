namespace GraphLesson.Representations;

public partial class GraphAdjacencyListOnDictionary
{
    public static void BFS(Dictionary<string, List<string>> adjacencyList, string vertex)
    {
        var visited = new HashSet<string>();
        var queue = new Queue<string>();
        queue.Enqueue(vertex);
        int i = 1;
        while (queue.Count > 0)
        {
            Console.WriteLine();
            Console.WriteLine($"Step {i++}");
            var current = queue.Dequeue();
            Console.WriteLine($"Current: {current}. " + (visited.Contains(current) ? "VISITED" : ""));
            Console.WriteLine($"Queue: {string.Join(", ", queue)}");
            Console.WriteLine($"Visited: {string.Join(", ", visited)}");
            
            
            if (visited.Contains(current)) continue;
            visited.Add(current);
            Console.WriteLine($"Enqueue {current}'s neighbors: {string.Join(", ", adjacencyList[current])}");
            foreach (var neighbor in adjacencyList[current])
            {
                queue.Enqueue(neighbor);
            }
        }
    }

    public void BFS(string adjacencyList) => BFS(_adjacencyList, adjacencyList);
}