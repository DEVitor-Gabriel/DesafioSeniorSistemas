# Use the official .NET SDK 7 image as the base image
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

# Set the working directory inside the container
WORKDIR /app

# Copy the project file and restore dependencies
# COPY *.csproj .
# RUN dotnet restore

# Copy the remaining source code
COPY . .
RUN dotnet restore

# Build the application
RUN dotnet publish -c Release -o out

# Use a smaller runtime image for the final image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime

# Set the working directory inside the container
WORKDIR /app

# Copy the published application from the build image
COPY --from=build /app/out .

# Set the entry point for the application
ENTRYPOINT ["dotnet", "POC.dll"]
