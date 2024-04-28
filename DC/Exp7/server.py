from socket import socket
from threading import Thread

s = socket()
s.bind(("127.0.0.1", 4000))
s.listen()
print("Server Listening on Port", s.getsockname())

def receive_message(s: socket):
    while True:
        data = s.recv(1024).decode()
        print(data)

while True:
    newuser, addr = s.accept()
    print(addr, "Connected to Server")
    Thread(target=receive_message, args=(newuser,)).start()
