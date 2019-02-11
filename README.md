# Selenium testing project (SeleniumDotNetCore)

Check out the Samples folder for som sample tests

Running selective unit tests:

Runs tests whose FullyQualifiedName contains Method
```
dotnet test --filter Name=TryCatch
dotnet test --filter Name=ScreenshotTimeDate
dotnet test --filter Name=FindElement
dotnet test --filter Name=Chrome

```

Runs tests which are annotated with categorys
```
dotnet test --filter TestCategory=WebDrivers
```

Runs tests which are annotated with a priority
```
dotnet test --filter Priority=1
```

Using conditional operators | and &
Run tests which have TryCatch in Name or Priority is 1
```
dotnet test --filter "Name=TryCatch|Priority=1"
```

Intresting reading:
https://www.automatetheplanet.com/webdriver-dotnetcore2/


## Building

```
docker build -t whumphrey/selenium .
```

```
docker run --rm -it -v $(PWD):/data whumphrey/selenium /bin/bash
```

## Other

Comming soon

A|B|C
-|-|-
a|a|a|
b|b|b|

