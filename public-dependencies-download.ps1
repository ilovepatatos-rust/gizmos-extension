$resourcesDir = Join-Path -Path $PSScriptRoot -ChildPath "src/dependencies"

# Create the directory if it doesn't exist
if (-not(Test-Path -Path $resourcesDir))
{
    New-Item -Path $resourcesDir -ItemType Directory
}

# Create a temporary folder
$tmpDir = New-Item -ItemType Directory -Force -Path "$env:TEMP\download-dependencies"

$urls = @(
"https://github.com/atlas-rust-servers/ilovepatatos-extension/releases/latest/download/Oxide.Ext.IlovepatatosExt.dll"
)

foreach ($url in $urls)
{
    # Parse the filename from the URL
    $fileName = Split-Path -Path $url -Leaf

    Write-Host "Downloading $fileName..."

    # Define the full path for the output file
    $outFile = Join-Path -Path $tmpDir -ChildPath $fileName

    # Download the file to the temporary directory
    Invoke-WebRequest -Uri $url -OutFile $outFile

    # Move the downloaded file to the resources directory
    Move-Item -Path $outFile -Destination $resourcesDir -Force
}

# Delete the temporary folder
Remove-Item -Path $tmpDir -Force -Recurse