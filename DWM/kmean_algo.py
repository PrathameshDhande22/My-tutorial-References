import numpy as np

cluster1 = []
cluster2 = []
given = [2, 4, 10, 12, 3, 20, 30, 11, 25]

# assigning the random values
m1 = given[1]
m2 = given[2]

print(f"Given = {given}")
step = 1

while True:

    print(f"\nStep {step} = ")
    for i in range(len(given)):
        if (abs(given[i]-m1)) < (abs(given[i]-m2)):
            cluster1.append(given[i])
        else:
            cluster2.append(given[i])
    c1 = np.array(cluster1)
    c2 = np.array(cluster2)
    avg1 = c1.mean()
    avg2 = c2.mean()
    print(f"k1 = {c1.tolist()} | m1 = {avg1}\nk2 = {c2.tolist()} | m2 = {avg2}")
    if avg1 == m1 and avg2 == m2:
        break
    else:
        m1 = avg1
        m2 = avg2
    cluster1.clear()
    cluster2.clear()
    np.delete(c1, 0, axis=0)
    np.delete(c2, 0, axis=0)
    step = step+1

print(
    f"\nCluster Created are : \nCluster 1 = {c1.tolist()}\nCluster 2 = {c2.tolist()}")
