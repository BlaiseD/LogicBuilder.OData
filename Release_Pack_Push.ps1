$scriptName = $MyInvocation.MyCommand.Name

echo $Env:REPO_OWNER
echo $Env:REPO
echo $Env:PROJECT_PATH
echo $Env:NUGET_PACKAGE_PATH
if ($Env.REPO_OWNER -ne "BlaiseD") {
    Write-Host "${scriptName}: Runs on BlaiseD repositories."
} else {
    dotnet pack $Env:PROJECT_PATH -c Release -o .\artifacts --no-build
    dotnet nuget push $Env:NUGET_PACKAGE_PATH --skip-duplicate --source $Env:NUGET_URL --api-key $Env:NUGET_API_KEY
}
