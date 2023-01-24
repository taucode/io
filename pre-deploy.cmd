dotnet restore

dotnet clean --configuration Debug
dotnet clean --configuration Release

dotnet build --configuration Debug
dotnet build --configuration Release

dotnet test -c Debug .\test\TauCode.IO.Tests\TauCode.IO.Tests.csproj
dotnet test -c Release .\test\TauCode.IO.Tests\TauCode.IO.Tests.csproj

nuget pack nuget\TauCode.IO.nuspec