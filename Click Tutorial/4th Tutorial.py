import click

# documenting the scripts

@click.group()
def main():
    """ The main command runs here"""
    pass

@main.command()
def second():
    """ The main command group 2nd command"""
    click.echo("main method ka second ")


# meta vars change the input in <name> format
#metavar parameter should be passed to changed
@click.group()
def cli():
    pass

@cli.command()
@click.option("--print",metavar='<print>')
@click.argument("name",metavar="[enter]")
def slight(print,name):
    click.echo(f"{name} and to print {print}")

slight()