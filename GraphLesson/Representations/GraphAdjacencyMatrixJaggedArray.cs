namespace GraphLesson.Representations;

public class GraphAdjacencyMatrixJaggedArray
{
    private readonly string[] _personNames;
    private readonly int[][] _matrix;
    private readonly int _size;

    public static GraphAdjacencyMatrixJaggedArray CreateFriends()
    {
        string[] personNames = {
            "Bill",   //0
            "Steve",  //1
            "Elon",   //2
            "Larry",  //3
            "Sergey", //4
            "Sheryl", //5
            "Jeff",   //6
            "Mark"    //7
        };
        int[][] adjacencyMatrix = {
            // Bill, Steve, Elon, Larry, Sergey, Sheryl, Jeff, Mark
            new[] { 0, 1, 1, 0, 0, 0, 1, 0 }, // Bill Gates
            new[] { 1, 0, 1, 1, 0, 0, 0, 0 }, // Steve Jobs
            new[] { 1, 1, 0, 1, 0, 0, 1, 0 }, // Elon Musk
            new[] { 0, 1, 1, 0, 1, 1, 0, 0 }, // Larry Page
            new[] { 0, 0, 0, 1, 0, 1, 0, 0 }, // Sergey Brin
            new[] { 0, 0, 0, 1, 1, 0, 0, 1 }, // Sheryl Sandberg
            new[] { 1, 0, 1, 0, 0, 0, 0, 1 }, // Jeff Bezos
            new[] { 0, 0, 0, 0, 0, 1, 1, 0 }  // Mark Zuckerberg
        };
        var graph = new GraphAdjacencyMatrixJaggedArray(adjacencyMatrix, personNames);
        return graph;
    }
    
    public GraphAdjacencyMatrixJaggedArray(int[][] matrix, string[] personNames)
    {
        _size = matrix.Length;
        _matrix = matrix;
        _personNames = personNames;
    }

    public GraphAdjacencyMatrixJaggedArray(int size, string[] personNames)
    {
        _size = size;
        _personNames = personNames;
        _matrix = new int[size][];
        for (int i = 0; i < size; i++)
        {
            _matrix[i] = new int[size];
        }
    }
    
    public static GraphAdjacencyListOnDictionary MatrixToList(int[][] adjacencyMatrix, List<string> nodeNames)
    {
        Dictionary<string, List<string>> adjacencyList = new Dictionary<string, List<string>>();

        for (int i = 0; i < adjacencyMatrix.Length; i++)
        {
            string currentNode = nodeNames[i];
            List<string> connectedNodes = new List<string>();

            for (int j = 0; j < adjacencyMatrix[i].Length; j++)
            {
                var hasEdge = adjacencyMatrix[i][j] == 1;
                if (hasEdge) connectedNodes.Add(nodeNames[j]);
            }

            adjacencyList[currentNode] = connectedNodes;
        }

        return new GraphAdjacencyListOnDictionary(adjacencyList);
    }

    public void Print()
    {
        for (int i = 0; i < _matrix.Length; i++)
        {
            for (int j = 0; j < _matrix[i].Length; j++)
            {
                Console.Write(_matrix[i][j] + "\t");
            }
            Console.WriteLine();
        }
    }

    public void BFSUsingQueue(int startVertex)
    {
        var visited = new bool[_size];
        var queue = new Queue<int>();
        queue.Enqueue(startVertex);
        while (queue.Count != 0)
        {
            var vertex = queue.Dequeue();
            if (!visited[vertex])
            {
                visited[vertex] = true;
                Console.WriteLine(_personNames[vertex]);
                for (int i = 0; i < _size; i++)
                {
                    if (HasEdge(vertex, i) && !visited[i])
                    {
                        queue.Enqueue(i);
                    }
                }
            }
        }
    }

    public void DFSUsingStack(int startVertex)
    {
        var visited = new bool[_size];
        var stack = new Stack<int>();
        stack.Push(startVertex);
        while (stack.Count != 0)
        {
            var vertex = stack.Pop();
            if (!visited[vertex])
            {
                visited[vertex] = true;
                Console.WriteLine(_personNames[vertex]);
                for (int i = 0; i < _size; i++)
                {
                    if (HasEdge(vertex, i) && !visited[i])
                    {
                        stack.Push(i);
                    }
                }
            }
        }
    }
    
        
    /// <summary>
    /// Проверка, являются ли вершины смежными (имею общее ребро)
    /// </summary>
    public bool HasEdge(int from, int to) => _matrix[from][to] == 1;

    public void AddEdge(int from, int to)
    {
        _matrix[from][to] = 1;
        _matrix[to][from] = 1;
    }

    public void RemoveEdge(int from, int to)
    {
        _matrix[from][to] = 0;
        _matrix[to][from] = 0;
    }

    public int GetRank(int vertex)
    {
        var rank = 0;
        for (int i = 0; i < _size; i++)
        {
            if (HasEdge(vertex, i))
            {
                rank++;
            }
        }
        return rank;
    }
    
    public int GetSize()
    {
        return _size;
    }
    
    public int GetEdgeCount()
    {
        var edgeCount = 0;
        for (int i = 0; i < _size; i++)
        {
            for (int j = 0; j < _size; j++)
            {
                if (HasEdge(i, j))
                {
                    edgeCount++;
                }
            }
        }
        return edgeCount / 2;
    }
    
    public int GetDegree(int vertex)
    {
        var degree = 0;
        for (int i = 0; i < _size; i++)
        {
            if (HasEdge(vertex, i))
            {
                degree++;
            }
        }
        return degree;
    }
    
    public int GetMaxDegree()
    {
        var maxDegree = 0;
        for (int i = 0; i < _size; i++)
        {
            var degree = GetDegree(i);
            if (degree > maxDegree)
            {
                maxDegree = degree;
            }
        }
        return maxDegree;
    }
    
    public int GetMinDegree()
    {
        var minDegree = int.MaxValue;
        for (int i = 0; i < _size; i++)
        {
            var degree = GetDegree(i);
            if (degree < minDegree)
            {
                minDegree = degree;
            }
        }
        return minDegree;
    }
    
    public double GetAverageDegree()
    {
        var edgeCount = GetEdgeCount();
        return (double) edgeCount / _size;
    }
    
    public int GetMaxRank()
    {
        var maxRank = 0;
        for (int i = 0; i < _size; i++)
        {
            var rank = GetRank(i);
            if (rank > maxRank)
            {
                maxRank = rank;
            }
        }
        return maxRank;
    }
    
    public int GetMinRank()
    {
        var minRank = int.MaxValue;
        for (int i = 0; i < _size; i++)
        {
            var rank = GetRank(i);
            if (rank < minRank)
            {
                minRank = rank;
            }
        }
        return minRank;
    }
    
    public double GetAverageRank()
    {
        var rankSum = 0;
        for (int i = 0; i < _size; i++)
        {
            var rank = GetRank(i);
            rankSum += rank;
        }
        return (double) rankSum / _size;
    }
    
    public int GetSelfLoopCount()
    {
        var selfLoopCount = 0;
        for (int i = 0; i < _size; i++)
        {
            if (HasEdge(i, i))
            {
                selfLoopCount++;
            }
        }
        return selfLoopCount;
    }
    
    public bool IsComplete()
    {
        var edgeCount = GetEdgeCount();
        var maxEdgeCount = _size * (_size - 1) / 2;
        return edgeCount == maxEdgeCount;
    }
    
    public bool IsSimple() => GetSelfLoopCount() == 0;
    
    public bool IsRegular() => GetMaxDegree() == GetMinDegree();
    
    public bool IsEmpty() => GetEdgeCount() == 0;
    
    public bool IsConnected()
    {
        var visited = new bool[_size];
        var queue = new Queue<int>();
        queue.Enqueue(0);
        while (queue.Count > 0)
        {
            var vertex = queue.Dequeue();
            visited[vertex] = true;
            for (int i = 0; i < _size; i++)
            {
                if (HasEdge(vertex, i) && !visited[i])
                {
                    queue.Enqueue(i);
                }
            }
        }
        for (int i = 0; i < _size; i++)
        {
            if (!visited[i])
            {
                return false;
            }
        }
        return true;
    }
    
    public bool IsBipartite()
    {
        var visited = new bool[_size];
        var colors = new int[_size];
        var queue = new Queue<int>();
        queue.Enqueue(0);
        while (queue.Count > 0)
        {
            var vertex = queue.Dequeue();
            visited[vertex] = true;
            for (int i = 0; i < _size; i++)
            {
                if (HasEdge(vertex, i))
                {
                    if (!visited[i])
                    {
                        colors[i] = 1 - colors[vertex];
                        queue.Enqueue(i);
                    }
                    else if (colors[i] == colors[vertex])
                    {
                        return false;
                    }
                }
            }
        }
        return true;
    }
    
    public bool IsEulerian()
    {
        if (!IsConnected())
        {
            return false;
        }
        for (int i = 0; i < _size; i++)
        {
            if (GetDegree(i) % 2 != 0)
            {
                return false;
            }
        }
        return true;
    }
    
    public bool IsHamiltonian()
    {
        if (!IsConnected())
        {
            return false;
        }
        for (int i = 0; i < _size; i++)
        {
            if (GetDegree(i) < _size / 2)
            {
                return false;
            }
        }
        return true;
    }
    
    public bool IsDAG()
    {
        if (!IsConnected())
        {
            return false;
        }
        var visited = new bool[_size];
        var stack = new Stack<int>();
        stack.Push(0);
        while (stack.Count > 0)
        {
            var vertex = stack.Pop();
            visited[vertex] = true;
            for (int i = 0; i < _size; i++)
            {
                if (HasEdge(vertex, i))
                {
                    if (!visited[i])
                    {
                        stack.Push(i);
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
        return true;
    }
    
    public bool IsTree()
    {
        if (!IsConnected())
        {
            return false;
        }
        if (GetEdgeCount() != _size - 1)
        {
            return false;
        }
        return true;
    }
}