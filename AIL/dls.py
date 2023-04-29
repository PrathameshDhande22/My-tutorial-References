graph = {
    "A": ["B", 'C'],
    "B": ["D", "E"],
    "C": ["F"],
    "D": ["G"],
    "E": [],
    "F": ["H"],
    "G": [],
    "H": []
}

def dls(graph:dict,limit:int,depth:int,path:list,goal:str,node:str):
    print("Level ",depth)
    print("Exploring Node ",node)
    path.append(node)
    print("Current Path is : ",path)
    if depth>limit:
        print("Depth Limit Exceed")
        return False
    if node==goal:
        return path
    for child in graph[node]:
        if dls(graph,limit,depth+1,path,goal,child):
            return path
        path.pop()
    
print("Path is : ",dls(graph,2,0,[],"F","A"))