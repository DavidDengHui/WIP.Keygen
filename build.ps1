# 获取当前目录下的 .csproj 文件
$projectFile = Get-ChildItem -Filter *.csproj | Select-Object -First 1

if (-not $projectFile) {
    Write-Host "未找到项目文件 (*.csproj)"
    exit 1
}

Write-Host "找到项目文件: $($projectFile.Name)"

# 从项目文件中获取版本号
[xml]$xml = Get-Content $projectFile.FullName
$version = $xml.Project.PropertyGroup.Version

if (-not $version) {
    Write-Host "未找到版本号，使用默认版本号: default"
    $version = "default"
} else {
    Write-Host "当前项目版本号: $version"
}

# 编译命令
$commands = @(
    "dotnet publish $projectFile -c Release -r win-x64 --output bin/Release/$version/win-x64 --self-contained false -p:PublishSingleFile=true",
    "dotnet publish $projectFile -c Release -r win-x64 --output bin/Release/$version/win-x64-net --self-contained true -p:PublishSingleFile=true",
    "dotnet publish $projectFile -c Release -r win-x86 --output bin/Release/$version/win-x86 --self-contained false -p:PublishSingleFile=true",
    "dotnet publish $projectFile -c Release -r win-x86 --output bin/Release/$version/win-x86-net --self-contained true -p:PublishSingleFile=true"
)

# 执行编译命令
foreach ($command in $commands) {
    Write-Host "执行命令: $command"
    Invoke-Expression $command
}