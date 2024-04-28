from socket import socket
from threading import Thread

s = socket()
s.bind(("127.0.0.1", 4000))
s.listen()
print("Server is Listening on ", s.getsockname())
clients: list[socket] = []


def handleClient(clientSocket: socket):
    name = clientSocket.recv(355).decode()
    print(name, "Joined")
    while True:
        try:
            message = clientSocket.recv(244)
            broadcast(message.decode(), name, clientSocket)
        except Exception as e:
            print("Error Occured")
            break


def broadcast(message: str, name: str, clientSocket: socket):
    for client in clients:
        if client != clientSocket:
            client.sendall(f"Received from {name} : {message}".encode())


while True:
    clientSocket, addr = s.accept()
    clients.append(clientSocket)
    Thread(target=handleClient, args=(clientSocket,)).start()
