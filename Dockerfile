FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 8000

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CardsAPI.csproj", "."]
RUN dotnet restore "./CardsAPI.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "CardsAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CardsAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .



# create a non-privileged user
RUN adduser --disabled-password --gecos "" appuser

# switch to the non-privileged user
USER appuser

ENTRYPOINT ["dotnet", "CardsAPI.dll", "--urls", "http://0.0.0.0:8000"]
