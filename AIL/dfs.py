graph={
"A":["B","C"],
"B":["D","E"],
"C":["F"],
"D":["G"],
"E":[],
"F":["H"],
"H":[],
"G":[]
}

print(graph)

def dfs(graph:dict,node:str,start:str):
	stack=[]
	visited=[]
	stack.append(start)
	while len(stack)!=0:
		ans=stack.pop(0)
		print("Popped ",ans)
		visited.append(ans)
		if ans==node:
			return visited
		else:
			i=0
			for branch in graph[ans]:
				stack.insert(i,branch)
				i+=1
		print("stack",stack)
	return "Algorithm Fails to Find the Goal Node"
  
print("list is ",dfs(graph,"G","A"))