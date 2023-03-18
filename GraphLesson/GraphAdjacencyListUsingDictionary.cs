﻿namespace GraphLesson;

public class GraphAdjacencyListUsingDictionary
{
    private readonly Dictionary<string, List<string>> _adjacencyList;

    public static GraphAdjacencyListUsingDictionary CreateFriends()
    {
        Dictionary<string, List<string>> adjacencyList = new Dictionary<string, List<string>> {
            { "Bill", new List<string> { "Steve", "Elon", "Jeff" } },
            { "Steve", new List<string> { "Bill", "Elon", "Larry" } },
            { "Elon", new List<string> { "Bill", "Steve", "Larry", "Jeff" } },
            { "Larry", new List<string> { "Steve", "Elon", "Sergey", "Sheryl" } },
            { "Sergey", new List<string> { "Larry", "Sheryl" } },
            { "Sheryl", new List<string> { "Larry", "Sergey", "Mark" } },
            { "Jeff", new List<string> { "Bill", "Elon", "Mark" } },
            { "Mark", new List<string> { "Sheryl", "Jeff" } }
        };

        return new GraphAdjacencyListUsingDictionary(adjacencyList);
    }
    
    public GraphAdjacencyListUsingDictionary()
    {
        _adjacencyList = new Dictionary<string, List<string>>();
    }
    
    public GraphAdjacencyListUsingDictionary(Dictionary<string, List<string>> adjacencyList)
    {
        _adjacencyList = adjacencyList;
    }

    public void AddVertex(string vertex)
    {
        _adjacencyList[vertex] = new List<string>();
    }
    
    public void AddEdge(string vertex1, string vertex2)
    {
        _adjacencyList[vertex1].Add(vertex2);
        _adjacencyList[vertex2].Add(vertex1);
    }
    
    public void RemoveEdge(string vertex1, string vertex2)
    {
        _adjacencyList[vertex1].Remove(vertex2);
        _adjacencyList[vertex2].Remove(vertex1);
    }
    
    public void RemoveVertex(string vertex)
    {
        while (_adjacencyList[vertex].Count != 0)
        {
            var adjacentVertex = _adjacencyList[vertex][0];
            RemoveEdge(vertex, adjacentVertex);
        }
        _adjacencyList.Remove(vertex);
    }
    
    public void DFS(string vertex)
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
            foreach (var neighbor in _adjacencyList[current])
            {
                stack.Push(neighbor);
            }
        }
    }
    
    public void BFS(string vertex)
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
            foreach (var neighbor in _adjacencyList[current])
            {
                queue.Enqueue(neighbor);
            }
        }
    }
    
    public bool DFSRecursive(string vertex, string target)
    {
        var visited = new HashSet<string>();
        return DFSRecursive(vertex, target, visited);
    }
    
    private bool DFSRecursive(string vertex, string target, HashSet<string> visited)
    {
        if (visited.Contains(vertex)) return false;
        visited.Add(vertex);
        if (vertex == target) return true;
        foreach (var neighbor in _adjacencyList[vertex])
        {
            if (DFSRecursive(neighbor, target, visited)) return true;
        }
        return false;
    }
}