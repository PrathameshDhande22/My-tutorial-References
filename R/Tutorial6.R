# Tutorial 6

# Tutorial on data manipulation

# Read a csv file
data=read.csv("./data.csv")
data

class(data)

# get minimum and maximum value 
min(data$X1958)
max(data$X1959)

# subset 
nrow(subset(data,1958>300))

# write a dataframe into csv
write.csv(df,"./file.csv")