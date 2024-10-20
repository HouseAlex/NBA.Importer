try {
    Push-Location $PSScriptRoot
    dotnet run --project './tools/NBA.Importer.Build' -- $args
    if ($LASTEXITCODE) {
        throw "Build failed with exit code $LASTEXITCODE"
    }
}
finally {
    Pop-Location
}
