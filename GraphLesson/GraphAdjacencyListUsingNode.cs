namespace GraphLesson;

public class GraphAdjacencyListUsingNode
{
    public record Node(string Value, List<Node> Neighbors);
    
    private readonly Node _root;

    public static GraphAdjacencyListUsingNode CreateFriends()
    {
        Node bill = new Node("Bill", new());
        Node steve = new Node("Steve", new());
        Node elon = new Node("Elon", new());
        Node larry = new Node("Larry", new());
        Node sergey = new Node("Sergey", new());
        Node sheryl = new Node("Sheryl", new());
        Node jeff = new Node("Jeff", new());
        Node mark = new Node("Mark", new());

        bill.Neighbors.AddRange(new List<Node> { steve, elon, jeff });
        steve.Neighbors.AddRange(new List<Node> { bill, elon, larry });
        elon.Neighbors.AddRange(new List<Node> { bill, steve, larry, jeff });
        larry.Neighbors.AddRange(new List<Node> { steve, elon, sergey, sheryl });
        sergey.Neighbors.AddRange(new List<Node> { larry, sheryl });
        sheryl.Neighbors.AddRange(new List<Node> { larry, sergey, mark });
        jeff.Neighbors.AddRange(new List<Node> { bill, elon, mark });
        mark.Neighbors.AddRange(new List<Node> { sheryl, jeff });
        
        return new GraphAdjacencyListUsingNode(bill);
    }
    
    private GraphAdjacencyListUsingNode(Node root)
    {
        _root = root;
    }
}