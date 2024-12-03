public class Solution {
    public int NumIslands(char[][] grid) {
        int count = 0;
        int rows = grid.Length;
        int cols = grid[0].Length;
        for(int i = 0; i < rows; i++){
            for(int j = 0; j < cols; j++){
                if(grid[i][j] == '1'){
                    DFS(grid, i, j);
                    count++;
                }
            }
        }
        return count;
    }
    public void DFS(char[][] grid, int i, int j){
        if(i < 0 
            || j < 0 
            || i >= grid.Length 
            || j >= grid[0].Length 
            || grid[i][j] == '0'){
                return;
        }
        grid[i][j] = '0';
        DFS(grid, i + 1, j);
        DFS(grid, i, j + 1);
        DFS(grid, i - 1, j);
        DFS(grid, i, j - 1);
    }
}
