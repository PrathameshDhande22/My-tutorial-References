import socket

s = socket.socket()
s.connect(("127.0.0.1", 3000))
server = ""
while server != "exit":
    client = input("Enter Client: ")
    s.sendall(client.encode())
    server = s.recv(3445).decode()
    print("Server Says ", server)
