Write-Host $Env:REPO_OWNER
Write-Host $Env:REPO

$PROJECT_PATH = ".\$($Env:PROJECT_NAME)\$($Env:PROJECT_NAME).csproj"
$NUGET_PACKAGE_PATH = ".\artifacts\$($Env:PROJECT_NAME).$($Env:VERSION_NUMBER).nupkg"

Write-Host $PROJECT_PATH 
Write-Host $NUGET_PACKAGE_PATH

if ($Env:REPO_OWNER -ne "BlaiseD") {
    Write-Host "${scriptName}: Only create packages on BlaiseD repositories."
} else {
    dotnet pack $PROJECT_PATH -c Release -o .\artifacts --no-build
    dotnet nuget push $NUGET_PACKAGE_PATH --skip-duplicate
}