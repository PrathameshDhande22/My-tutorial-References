from socket import socket

s = socket()
s.connect(("127.0.0.1", 4000))
s1 = socket()
s1.bind(("127.0.0.1", 4001))
s1.listen()
user, addr = s1.accept()
token = "TOKEN"
while True:
    if token == "TOKEN":
        choice = input("Do you want to Send Data?\nEnter Yes or No: ")
        if choice.lower() == "yes":
            data = input("Enter Data:")
            s.sendall(data.encode())
        user.sendall("TOKEN".encode())
    print("Waiting for Token")
    data = user.recv(1024).decode()
