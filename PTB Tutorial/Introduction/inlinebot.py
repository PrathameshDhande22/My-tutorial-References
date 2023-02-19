from telegram.ext import *
from telegram import *


async def start(update: Update, context: ContextTypes.DEFAULT_TYPE):
    text = "Welcome "+update.effective_chat.first_name + \
        " to the bot \n This is Inline bot tutorial"
    await context.bot.send_message(update.effective_message.chat_id, text=text)

# This function is to use the bot as the inline query result
async def inline(update: Update, context: ContextTypes.DEFAULT_TYPE):
    query = update.inline_query.query
    if not query:
        print("This is not query")
    result = []
    result.append(InlineQueryResultArticle(id=update.inline_query.id, title="Inline", input_message_content=InputTextMessageContent(query.upper())))
    await context.bot.answer_inline_query(update.inline_query.id, results=result)

if __name__ == '__main__':
    app = Application.builder().token(
        "6000547107:AAE5oj0L13-BRu2-dPj8l-rxKhecku1nTPg").build()
    startcommand = CommandHandler('start', start)

    # used to add the handler for inline query
    inlinehandler = InlineQueryHandler(inline)

    app.add_handler(startcommand)
    app.add_handler(inlinehandler)
    app.run_polling()
