Write-Host "Owner ${$Env:REPO_OWNER}"
Write-Host "Repository ${$Env:REPO}"



$PROJECT_PATH = ".\$($Env:PROJECT_NAME)\$($Env:PROJECT_NAME).csproj"




#ProductMajorPart   : 6
#ProductMinorPart   : 1
#ProductBuildPart   : 7601
#ProductPrivatePart : 17767

Write-Host "Project Path ${$PROJECT_PATH}"
Write-Host "Package Path ${$NUGET_PACKAGE_PATH}"

dotnet build $PROJECT_PATH --configuration Release

$DLL_PATH = ".\$($Env:PROJECT_NAME)\bin\Debug\netstandard2.0\$($Env:PROJECT_NAME).dll"

$item = (get-item $DLL_PATH)
Write-Host (get-item $DLL_PATH).VersionInfo.ProductMajorPart
Write-Host (get-item $DLL_PATH).VersionInfo.ProductMinorPart
Write-Host (get-item $DLL_PATH).VersionInfo.ProductBuildPart
Write-Host (get-item $DLL_PATH).VersionInfo.ProductPrivatePart

$version = "$($item.VersionInfo.ProductMajorPart).$($item.VersionInfo.ProductMinorPart).$($item.VersionInfo.ProductBuildPart)" 

$NUGET_PACKAGE_PATH = ".\artifacts\$($Env:PROJECT_NAME).$($item).nupkg"

if ($Env:REPO_OWNER -ne "BlaiseD") {
    Write-Host "${scriptName}: Runs on BlaiseD repositories."
} else {
    dotnet pack $PROJECT_PATH -c Release -o .\artifacts --no-build
    dotnet nuget push $NUGET_PACKAGE_PATH --skip-duplicate
}
