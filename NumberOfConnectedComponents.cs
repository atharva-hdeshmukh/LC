public int CountComponents(int n, int[][] edges) {
        int[] parent = new int[n];
        int[] rank = new int[n];
        for(int i = 0; i < n; i++){
            parent[i] = i;
            rank[i] = 0;
        }
        int Find(int node){
            if(parent[node] != node){
                parent[node] = Find(parent[node]);
            }
            return parent[node];
        }
        void Union(int node1, int node2){
            int root1 = Find(node1);
            int root2 = Find(node2);
            if(root1 != root2){
                if(rank[root1] > rank[root2]){
                    parent[root2] = root1;
                }else if(rank[root2] > rank[root1]){
                    parent[root1] = root2;
                }else{
                    parent[root2] = root1;
                    rank[root1]++;
                }
            }
        }
        foreach(var edge in edges){
            Union(edge[0], edge[1]);
        }
        HashSet<int> uniqueRoots = new HashSet<int>();
        for(int i = 0; i < n; i++){
            uniqueRoots.Add(Find(i));
        }
        return uniqueRoots.Count;
    }
