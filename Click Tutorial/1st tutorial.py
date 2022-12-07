#importing the module
import click

"""
    Click tutorial for options 1st Tutorial
    """

# defining the main group as the main command to be called
@click.group()
@click.version_option(message="This is the newest version",version="Version 1.0")
def main():
    pass

#command with argument and option
@click.command()
@click.argument("name")  # argument to be provided and pass to the function with the same name it is applicable to argument and option also.
@click.option("--n",default=1,help="print the numbers")  # for more parameter refer to the docmentation.
def getname(name,n):
    print(n) # to print the number as its not supported by click.echo() method to print integer type.
    click.echo(name) 

@click.command()
# mutliple option for a single command note that  the parameter is treated when --string then parameter should be string if string single parameter defined then parameter should be passed to the function is string only. 
@click.option("-s",help="Printing the rollno",default="Prathamesh",show_default=True) # showing the default value when help option is called
@click.option("-n",help="The number count",default=1)
def getno(s,n):
    # click.echo(f"Hello you roll no is {n} {s}")
    if n:
        click.echo(f"rollno is {n}")
    elif s:
        click.echo(f"Name is {s}")
    else:
        click.echo(f"Hello you roll no is {n} {s}")
    
    
@click.command(name="Choice") # name parameter will give the name instead of the default function name
@click.option("--select",required=True,type=str) # to make the option required
def select(select):
    click.echo(f"you seleced {select}")


# to show the mutliple value argument
@click.command()
@click.option("-n",nargs=2,help="Multiple value argument")
def multi(n):
    click.echo(f"{n}") # it will retun it in the tuple

# mutiple option 
@click.command()
# metavar defines how the data is to presented in the command line
@click.option("-m","--message",multiple=True,help='to print the message in mutiple times',metavar="this is the print message")
def printMessage(message):
    click.echo(f"Message is :{message}")


# the boolean flag should be given in / operator the first value should be passed and it returns the firsst value as true.
@click.command()
@click.option("--close/--open",default=False,help="Opens the document or closes the doucument")
def closeoropen(close):
    click.echo(f"{close}")


# this conly command allow only to choice the options form the fixed values
@click.command(name="conly")
@click.option("--choice",type=click.Choice(choices=["Java","Python"]),help="choice your favourite subject")
def coly(choice):
    click.echo(f"Your favourite subject is {choice}")

# prompt parameter asks the user to enter the specified text as by his choice
@click.command()
@click.option("--name",prompt="Enter Your Name : ")
def prompt(name):
    click.echo(f"You entered the name as :{name}")


# password prompts
@click.command()
# this method has inbuilt confirmation password
@click.password_option("--passwd",help="Verify the user")
def see(passwd):
    click.echo(f"{passwd}")

#single passsword
@click.command()
# hide input will hide the input confirmation_prompt parameter will ask to renter the
@click.option("--passwd",help="Single entered password",prompt="Enter the password :",hide_input=True)
def sinpass(passwd):
    click.echo(f"Password is :{passwd}")


@click.command()
# asks the confirmation option in y or n if y then true else aborted message will be thrown
@click.confirmation_option(prompt="Are You Sure ")
def sure():
    click.echo("Sured")



# add the command to the main command which is initiated by group() decorator
main.add_command(prompt)
main.add_command(sure)
main.add_command(sinpass)
main.add_command(see)
main.add_command(getname)
main.add_command(coly)
main.add_command(getno)
main.add_command(select)
main.add_command(multi)
main.add_command(printMessage)
main.add_command(closeoropen)


@click.command()
def printing():
    click.echo("1st tutorial") # to print in the console use click.echo() method instead of print() method.

if __name__=='__main__':
    main()
