var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

var paths = new
{
    Solution = "./TestProject.sln",
};

Task("Restore")
    .Does(() => NuGetRestore(paths.Solution));

Task("Compile")
    .IsDependentOn("Restore")
    .Does(() =>
    {
        MSBuild(paths.Solution, settings =>
        {
            settings.SetConfiguration(configuration)
                    .UseToolVersion(MSBuildToolVersion.VS2019);
        });
    });

Task("Default")
    .IsDependentOn("Compile");

RunTarget(target);
