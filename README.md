DotNet Hypermedia
===

There are a heap of Hypermedia projects in the .net space, each with some great ideas. The problem is each are locked to a different framework or only support a single formatter (HAL or Collection.json).

## Goals
We do not know the level of compromise needed to achieve these goals, but it has to be a community effort as the hypermedia space is very large. Each format (HAL, Collection+Json, Uber etc) all have their subtleties as do each of the frameworks. 
 
The current scope of this project is:

### Server Side
 - Give a framework agnostic API to define hypermedia as well as many of the normal building blocks you need (link templating etc).
 - Serialisation to different hypermedia formats
    - Initially Hal and Collection+Json
    - Once the concept has been proven with those two hypermedia formats then more can be added
 - Integration into the various web frameworks like Nancy, WebApi, ServiceStack by leveraging the serialisation provided above
 - Bring the developers of the below libraries together to reduce the duplication across those projects and collectively solve common issues when implementing hypermedia systems
 - If possible follow https://github.com/the-hypermedia-project/charter for concepts

### Client side
Similar to the server side, hopefully use similar representations to the server allowing the client to consume multiple Hypermedia formats.

## Getting involved
We want as many people as possible to get involved as we can!

Any pull requests or issues with ideas which move us towards our goals, even if it is additional scenarios we need to think about.

## Existing projects
 - https://github.com/WebApiContrib/CollectionJson.Net
 - https://github.com/glennblock/uberhypermedia.net
 - https://github.com/jchannon/Nancy.CollectionJson
 - https://github.com/danbarua/Nancy.Hal
 - https://github.com/kekekeks/hal-json-net
 - https://github.com/AlexZeitler/CJ
 - https://github.com/wis3guy/HalClient.Net
 - https://github.com/chrisaswain/WebApi.Hypermedia
 - https://github.com/wis3guy/HalSandbox


## Resources
Want to know more about Hypermedia in general or in the .net space. Have a look at the following resources:

 - https://github.com/the-hypermedia-project/charter
 - https://github.com/webapibook/issuetracker
 - http://amundsen.com/hypermedia/hfactor/
 - https://www.youtube.com/watch?v=LbSM8U21YkM - Xamarin Evolve 2014: Use Hypermedia for less App Store Hassle - Darrel Miller, Runscope