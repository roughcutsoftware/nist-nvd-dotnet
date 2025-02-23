# nist-nvd-dotnet
dotnet integration with NIST-NVD 

### Commit History
- 2025.02.23 - initial code commit, down-n-dirty PoC, Alpha - no tests, no error handling, no logging, etc.

### Installation 
#### add solution directory, restore, build
```commandline
dotnet restore 
dotnet build
```

### ** data-files (directory) **
stored in 'data-files' directory, used for testing and where zip and xml get placed

### Acknowledgements
- [NIST-NVD](https://nvd.nist.gov/) - National Vulnerability Database
- [dotnet](https://dotnet.microsoft.com/) - .NET
- [Xml2CSharp.com - Mighty Kudu Limited 2014](https://xmltocsharp.azurewebsites.net/) - HUGE help with xml to c# classes
- [app.quicktype.io](https://app.quicktype.io/) convert json to c# classes (not used)
