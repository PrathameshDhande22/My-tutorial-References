from telegram import *
from telegram.ext import *


async def start(update: Update, context: ContextTypes.DEFAULT_TYPE):
    await extract(context.bot)
    await update.message.reply_text("You Started the Bot")


async def button(update: Update, context: ContextTypes.DEFAULT_TYPE):
    """This Function just shows the Inline Keyboard button"""
    keyboard = [
        [
            InlineKeyboardButton("Btn 1", callback_data="1"),
            InlineKeyboardButton("Btn 2", callback_data="2")
        ],
        [
            InlineKeyboardButton("Btn 3", callback_data="3")
        ]]
    reply = InlineKeyboardMarkup(keyboard)
    await update.message.reply_text("Please Choose :", reply_markup=reply)


async def databack(update: Update, context: ContextTypes.DEFAULT_TYPE):
    """This function is used to help with the callback data assigned to each button or to communicate with the button"""
    query = update.callback_query
    await query.answer(text=f"You Selected the {query.data} button", show_alert=True)
    await query.edit_message_text(f"You Selected the {query.data} button")

async def replybtn(update:Update,context:ContextTypes.DEFAULT_TYPE):
    markup=ReplyKeyboardMarkup([["Btn 1","Btn 2"],["Btn 3","Btn 4"]],one_time_keyboard=True)
    await context.bot.send_message(update.effective_chat.id,text="Select",reply_markup=markup)

async def extract(bot:Bot):
    await bot.set_my_commands(commands=[BotCommand("start","Starts"),BotCommand("btn","Shows the btn"),BotCommand("reply","Replies to you"),BotCommand("send","Send the Doc")])
    print(bot.username)
    
async def sendPhoto(update:Update,context:ContextTypes.DEFAULT_TYPE):
    """this function just sends the user uploaded photo to the user only"""
    id=update.effective_chat.id
    print(update.message.photo[0])
    await context.bot.send_photo(update.effective_chat.id,photo=update.message.photo[0],caption="yours photo only")

app = ApplicationBuilder().token(
        "6000547107:AAE5oj0L13-BRu2-dPj8l-rxKhecku1nTPg").build()
app.add_handler(CommandHandler('start', start))
app.add_handler(CommandHandler('btn', button))
app.add_handler(CallbackQueryHandler(databack))
app.add_handler(CommandHandler("reply",replybtn))
app.add_handler(MessageHandler(filters=filters.PHOTO,callback=sendPhoto))

app.run_polling()