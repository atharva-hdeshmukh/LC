public int[] FindOrder(int numCourses, int[][] prerequisites) {
        // Step 1 : Build Adjacency list and in-degree Array
        List<int>[] graph = new List<int>[numCourses];
        int[] indegree = new int[numCourses];
        for(int i = 0; i < numCourses; i++){
            graph[i] = new List<int>();
        }
        foreach(var pre in prerequisites){
            int u = pre[1]; //prerequisite
            int v = pre[0]; //dependent
            graph[u].Add(v);
            indegree[v]++;
        }
        // Step 2: Initialize the queue with courses having in-degree 0
        Queue<int> queue = new Queue<int>();
        for(int i = 0; i < numCourses; i++){
            if(indegree[i] == 0){
                queue.Enqueue(i);
            }
        }
        // Step 3: Process the queue and construct the result
        List<int> result = new List<int>();
        while(queue.Count > 0){
            int course = queue.Dequeue();
            result.Add(course);
            foreach(int neighbor in graph[course]){
                indegree[neighbor]--;
                if(indegree[neighbor] == 0){
                    queue.Enqueue(neighbor);
                }
            }
        }
        if(result.Count == numCourses){
            return result.ToArray();
        }
        return new int[0];
    }
