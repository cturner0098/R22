#!/bin/sh

# Start the server.
start_server() {
    cd ~/texxit && screen -dmS texxit ./ServerStart.sh
}

start_server