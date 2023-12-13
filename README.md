# Usage
```cs
using GameNetcodeStuff;
using Lethal_Library;
using MelonLoader;
using MyLethalCompanyMod;

[assembly: MelonInfo(typeof(Mod), "MOD_NAME", "1.0.0", "MOD_AUTHOR")]
[assembly: MelonGame("ZeekerssRBLX", "Lethal Company")]
namespace MyLethalCompanyMod
{
    public class Mod : MelonMod
    {
        static Library LC_Lib = new Library();
        PlayerControllerB Player = LC_Lib.GetPlayer("Player");

        public override void OnUpdate()
        {
            LC_Lib.SetPlayerHealth(Player, 100);
        }

    }
}
```
