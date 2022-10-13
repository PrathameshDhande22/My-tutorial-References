import pandas as pd


def prob(data, list, clas, tcl):
    pc = 1

    for i in range(len(list)):
        o1 = data.loc[(data[str(data.columns[i])] == list[i])]
        count = int(o1.loc[(o1['play'] == tcl)].count(
            axis=0, numeric_only=True))

        pc = pc*(count/clas)
    return pc


def getLabel(pxc1, pxc2):

    if (pxc1 < pxc2):
        print(pxc1, "<", pxc2)
        return "No"
    else:
        print(pxc1, ">", pxc2)
        return "Yes"


dataset = pd.read_csv("data.csv")
tot = int(dataset.count(axis=0, numeric_only=True))
c1 = int(dataset.loc[(dataset['play'] == 'Yes')
                     ].count(axis=0, numeric_only=True))
c2 = int(dataset.loc[(dataset['play'] == 'No')
                     ].count(axis=0, numeric_only=True))
pc1 = c1/tot
pc2 = c2/tot

pxc1 = prob(dataset, ['sunny', 'hot', 'high', False], c1, 'Yes')*pc1
pxc2 = prob(dataset, ['sunny', 'hot', 'high', False], c2, 'No')*pc2
print(getLabel(pxc1, pxc2))
