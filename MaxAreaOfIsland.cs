public class Solution {
    private static readonly int[][] directions = new int[][]{
        new int[]{1, 0}, new int []{-1, 0},
        new int[]{0, 1}, new int []{0, -1}
    };
    public int MaxAreaOfIsland(int[][] grid) {
        int rows = grid.Length;
        int cols = grid[0].Length;
        int maxArea = 0;
        for(int i = 0; i < rows; i++){
            for(int j = 0; j < cols; j++){
                if(grid[i][j] == 1){
                    maxArea = Math.Max(maxArea, BFS(grid, i, j));
                }
            }
        }
        return maxArea;
    }
    private int BFS(int[][] grid, int i, int j){
        Queue<int[]> queue = new Queue<int[]>();
        grid[i][j] = 0;
        queue.Enqueue(new int[]{i, j});
        int area = 1;
        while(queue.Count > 0){
            var node = queue.Dequeue();
            int row = node[0]; int col = node[1];
            foreach(var dir in directions){
                int nr = row + dir[0]; int nc = col + dir[1];
                if(nr >= 0 && nc >= 0 && nr < grid.Length && nc < grid[0].Length && grid[nr][nc] == 1){
                    queue.Enqueue(new int[]{nr, nc});
                    grid[nr][nc] = 0;
                    area++;
                }
            }
        }
        return area;
    }
}
