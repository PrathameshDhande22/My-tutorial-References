data = [
    [100, [1, 3, 4]],
    [200, [2, 3, 5]],
    [300, [1, 2, 3, 5]],
    [400, [2, 5]]
]
min_support = 50/100

def print_table(itemset, data):
    for i in range(len(itemset)):
        print(f"{itemset[i]} = {data[i]}")

# step 1
itemset1 = set()
for ex in data:
    for i in ex[1]:
        itemset1.add(i)
dict = {}
for i in itemset1:
    for no in data:
        if i in no[1]:
            if i in dict:
                no = dict.get(i)
                no = no+1
                dict.__setitem__(i, no)
            else:
                no = 1
                dict.__setitem__(i, no)
print("C1 :")
print_table(list(dict.keys()), list(dict.values()))
total = len(data)

def support(dict, min_support, total):
    for key, value in list(dict.items()):
        if value/total < min_support:
            del dict[key]
    return dict

print("\nL1 :")
l1 = support(dict, min_support, total)
print_table(list(dict.keys()), list(dict.values()))

itemset = []
for i in list(l1.keys()):
    for j in list(l1.keys()):
        if [j, i] in itemset or i == j:
            pass
        else:
            itemset.append([i, j])

c2 = {}
for i in itemset:
    for no in data:
        if i[0] in no[1] and i[1] in no[1]:
            if str(i) in c2:
                n = c2.get(str(i))
                n = n+1
                c2.__setitem__(str(i), n)
            else:
                n = 1
                c2.__setitem__(str(i), n)

print("\nC2 : ")
print_table(list(c2.keys()), list(c2.values()))
print("\nL2 : ")
l2 = support(c2, min_support, total)
print_table(list(l2.keys()), list(l2.values()))

itemset3=[]
for i in list(dict.keys()):
    for j in list(dict.keys()):
        for z in list(dict.keys()):
            if i==j or i==z or j==i or j==z or z==1 or z==j or [j,z,i] in itemset3 or [z,i,j] in itemset3 or [j,i,z] in itemset3 or [z,j,i] in itemset3 or [i,z,j] in itemset3:
                pass
            else:
                itemset3.append([i,j,z])

c3={}
for i in itemset3:
    for no in data:
        if i[0] in no[1] and i[1] in no[1] and i[2] in no[1]:
            if str(i) in c3:
                n = c3.get(str(i))
                n = n+1
                c3.__setitem__(str(i), n)
            else:
                n = 1
                c3.__setitem__(str(i), n)
print("\n C3 :")
print_table(list(c3.keys()),list(c3.values()))
print("\n L3 :")
l3=support(c3,min_support,total)
print_table(list(l3.keys()),list(l3.values()))

def getc1_confidence(tupa,addlist):
    support=l3.get(str(addlist))/l1.get(tupa)
    return "{:.2f}".format(support*100)

def getc2_confidence(tupa,addlist):
    support=l3.get(str(addlist))/l2.get(str(tupa))
    return "{:.2f}".format(support*100)

# association rule
for key in list(l3.keys()):
    l=list(key)
l.remove(' ')
l.remove(' ')
l.remove(",")
l.remove(",")
l.remove("[")
l.remove("]")
addlist=[]
for i in l:
    addlist.append(int(i))
select=0
print("\nAssociation Rule :")
result=[]
for i in range(3):
    copylist=addlist.copy()
    selected=copylist.pop(select)
    print(f"{selected} -> {copylist} = {getc1_confidence(selected,addlist)}")
    print(f"{copylist} -> {selected} = {getc2_confidence(copylist,addlist)}")
    select=select+1
    result.append([[f"{selected} -> {copylist}"],getc1_confidence(selected,addlist)])
    result.append([[f"{copylist} -> {selected}"],getc2_confidence(copylist,addlist)])

print("\n")
for i in result:
    if float(i[1])>=70:
        print(f"Choosing : {i[0][0]}")