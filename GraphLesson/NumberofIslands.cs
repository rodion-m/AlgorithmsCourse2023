namespace GraphLesson;

public class NumberofIslands
{
    record struct Point(int X, int Y);

    public class Solution
    {
        public int NumIslands(char[][] grid)
        {
            var dicovered = new HashSet<Point>();
            int islandsCount = 0;
            for (var y = 0; y < grid.Length; y++)
            {
                for (var x = 0; x < grid[y].Length; x++)
                {
                    if (grid[y][x] == '0') continue;

                    var point = new Point(x, y);
                    if (dicovered.Contains(point)) continue; //y == 0, x == 1

                    islandsCount++;
                    DiscoverIslands(point);
                }
            }

            return islandsCount;

            void DiscoverIslands(Point point)
            {
                var queue = new Queue<Point>();
                queue.Enqueue(point);
                dicovered.Add(point);
                while (queue.Count > 0)
                {
                    var current = queue.Dequeue();
                    // проверка верхней точки
                    if (current.Y > 0 && grid[current.Y - 1][current.X] == '1')
                    {
                        var up = current with { Y = current.Y - 1 };
                        if (!dicovered.Contains(up))
                        {
                            queue.Enqueue(up);
                            dicovered.Add(up);
                        }
                    }

                    // проверка нижней точки
                    if (current.Y < grid.Length - 1 && grid[current.Y + 1][current.X] == '1')
                    {
                        var down = current with { Y = current.Y + 1 };
                        if (!dicovered.Contains(down))
                        {
                            queue.Enqueue(down);
                            dicovered.Add(down);
                        }
                    }

                    //проверка точки слева
                    if (current.X > 0 && grid[current.Y][current.X - 1] == '1')
                    {
                        var left = current with { X = current.X - 1 };
                        if (!dicovered.Contains(left))
                        {
                            queue.Enqueue(left);
                            dicovered.Add(left);
                        }
                    }

                    //проверка точки справа
                    if (current.X < grid[current.Y].Length - 1 &&
                        grid[current.Y][current.X + 1] == '1')
                    {
                        var right = current with { X = current.X + 1 };
                        if (!dicovered.Contains(right))
                        {
                            queue.Enqueue(right);
                            dicovered.Add(right);
                        }
                    }
                }
            }
        }
    }
}

public class Solution
{
    public int NumIslands(char[][] grid) //изм. входных данных антипаттерн
    {
        int count = 0;
        if (grid == null || grid.Length == 0)
        {
            return count;
        }

        for (int y = 0; y < grid.Length; y++)
        {
            for (int x = 0; x < grid[0].Length; x++)
            {
                if (grid[y][x] == '1')
                {
                    count += 1;
                    Dfs(grid, y, x);
                }
            }
        }

        return count;
    }

    public int Dfs(char[][] g, int y, int x)
    {
        g[y][x] = '0';
        if (y - 1 >= 0 && g[y - 1][x] == '1')
        {
            Dfs(g, y - 1, x);
        }

        if (x - 1 >= 0 && g[y][x - 1] == '1')
        {
            Dfs(g, y, x - 1);
        }

        if (y + 1 < g.Length && g[y + 1][x] == '1')
        {
            Dfs(g, y + 1, x);
        }

        if (x + 1 < g[0].Length && g[y][x + 1] == '1')
        {
            Dfs(g, y, x + 1);
        }

        return 0;
    }
}


//
// public class Solution {
//     public int NumIslands(char[][] grid)
//     {
//         var adjList = CreateAdjList(grid);
//         var visited = new HashSet<int>();
//         var count = 0;
//         foreach (var v in adjList.Keys)
//         {
//             if(visited.Contains(v)) continue;
//             if(adjList[v].Count == 0) continue;
//             count++;
//             var queue = new Queue<int>();
//             queue.Enqueue(v);
//             visited.Add(v);
//             while (queue.TryDequeue(out var current))
//             {
//                 foreach (var neighbor in adjList[current])
//                 {
//                     if (visited.Contains(neighbor)) continue;
//                     queue.Enqueue(neighbor);
//                     visited.Add(neighbor);
//                 }
//             }
//                 
//         }
//         return count;
//     }
//
//     private static Dictionary<int, List<int>> CreateAdjList(char[][] grid)
//     {
//         var adjList = new Dictionary<int, List<int>>();
//         var vertexCount = Math.Max(grid.Length, grid[0].Length);
//         for (int v = 0; v < vertexCount; v++)
//         {
//             adjList.Add(v, new List<int>());
//         }
//
//         for (int v = 0; v < grid.Length; v++)
//         {
//             for (int n = 0; n < grid[v].Length; n++)
//             {
//                 if (grid[v][n] == '1')
//                 {
//                     adjList[v].Add(n);
//                     adjList[n].Add(v);
//                 }
//             }
//         }
//
//         return adjList;
//     }
// }