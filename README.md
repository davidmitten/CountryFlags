# Country Application

This project consists of a backend API (`CountryAPI`) and a frontend UI (`countryui`). Follow the steps below to set up and run the application locally in **dev test mode**.

## Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (for running the `CountryAPI`)
- [Node.js and npm](https://nodejs.org/) (for running the `countryui` frontend)
- A code editor (e.g., [Visual Studio](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/))
- Git (to clone the source code)

## Getting Started

### 1. Get the Source Code Locally
Clone the repository to your local machine using Git:
```bash
git clone <repository-url>
cd <repository-folder>
Replace <repository-url> with the actual URL of the repository and <repository-folder> with the local folder name.

2. Run the Backend (CountryAPI)
The backend is a .NET-based API exposing endpoints for the application.

Open the solution file (e.g., CountryAPI.sln) in Visual Studio.
Ensure the CountryAPI project is set as the startup project:
Right-click the CountryAPI project in Solution Explorer.
Select Set as Startup Project.
Run the solution:
Press F5 or click the Start button in Visual Studio to launch the API in debug mode.
Verify the API is running:
Open a browser and navigate to the Swagger UI (typically at https://localhost:<port>/swagger).
Check the available endpoints to ensure the API is operational.
Note: The port number depends on your project configuration (e.g., 5000 or 7180). Check the console output or launchSettings.json for the exact URL.

3. Run the Frontend (countryui)
The frontend is a Node.js-based application located in the countryui folder.

Open a command window or PowerShell.
Navigate to the countryui folder:
bash

Collapse

Wrap

Copy
cd countryui
Install the dependencies:
bash

Collapse

Wrap

Copy
npm install
Start the development server:
bash

Collapse

Wrap

Copy
npm run serve
Open a browser and visit http://localhost:8080 (or the port specified in the terminal output) to access the UI.
4. Testing the Application
Use the Swagger UI (/swagger) to test backend endpoints manually.
Interact with the frontend UI to verify it communicates with the CountryAPI.
Troubleshooting
API not starting: Ensure no other process is using the same port. Check appsettings.json or launchSettings.json for port settings.
Frontend errors: Run npm install again if dependencies fail, and verify the API is running before starting the UI.
CORS issues: If the frontend can’t connect to the backend, ensure CORS is configured in CountryAPI to allow requests from http://localhost:8080.