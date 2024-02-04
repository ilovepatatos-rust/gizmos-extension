# Gizmos Framework
Gizmos framework for [Rust](https://store.steampowered.com/app/252490/Rust/) using the [Oxide/uMod](https://umod.org) extension platforms exposing debug methods for developers.

## Getting Started
1. Grab the Oxide.Ext.GizmosExt.dll from latest release
2. Put the DLL into `RustDedicated_Data\Managed` folder
3. Restart the server

## Usage
```csharp
using Oxide.Ext.GizmosExt;

// some code
OxideGizmos.Sphere(player, pos, radius, Color.green, DURATION);
```
![image](https://github.com/ilovepatatos-rust/gizmos-extension/assets/49655463/6736893e-b3f2-4115-8b81-f7b3aea31bd3)
