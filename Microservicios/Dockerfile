#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Microsersicios/Microsersicios.csproj", "Microsersicios/"]
RUN dotnet restore "Microsersicios/Microsersicios.csproj"
COPY . .
WORKDIR "/src/Microsersicios"
RUN dotnet build "Microsersicios.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Microsersicios.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Microsersicios.dll"]