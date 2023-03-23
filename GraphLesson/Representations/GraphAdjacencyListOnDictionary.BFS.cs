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
            
            foreach (var neighbor in adjacencyList[current]) // O(E)
            {
                queue.Enqueue(neighbor);
            }
        }
    }
    
    public static void BFSShort(Dictionary<string, List<string>> adjList, string vertex)
    {
        var visited = new HashSet<string>();
        var queue = new Queue<string>();
        queue.Enqueue(vertex); visited.Add(vertex);
        int i = 1;
        while (queue.TryDequeue(out var current))
        {
            Console.WriteLine();
            Console.WriteLine($"Step {i++}");
            Console.WriteLine($"Current: {current}. ");
            Console.WriteLine($"Queue: {string.Join(", ", queue)}");

            var notVisitedNeightbours = adjList[current].Where(visited.Add).ToList();
            if(!notVisitedNeightbours.Any()) continue;
            Console.WriteLine($"Enqueue {current}'s neighbors: {string.Join(", ", notVisitedNeightbours)}");
            notVisitedNeightbours.ForEach(queue.Enqueue);
        }
    }

    public void BFS(string vertex) => BFSShort(_adjacencyList, vertex);
}