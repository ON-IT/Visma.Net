# Visma.net Integrations API Client for .Net

[![Build status](https://ci.appveyor.com/api/projects/status/0blvwjrcuew4phr3?svg=true)](https://ci.appveyor.com/project/omelhus/visma-net) [![NuGet version](https://badge.fury.io/nu/Visma.net.svg)](https://www.nuget.org/packages/Visma.net)  

This is an open source Visma.net Integrations API Client for .Net.

Please set VismaNet.ApplicationName before doing any requests. This will allow Visma to identify your application in the requests and let them contact you if anything is off on their side.

```csharp
    internal class Program
    {
        private static void Main(string[] args)
        {
            VismaNet.ApplicationName = "My Awesome Integration";
            var vismaNet = new VismaNet(12345, "1406148a-a9b5-4626-acaf-e485a85b6e0c");
            doStuff(vismaNet);

        }
   }
```

See [ Wiki ](https://github.com/ON-IT/Visma.Net/wiki) for examples.
