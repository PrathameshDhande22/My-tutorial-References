# Tutorial 1 based on basics of R

# printing hello world
msg <- "Hello World"
print(msg)

# these is the single line comment

# Variables

# Declaring the variables
a=1.8
print(a)

# declaring the method another type
a<-1.2
print(a)


# Types of variables

# Boolean Variables
b=TRUE
print(b)
print(typeof(b))
print(class(b))

# Integer Variables
c=12L
print(c)
print(class(c))

# floating point variables or numeric objects
d=13.2
print(class(d))
print(d)

# Character Variables
alpha='a'
print(alpha)
print(class(alpha))
print(typeof(alpha))

# String Variables
msg="These is the String Variable"
print(msg)
print(class(msg))

# R constants
# Declaring the constants using the <- symbol
const<- "Constant Varialb"
print(const)
print(class(const))

# Integer Constant
# Hexadecimal Value
he_datat=0x14L
print(he_datat)
print(typeof(he_datat))

# Exponential Value
ex_data=2e3L
print(ex_data)
print(typeof(ex_data))

# Complex Constant
complex_data=1+3i
print(complex_data)
print(class(complex_data))
da=complex(real = 3L,imaginary = 3.1)
print(da)

# null constant
nul_data<- NULL
print(nul_data)
print(class(nul_data))

# Built in R Constants
print(letters)
print(LETTERS)
print(month.name)
print(month.abb)
print(pi)

# Print output
print("Hello")
print(paste("Hello"))
print(paste("Months = ",month.name))

# sprintf function
a=1.2
b=2L
sprintf("Value of a is %f and b is %i",a,b)

# Operator in R
a=1
b=2
print(a!=b)
print(a==b)
print(a<b)
print(a&b)
