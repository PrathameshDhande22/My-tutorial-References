"""User-based Collaborative Filtering"""

import copy
import math

# taking inputs
tables = {
    "U1": [3, 5, 4, 4],
    "U2": [5, 3, 4, 3],
    "U3": [3, 2, 5, 3],
    "U4": [5, 3, 2, 3],
    "U5": ["?", 5, 4, 4],
    "U6": [2, 1, 4, 5],
}
# the index of the list which have the ? mark symbol
not_rated_index = 0

# Prathamesh Dhande
# user of which rating is not present
not_rated_user = "U5"

# creating the copy of tables
new_tables = copy.deepcopy(tables)

# calculating average ratings
avg_rating = {}
for key, values in new_tables.items():
    values.pop(not_rated_index)
    avg = sum(values) / len(values)
    avg_rating[f"r{key}"] = avg

    # calculating the new ratings
    new_tables[key] = list(map(lambda x: x - avg, values))
    print(f"r{key} = {avg}")

# printing the tables
for key, value in new_tables.items():
    print(f"{key}\t{value}")


# calculating the similarity
def sim(u1: str, u2: str) -> float:
    mul = sum(list(map(lambda x, y: x * y, new_tables[u1], new_tables[u2])))
    sq1 = math.sqrt(sum(list(map(lambda x: x**2, new_tables[u1]))))
    sq2 = math.sqrt(sum(list(map(lambda x: x**2, new_tables[u2]))))
    similar = mul / (sq1 * sq2)
    print(f"Sim({u1},{u2}) = {similar}")
    return similar


# storing all similarity in list
users = [name for name in new_tables.keys() if name != not_rated_user]
similarity = []
for u in users:
    similarity.append(sim(not_rated_user, u))

# predicting the rating of the app not rated by the user
cal_0 = 0
cal_1 = 0
for index, user in enumerate(users):
    cal_0 += similarity[index] * (tables[user][not_rated_index] - avg_rating[f"r{user}"])
    cal_1 += abs(similarity[index])
pred = avg_rating[f"r{not_rated_user}"] + (cal_0 / cal_1)

print(f"Missing rating = {pred}")
