use("Prathamesh")

db.sales.find()

// count pipeline operator
db.sales.aggregate([{
    $group: {
        _id: "$item",
        TotalQuantity: { $sum: "$quantity" },
        Count: { $count: {} }
    }
}
])

db.sales.find()
// sum operator pipeline 
db.sales.aggregate([{
    $group: {
        _id: "$item",
        TotalQuantity: { $sum: "$quantity" },
        Count: { $count: {} },
        MulQ: { $sum: { $multiply: ["$quantity", "$price"] } },
        priceSum: { $sum: "$price" }
    }
}
])

// average operator pipeline
db.sales.aggregate([{
    $group: {
        _id: "$item",
        AvgPrice: { $avg: "$price" }
    }
}])

// min operator pipeline
db.sales.aggregate([
    {
        $group: {
            _id: "$item",
            qty: { $min: "$quantity" }
        }
    },
    {
        $sort: {
            qty: 1
        }
    }
])

// sort operator
db.sales.aggregate([
    {
        $group: {
            _id: "$item",
            qty: { $min: "$quantity" }
        }
    },
    {
        $sort: {
            qty: 1
        }
    },
    {
        $skip: 2
    }
])


// count stage
db.sales.aggregate([
    {
        $group: {
            _id: "$item",
            qty: { $min: "$quantity" }
        }
    },
    {
       $count: 'Total Documents'
    }
])

db.sales.find()

// other operator 
db.sales.aggregate([
    {
       $project: {
         item:{$toUpper:"$item"}
       }
    }
])

db.sales.remove({_id:4})

db.getCollectionNames()

db.employee.drop()

db.getCollectionNames()

db.inventory.deleteMany({})

db.inventory.find()
