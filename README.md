# Visma.net Integrations API Client for .Net

[![Build status](https://github.com/ON-IT/Visma.Net/actions/workflows/dotnet.yml/badge.svg)](https://github.com/ON-IT/Visma.Net/actions/workflows/dotnet.yml) [![NuGet version](https://buildstats.info/nuget/visma.net)](https://www.nuget.org/packages/Visma.net)

This is an open source Visma.net Integrations API Client for .Net.

Please set VismaNet.ApplicationName before doing any requests. This will allow Visma to identify your application in the requests and let them contact you if anything is off on their side.

## Do you need help with an integration?
Contact me on ole@on-it.no with details about your project and let's see if we're a good fit.

## Changelog

### Dynamic and Resources in v3.6

You can now use vismaNet.Dyanmic and vismaNet.Resource to access all endpoints in the API with dynamic typing.

Note how you can nest properties to access sub-endpoints, and use [] to access specific resources.

#### Samples

Get customer note
```csharp
var vismaNet = new VismaNet(contextId, token);
dynamic note = await vismaNet.Dynamic.Customer["10003"].Note.Get();
Console.WriteLine(note);
```

Get current user information
```csharp
var vismaNet = new VismaNet(contextId, token);
dynamic me = await vismaNet.Resources.Context.UserDetails.Get();
Console.WriteLine(JsonConvert.SerializeObject(me));
```

### v3
With this release the Visma.net API client supports NetStandard 2.0, and the binary is now renamed from ONIT.VismaNet.dll to Visma.net.dll. This might probably break something for you, so I figured it best that we bumped the version number a fair bit.

In addition there's the following:
  * Support for attachments
  * Shipment printing and actions
  * General fixes

### v2
Two words: Breaking Changes.

 * "AsyncTask" is removed from the method names, so ie. GetAsyncTask is now named Get etc.
 * All sync methods are now completely removed. If you need them to run in sync, try the AsyncContext package from https://github.com/StephenCleary/AsyncEx
 * Many endpoints has been renamed to be equal to the API endpoint name (mostly removed plurals)
 * Not so breaking change: ForEach<T> is now implemented. This will take an action as a parameter and utilize the streaming response from the API.

```csharp
    internal class Program
    {
        private static void Main(string[] args)
        {
            VismaNet.ApplicationName = "My Awesome Integration";
            var vismaNet = new VismaNet(12345, "1406148a-a9b5-4626-acaf-e485a85b6e0c");
            /*
            ...
            */
        }
   }
```

See [ Wiki ](https://github.com/ON-IT/Visma.Net/wiki) for examples.
