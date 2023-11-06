# Tutorial 4 Based on Data Structure

# Matrix

# creating the matrix
mat=matrix(c(1:10),nrow = 2,ncol = 5)
print(mat)

# accesing the matrix element
print(mat[2,1])

# accessing the multi matrix
print(mat[,1:3])

# combining the two matrices
mat2=matrix(c(11:20),nrow=2,ncol = 5,byrow = TRUE)
print(mat2)

# cbind() combining by column
print(cbind(mat,mat2))

# rbind() combining by row
print(rbind(mat,mat2))

# check if element exists in r
21 %in% mat2

1 %in% c(1:3)

# acessing the dimension
dim(mat)

# length of the matrix
length(mat)

# looping on matrix
for(d in mat){
  print(d)
}

# accesing the no of rows
nrow(mat)

# accessing the no of cols
ncol(mat)

# sorting the vectors
sort(c(19,12,45,76,9))

sort(mat)


# Lists
# creating the list
container=list(c(1:5),c("a","f","b","c"))
print(container)

# accessing the elements
container[2]

# length of the list
length(container)

# add items to list
append(container,c(11:20))

print(container)

# remove the items from list
lis=list(24,"Nepal")
print(lis)
print(lis[-2])
print(lis)

# Arrays
# Creating the Arrays
arr=array(c(1:12),dim = c(2,3,3))
arr

# accessing the elements in array
arr[2,2,2]

# dataframe
# Creating the dataframe
df=data.frame(sr_no=c(1:3),name=c("PD","ND","JD"),age=c(19,13,45))
print(df)

# access the dataframe column
df$name

df[1]

df[["age"]]


# combining the dataframes by row using rbind()
df2=data.frame(sr_no=c(4,5),name=c("SJ","LP"),age=c(20,23))
df2
df=rbind(df,df2)
df

# combining the dataframes by column using cbind()
df3=data.frame(hobby=c("Cycle","reading","Swiming","gaming","sitting"))
df3

df=cbind(df,df3)
nrow(df)
df
df=df[-5]
df

# summarize the dataframe
summary(df)

# subset function
subset(df,age>13)

# Factors
# Creating the factors
gender=factor(c("male","female","male","female","transgender"))
gender

df[1,]

df[1:2,]
