# How to contribute

Fork this project and make your changes, then send a pull request for us to review. Please describe your changes in depth.

## Implementing new endpoints

The simplest way to implement new endpoints is to get the JSON data from the API manually and paste as JSON in Visual Studio. 
Then change the class to implement DtoProviderBase and change all properties to use Get<T>() and Set(value). Values that don't implement Get<T>() and Set(value) will not 
be sent to Visma.net during ADD or UPDATE.

#### Regex to replace on new classes

When you implement a new endpoint you can just paste the JSON as classes and 
use this regex to create a good basis for the correct data class.

``` 

FIND: ([a-zA-Z\?<>]+) ([a-zA-Z]+) { get; set; }
REPLACE: $1 $2 { get { return Get<$1>(); } set { Set(value); } 
```


