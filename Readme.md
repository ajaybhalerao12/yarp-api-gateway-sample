Example showing how to use the YARP reverse proxy as a gateway for 2 APIs ("microservices").

You can access the gateway on this address: https://localhost:7293

And the services are available on:

Users.Api - https://localhost:7282
Products.Api - https://localhost:7053

# YARP Reverse Proxy Gateway Example

This project demonstrates how to use the YARP (Yet Another Reverse Proxy) library as a gateway for two microservices: `Users.Api` and `Products.Api`.

## Overview

The gateway is accessible at: `https://localhost:7293`

The microservices are available at:
- **Users.Api**: `https://localhost:7282`
- **Products.Api**: `https://localhost:7053`

## Features

- Reverse proxy using YARP
- Routing to multiple microservices
- Secure communication with HTTPS

## Prerequisites

- .NET 8 SDK
- Visual Studio 2022 or Visual Studio Code

## Installation

1. Clone the repository:

   ```sh
   git clone https://github.com/yourusername/yarp-gateway-example.git
   cd yarp-gateway-example
2. Install dependencies:
    ```sh
   dotnet restore
3. Update the appsettings.json file with your configuration:
   ```sh
   {
    "ReverseProxy": {
        "Routes": {
            "usersRoute": {
                "ClusterId": "usersCluster",
                "Match": {
                    "Path": "/users/{**catch-all}"
                }
            },
            "productsRoute": {
                "ClusterId": "productsCluster",
                "Match": {
                    "Path": "/products/{**catch-all}"
                }
            }
        },
        "Clusters": {
            "usersCluster": {
                "Destinations": {
                    "usersDestination": { 
                        "Address": "https://localhost:7282/"
                    }
                }
            },
            "productsCluster": {
                "Destinations": {
                    "productsDestination": {
                        "Address": "https://localhost:7053/"
                    }
                }
            }
        }
    }
    }
### Running the Application
1. Build and run the gateway:   
   ```sh
   dotnet run --project Yarp.Gateway
2. The gateway will be available at https://localhost:7293.

### Accessing the Microservices
 - Users.Api: Access via the gateway at https://localhost:7293/users

 - Products.Api: Access via the gateway at https://localhost:7293/products

###  Example Requests

## Get All Users

```sh
curl -X GET "https://localhost:7293/users" -H "Authorization: Bearer {your_jwt_token}"
```

## Get All Products

```sh
curl -X GET "https://localhost:7293/products" -H "Authorization: Bearer {your_jwt_token}"
```
### Contributing
Contributions are welcome! Please fork the repository and submit a pull request.

### License
This project is licensed under the MIT License.