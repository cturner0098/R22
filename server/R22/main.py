import socket

LOCALHOST = "10.230.209.87"
PORT = 8080

server = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
server.bind((LOCALHOST, PORT))
server.listen(1)

print("Server Started")
print("Waiting for client request...")

clientConnection, clientAddress = server.accept()

while True:
    print("Connected client: ", clientAddress)
    data = clientConnection.recv(1024)
    print("From client: ", data.decode())
    clientConnection.send(bytes("Successfully connected to server!", 'UTF-8'))
