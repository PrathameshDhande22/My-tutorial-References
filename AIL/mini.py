graph = {
    "A": ["B", "C"],
    "B": ["D", "E"],
    "C": ["F", "G"],
    "D": [-1, 8],
    "E": [-3, -1],
    "F": [2, 1],
    "G": [-3, 4]
}


def getWeight(isMax: bool, node: str):
    if isMax:
        return max(graph[node])
    return min(graph[node])


def minimax(node: str, depth: int, maxTurn: bool):
    print("Exploring Node : ", node)
    if depth == 0:
        return getWeight(maxTurn, node)
    if maxTurn:
        bestScore = float("-inf")
        for child in graph[node]:
            score = minimax(child, depth-1, False)
            bestScore = max(bestScore, score)
        return bestScore
    else:
        bestScore = float("inf")
        for child in graph[node]:
            score = minimax(child, depth-1, True)
            bestScore = min(bestScore, score)
        return bestScore


if __name__ == '__main__':
    print("The Optimal value is :", minimax("A", 2, True))
