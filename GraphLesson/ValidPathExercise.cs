namespace GraphLesson;

public class ValidPathExercise
{
    public bool ValidPath(int n, int[][] edges, int source, int destination)
    {
        var graph = CreateGraphAdjacencyList(n, edges);

        var visited = new HashSet<int>();
        var queue = new Queue<int>();
        queue.Enqueue(source);
        visited.Add(source);

        while (queue.Count > 0)
        {
            var currentVertex = queue.Dequeue();
            if (currentVertex == destination)
            {
                return true;
            }

            foreach (var neighbor in graph[currentVertex])
            {
                if (!visited.Contains(neighbor))
                {
                    queue.Enqueue(neighbor);
                    visited.Add(neighbor);
                }
            }
        }

        return false;
    }

    // [[0,1],[1,2],[2,0]]
    private static Dictionary<int, List<int>> CreateGraphAdjacencyList(int n, int[][] edges)
    {
        var adjList = new Dictionary<int, List<int>>();
        for (int i = 0; i < n; i++) adjList.Add(i, new List<int>());

        foreach (var edge in edges)
        {
            var edge1 = edge[0];
            var edge2 = edge[1];
            adjList[edge1].Add(edge2);
            adjList[edge2].Add(edge1);
        }

        return adjList;
    }
}