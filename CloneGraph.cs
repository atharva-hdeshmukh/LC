private Dictionary<Node, Node> visited = new Dictionary<Node, Node>();
    public Node CloneGraph(Node node) {
        if(node == null)
            return null;
        if(visited.ContainsKey(node)){
            return visited[node];
        }
        Node newNode = new Node(node.val);
        visited[node] = newNode;
        foreach(var neighbor in node.neighbors){
            newNode.neighbors.Add(CloneGraph(neighbor));
        }
        return newNode;
    }
