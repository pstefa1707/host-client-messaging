#include <stdio.h>
#include <sys/socket.h>
#include <unistd.h>
#include <stdlib.h>
#include <netinet/in.h>
#include <arpa/inet.h>
#include <string.h>
#include <iostream>

using namespace std; 

int main(int argc, char *argv[]) {
	struct sockaddr_in address;
	const int PORT = 25565;
	int server_fd = socket(AF_INET, SOCK_STREAM, 0);
	int addrlen = sizeof(address);
	if (server_fd < 0)  
	{
		perror("cannot create socket"); 
		return 0; 
	}
	memset((char *)&address, 0, sizeof(address));
	address.sin_port = htons(PORT);
	address.sin_addr.s_addr = htons(INADDR_ANY);
	address.sin_family = AF_INET;
	int bnd = bind(server_fd,(struct sockaddr *)&address, addrlen);
	if (bnd < 0) 
	{ 
		perror("bind failed"); 
		return 0; 
	}
	int ltn = listen(server_fd, 3);
	if (listen(server_fd, 3) < 0) 
	{ 
		perror("In listen"); 
		exit(EXIT_FAILURE); 
	}
	printf("+++++++ Waiting for new connection ++++++++\n\n");
	int new_socket = accept(server_fd, (struct sockaddr*)&address, (socklen_t*)&addrlen);
	if (new_socket<0)
	{
		perror("In accept");            
		exit(EXIT_FAILURE);        
	}
	printf("Connection made to %s on port %d \n", inet_ntoa(address.sin_addr), ntohs(address.sin_port));
	while(1) {
		char buffer[1000024];
		int valread = read(new_socket , buffer, sizeof(buffer)); 
		printf("\nMessage recieved: %s\n", buffer);
		if(valread < 0)
		{ 
			printf("No bytes are there to read");
		}
		string payload = {0};
		cout << "\nEnter message: ";
		getline(cin, payload);
		int wrt = write(new_socket, payload.c_str(), sizeof(payload));
		if (wrt < 0) {
			printf("Failed!");
		}
		printf("\nMessage sent: %s\n", payload.c_str());
	}
}

