namespace GraphLesson.Representations;

public class GraphAdjacencyMatrixTwoDimensional
{
    private readonly int[,] _matrix;
    private readonly int _size;

    public static GraphAdjacencyMatrixTwoDimensional CreateFriends()
    {
        int[,] adjacencyMatrix = {
            // Bill, Steve, Elon, Larry, Sergey, Sheryl, Jeff, Mark
            { 0, 1, 1, 0, 0, 0, 1, 0 }, // Bill Gates
            { 1, 0, 1, 1, 0, 0, 0, 0 }, // Steve Jobs
            { 1, 1, 0, 1, 0, 0, 1, 0 }, // Elon Musk
            { 0, 1, 1, 0, 1, 1, 0, 0 }, // Larry Page
            { 0, 0, 0, 1, 0, 1, 0, 0 }, // Sergey Brin
            { 0, 0, 0, 1, 1, 0, 0, 1 }, // Sheryl Sandberg
            { 1, 0, 1, 0, 0, 0, 0, 1 }, // Jeff Bezos
            { 0, 0, 0, 0, 0, 1, 1, 0 }  // Mark Zuckerberg
        };
        var graph = new GraphAdjacencyMatrixTwoDimensional(adjacencyMatrix);
        return graph;
    }
    
    public GraphAdjacencyMatrixTwoDimensional(int[,] matrix)
    {
        _size = matrix.GetLength(0);
        _matrix = matrix;
    }

    public GraphAdjacencyMatrixTwoDimensional(int size)
    {
        _size = size;
        _matrix = new int[size, size];
    }

    public void AddEdge(int from, int to)
    {
        _matrix[from, to] = 1;
        _matrix[to, from] = 1;
    }

    public void RemoveEdge(int from, int to)
    {
        _matrix[from, to] = 0;
        _matrix[to, from] = 0;
    }

    public bool HasEdge(int from, int to)
    {
        return _matrix[from, to] == 1;
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

    public int GetTwoRank(int vertex)
    {
        var twoRank = 0;
        for (int i = 0; i < _size; i++)
        {
            if (HasEdge(vertex, i))
            {
                twoRank += GetRank(i);
            }
        }

        return twoRank;
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
}