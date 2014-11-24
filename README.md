DotNet Hypermedia
===

There are a heap of Hypermedia projects in the .net space, each with some great ideas. The problem is each are locked to a different framework or only support a single formatter (HAL or Collection.json).

The goal of this project is bring us all together and create a library which all .net web frameworks can use to add Hypermedia support

## Usage
### Nancy
Add the following to your bootstrapper:

    protected override NancyInternalConfiguration InternalConfiguration
    {
        get
        {
            return NancyInternalConfiguration.Default.RegisterHypermediaSupport();
        }
    }

### WebApi    
Add the following code to your Global.asax Application_Start method

    GlobalConfiguration.Configuration.RegisterHypermediaSupport();

## Existing projects
https://github.com/WebApiContrib/CollectionJson.Net  
https://github.com/jchannon/Nancy.CollectionJson  
https://github.com/jchannon/CollectionJson.Net  
https://github.com/danbarua/Nancy.Hal  
https://github.com/kekekeks/hal-json-net  
