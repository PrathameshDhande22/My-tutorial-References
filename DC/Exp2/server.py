import socket

s = socket.socket()
s.bind(("127.0.0.1", 3000))
s.listen()
newuser, addr = s.accept()
server = ""
print("Connected to ", addr)
while server != "exit":
    client = newuser.recv(5445).decode()
    print("Client Says:", client)
    server = input("Enter Server: ")
    newuser.sendall(server.encode())
