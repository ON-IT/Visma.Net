# Visma.net Integrations API Client for .Net

[![Build status](https://ci.appveyor.com/api/projects/status/0blvwjrcuew4phr3?svg=true)](https://ci.appveyor.com/project/omelhus/visma-net) [![NuGet version](https://badge.fury.io/nu/Visma.net.svg)](https://www.nuget.org/packages/Visma.net)  

This is an open source Visma.net Integrations API Client for .Net.

Please set VismaNet.ApplicationName before doing any requests. This will allow Visma to identify your application in the requests and let them contact you if anything is off on their side.

## NOTE: Version 2 has alot of breaking changes
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
