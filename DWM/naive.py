import pandas as pd

data = pd.read_csv("data.csv")
print(data)


def prob(list, target, cla):
    ans = 1
    for i in range(len(list)):
        column_name = data.columns[i]
        newdata = data.loc[(data[column_name] == list[i])]
        count = newdata.loc[newdata["stolen"] == target].count()
        ans = ans*(int(count[0])/cla)
    return ans


def getlabel(p1, p2):
    if p1 < p2:
        return f"{p1} < {p2}\nNo"
    else:
        return f"{p1} > {p2}\nYes"


# finding the value of the yes and no
stolen = data.value_counts(subset=["stolen"])
total = data["stolen"].count()
yes = stolen[1]
no = stolen[0]
print(f"\nC1={yes} C2={no} total={total}")

# probability
pc1 = yes/total
pc2 = no/total

pxc1 = prob(["red", 'suv', 'domestic'], "yes", yes)*pc1
pxc2 = prob(["red", 'suv', 'domestic'], "no", no)*pc2
print(getlabel(pxc1, pxc2))
