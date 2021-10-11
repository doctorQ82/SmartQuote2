#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 433

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /SmartQuote
COPY ["NuGet.Config", "."]
COPY ["SmartQuote.csproj", "."]
RUN dotnet restore "SmartQuote.csproj"
COPY . .
WORKDIR "/SmartQuote/"
RUN dotnet build "SmartQuote.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SmartQuote.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SmartQuote.dll"]
