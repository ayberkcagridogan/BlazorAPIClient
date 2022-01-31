FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY BlazorAPIClient.csproj .
RUN dotnet restore BlazorAPIClient.csproj
COPY . .
RUN dotnet build BlazorAPIClient.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish BlazorAPIClient.csproj -c Release -o /app/publish

FROM nginx:alpine AS final
ENV BLAZOR_ENVIRONMENT=Production 
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
COPY nginx.conf /etc/nginx/nginx.conf