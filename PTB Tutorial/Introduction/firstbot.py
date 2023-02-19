from telegram.ext import *
from telegram import Update

# this function just welcomes the new user or greet it.
async def start(update: Update, context: ContextTypes.DEFAULT_TYPE):
    await context.bot.send_message(update.message.chat_id, f"Hii {context._user_id} Welcome to the bot")

# this function is helpful when you write the command with text eg:/cap hello bro so this will recieve hello bro in a splited list
async def caps(update:Update,context:ContextTypes.DEFAULT_TYPE):
    print(context.args)
    await context.bot.send_message(update.effective_message.chat_id,text=f"you wrote this {context.args}")

# this function just sends the message as user send it to the bot
async def echo(update: Update, context: ContextTypes.DEFAULT_TYPE):
    await context.bot.send_message(update.effective_message.chat_id, text=update.message.text)

if __name__ == '__main__':
    # this class is used to make initialize the bot with token
    app = ApplicationBuilder().token(
        "6000547107:AAE5oj0L13-BRu2-dPj8l-rxKhecku1nTPg").build()

    # This class is used to add the command handler means when you will type /start in bot this function will be called
    starthandler = CommandHandler('start', start)
    capshandler=CommandHandler('cap',caps)
    # this class is used to add the message handler
    # filters is used to add that the message should be text or command only
    echohandler = MessageHandler(filters=filters.TEXT or filters.COMMAND, callback=echo)
    
    
    # used to add the handler
    app.add_handler(starthandler)
    app.add_handler(capshandler)
    app.add_handler(echohandler)
    
    # used the run the bot till any update it recieves
    app.run_polling()
