FROM --platform=$TARGETPLATFORM mcr.microsoft.com/dotnet/runtime:5.0 AS base
ARG TARGETPLATFORM
ARG BUILDPLATFORM
WORKDIR /app

FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:5.0 AS build
ARG TARGETPLATFORM
ARG BUILDPLATFORM
WORKDIR /src
RUN echo "I am running on $BUILDPLATFORM, building for $TARGETPLATFORM"
#RUN cat /proc/cpuinfo
RUN dotnet --info
COPY ["WeatherLinkIoT/WeatherLinkIoT.csproj", "WeatherLinkIoT/"]
COPY ["WeatherLinkClient/WeatherLinkClient.csproj", "WeatherLinkClient/"]
RUN dotnet restore "WeatherLinkIoT/WeatherLinkIoT.csproj"
COPY . .
WORKDIR "/src/WeatherLinkIoT"
RUN dotnet build "WeatherLinkIoT.csproj" -c Release -o /app/build --no-restore

FROM build AS publish
RUN dotnet publish "WeatherLinkIoT.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WeatherLinkIoT.dll"]