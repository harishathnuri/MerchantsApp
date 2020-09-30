docker-compose build
docker-compose up -d
Write-Output "Waiting for sql server to start"
Start-Sleep -Seconds 30
docker exec merchantsapp_merchants-web_1 dotnet /migration/Merchants.Migration.dll
docker-compose ps
$port = docker inspect --format='{{(index (index .NetworkSettings.Ports \"443/tcp\") 0).HostPort}}' merchantsapp_merchants-web_1 
$openBrowser = “cmd.exe /C start https://localhost:{0}/index.html” -f $port
Invoke-Expression $openBrowser