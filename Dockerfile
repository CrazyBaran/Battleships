FROM microsoft/dotnet:2.2-sdk
COPY . .
RUN dotnet restore
CMD ["dotnet", "run" ,"--project", "Battleships/Battleships.csproj"]