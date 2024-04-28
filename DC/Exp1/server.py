from xmlrpc import server
from adder import Adder, sayHello

PORT = 4000
try:
    s = server.SimpleXMLRPCServer(addr=("127.0.0.1", PORT))
    s.register_instance(Adder())
    s.register_function(sayHello, "greet")
    print("Server is Listening on ", s.server_address)
    s.serve_forever()
except KeyboardInterrupt as e:
    s.server_close()
    print("Disconnected")
