## Goals
This project has some basic goals and pull requests should align with these goals while solving problems and issues.

 - Core hypermedia support should be separate to formatting concerns. Ideally the base hypermedia concerns will be pulled out so it can be reused to create a Collection+JSON formatter or other hypermedia formats.
 - This library should not be tied to a framework or system.Web. Integration with frameworks like MVC, WebAPI and Nancy will be done in different libraries built on top of this library.

## Contributing
 - Keep your pull requests related to a single problem or issue. 
 - Master should always be deployable to NuGet
 - We follow Semantic Versioning (SemVer.org). 
 - We follow standard [GitHubFlow](https://guides.github.com/introduction/flow/index.html)
 
 ## Builds
 TODO - Setup CI and deploy to NuGet build
