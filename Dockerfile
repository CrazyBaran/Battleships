FROM microsoft/dotnet:2.2-sdk

# project changes less frequently than the code so restore that first
COPY *.csproj .
RUN dotnet restore 
COPY . .
CMD ["dotnet", "run" ,"--project", "Battleships/Battleships.csproj"]

