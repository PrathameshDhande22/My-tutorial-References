"""Collaborative Filtering"""

import math
import pandas as pd

# creating the dataframe of it
data = {
    "Inshorts(I1)": [5, 3, 4, 3],
    "HT(I2)": [4, 1, 3, 3],
    "NYT(I3)": [1, 2, 4, 1],
    "TOI(I4)": [4, 3, 3, 5],
    "BBC(I5)": ["?", 3, 5, 4],
}
df = pd.DataFrame(data, index=["Alice", "U1", "U2", "U3"])
print(df)

# removing the Question mark row
not_rated = df["BBC(I5)"].iloc[1:].to_list()

# removing the Question mark column
df2 = df.drop(columns="BBC(I5)")

# getting the user name as stored in index of dataframe
user_name = df2.index

# calculating the average of all rating
avg_rating = []
for u in user_name:
    ar = df2.loc[u, :].sum() / df2.shape[0]
    avg_rating.append(ar)

    # calculating the new rating's
    df2.loc[u, :] -= ar
    print(f"r{u} = {ar}")

# printing the new rating table
print(df2)


def sim(u1: str, u2: str) -> float:
    global df2
    mu = df2.loc[u1, :] * df2.loc[u2, :]
    sq1 = df2.loc[u1, :] ** 2
    sq2 = df2.loc[u2, :] ** 2
    similar = mu.sum() / math.sqrt(sq1.sum() * sq2.sum())
    print(f"sim({u1},{u2}) = {similar}")
    return similar


similarity = []
# calculating the similarity between alice and other user
s1 = sim("Alice", "U1")
s2 = sim("Alice", "U2")
s3 = sim("Alice", "U3")
similarity.extend([s1, s2, s3])

# predicting the rating of the app
pred = 0
upon = 0
for i in range(len(similarity)):
    pred += similarity[i] * (not_rated[i] - avg_rating[i + 1])
    upon += abs(similarity[i])

# new Rating
nr = avg_rating[0] + (pred / upon)
print("New Rating = ", nr)
