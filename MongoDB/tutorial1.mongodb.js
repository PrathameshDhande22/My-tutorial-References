use("Prathamesh")

// operator tutorial in mongoDB
db.products.find()

db.products.find({ price: 799 })

// not equal to operator
db.products.find({ price: { $ne: 799 } }, { _id: 0, spec: 0 })

// in operator
db.products.find({ price: { $in: [799, 599] } })

// not in operator
db.products.find({
    price: {
        $nin: [599, 699, 799]
    }
})

// or operator
db.products.find({ $or: [{ price: 799 }, { price: 599 }] })

// not and greater than operator
db.products.find({
    price: {
        $not: {
            $gt: 599
        }
    }
})

// nor operator
db.products.find({
    $nor: [{ price: 799 }, { name: "SmartPhone" }]
})

// array size operator
db.products.find({
    color: {
        $not: { $size: 3 }
    }
})

// array all operator
db.products.find({
    color: {
        $all: ["white", "gold"]
    }
})

// array in operator
db.products.find({ color: { $in: ["white", "gold"] } })

// accessing the array elements
db.products.find({ "color.0": "green" })

// increment operator
db.products.updateOne({
    _id: 3
},
    {
        $inc: {
            price: 50
        }
    }
)

db.products.find({_id:3})

