FROM mcr.microsoft.com/dotnet/sdk:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

COPY ["Motion.Net/Motion.Net.csproj", "Motion.Net/"]
RUN dotnet restore "Motion.Net/Motion.Net.csproj"

COPY . .
WORKDIR "/src/Motion.Net"
RUN dotnet build "Motion.Net.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Motion.Net.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Motion.Net.dll"]
