public class Solution {
    public void Solve(char[][] board) {
        int rows = board.Length;
        int cols = board[0].Length;

        for(int i = 0; i < rows; i++){
            if(board[i][0]  == 'O') dfs(board, i, 0);
            if(board[i][cols - 1] == 'O') dfs(board, i, cols - 1);
        }
        for(int j = 0; j < cols; j++){
            if(board[0][j] == 'O') dfs(board, 0, j);
            if(board[rows - 1][j] == 'O') dfs(board, rows - 1, j);
        }
        for(int i = 0; i < rows; i++){
            for(int j = 0; j < cols; j++){
                if(board[i][j] == 'O') board[i][j] = 'X';
                if(board[i][j] == '#') board[i][j] = 'O';
            }
        }
    }
    private void dfs(char[][] board, int row, int col){
        if(row < 0 || col < 0 || row >= board.Length || col >= board[0].Length || board[row][col] != 'O'){
            return;
        }
        board[row][col] = '#';
        dfs(board, row + 1, col);
        dfs(board, row - 1, col);
        dfs(board, row, col + 1);
        dfs(board, row, col - 1);
    }
}
