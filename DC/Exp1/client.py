from xmlrpc import client

c = client.ServerProxy("http://localhost:4000")
print(c.greet("Prathamesh"))
print(c.add(3, 4))
print(c.mul(5, 2))
print(c.sub(5, 5))
