"""Flajolet Martin"""

elements = [4, 2, 5, 9, 1, 6, 3, 7]
hash_function = [[3, 1, 32], [1, 6, 32]]

distinct_elements = set(elements)
print("Distinct Elements : ", distinct_elements)


# finding the trailing zeros
def getTrailingZero(no: int) -> int:
    count = 0
    while no > 0:
        if no & 1 == 0:
            count += 1
        else:
            break
        no = no >> 1
    return count


# making the hash equation
def hashEquation(x: int, first: int, second: int, mod: int) -> int:
    return ((first * x) + second) % mod


# storing the r-max value for each hash function
store_r_max = []

for hash_fn in hash_function:
    # storing r values in list for each element
    r_values = []
    print(f"\nfor hash function h(x)={hash_fn[0]}x+{hash_fn[1]}%{hash_fn[2]}")

    for ele in distinct_elements:
        hash_value = hashEquation(ele, hash_fn[0], hash_fn[1], hash_fn[2])

        r = getTrailingZero(hash_value)
        r_values.append(r)
        print(f"n = {ele}\tBinary = {bin(hash_value)[2:]}\tr = {r}\thash value={hash_value}")

    r_max = max(r_values)
    print("Rmax = ", r_max)
    print("Estimate 2^Rmax = ", 2**r_max)
    store_r_max.append(2**r_max)

# average
avg = int(sum(store_r_max) / len(hash_function))
print(f"\nValue = {avg}")
