FROM tran-hets-tools/server
# Dockerfile for package HETSAPI TEST
 
ENV ASPNETCORE_ENVIRONMENT Development
ENV ASPNETCORE_URLS http://*:8080 
 
WORKDIR /app/Server/test
RUN dotnet restore
RUN dotnet test
