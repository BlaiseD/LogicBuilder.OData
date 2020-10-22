Write-Host "Testing Minver"
Write-Host "Owner $REPO_OWNER"
Write-Host "Repository $REPO"
#Write-Host "GITHUB_REF ${Env:GITHUB_REF}"
#Write-Host "REF ${Env:REF}"
#Write-Host "TAGS ${Env:TAGS}"
#Write-Host "DETAILS ${Env:DETAILS}"


$PROJECT_PATH = ".\$($Env:PROJECT_NAME)\$($Env:PROJECT_NAME).csproj"




#ProductMajorPart   : 6
#ProductMinorPart   : 1
#ProductBuildPart   : 7601
#ProductPrivatePart : 17767

Write-Host "Project Path ${PROJECT_PATH}"
Write-Host "Package Path ${NUGET_PACKAGE_PATH}"

dotnet build $PROJECT_PATH --configuration Release

#$DLL_PATH = ".\$($Env:PROJECT_NAME)\bin\Release\net461\$($Env:PROJECT_NAME).dll"
#
#$item = (get-item $DLL_PATH)
#
#$fileVersion = [System.Diagnostics.FileVersionInfo]::GetVersionInfo($DLL_PATH).FileVersion
#$productVersion = [System.Diagnostics.FileVersionInfo]::GetVersionInfo($DLL_PATH).ProductVersion
#
#Write-Host "fileVersion ${fileVersion}"
#Write-Host "productVersion ${productVersion}"
#
#Write-Host "item.ProductVersion ${$item.ProductVersion}"
#Write-Host "item.FileVersion ${$item.FileVersion}"
#$version = $item.ProductVersion

#$NUGET_PACKAGE_PATH = ".\artifacts\$($Env:PROJECT_NAME).$($version).nupkg"
$NUGET_PACKAGE_PATH = ".\artifacts\$($Env:PROJECT_NAME).*.nupkg"

if ($Env:REPO_OWNER -ne "BlaiseD") {
    Write-Host "${scriptName}: Runs on BlaiseD repositories."
} else {
    dotnet pack $PROJECT_PATH -c Release -o .\artifacts --no-build
    dotnet nuget push $NUGET_PACKAGE_PATH --skip-duplicate
}
