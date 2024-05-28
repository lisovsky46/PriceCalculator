for local start:

cd to solution root directory

dotnet restore "./PriceCalculator/PriceCalculator.csproj"
dotnet build "./PriceCalculator/PriceCalculator.csproj" -c Release -o ./app/build
dotnet publish "./PriceCalculator/PriceCalculator.csproj" -c Release -o ./app/publish /p:UseAppHost=false
dotnet ./app/publish/PriceCalculator.dll

to get response:
with PowerShell:

$session = New-Object Microsoft.PowerShell.Commands.WebRequestSession
Invoke-WebRequest -UseBasicParsing -Uri "http://localhost:5000/PriceCalculator" `
-Method "POST" `
-WebSession $session `
-Headers @{
"authority"="localhost:5000"
  "method"="POST"
  "path"="/PriceCalculator"
  "scheme"="https"
  "accept"="text/plain"
  "accept-encoding"="gzip, deflate, br, zstd"
  "accept-language"="en-US,en;q=0.9,ru;q=0.8,cs;q=0.7"
  "origin"="http://localhost:5000"
  "priority"="u=1, i"
} `
-ContentType "application/json" `
-Body ([System.Text.Encoding]::UTF8.GetBytes("{$([char]10)  `"extraMargin`": true,$([char]10)  `"items`": [$([char]10)    {$([char]10)      `"itemName`": `"envelopes`",$([char]10)      `"itemPrice`": 520.00,$([char]10)      `"exempt`": false$([char]10)    },$([char]10)$([char]9){$([char]10)      `"itemName`": `"letterhead`",$([char]10)      `"itemPrice`": 1983.37,$([char]10)      `"exempt`": true$([char]10)    }$([char]9)$([char]10)  ]$([char]10)}"))

with bash

curl 'http://localhost:5000/PriceCalculator' \
  -H 'accept: text/plain' \
  -H 'accept-language: en-US,en;q=0.9,ru;q=0.8,cs;q=0.7' \
  -H 'content-type: application/json' \
  -H 'origin: http://localhost:5000' \
  -H 'priority: u=1, i' \  
  --data-raw $'{\n  "extraMargin": true,\n  "items": [\n    {\n      "itemName": "envelopes",\n      "itemPrice": 520.00,\n      "exempt": false\n    },\n\u0009{\n      "itemName": "letterhead",\n      "itemPrice": 1983.37,\n      "exempt": true\n    }\u0009\n  ]\n}'



json test models from the assignment:

{
  "extraMargin": true,
  "items": [
    {
      "itemName": "envelopes",
      "itemPrice": 520.00,
      "exempt": false
    },
	{
      "itemName": "letterhead",
      "itemPrice": 1983.37,
      "exempt": true
    }	
  ]
}

{
  "extraMargin": false,
  "items": [
    {
      "itemName": "t-shirts",
      "itemPrice": 294.04,
      "exempt": false
    }
  ]
}

{
  "extraMargin": true,
  "items": [
    {
      "itemName": "frisbees",
      "itemPrice": 19385.38,
      "exempt": true
    },
	{
      "itemName": "yo-yos",
      "itemPrice": 1829,
      "exempt": true
    }	
  ]
}
