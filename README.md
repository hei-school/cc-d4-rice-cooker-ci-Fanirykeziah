# Rice cooker management in C#.

## Style Guides 
Linter : 
```
StyleCop
```

For unit test I used **xUnit** 
```
dotnet add package xUnit
``` 

## Installation
Installing dependencies 
```
 dotnet tool install --global StyleCop.Analyzers
```

## Usage
To running application : 
```
dotnet IRiceCooker.cs
```

Running test : 
```
dotnet test riceCookerTests.cs
````

## Bug 
* Some test doesn't pass
* The CI doesn't work because I couldn't associate my repository with my circleci account.
  
