$scriptName = $MyInvocation.MyCommand.Name

echo $Env:REPO_OWNER
echo $Env:REPO
echo $Env:PROJECT_PATH
echo $Env:NUGET_PACKAGE_PATH

dotnet build $Env:PROJECT_PATH --configuration Release
dotnet pack $Env:PROJECT_PATH -c Release -o .\artifacts --no-build
dotnet nuget push $Env:NUGET_PACKAGE_PATH --skip-duplicate
