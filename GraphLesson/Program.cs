using GraphLesson;
using GraphLesson.Representations;

char[][] grid1 = {
    new[] {'1', '1', '0', '0', '0'},
    new[] {'1', '1', '0', '0', '0'},
    new[] {'0', '0', '1', '0', '0'},
    new[] {'0', '0', '0', '1', '1'}
}; //3
char[][] grid2 = new char[][] {
    new [] {'1', '1', '1', '1', '0'},
    new [] {'1', '1', '0', '1', '0'},
    new [] {'1', '1', '0', '0', '0'},
    new [] {'0', '0', '0', '0', '0'}
}; //1
// var grid3 = new char[][]
// {
//     [["1","0","1","1","0","1","1"]]
// }


Console.WriteLine(new NumberofIslands.Solution().NumIslands(grid1));

//GraphAdjacencyListOnDictionary.CreateFriends().BFS("Bill");
//GraphAdjacencyMatrixJaggedArray.CreateFriends().BFSUsingQueue(0);

