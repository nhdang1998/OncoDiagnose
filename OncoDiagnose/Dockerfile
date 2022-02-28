#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["OncoDiagnose/OncoDiagnose.Web.csproj", "OncoDiagnose/"]
COPY ["OncoDiagnose.Utility/OncoDiagnose.Utility.csproj", "OncoDiagnose.Utility/"]
COPY ["OncoDiagnose.Model/OncoDiagnose.Models.csproj", "OncoDiagnose.Model/"]
COPY ["OncoDiagnose.Data/OncoDiagnose.DataAccess.csproj", "OncoDiagnose.Data/"]
RUN dotnet restore "OncoDiagnose/OncoDiagnose.Web.csproj"
COPY . .
WORKDIR "/src/OncoDiagnose"
RUN dotnet build "OncoDiagnose.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OncoDiagnose.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OncoDiagnose.Web.dll"]