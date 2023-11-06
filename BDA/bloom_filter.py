"""Bloom Filter"""


# function to get bits at even or odd numbered depends on flag=0 odd bits and flag=1 even bits
def getoddevenbits(no: int, flag: int) -> int:
    binary = bin(no)[2:]
    return int(binary[flag::2], 2)


# enter the size of the array
size = int(input("Enter the size of the array : "))

# initialize the filter list with 0 with the given size
filter = [0] * size

# enter the number of stream elements
no_stream_elements = int(input("Enter the Number of Stream Elements : "))

count = 0

for i in range(no_stream_elements):
    # checking if filter is filled by half
    if size / 2 < count:
        filter = [0] * size
        print("Filter Updated ", filter)

    element = int(input("\nEnter the Input Element : "))
    print("Binary = ", bin(element)[2:])
    # h1
    h1 = getoddevenbits(element, 0) % size
    filter[h1] = 1
    # h2
    h2 = getoddevenbits(element, 1) % size
    filter[h2] = 1
    count += 2
    print(f"h1={h1},h2={h2}")
    print("Filter = ", filter)
