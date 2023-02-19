from telegram import Bot
from telegram.ext import ApplicationBuilder
import asyncio

# this was just the introduction to the bot working
async def main():
    bot=Bot(token="6000547107:AAE5oj0L13-BRu2-dPj8l-rxKhecku1nTPg")
    async with bot:
        # getting the bot user created the bot.
        # print(await bot.get_me())
        
        # getting the bot updates 
        # print(await bot.get_updates())
        
        # this function send the message to the chat id that we have got from the get_updates() method.
        await bot.send_message(chat_id=1664053896,text="Welcome to the bot")
        
if __name__=='__main__':
    asyncio.run(main())