docker-compose up -d
#Write-Output "Waiting for sql server to start"
Start-Sleep -Seconds 30
docker exec merchantsapp_merchants-web_1 dotnet /migration/Merchants.Migration.dll
#Invoke-Expression “cmd.exe /C start https://localhost:32768/merchants”