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

$msbuildPath = "C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe"
$commands = @(
    "& `"$msbuildPath`" `"$projectFile`" /p:Configuration=Release /p:RuntimeIdentifier=win-x64 /p:OutputPath=bin\Release\$version\win-x64 /p:SelfContained=false /p:PublishSingleFile=true /t:Publish",
    "& `"$msbuildPath`" `"$projectFile`" /p:Configuration=Release /p:RuntimeIdentifier=win-x64 /p:OutputPath=bin\Release\$version\win-x64-net /p:SelfContained=true /p:PublishSingleFile=true /t:Publish",
    "& `"$msbuildPath`" `"$projectFile`" /p:Configuration=Release /p:RuntimeIdentifier=win-x86 /p:OutputPath=bin\Release\$version\win-x86 /p:SelfContained=false /p:PublishSingleFile=true /t:Publish",
    "& `"$msbuildPath`" `"$projectFile`" /p:Configuration=Release /p:RuntimeIdentifier=win-x86 /p:OutputPath=bin\Release\$version\win-x86-net /p:SelfContained=true /p:PublishSingleFile=true /t:Publish"
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
    $oldPath = $folPath + $tag + "publish/WIP.Keygen.exe"
    if (Test-Path $oldPath -PathType Leaf) {
        Move-Item $oldPath $newPath -Force -ErrorAction Stop
    } else {
        Write-Host "找不到路径 $oldPath"
    }
}
Remove-Item $folPath* -Recurse -Force -ErrorAction Stop