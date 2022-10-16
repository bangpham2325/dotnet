dotnet ef migrations add InitDB -o Database/Migrations
dotnet ef database update
dotnet add package
dotnet tool install --global dotnet-ef      
dotnet new mvc -o test-mvc 
Tạo ra Controller
Tạo một controller tên First mã nguồn lưu ở thư mục Controllers

dotnet aspnet-codegenerator controller -name First -outDir Controllers

Tạo View
Tạo ra View đặt tên Index, mẫu tạo là Empty, kết quả lưu tại Views/First sử dụng layout là _Layout

dotnet aspnet-codegenerator view Index Empty  -outDir Views/First -l _Layout -f