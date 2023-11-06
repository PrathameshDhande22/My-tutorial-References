"""Word Count"""

# storing the file data in splitted manner
data = []

# reading the file and spliting and storing in data
with open("file.txt", "r") as f:
    for line in f:
        data.extend(line.split())

# Storing the values in dictionary
mapper = dict()

# mapping the words
for words in data:
    if mapper.get(words) is None:
        mapper[words] = 1
    else:
        mapper[words] = mapper.get(words) + 1

# printing the words counted
print("Word Count : ")
for key, value in mapper.items():
    print(f"{key} {value}")