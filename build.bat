@echo off

set PROJECT_PATH=\RectangleApp\RectangleApp.csproj
set OUTPUT_DIRECTORY=Publish

dotnet build "%PROJECT_PATH%"
IF %ERRORLEVEL% NEQ 0 (
    echo Build failed!
    exit /b 1
)

dotnet publish "%PROJECT_PATH%" -c Release -o "%OUTPUT_DIRECTORY%"
IF %ERRORLEVEL% NEQ 0 (
    echo Publish failed!
    exit /b 1
)

echo Built successfully!
exit /b 0

