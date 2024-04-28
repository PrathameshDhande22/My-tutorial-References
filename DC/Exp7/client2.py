from socket import socket

s = socket()
s.connect(("127.0.0.1", 4000))
s1 = socket()
s1.connect(("127.0.0.1", 4001))
token = ""
while True:
    print("Waiting for Token")
    token = s1.recv(1024).decode()
    if token == "TOKEN":
        choice = input("Do you want to Send Data?\nEnter Yes or No: ")
        if choice.lower() == "yes":
            senddata = input("Enter Data:")
            s.sendall(senddata.encode())
        s1.sendall("TOKEN".encode())
