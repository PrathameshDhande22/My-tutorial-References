from telegram import *
from telegram.ext import *

# whenever this command is called it will reply to the user directly
async def say(update: Update, context: ContextTypes.DEFAULT_TYPE):
    # this line says that whenever it will be called it will first send the action of like typing or uploading
    await context.bot.send_chat_action(chat_id=update.effective_message.chat_id, action=constants.ChatAction.TYPING)

    await update.message.reply_text("You can do it")


async def marking(update: Update, context: ContextTypes.DEFAULT_TYPE):
    # this uses the text to parse as a markdown style
    text1 = "**bold** *italic* [clickhere](https://www.google.com)"
    await context.bot.send_message(update.effective_chat.id, text=text1, parse_mode=constants.ParseMode.MARKDOWN_V2)

    # this uses the text to parse as a html style
    text2 = "<b>Bold Text</b> <a href='www.google.com'>Hllo</a>"
    await context.bot.send_message(chat_id=update.effective_chat.id, text=text2, parse_mode=constants.ParseMode.HTML)


async def buttons(update: Update, context: ContextTypes.DEFAULT_TYPE):
    # showed like row 1 has 2 button ,row 2 has 2 button
    keybord = [['left', 'right'], ['top', 'bottom']]
    # used to return keyboard in with the text
    reply = ReplyKeyboardMarkup(keybord)
    # used to reply with KeyboardButton
    await context.bot.send_message(update.effective_chat.id, text="Custom Keyboard", reply_markup=reply)


if __name__ == '__main__':
    app = ApplicationBuilder().token(
        "6000547107:AAE5oj0L13-BRu2-dPj8l-rxKhecku1nTPg").build()
    app.add_handler(CommandHandler('start', say))
    app.add_handler(CommandHandler('format', marking))
    app.add_handler(CommandHandler('but', buttons))
   
    app.run_polling()
