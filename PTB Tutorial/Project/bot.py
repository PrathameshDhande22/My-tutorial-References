from telegram.ext import *
from telegram import *
import message

"""Todo Bot"""


class Todo:
    def __init__(self):
        self.app = Application.builder().token(
            "6000547107:AAE5oj0L13-BRu2-dPj8l-rxKhecku1nTPg").build()
        self.app.add_handler(CommandHandler("start", self.start))
        self.app.add_handler(CommandHandler("help", self.help))
        self.app.add_handler(CommandHandler("new", self.new))
        self.app.add_handler(CommandHandler("list", self.listtodo))
        self.app.add_handler(CallbackQueryHandler(self.updateTask))
        self.app.add_handler(MessageHandler(filters.Text(
            ["Create Todo", "Cancel"]), callback=self.create))
        self.app.add_handler(MessageHandler(
            filters=filters.TEXT & (~ filters.COMMAND), callback=self.todos))
        self.newtodo = ""
        self.app.run_polling()

    async def start(self, update: Update, context: ContextTypes.DEFAULT_TYPE):
        context.user_data[update.effective_user.id] = []
        await context.bot.setMyCommands([BotCommand("start", "ReStart the Bot"), BotCommand("help", "How to Use?"), BotCommand("new", "Creates the New Todo"), BotCommand("list", "List the Todo")])
        await update.message.reply_text(text=message.WELCOME_TEXT.format(update.effective_user.first_name), parse_mode=constants.ParseMode.HTML)

    async def help(self, update: Update, context: ContextTypes.DEFAULT_TYPE):
        await update.message.reply_text(text=message.HELP_TEXT, parse_mode=constants.ParseMode.HTML)

    async def new(self, update: Update, context: ContextTypes.DEFAULT_TYPE):
        keyboard = [[KeyboardButton("Create Todo")], [
            KeyboardButton("Cancel")]]
        await context.bot.sendMessage(update.effective_chat.id, text="Enter The Todo Name :", reply_markup=ReplyKeyboardMarkup(keyboard, resize_keyboard=True))

    async def create(self, update: Update, context: ContextTypes.DEFAULT_TYPE):
        btn = update.message.text
        if btn == "Create Todo":
            if self.newtodo == "" or self.newtodo == " ":
                await context.bot.send_message(update.effective_chat.id, text="Empty TODO", reply_markup=ReplyKeyboardRemove())
                return
            else:
                context.user_data[update.effective_user.id].append(
                    {"title": self.newtodo, "Completed": False})
                self.newtodo = ""
            await context.bot.send_message(update.effective_chat.id, text="Todo Created", reply_markup=ReplyKeyboardRemove())
        else:
            await context.bot.send_message(update.effective_chat.id, text="Todo Canceled", reply_markup=ReplyKeyboardRemove())

    async def todos(self, update: Update, context: ContextTypes.DEFAULT_TYPE):
        self.newtodo = update.message.text

    async def listtodo(self, update: Update, context: ContextTypes.DEFAULT_TYPE):
        keyboard = []
        for l in context.user_data[update.effective_user.id]:
            text = f"{l['title']} ✅ " if not l["Completed"] else f"{l['title']} ❌ "
            keyboard.append([InlineKeyboardButton(
                text=text, callback_data=l["title"])])
        await context.bot.send_message(update.effective_chat.id, text=message.LIST_TEXT, parse_mode=constants.ParseMode.HTML, reply_markup=InlineKeyboardMarkup(keyboard))

    async def updateTask(self, update: Update, context: ContextTypes.DEFAULT_TYPE):
        query = update.callback_query.data
        keyboard = []
        for l in context.user_data[update.effective_user.id]:
            if l["title"] == query and not l["Completed"]:
                l["Completed"] = True
                await update.callback_query.answer(text=f"Completed {query}", show_alert=True)
                text = f"{l['title']} ✅ " if not l["Completed"] else f"{l['title']} ❌ "
            elif l["title"] == query and l["Completed"]:
                l["Completed"] = False
                await update.callback_query.answer(text=f"UnDone {query}", show_alert=True)
                text = f"{l['title']} ✅ " if not l["Completed"] else f"{l['title']} ❌ "
            else:
                text = f"{l['title']} ✅ " if not l["Completed"] else f"{l['title']} ❌ "
            keyboard.append([InlineKeyboardButton(
                text=text, callback_data=l["title"])])
        await update.callback_query.edit_message_text(text=message.LIST_TEXT, parse_mode=constants.ParseMode.HTML, reply_markup=InlineKeyboardMarkup(keyboard))


if __name__ == '__main__':
    ob = Todo()
