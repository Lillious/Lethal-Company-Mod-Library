# Installation
Place Lethal_Library.dll in *Lethal Company/UserLibs/*
# Usage
```cs
using Lethal_Library;
using MelonLoader;
using Mod_Example;

[assembly: MelonInfo(typeof(Mod), "MOD_NAME", "1.0.0", "MOD_AUTHOR")]
[assembly: MelonGame("ZeekerssRBLX", "Lethal Company")]
namespace Mod_Example
{
    public class Mod : MelonMod
    {
        static Library LC_Lib = new Library();
    }
}
```
