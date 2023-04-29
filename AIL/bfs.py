graph={
"A":["B","C"],
"B":["D","E"],
"C":["F"],
"D":["G"],
"E":[],
"F":["H"],
"G":[],
"H":[]
}

graph2 = {
  'A' : ['B','C'],
  'B' : ['D', 'E'],
  'C' : ['F'],
  'D' : [],
  'E' : ['F'],
  'F' : []
}

def bfs(graph:dict,goal:str,start:str)-> list:
	print("Graph is :",graph)
	visited=[]
	queue=[]
	queue.append(start)

	while(len(queue)!=0):
		current=queue.pop(0)
		print("Pop : ",current)
		visited.append(current)
		if current==goal:
			print("Found Goal Node")
			break;
		for a in graph[current]:
			queue.append(a)
		print(queue)
	return visited
	
print(bfs(graph,"H","A"))