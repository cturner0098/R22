import socket
import os

LOCALHOST = socket.gethostbyname(socket.gethostname())
PORT = 8080

server = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
server.bind((LOCALHOST, PORT))
server.listen(1)

PATH = os.getcwd()
files = []

for r, d, f in os.walk(PATH):
    for file in f:
        if '.sh' in file:
            files.append(os.path.join(r, file))


def wait_for_connection():
    print("Waiting for client request...")
    client_connection, client_address = server.accept()

    while True:
        try:
            print("Connected client: ", client_address)
            data = client_connection.recv(1024)

            if data.decode().strip() == "get_scripts()":
                get_scripts(client_connection)

            if data.decode().strip() == "start":
                os.system("cd ~/texxit && screen -dmS texxit ./ServerStart.sh")
                print("Texxit Server Started?")

            print("From client: ", data.decode())
        except:
            print("User Disconnected")
            client_connection.close()
            wait_for_connection()


def get_scripts(client_connection):
    print("Getting Scripts...")
    for file in files:
        client_connection.sendall(file)



if __name__ == "__main__":
    print("Server Started")
    wait_for_connection()