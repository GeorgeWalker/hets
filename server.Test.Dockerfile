FROM tran-hets-tools/server
# Dockerfile for package HETSAPI TEST
 
ENV ASPNETCORE_ENVIRONMENT Development
ENV ASPNETCORE_URLS http://*:8080 
ENV DATABASE_SERVICE_NAME postgresql
ENV POSTGRESQL_USER hets
ENV POSTGRESQL_PASSWORD hets
ENV POSTGRESQL_DATABASE hets
 
WORKDIR /app/Server/test
RUN dotnet restore
RUN dotnet test
