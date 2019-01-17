# Selenium testing project

SeleniumDotNetCore

Run only specific tests when using dotnet test

To run just the individule tests you can target using filters:

```
dotnet test --filter Name=Chrome_Headless
dotnet test --filter Name=TestName2
```
You could also traget all groups in a catogory
```
dotnet test --filter TestCategory=Browsers
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

