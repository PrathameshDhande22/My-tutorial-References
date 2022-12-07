import click
"""
    click 2nd Tutorial on arguments
    """

# passing the arguments
@click.command(name="hel")
@click.argument("name")
def say(name):
    click.echo(f"Welcome! {name}")

# specifying the type
@click.command(name="var")
@click.argument("varible",type=click.STRING) # in this you can define the many type you can refer to documentation
def declarevar(varible):
    click.echo(f"{type(varible)}")

#invoke without command
@click.group(invoke_without_command=False)
@click.pass_context
def main1(ctx):
    if ctx.invoked_subcommand is None:
        click.echo("hello ctx")
    else:
        click.echo("hello")

# merging multiple commands
@click.group()
def cli1():
    pass

@cli1.command()
def getname():
    """command of cli1"""
    click.echo("Getname of cli1 commands used")

@click.group()
def cli2():
    pass

@cli2.command()
def getname1():
    """command of cli2"""
    click.echo("getname of cli2 command called")

cmd=click.CommandCollection(sources=[cli1,cli2]) # CommandCollection() class is used to merge the group decorator function


# multi chaining commands
@click.group(chain=True)
def code():
    pass

@click.command("coder")
def coder():
    click.echo("code coder command is used")

# short_help parameter is used to define the short meassage of the command in commands listing
@click.command("ccoder",short_help="c language coder")
def ccoder():
    click.echo("c language coder")

code.add_command(coder)
code.add_command(ccoder)



if __name__=='__main__':
    # say()
    # declarevar()
    # cmd()
    code()
    