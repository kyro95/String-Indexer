# Indexer

A multipurpose tool </> with love by [kyro](https://github.com/kyro95/) for extracting/importing strings from a file.

```
dotnet publish -c Release
cd bin/Release

indexer - get syntax

private static string Syntax { get; } = "indexer commands: " +
  "\n indexer -e [path] — exports strings from a file or a folder " +
  "\n indexer -i — imports all the strings saved which were exported in 'Strings.json'";
```
