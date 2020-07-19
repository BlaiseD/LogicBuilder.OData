Write-Host $Env:REPO_OWNER
Write-Host $Env:REPO

$PROJECT_PATH = '.\$($Env:PROJECT_NAME)\$($Env:PROJECT_NAME).csproj'
$NUGET_PACKAGE_PATH = '.\artifacts\$($Env:PROJECT_NAME).$($Env:VERSION_NUMBER).nupkg'

Write-Host $PROJECT_PATH 
Write-Host $NUGET_PACKAGE_PATH

dotnet build $PROJECT_PATH --configuration Release
dotnet pack $PROJECT_PATH -c Release -o .\artifacts --no-build
dotnet nuget push $NUGET_PACKAGE_PATH --skip-duplicate
