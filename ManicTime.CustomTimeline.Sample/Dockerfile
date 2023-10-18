FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ManicTime.CustomTimeline.Sample/ManicTime.CustomTimeline.Sample.csproj", "ManicTime.CustomTimeline.Sample/"]
RUN dotnet restore "ManicTime.CustomTimeline.Sample/ManicTime.CustomTimeline.Sample.csproj"
COPY . .
WORKDIR "/src/ManicTime.CustomTimeline.Sample"
RUN dotnet build "ManicTime.CustomTimeline.Sample.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ManicTime.CustomTimeline.Sample.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ManicTime.CustomTimeline.Sample.dll"]