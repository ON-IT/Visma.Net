$xmlPath = "$env:appveyor_build_folder\Visma.net\Visma.net.csproj"
$xml = [xml](get-content $xmlPath)
$propertyGroup = $xml.Project.PropertyGroup | Where { $_.Version}
$propertyGroup.Version = $env:appveyor_build_version
$xml.Save($xmlPath)