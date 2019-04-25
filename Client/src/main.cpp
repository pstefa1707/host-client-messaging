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
	} else {
		std::cout << socket_fd << std::endl;
	}
	
	memset((char *)&address, 0, sizeof(address));
	in_addr_t server = inet_addr("192.168.0.15");
	address.sin_port = htons(PORT);
	address.sin_addr.s_addr = server;
	address.sin_family = AF_INET;
	
	if (connect(socket_fd, (struct sockaddr *)&address, sizeof(address)) < 0) {
		printf("error occured when connecting!");
	}
	char buffer[1024];
	std::cout << "Enter message to send >> ";
	std::cin >> buffer;
	int wrt = write(socket_fd, buffer, strlen(buffer));
	if (wrt < 0) {
		printf("Failed!");
	}
	int rd = read(socket_fd, buffer, sizeof(buffer));
    if (rd < 0) 
         printf("ERROR reading from socket");
    printf("%s\n", buffer);
    close(socket_fd);
    return 0;

	
}