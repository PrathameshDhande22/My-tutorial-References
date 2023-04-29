graph = {
    "S": [("G", 10), ("A", 1)],
    "A": [("B", 2), ("C", 1)],
    "B": [("D", 3)],
    "C": [("D", 3), ("G", 4)],
    "D": [("G", 2)],
    "G": []
}

heuristic = {
    "S": 5,
    "A": 3,
    "B": 4,
    "C": 2,
    "D": 6,
    "G": 0
}

print(graph)
node = "S"
goal = "G"
visited = []
visited.append(node)
while node != goal:
    fn = 0
    currentgraph = {}
    for currNode, cost in graph[node]:
        fn = cost+heuristic[currNode]
        currentgraph[fn] = currNode
    minimum = min(currentgraph)
    node = currentgraph[minimum]
    print(currentgraph)
    print("Minimum : ", minimum)
    print("Selecting Node : ", node)
    visited.append(node)
print("Path is : ", " -> ".join(visited))
