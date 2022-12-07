import click

@click.command()
def main():
    # click.style() function helps to modify the color of the text or other functionalites to text
    click.echo(click.style(text="Hello Prathamesh",underline=True,bg="green")) # here it underline the text and green color as background 
    # instead of using click.echo(click.sytle()) you can use secho() 
    click.secho(message="Hlello prathamesh from ssecho",fg="green",blink=True)
    # this method allows to print the text in the pager mode
    click.echo_via_pager("""Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo. Nullam dictum felis eu pede mollis pretium. Integer tincidunt. Cras dapibus. Vivamus elementum semper nisi. Aenean vulputate eleifend tellus. Aenean leo ligula, porttitor eu, consequat vitae, eleifend ac, enim. Aliquam lorem ante, dapibus in, viverra quis, feugiat a, tellus. Phasellus viverra nulla ut metus varius laoreet. Quisque rutrum. Aenean imperdiet. Etiam ultricies nisi vel augue. Curabitur ullamcorper ultricies nisi. Nam eget dui. Etiam rhoncus. Maecenas tempus, tellus eget condimentum rhoncus, sem quam semper libero, sit amet adipiscing sem neque sed ipsum. Nam quam nunc, blandit vel, luctus pulvinar, hendrerit id, lorem. Maecenas nec odio et ante tincidunt tempus. Donec vitae sapien ut libero venenatis faucibus. Nullam quis ante. Etiam sit amet orci eget eros faucibus tincidunt. Duis leo. Sed fringilla mauris sit amet nibh. Donec sodales sagittis magna. Sed consequat, leo eget bibendum sodales, augue velit cursus nunc""")


@click.command()
def hell():
    # clears all form the terminal
    click.clear()
    # opens the default text editor to edit the text
    click.edit("text.txt")
    # launches the particular web in the browser
    click.launch("https://www.google.com")


# progress bar
import time
@click.command()
def prog():
    s=[i for i in range(5)]
    with click.progressbar(s) as f:
        for a in f:
            click.echo(f"{a} ghh")
            time.sleep(2)


# defining context manager
def say(ctx:click.Context,param,value):
    print()

@click.command()
@click.option("--show",callback=say)
def show(show):
    click.echo("hello")

show()