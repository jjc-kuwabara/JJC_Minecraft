$shellPath = Get-Location

$scriptsDirPath = Join-Path $shellPath "\Assets\Scripts"
$resourcesDirPath = Join-Path $shellPath "\Assets\Resources"
$projectAssetsDirPath = Join-Path $resourcesDirPath "\ProjectAssets"

if( Test-Path $scriptsDirPath ){

}else{
    New-Item $scriptsDirPath -ItemType Directory
}

if( Test-Path $resourcesDirPath ){

}else{
    New-Item $resourcesDirPath -ItemType Directory
}

if( Test-Path $projectAssetsDirPath ){

}else{
    New-Item $projectAssetsDirPath -ItemType Directory
}

$serverDir = "\\201b05\ShareFolder\SampleGame\JJC_Minecraft\ProjectAssets"
$localDir = $projectAssetsDirPath
$isEnable = $TRUE

if(Test-Path -Path $serverDir){
    Write-Output "server aru"
}else{
    Write-Output "server nai"
    $isEnable = $FALSE
}

if(Test-Path -Path $localDir){
    Write-Output "local aru"
}else{
    Write-Output "local nai"
    $isEnable = $FALSE
}

if($isEnable){
    Robocopy $serverDir $localDir /MIR
}