 public bool ValidTree(int n, int[][] edges) {
        if(edges.Length != n - 1) return false;
        //Parent array 
        int[] parent = new int[n];
        for(int i = 0; i < n; i++){
            parent[i] = i;
        }
        //Find Function
        int Find(int x){
            if(parent[x] != x){
                parent[x] = Find(parent[x]);
            }
            return parent[x];
        }
        //Union Function
        bool Union(int x, int y){
            int rootX = Find(x);
            int rootY = Find(y);
            if(rootX == rootY) {
                return false;
            }
            parent[rootX] = rootY;
            return true;
        }
        foreach(var edge in edges){
            if(!Union(edge[0], edge[1]))
            return false; // Cycle detected;
        }
        return true;
    }
