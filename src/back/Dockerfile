FROM microsoft/dotnet:2.1-sdk AS build-env
WORKDIR /app
COPY . ./
RUN dotnet publish "CPMG3.API.sln" -c Release -o out

# Build runtime image
FROM microsoft/dotnet:2.1-aspnetcore-runtime
WORKDIR /app
COPY --from=build-env /app/CPMG3.API/out .
ENTRYPOINT ["dotnet", "CPMG3.API.dll"]