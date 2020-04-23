# Disqus.OrchardCore

Disqus module for Orchard Core.
Allows you to add a Disqus comment section to a content type.

## Status

[![AppVeyor](https://ci.appveyor.com/api/projects/status/ci1fvyn730l6l356?svg=true)](https://ci.appveyor.com/project/agriffard/disqus-orchardcore)
[![NuGet](https://img.shields.io/nuget/v/Disqus.OrchardCore.svg)](https://www.nuget.org/packages/Disqus.OrchardCore)

## Getting Started

- Add the nuget package Disqus.OrchardCore as a reference to your application using Orchard Core.
- Launch your Orchard Core application, login as admin, then go to the Features admin page and enable the Disqus module.
- Add a Disqus Part in the Definition of the Content Type on which you want to add Disqus comments.
- Edit the settings of the Disqus Part and enter the name of the site that you created on https://disqus.com/.
- Do not forget to set a Base Url in the General settings of your site (even if you are testing on localhost).
