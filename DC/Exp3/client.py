import socket
from threading import Thread

s = socket.socket()
s.connect(("127.0.0.1", 4000))

name = input("Enter Your Name: ")
s.sendall(name.encode())


def receiveMessage(clientSocket: socket.socket):
    try:
        while True:
            server_msg = clientSocket.recv(344).decode()
            print(server_msg)
    except Exception as e:
        print("Disconnected from server")


Thread(target=receiveMessage, args=(s,)).start()
while True:
    message = input()
    if message == "exit":
        break
    s.sendall(message.encode())
s.close()
