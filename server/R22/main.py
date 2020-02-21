import socket
import os


LOCALHOST = socket.gethostbyname(socket.gethostname())
PORT = 8080

PATH = os.getcwd()
files = {}


def wait_for_connection():
    # Set the server socket
    server = socket.socket(socket.AF_INET, socket.SOCK_STREAM)

    try:
        # Clear the old port and bind the new ones
        print("Binding {0}:{1}".format(LOCALHOST, PORT))
        server.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)
        server.bind((LOCALHOST, PORT))
        server.listen(1)
        print("Server Started!")

        # Wait for the clients connection
        print("Waiting for client request...")
        client_connection, client_address = server.accept()

        # Wait for clients commands
        print("Connected client: ", client_address)
        wait_for_command(client_connection, client_address, server)
    except:
        # Check if client exists
        if client_connection is not None:
            client_connection.close()
            server.close()

        # If we got here, we gotta look for a new connection
        wait_for_connection()


def wait_for_command(client_connection, client_address, server):
    # Infinite loop to keep client connected
    while True:
        try:
            # Wait for user command
            print("Waiting for command...")
            data = client_connection.recv(1024)

            # Sometimes when users close, it loops back. This is a quick n dirty.
            if data.decode().strip() == "":
                client_connection.close()

            # Check if the users wants to get scripts
            if data.decode().strip() == "get_scripts()":
                get_scripts(client_connection, client_address, server)

            # Execute selected script
            if data.decode().strip() == "execute":
                print("Executing...")
                data = client_connection.recv(1024)
                print("." + files[data.decode().strip()])
                # Change directory to script and execute it
                os.system("cd " + files[data.decode().strip()] + " && ./" + data.decode().strip())
        except:
            # We get here if the user aborts connection, so close all connections and wait for another
            print("User Disconnected...")
            client_connection.close()
            server.close()
            wait_for_connection()

    # Some edge cases break the loop, so disconnect in case
    print("User Disconnected...")
    client_connection.close()
    server.close()
    wait_for_connection()


def get_scripts(client_connection, client_address, server):
    # Gets the scripts and append them to a string to later be split
    print("Getting Scripts...")
    strFiles = ""
    for key in files:
        strFiles += key + ","

    # Send scripts to client
    client_connection.send(bytes(strFiles, 'UTF-8'))

    # Wait for another command
    wait_for_command(client_connection, client_address, server)


if __name__ == "__main__":
    # On load, load the scripts and append them to files{}
    print("Script Path: " + PATH + "/scripts")
    for r, d, f in os.walk(PATH + '/scripts/'):
        for file in f:
            if '.sh' in file:
                print("Script " + file + " loaded.")
                files[file] = r

    # Start the server and await connections
    wait_for_connection()
