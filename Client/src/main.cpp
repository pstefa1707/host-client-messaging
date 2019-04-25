#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <string.h>
#include <iostream>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <arpa/inet.h>

int main(int argc, char *argv[]) {
	struct sockaddr_in address;
	const int PORT = 25565;
	int socket_fd = socket(AF_INET, SOCK_STREAM, 0);
	if (socket_fd < 0) {
		printf("Socket creation failed!");
	}	
	memset((char *)&address, 0, sizeof(address));
	std::string serverTmp = {0};
	std::cout << "Enter IP to connect to: ";
	getline(std::cin, serverTmp);
	in_addr_t server = inet_addr(serverTmp.c_str());
	address.sin_port = htons(PORT);
	address.sin_addr.s_addr = server;
	address.sin_family = AF_INET;
	
	if (connect(socket_fd, (struct sockaddr *)&address, sizeof(address)) < 0) {
		printf("error occured when connecting!");
	}
	while (1) {
		std::string message = {0};
		std::cout << "\nEnter message: ";
		getline(std::cin, message);
		int wrt = write(socket_fd, message.c_str(), sizeof(message));
		if (wrt < 0) {
			printf("Failed!");
		}
		printf("\nMessage sent: %s\n", message.c_str());
		char recieved[1000024];
		int reply = recv(socket_fd, recieved, sizeof(recieved), 0);
		if (reply < 0) 
			printf("ERROR reading from socket");
		printf("\nMessage Recieved: %s\n", recieved);
	}

}