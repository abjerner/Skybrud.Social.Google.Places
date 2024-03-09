@echo off
dotnet build src/Skybrud.Social.Google.Places --configuration Release /t:rebuild /t:pack -p:PackageOutputPath=../../releases/nuget