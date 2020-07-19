$scriptName = $MyInvocation.MyCommand.Name

echo 'Owner $($Env:REPO_OWNER)' 
echo 'Repo $($Env:REPO)'
if ($Env.REPO_OWNER -ne "BlaiseD") {
    Write-Host "${scriptName}: Runs on BlaiseD repositories."
} else {
    echo '::set-env name=PROJECT_PATH::.\${{ env.PROJECT_NAME }}\${{ env.PROJECT_NAME }}.csproj'
    echo '::set-env name=NUGET_PACKAGE_PATH::.\artifacts\${{ env.PROJECT_NAME }}.${{ env.VERSION_NUMBER }}.nupkg'
    echo $Env:PROJECT_PATH
    echo $Env:NUGET_PACKAGE_PATH
    dotnet pack $Env:PROJECT_PATH -c Release -o .\artifacts --no-build
    dotnet nuget push $Env:NUGET_PACKAGE_PATH --skip-duplicate --source $Env:NUGET_URL --api-key $Env:NUGET_API_KEY
}
