public int[] FindRedundantConnection(int[][] edges) {
        int n = edges.Length;
        int[] parent = new int[n + 1];
        int[] rank = new int[n + 1];
        for(int i = 0; i <= n; i++){
            parent[i] = i;
            rank[i] = 0;
        }
        int Find(int node){
            if(parent[node] != node){
                parent[node] = Find(parent[node]);
            }
            return parent[node];
        }
        bool Union (int node1, int node2){
            int root1 = Find(node1);
            int root2 = Find(node2);
            if(root1 == root2) return false;
            if(rank[root1] > rank[root2]){
                parent[root2] = root1;
            }else if(rank[root2] > rank[root1]){
                parent[root1] = root2;
            }else{
                parent[root2] = root1;
                rank[root1]++;
            }
            return true;
        }
        foreach(var edge in edges){
            if(!Union(edge[0], edge[1])){
                return edge;
            }
        }
        return new int[0];    
    }
