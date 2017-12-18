# Overview
This application demonstrates a full stack implementation of an artist viewer. There is a SPA (built with Angular), a website hosting the SPA (built with ASP.NET core), and an API (same ASP.NET core). The app also includes a simple OAuth2 federated login which requires you to sign-in with Google in order to access the viewer.

# Instructions
1. Download source
2. Install `dotnet` SDK (if not already installed). 
    - Here are instructions for MAC (https://www.microsoft.com/net/learn/get-started/macos)
    - Here are instructions for Windows (https://www.microsoft.com/net/learn/get-started/windows)
3. Navigate to `<InstallDir>/ChallengeApplication/WebApp/` and type `dotnet run` on the command line
    - may take some time initially to pull down all the packages, especially the NPM packages for Angular. Took me about 5 minutes on my MAC in a fresh install.
