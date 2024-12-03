public bool CanFinish(int numCourses, int[][] prerequisites) {
        // Build Adjacency List and in-degree array
        List<int>[] graph = new List<int>[numCourses];
        int[] indegree = new int[numCourses];
        for(int i = 0; i < numCourses; i++){
            graph[i] = new List<int>();
        }
        foreach(var pre in prerequisites){
            graph[pre[1]].Add(pre[0]);
            indegree[pre[0]]++;
        }
        //Add all courses with in-degree 0 to the queue
        Queue<int> queue = new Queue<int>();
        for(int i = 0; i < numCourses; i++){
            if(indegree[i] == 0){
                queue.Enqueue(i);
            }
        }
        //Process Courses
        int processedCourses = 0;
        while(queue.Count > 0){
            int course = queue.Dequeue();
            processedCourses++;
            foreach(int neighbour in graph[course]){
                indegree[neighbour]--;
                if(indegree[neighbour] == 0){
                    queue.Enqueue(neighbour);
                }
            }
        }
        return processedCourses == numCourses;
    }
