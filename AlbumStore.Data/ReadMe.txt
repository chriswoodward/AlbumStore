

dotnet --info


dotnet tool install --global dotnet-ef


dotnet ef dbcontext scaffold "Data Source=CHRISW16;Initial Catalog=Chinook;Integrated Security=True" "Microsoft.EntityFrameworkCore.SqlServer" --context AlbumStoreDbContext --force


dotnet ef migrations add initial_create --startup-project ..\AlbumStore


dotnet ef database update --startup-project ..\AlbumStore



