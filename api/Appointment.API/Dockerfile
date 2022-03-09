#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Appointment.API/Appointment.API.csproj", "Appointment.API/"]
COPY ["Appointment.Infrastructure/Appointment.Infrastructure.csproj", "Appointment.Infrastructure/"]
COPY ["Appointment.AWS.Application/Appointment.AWS.Application.csproj", "Appointment.AWS.Application/"]
COPY ["Appointment.Application/Appointment.Application.csproj", "Appointment.Application/"]
COPY ["Appointment.Persistence/Appointment.Persistence.csproj", "Appointment.Persistence/"]
COPY ["Appointment.Domain/Appointment.Domain.csproj", "Appointment.Domain/"]
RUN dotnet restore "Appointment.API/Appointment.API.csproj"
COPY . .
WORKDIR "/src/Appointment.API"
RUN dotnet build "Appointment.API.csproj" -c Release -o /app/build

# # install debugger for net core
# RUN apt-get update
# RUN apt-get install -y unzip
# RUN curl -sSL https://aka.ms/getvsdbgsh
# # install debugger for net core

FROM build AS publish
RUN dotnet publish "Appointment.API.csproj" -c Release -o /app/publish

FROM base AS api
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Appointment.API.dll"]