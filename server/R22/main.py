import socket
import os


LOCALHOST = socket.gethostbyname(socket.gethostname())
PORT = 8080

PATH = os.getcwd()
files = {}


def wait_for_connection():
    server = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

    try:
        server.bind((LOCALHOST, PORT))
        print("Waiting for client request...")
        server.listen(1)
        client_connection, client_address = server.accept()
        wait_for_command(client_connection, client_address, server)
    except:
        if client_connection is not None:
            client_connection.close()
            server.close()
        wait_for_connection()


def wait_for_command(client_connection, client_address, server):
    while True:
        try:
            print("Connected client: ", client_address)
            data = client_connection.recv(1024)

            if data.decode().strip() == "":
                client_connection.close()

            if data.decode().strip() == "get_scripts()":
                get_scripts(client_connection, client_address, server)

            if data.decode().strip() == "execute":
                #os.system("cd ~/texxit && screen -dmS texxit ./ServerStart.sh")
                print("Executing...")
                data = client_connection.recv(1024)
                print("." + files[data.decode().strip()])
                os.system("cd " + files[data.decode().strip()] + " && ./" + data.decode().strip())

            if data.decode().strip() == "start":
                os.system("cd ~/texxit && screen -dmS texxit ./ServerStart.sh")


            print("From client: ", data.decode())
        except:
            print("User Disconnected")
            client_connection.close()
            server.close()
            wait_for_connection()
    client_connection.close()
    server.close()
    wait_for_connection()

def get_scripts(client_connection, client_address, server):
    print("Getting Scripts...")
    strFiles = ""
    for key in files:
        strFiles += key + ","

    client_connection.send(bytes(strFiles, 'UTF-8'))

    wait_for_command(client_connection, client_address, server)


if __name__ == "__main__":
    print(PATH + "/scripts")
    for r, d, f in os.walk(PATH + '/scripts/'):
        for file in f:
            print(file)
            if '.sh' in file:
                print(file)
                files[file] = r

    print("Server Started")

    wait_for_connection()
