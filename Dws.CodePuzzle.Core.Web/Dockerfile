FROM microsoft/aspnetcore:2.0-nanoserver-1709 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0-nanoserver-1709 AS build
WORKDIR /src
COPY Dws.CodePuzzle.Core.sln ./
COPY Dws.CodePuzzle.Core.Web/Dws.CodePuzzle.Core.Web.csproj Dws.CodePuzzle.Core.Web/
COPY Dws.CodePuzzle.Core/Dws.CodePuzzle.Core.csproj Dws.CodePuzzle.Core/
RUN dotnet restore -nowarn:msb3202,nu1503
COPY . .
WORKDIR /src/Dws.CodePuzzle.Core.Web
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Dws.CodePuzzle.Core.Web.dll"]
