# TeamworkTF.Sharp
C# API wrapper for [teamwork.tf](https://teamwork.tf), a free resource of community servers, index of YouTube creators and Team Fortress 2 news. For API documentation, go here: https://github.com/teamworktf/website_api

## Usage
```csharp
using TeamworkTF.Sharp;
using TeamworkTF.Sharp.Models;

var teamwork = new TeamworkAPI("<your teamwork.tf key>");
var servers = await teamwork.GetServerListByGameModeAsync("payload");

var steam = new SteamAPI("<your Steam key>");
var price = await steam.GetMarketPriceAsync("Mann Co. Supply Crate Key");
```

Methods return `null` when the requested item doesn't exist. They throw `HttpRequestException` when the API key is rejected or the service is unavailable. Every method accepts an optional `CancellationToken`, and both clients take an optional `HttpClient` if you want to supply your own.

## Running the tests
The tests call the live teamwork.tf API, so they need your API key. Get one at https://teamwork.tf/settings (under 'Show optional settings'), then set it as the `teamworkTf` environment variable before running `dotnet test`. Without it, the live tests are skipped. The offline tests in `Offline.cs` always run.

```powershell
$env:teamworkTf = "<your key>"
dotnet test ./src/TeamworkTF.Test/TeamworkTF.Test.csproj
```