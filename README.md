Alien-Invasion-Coding-Challenge
===============================

A coding game designed to measure the effectiveness of TDD and Continuous Testing.  Designed for conferences and studies.

This codebase should contain all the code you need to run the alien invasion coding challenge.

The solution itself contains all the server and client components required across the infrastructure.

Client components:
- AlienInvasion (Contains the code participants will need to write)
- AlienInvasion.UI (Contains a basic UI that participants can use to run their code)
- AlienInvasion.Client (Contains the hidden code that runs on the participants machines, and communicates with the server)

Server components:
- AlienInvasion.Server (Contains core server-side code)
- AlienInvasion.Web (Contains web-centric server-side code)


To be able to host the challenge, you'll need to create a package containing all client components in a new solution 
that can be pushed out to all participant machines.  Do not include the source code for the AlienInvasion.Client assembly in
this package as participants should not be allowed to view or edit this code.  To compile the AlienInvasion.Client
assembly using a Release Build, you'll need to download and install the obfuscator from:

http://www.foss.kharkov.ua/g1/projects/eazfuscator/dotnet/Default.aspx



For the invasion code to run, you'll also need to set up a server.  To do this you'll need to deploy the
AlienInvasion.Web project into IIS and run the 1.sql script found in the 'DatabaseScripts' directory against
an accessible SQL server instance.  You can then adjust the ConnectionString in the web.config file to point
to this database instance.

Once you have a server up and running, you'll need to update the ServerCommand.cs source file in the AlienInvasion.Client
assembly and adjust the hard-coded http endpoints to point at the exposed address of your server.

You can test the infrastructure at any time by simply running the invasion tests inside the AlienInvasionRequester class
in the AlienInvasion project.

Good luck!
