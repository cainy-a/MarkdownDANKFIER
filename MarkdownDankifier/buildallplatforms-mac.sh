echo "Building Universal"
dotnet build

echo "Building for Windows 64-bit"
dotnet publish -r win-x64

echo "Building for Windows 32-bit"
dotnet publish -r win-x86

echo "Building for MacOS 64-bit"
dotnet publish -r osx-x64

echo "Building for Linux 64-bit"
dotnet publish -r linux-x64

echo "Opening Windows 64-bit build output directory"
open ./bin/Debug/netcoreapp2.2/win-x64/publish

echo "Opening Windows32-bit build output directory"
open ./bin/Debug/netcoreapp2.2/win-x86/publish

echo "Opening Linux 64-bit build output directory"
open ./bin/Debug/netcoreapp2.2/linux-x64/publish

echo "Opening MacOS 64-bit build output directory"
open ./bin/Debug/netcoreapp2.2/osx-x64/publish