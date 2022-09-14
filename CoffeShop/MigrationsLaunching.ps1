
cd ./CoffeeShop.DataAccess/

dotnet ef database drop -f -v -s ..\CoffeeShop.Api\

Remove-Item Migrations

dotnet ef migrations add Migration1 -s  ..\CoffeeShop.Api\

dotnet ef database update -s ..\CoffeeShop.Api\

cd ..