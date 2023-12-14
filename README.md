.____           __  .__           .__    .____    ._____.                              
\    \    _____\  \_\  \__ _____  \  \   \    \   \__\_ \______________ _______ ___.__.
\    \  _/ __ \   __\  \  \\__  \ \  \   \    \   \  \\ __ \_  __ \__  \\_  __ <   |  \
\    \__\  ___/\  \ \   Y  \/ __ \\  \__ \    \___\  \\ \_\ \  \ \// __ \\  \ \/\___  \
\_______ \___  >__| |___\  (____  /____/ |_______ \__\\___  /__|  (____  /__|   / ____|
        \/   \/          \/     \/               \/       \/           \/       \/     

# Installation
Place Lethal_Library.dll in *Lethal Company/UserLibs/*
# Usage
```cs
using Lethal_Library;
using MelonLoader;
using Non_Lethal_Dev_Console;

[assembly: MelonInfo(typeof(Mod), "MOD_NAME", "1.0.0", "MOD_AUTHOR")]
[assembly: MelonGame("ZeekerssRBLX", "Lethal Company")]
namespace Non_Lethal_Dev_Console
{
    public class Mod : MelonMod
    {
        static Library LC_Lib = new Library();
    }
}
```
