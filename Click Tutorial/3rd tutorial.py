import click

"""3rd Tutorial on click module"""

@click.command(name="start")
def main(name):
    #confirm function helps to take confirmation instead of usiing the confirmation option decorator
    if click.confirm(text="Are you sure",default="no",show_default=True):
        click.echo("Yes sure")
    else:
        click.echo("Not sure")

# prompt function
@click.command()
def main2():
    name=click.prompt("Select ",show_choices=True,type=click.Choice(["Java","Python"]))
    click.echo(f"{name}")


main2()