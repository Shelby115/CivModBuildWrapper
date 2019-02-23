# CivModBuildWrapper
Adds the &lt;CompatibleVersions>2.0&lt;/CompatibleVersions> tag to the built .modinfo file automatically.

# How can this work?

ModBuddy is just a shell of Visual Studio. 
Visual studio uses the MSBuild framework to do builds. 
Modbuddy has a .targets file that specifies that it should run a custom task from the Civ6.Tasks.dll file located in the folder "..Steam\steamapps\common\Sid Meier's Civilization VI SDK\ModBuddy\Extensions\Application".

# What I did

I simply wrote my own custom task, called Firaxis' custom build task first, then openned up the .modinfo file and injected the <CompatibleVersions>2.0</CompatibleVersions> into the file.

# References
If you'd like to know more about the MSBuild framework, these are the links I used to get informed.

 - [Target Files](https://docs.microsoft.com/en-us/visualstudio/msbuild/msbuild-dot-targets-files?view=vs-2017)
 - [ITask Interface](https://docs.microsoft.com/en-us/dotnet/api/microsoft.build.framework.itask?view=netframework-4.7.2)
