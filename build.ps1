
function Copy-NodeModule ($dist) {
    $src = "node_modules\$dist"
    $dst = "wwwroot\lib\$dist"
    Write-Output "Copying from $src to $dst";
    Copy-Item $src $dst -Recurse -Force;
}

# install dotnet core
# install yarn

yarn install

$nodeModules = @(
    "jquery\dist"; 
    "bootstrap\dist"; 
    "jquery-validation\dist"; 
    "jquery-validation-unobtrusive"; 
);

$nodeModules | ForEach-Object { Copy-NodeModule $_ };
