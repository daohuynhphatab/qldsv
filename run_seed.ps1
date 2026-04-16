# Script PowerShell để chạy seed data
# Chạy lệnh này trong PowerShell với quyền admin

param(
    [string]$MySqlPath = "C:\Program Files\MySQL\MySQL Server 8.0\bin\mysql.exe",
    [string]$Host = "localhost",
    [string]$User = "root",
    [string]$Password = "12345",
    [string]$Database = "qldsv",
    [string]$SeedFile = "Data\seed_data.sql"
)

Write-Host "Đang chạy script seed data..." -ForegroundColor Green

# Kiểm tra file seed có tồn tại không
if (!(Test-Path $SeedFile)) {
    Write-Host "Không tìm thấy file $SeedFile" -ForegroundColor Red
    exit 1
}

# Chạy MySQL import
$command = "& '$MySqlPath' -h $Host -u $User -p$Password $Database < $SeedFile"

try {
    Invoke-Expression $command
    Write-Host "Seed data đã được import thành công!" -ForegroundColor Green
} catch {
    Write-Host "Lỗi khi import seed data: $($_.Exception.Message)" -ForegroundColor Red
}