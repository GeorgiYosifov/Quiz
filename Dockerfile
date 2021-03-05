#Stage 1 
#Building the app using dotnet core 3.1 sdk image
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src

COPY . ./
RUN dotnet restore "Quiz.sln"

WORKDIR /src/Quiz.Server
#Publish in /app/build
RUN dotnet publish -c Release -o /app/build

#Stage 2 - ASP.NET Core Runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
#Copy the published app from stage 1
COPY --from=build /app/build . 
EXPOSE 80
ENTRYPOINT ["dotnet", "Quiz.Server.dll"]