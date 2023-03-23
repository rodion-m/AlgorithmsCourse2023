namespace GraphLesson;

public class FindJudgeExercise
{
    public class Solution
    {
        // O(V+E)
        public int FindJudgeSmart(int n, int[][] trust) {
            if (trust.Length == 0 && n == 1)
                return 1;
            
            //Список доверенных лиц для жителя
            int[] trustCount = new int[n + 1];
            foreach (int[] person in trust) //O(E)
            {
                // Увеличиваем счетчик доверия тем, КОМУ доверяют
                var toPerson = person[1];
                trustCount[toPerson]++;
                
                // Уменьшаем счетчик доверия тем, КТО доверяет
                // Если бы судья кому-то доверял, то его счетчик доверия бы уменьшился
                var fromPerson = person[0];
                trustCount[fromPerson]--;
            }

            for (var person = 1; person <= n; person++) //O(V)
            {
                // Судье должны доверять все жители, кроме самого судьи (n - 1)
                if (trustCount[person] == n - 1) return person;
            }

            return -1;
        }

        
        //V = n = 1000, E = 1000
        //O(V^2) = 1_000_000
        //O(V*E) = 1_000_000
        //O(V+E) = 2000
        //result = 4000
        public int FindJudge(int n, int[][] trust)
        {
            if(n == 1 && trust.Length == 0) return 1; //в городе один судья
            if(n > 1 && trust.Length == 0) return -1; //в городе n жителей и никто никому не доверяет
            if (trust.Length == 1) return trust[0][1]; // 1 житель в городе и один судья
            
            //trust = [[1,3],[2,3],[3,1]], n = 3
            //1->3
            //2->3
            //3->1
            
            //[[1,3],[2,3]], n = 3
            //1 -> 3
            //2 -> 3
            //3
            
            var adjList = CreateGraphAdjacencyList(n, trust); //O(V + E) = 2000
            // Шаг 1: Проверяем, есть ли житель, которому никто не доверяет
            var possibleJudge = adjList.FirstOrDefault(v => v.Value.Count == 0).Key; //O(V) = +1000
            if(possibleJudge == 0) return -1; //нет жителей, которые не доверяют никому
            
            foreach (var (v, edges) in adjList) //O(V) = +1000
            {
                if (v != possibleJudge && !edges.Contains(possibleJudge)) //O(1)
                {
                    // Этот житель не доверяет судье
                    return -1;
                }
            }
            
            return possibleJudge;
        }
        
        //n = 4. [[1,2],[1,3],[1,4],[2,1][2,3][2,4]]....
        private static Dictionary<int, HashSet<int>> CreateGraphAdjacencyList(int n, int[][] edges) //O(V + E)
        {
            var adjList = new Dictionary<int, HashSet<int>>();
            for (int i = 1; i <= n; i++) adjList.Add(i, new()); //O(V)

            foreach (var edge in edges) //O(E)
            {
                var fromVertext = edge[0];
                var toVertex = edge[1];
                adjList[fromVertext].Add(toVertex);
            }

            return adjList;
        }
    }

}