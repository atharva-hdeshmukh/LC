public class Solution {
    public int OrangesRotting(int[][] grid) {
        int rows = grid.Length;
        int cols = grid[0].Length;
        Queue<int[]> queue = new Queue<int[]>();
        int timer = 0;
        int freshOranges = 0;
        int[][] directions = new int[][]{
            new int[]{0, 1},
            new int[]{0, -1},
            new int[]{1, 0},
            new int[]{-1, 0}
        };
        for(int i = 0; i < rows; i++){
            for(int j = 0; j < cols; j++){
                if(grid[i][j] == 2){
                    queue.Enqueue(new int[]{i,j});
                }else if(grid[i][j] == 1){
                    freshOranges++;
                }
            }
        }
        if(freshOranges == 0) return 0;
        while(queue.Count > 0){
            int size = queue.Count;
            bool hasSpread = false;
            for(int i = 0; i < size; i++){
                int[] current = queue.Dequeue();
                int row = current[0];
                int col = current[1];
                foreach(var dir in directions){
                    int nr = row + dir[0];
                    int nc = col + dir[1];
                    if(nr >= 0 && nc >=0 && nr < rows && nc < cols && grid[nr][nc] == 1){
                        grid[nr][nc] = 2;
                        freshOranges--;
                        queue.Enqueue(new int[] {nr, nc});
                        hasSpread = true;
                    }
                }
            }
            if(hasSpread) timer++;
        }
        return freshOranges == 0 ? timer : -1;
    }
}
