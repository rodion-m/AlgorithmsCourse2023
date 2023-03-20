namespace GraphLesson.Representations;

public class GraphAdjacencyListOnEdgeList
{
    public record Edge(string Node1, string Node2);
    
    private readonly List<Edge> _edgeList;

    public GraphAdjacencyListOnEdgeList(List<Edge> edgeList)
    {
        _edgeList = edgeList;
    }

    public static GraphAdjacencyListOnEdgeList CreateFriends()
    {
        List<Edge> edgeList = new List<Edge>
        {
            new("Bill", "Steve"),
            new("Bill", "Elon"),
            new("Bill", "Jeff"),
            new("Steve", "Elon"),
            new("Steve", "Larry"),
            new("Elon", "Larry"),
            new("Larry", "Sergey"),
            new("Larry", "Sheryl"),
            new("Sergey", "Sheryl"),
            new("Sheryl", "Mark"),
            new("Elon", "Jeff"),
            new("Jeff", "Mark")
        };
        return new GraphAdjacencyListOnEdgeList(edgeList);
    }
}