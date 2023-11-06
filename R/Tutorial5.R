# Tutorial 5 

# Data Visualization

# barplot
temp=c(122,145,200,340,289,520,45)
barplot(temp,xlab = "Degree Celsius",ylab = "Temperature in Degree",
names.arg = c("Sunday","Monday","Tuesday","Wednesday","Thursday","Firday","Saturday"),
main = "Temperature",
col = c("red","green","blue","pink","yellow","lightblue","orange"),
legend.text = c("Sunday","Monday","Tuesday","Wednesday","Thursday","Firday","Saturday"),
density = c(30,40),
border = TRUE
)

#histogram
help(hist)
hist(temp,col = "red",main = "Temperature")

# Pie chart
help("pie")
expenditure <- c(600, 300, 150, 100, 200)
pie(expenditure,labels = c("TV","Oven","Laptop","Mouse","Keyboard"),col = c("red","green","blue","pink","yellow"),main="Expenditure",bg="yellow")

# box plot
df=datasets::airquality
df
boxplot(df[,1:3],notch = TRUE,col = c("red","green","blue"))

# strip plot
df=datasets::airquality
df
data=list(df$Wind[0:40],df$Ozone[0:40])
data
stripchart(data)

#plot 
plot(c(4,1,6,9,10),c(1,2,3,4,5),type = "l")

colors()
