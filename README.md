# ClientServer
TCP Client and Server programs written in C#.

## Purpose
The purpose of this client server project is to provide a standalone project which can be consumed by one of my
other projects, specifically the GDK. While it would be nice to be able to handle multiple clients, it is just
not necessary for the GDK.

## Requirements

Server shall handle a single client at a time.
Server shall listen for a client connection.
Server shall keep client connection open until the client disconnects.
Server shall listen for a new client connection once the client disconnects.
Server shall provide a mechanism to notify of client connection.
Server shall provide a mechanism to notify of client disconnection.
Server shall provide a mechanism to notify of any data received from client.
Server shall provide a mechanism to send data to client.

Client shall connect to the server.
Client shall keep connection to server open until as long as it wishes to communicate with server.
Client shall close the connection to server if possible.
Client shall provide a mechanism to notify once connected to server.
Client shall provide a mechanism to notify once disconnected from server.
Client shall provide a mechanism to notify of any data received from server.
Client shall provide a mechanism to send data to server.

