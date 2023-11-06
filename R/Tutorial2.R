# Tutorial 2  based on basics of R

# if statement
a=1
b=2
if (a==b){
  print("Yes")
}

# if else statement
age<-14
if(age>=18){
  print("You are eligible")
}else{
  print("You are not eligible")
}

# if..else if...else statement
if(age<=17 & age>=10){
  print("You are Minor")
}else if(age>=18){
  print("Your are eligible")
}else{
  print("You are not eligible")
}

# ifelse function
age<-17
print(ifelse(age>=18,"TRUE","False"))


# While loop
no=0
while(no<=10){
  print(no)
  no=no+1
}

# break statement
no=0
while(no<=10){
  print(no)
  if(no==6){
    break
  }
  no=no+1
}

# next statement
no=0
while(no<=10){
  if(no==5){
    no=no+1
    next
  }
  print(no)
  no=no+1
}

# for loop
number=c(1,2,3,4)
for(x in number){
  print(x)
}

# repeat loop
no=0
repeat{
  print(no)
  if(no==10){
    break
  }
  no=no+1
}

# function simple funtion
power=function(a){
  print(a)
  return (a+10)
}

# calling the function
print(power(1))

# default argument
square=function(a=10){
  return (a^2)
}
print(square())

# nested function
power=function(a){
  exponent=function(b){
    return (a^b)
  }
  return (exponent)
}
print(power(2)(2))

# switch statement
x=3
ans=switch(x,"Hello","Say")
print(ans)
