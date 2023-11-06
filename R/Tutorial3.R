# Tutorial 3  based on  Data structure

# Declaring the strings
name="Prathamesh"
name2="Prashant"
sprintf("%s %s",name,name2)

# length of the string
print(nchar(name))

# join two strings
joined=paste(name,name2)
print(joined)

# uppercase string
print(toupper(name))

# lowercase string
print(tolower(name))

# Multiline string
sentence="
My name is
prathamesh
dhande
"
print(sentence)

# Vectors

# Declaring Vectors
emp=c("Nidhi","Prathamesh","Prashant")
print(emp)

# acessing specific elements
print(emp[1])

# changing the elements
emp[1]="Sushant"
print(emp)

print(emp[1:2])

# creating the sequence of a number
nums=1:10
print(nums)
print(class(nums))

# repeat vectors
num=rep(c(1,2,3),4)
print(num)

# looping over vectors
for(x in num){
  print(x)
}

# length of a vector
print(length(emp))
