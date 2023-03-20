namespace GraphLesson;

public class FindCenterOfStarGraphExercise
{
    public class Solution {
        public int FindCenter(int[][] edges) {
            if(edges.Length == 0) return -1;
            if(edges.Length == 1) return edges[0][0];
            var edge1 = edges[0];
            var edge2 = edges[1];
            if(edge1[0] == edge2[0] || edge1[0] == edge2[1]) return edge1[0];
            return edge1[1];
        }
    }
}