# Pymongo Tutorial

# pip install pymongo
# Instaling the pymongo

# importing the pymongo
from bson import ObjectId
from pymongo import MongoClient
import pymongo

# initailing the connection with pymongo
client = MongoClient("mongodb://localhost:27017/")

# get all the database names
print(client.list_database_names())

# getting the database
db = client.get_database(name="Prathamesh")
# or
db = client["Prathamesh"]

# listing all the collection in the database
print(db.list_collection_names())

# getting the documents in a collection
print("Documents")
datas = list(db.sales.find({}))
print(datas)

# iterating over the documents in a collection returns the dictionary
for data in datas:
    print(data)

# converting the objectID to string
print("converting the object ID to string")
for data in list(db.employee.find()):
    print(ObjectId(data["_id"]), data)

# CRUD Operations

# inserting the documents
"""
inserting_data=[
    {
        "name":"Kepler",
        "rollno":7
    },
    {
        "name":"Lala",
        "rollno":8
    }
]
result=db.employee.insert_many(inserting_data)

# getting the inserted objectids
print(result.inserted_ids," ",result.acknowledged)
"""

# read operations
resultdata = list(db.sales.find({"size": "Tall"}))
for result in resultdata:
    print(result)

# counting the number of documents
print(db.employee.count_documents({}))

# sorting the documents
resultdata = list(db.sales.find().sort("price", pymongo.DESCENDING))
for result in resultdata:
    print(result)

# update operation
result = db.sales.update_one({"price": 25}, {"$set": {"quantity": 35}})
print(result.modified_count)

# delete operation
result = db.employee.delete_many({"rollno": 7})
print(result.deleted_count)

# projection
result = db.sales.find(projection={"_id": False, "date": False})
for res in result:
    print(res)

# sorting and limiting
result = db.sales.find(skip=4, limit=3)
for res in result:
    print(res)

# sorting using find
result = db.sales.find(sort=[("quantity", pymongo.DESCENDING)], projection={
                       "_id": False, "date": False})
for res in result:
    print(res)

# aggregation
result = db.sales.aggregate([
    {
        "$group": {"_id": "$size",
                   "TotalPrice": {"$sum": "$price"}}
    },
    {
        "$project": {
            "_id": 1,
            "date": 0
        }
    }
])
for res in result:
    print(res)

# getting the distinct values
result = db.sales.distinct("item")
print(result)

# listing the indexes
print(list(db.sales.list_indexes()))

# this is the mongodb in python ends
