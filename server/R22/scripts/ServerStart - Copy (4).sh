#!/bin/sh

# Start the server.
start_server() {
    java -server -Xms2G -Xmx4G -jar forge-1.12.2-14.23.5.2847-universal.jar nogui
}

start_server