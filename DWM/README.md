# Data Warehouse and Data mining Algorithms
</br>

## Contains Algorithms:
1. Apriori
2. Naive Bayes
3. Kmean 

</br>

## Output:
1. apriori.py
```
C1 :
1 = 2
2 = 3
3 = 3
4 = 1
5 = 3

L1 :
1 = 2
2 = 3
3 = 3
5 = 3

C2 :
[1, 2] = 1
[1, 3] = 2
[1, 5] = 1
[2, 3] = 2
[2, 5] = 3
[3, 5] = 2

L2 :
[1, 3] = 2
[2, 3] = 2
[2, 5] = 3
[3, 5] = 2

 C3 :
[1, 2, 3] = 1
[1, 2, 5] = 1
[1, 3, 5] = 1
[2, 3, 5] = 2

 L3 :
[2, 3, 5] = 2

Association Rule :
2 -> [3, 5] = 66.67
[3, 5] -> 2 = 100.00
3 -> [2, 5] = 66.67
[2, 5] -> 3 = 66.67
5 -> [2, 3] = 66.67
[2, 3] -> 5 = 100.00


Choosing : [3, 5] -> 2
Choosing : [2, 3] -> 5
```

2. kmean_algo.py
```
Given = [2, 4, 10, 12, 3, 20, 30, 11, 25]

Step 1 =
k1 = [2, 4, 3] | m1 = 3.0
k2 = [10, 12, 20, 30, 11, 25] | m2 = 18.0

Step 2 =
k1 = [2, 4, 10, 3] | m1 = 4.75
k2 = [12, 20, 30, 11, 25] | m2 = 19.6

Step 3 =
k1 = [2, 4, 10, 12, 3, 11] | m1 = 7.0
k2 = [20, 30, 25] | m2 = 25.0

Step 4 =
k1 = [2, 4, 10, 12, 3, 11] | m1 = 7.0
k2 = [20, 30, 25] | m2 = 25.0

Cluster Created are :
Cluster 1 = [2, 4, 10, 12, 3, 11]
Cluster 2 = [20, 30, 25]
```

3. naive.py
```
    color    type    origin stolen
0     red  sports  domestic    yes
1     red  sports  domestic     no
2     red  sports  domestic    yes
3  yellow  sports  domestic     no
4  yellow  sports  imported    yes
5  yellow     suv  imported     no
6  yellow     suv  imported    yes
7  yellow     suv  domestic     no
8     red     suv  imported     no
9     red  sports  imported    yes

C1=5 C2=5 total=10
0.024 < 0.072
No
```
