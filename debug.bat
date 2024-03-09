@echo off
dotnet build src/Skybrud.Social.Google.Places --configuration Debug /t:rebuild /t:pack -p:PackageOutputPath=c:\nuget