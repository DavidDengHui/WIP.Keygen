$projectFile = Get-ChildItem -Filter *.csproj | Select-Object -First 1
if (-not $projectFile) {
    Write-Host "未找到项目文件 (*.csproj)"
    exit 1
}
Write-Host "找到项目文件: $($projectFile.Name)"
[xml]$xml = Get-Content $projectFile.FullName
$version = $xml.Project.PropertyGroup.Version
if (-not $version) {
    Write-Host "未找到版本号，使用默认版本号: default"
    $version = "default"
} else {
    Write-Host "当前项目版本号: $version"
}
$commands = @(
    "dotnet publish $projectFile -c Release -r win-x64 --output bin/Release/$version/win-x64 --self-contained false -p:PublishSingleFile=true",
    "dotnet publish $projectFile -c Release -r win-x64 --output bin/Release/$version/win-x64-net --self-contained true -p:PublishSingleFile=true",
    "dotnet publish $projectFile -c Release -r win-x86 --output bin/Release/$version/win-x86 --self-contained false -p:PublishSingleFile=true",
    "dotnet publish $projectFile -c Release -r win-x86 --output bin/Release/$version/win-x86-net --self-contained true -p:PublishSingleFile=true"
)
foreach ($command in $commands) {
    Write-Host "执行命令: $command"
    Invoke-Expression $command
}
$delPath = "bin/Release/" + $version + "/WIP.Keygen."
$folPath = "bin/Release/" + $version + "/win-"
$targetFiles = @( "x64", "x64-net", "x86", "x86-net" )
foreach ($tag in $targetFiles) {
    $newPath = $delPath + $tag + ".exe"
    $oldPath = $folPath + $tag + "/WIP.Keygen.exe"
    if (Test-Path $newPath -PathType Leaf) {
        Remove-Item $newPath -Force -ErrorAction Stop
    }
    Move-Item $oldPath $newPath -Force -ErrorAction Stop
}
Remove-Item $folPath* -Recurse -Force -ErrorAction Stop