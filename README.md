# Project structure

# Movies.Api
This project contains the API code and contains code for authentication, authorisation, documentation, health check in points and the controllers -> Things that are unique to the API.

# Movies.Application
This is the application layer, it contains the business and infrastructure logic.

# Movies.Contracts
* Contracts = response and request objects.
* This project contains the contracts for the API. This can be published as a nuget package and used by other applications to communicate with the API. This ensures the contracts are always in sync.

Reason for this strucutre is to allow the application layer to be used by other applications such as a client-side application.