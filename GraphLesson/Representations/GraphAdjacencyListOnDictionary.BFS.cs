namespace GraphLesson.Representations;

public partial class GraphAdjacencyListOnDictionary
{
    public static void BFS(Dictionary<string, List<string>> adjacencyList, string vertex)
    {
        var visited = new HashSet<string>();
        var queue = new Queue<string>();
        queue.Enqueue(vertex);
        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            if (visited.Contains(current)) continue;
            visited.Add(current);
            Console.WriteLine(current);
            foreach (var neighbor in adjacencyList[current])
            {
                queue.Enqueue(neighbor);
            }
        }
    }
}