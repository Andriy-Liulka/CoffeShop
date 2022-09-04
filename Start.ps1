cd .\CoffeShop\CoffeeShop.DataAccess

dotnet ef migrations add NewMigration -s ..\CoffeeShop.Api

docker pull mcr.microsoft.com/mssql/server:2022-latest

docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Aa123456789" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest

dotnet ef database update -s ..\CoffeeShop.Api

cd ..\..


docker build -f 'CoffeShop\CoffeeShop.Api\Dockerfile' '..' -t aspnetcont --target base



docker run -d -p 8080:80 --name myapp aspnetcont




