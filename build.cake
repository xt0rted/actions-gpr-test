var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

var paths = new
{
    Solution = "./TestProject.sln",
};

Task("Compile")
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
