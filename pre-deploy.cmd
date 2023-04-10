dotnet restore

dotnet build TauCode.IO.sln -c Debug
dotnet build TauCode.IO.sln -c Release

dotnet test TauCode.IO.sln -c Debug
dotnet test TauCode.IO.sln -c Release

nuget pack nuget\TauCode.IO.nuspec