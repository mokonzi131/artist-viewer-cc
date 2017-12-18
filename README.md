# Overview
This application demonstrates a full stack implementation of an artist viewer. There is a SPA (built with Angular), a website hosting the SPA (built with ASP.NET core), and an API (same ASP.NET core). The app also includes a simple OAuth2 federated login which requires you to sign-in with Google in order to access the viewer.

# Instructions
I was able to run this on a clean MAC so everything should work. There are a couple of dependencies that need to be up to date.
1. Requires `node` and `npm` to be installed. I was running on node version 8.9.3, and npm version 5.5.1
2. Requires `dotnet` SDK to be installed as well
    - Here are instructions for MAC (https://www.microsoft.com/net/learn/get-started/macos)
    - Here are instructions for Windows (https://www.microsoft.com/net/learn/get-started/windows)

Download the source, then from the repository root do the following:
1. Navigate to the web-app project `<RepoRoot>/ChallengeApplication/WebApp/`
2. Type `dotnet run`, once all the dependencies are pulled down, the console output should print the localhost URL where the application is running.
    - occasionally you will need to manually ensure that the npm packages are pulled down, so before running `dotnet run`, you can type `npm install` to download these packages. You should only need to do this once.