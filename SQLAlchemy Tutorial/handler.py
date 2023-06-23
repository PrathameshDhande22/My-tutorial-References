import json
import random


def getdatas(User):
    deptsidlist = [101, 102, 103, 104, 105]
    alldatas = list()
    opened = open("response.json")
    data = json.load(opened)
    for ids in data["users"]:
        dep = random.choice(deptsidlist)
        alldatas.append(User(id=ids["id"], fname=ids["firstName"],
                        lname=ids["lastName"], age=ids["age"], deptid=dep))
    return alldatas
