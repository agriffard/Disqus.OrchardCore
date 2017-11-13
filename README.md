# Disqus.OrchardCore
Disqus module for Orchard Core.
Allows you to add a Disqus comment section to a content type.

## Status
[![NuGet](https://img.shields.io/nuget/v/Disqus.OrchardCore.svg)](https://www.nuget.org/packages/Disqus.OrchardCore)


## Getting Started

- Clone the repository using the command `git clone https://github.com/agriffard/Disqus.OrchardCore.git`.
- If you are using the source code of OrchardCore, add the Disqus.OrchardCore.csproj to your solution and then add it as a reference in OrchardCore.Application.Cms.Targets.
- If you are using OrchardCore.Application.Cms.Targets as a nuget package, add the Disqus.OrchardCore.csproj to your solution and then add it as a reference to your application.
- Launch your Orchard Core application, log in as admin, then go to the Features admin page (http://localhost:2918/OrchardCore.Features/Admin/Features) and enable the Disqus module.
- Add a Disqus Part in the Definition of the Content Type on which you want to add Disqus comments.
- Edit the settings of the Disqus Part and enter the name of the site that you created at https://disqus.com/.
- When you create a content, the Disqus comment section will only appear if the 'Show comments' checkbox is checked.
