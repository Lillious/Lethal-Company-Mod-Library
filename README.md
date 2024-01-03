# Lethal Company Mod Library

## Install Instructions

<br>

> [!TIP]
> **Don't know how to install? Review the information below**

### MelonLoader
- Download [MelonLoader.Installer.exe](https://github.com/LavaGang/MelonLoader/releases/latest)
- Run MelonLoader.Installer.exe
- Click the **select** button.
- Select Lethal Company.exe in your Game's Installation Folder.
- Uncheck **Latest** and select version **v0.6.1** from the Drop-Down List.
- Once the installation is successful, open the game through Steam.
- Place **Lethal_Library.dll** into the newly created Mods folder inside the Game's Installation Folder.

<br>

### BepInEx

<br>

> [!WARNING]
> **Not supported at this time**

<br>

## Usage
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

## UI

<br>

> [!NOTE]
> **Functions that handle the in-game UI**

<br>

- **SendNotification(string MessageBody, string ButtonText)** > `void`
  - Send a notification popup on the MainMenu scene
        
- **GameObject GetCanvas()** > `GameObject`
  - Get Reference to Canvas
    
## Player
    
<br>

> [!NOTE]
> **Functions that handle player properties**

<br>

- **SetAntiCheatStatus(PlayerControllerB Player, bool IsAntiCheatEnabled)** > `void`
  - Set anti-cheat status
        
- **IsAntiCheatEnabled(PlayerControllerB Player)** > `bool`
  - Get anti-cheat status
    
- **IsInGame()** > `bool`
  - Checks if the player is currently in the game
    
- **IsInMainMenu()** > `bool`
  - Checks if the player is currently in the main menu

- **GetPlayerName(PlayerControllerB Player)** > `string`
  - Returns the players name

- **GetPlayerByName(string PlayerName)** > `PlayerControllerB`
  - Returns the player controller of the player

- **GetPlayer(string PlayerID)** > `PlayerControllerB`
  - Returns the player controller of the player

- **GetAllPlayers()** > `List<PlayerControllerB>`
  - Returns all currently controlled players

- **IsCurrentPlayer(PlayerControllerB Player)** > `bool`
  - Checks if the player is the current player

- **SearchForControlledPlayer()** > `PlayerControllerB`
  - Searches for the currently controlled player

- **SearchForPlayer(PlayerControllerB Player)** > `PlayerControllerB`
  - Checks if a player is currently being controlled

- **SetPlayerHealth(PlayerControllerB Player, int Healt)** > `void`
  - Set the player's health

- **GetPlayerHealth(PlayerControllerB Player)** > `int`
  - Get the player's health
    
- **SetPlayerSpeed(PlayerControllerB Player, float Speed)** > `void`
  - Set the player's speed

- **GetPlayerSpeed(PlayerControllerB Player)** > `float`
  - Get the player's speed

- **SetPlayerJumpForce(PlayerControllerB Player, float JumpForce)** > `void`
  - Set the player's jump force

- **GetPlayerJumpForce(PlayerControllerB Player)** > `float`
  - Get the player's jump force

- **SetSprintState(PlayerControllerB Player, bool IsSprinting)** > `void`
  - Set the player's sprint state

- **GetSprintState(PlayerControllerB Player)** > `bool`
  - Get the player's sprint state
 
- **AddHelmet()** > `void`
  - Adds the current player's helmet

- **RemoveHelmet()** > `void`
  - Remove the current player's helmet

- **SetClimbSpeed(PlayerControllerB Player, float ClimbSpeed)** > `void`
  - Set the player's climb speed

- **GetClimbSpeed(PlayerControllerB Player)** > `float`
  - Get the player's climb speed

- **SetDrunkness(PlayerControllerB Player, float Drunkness)** > `void`
  - Set the player's drunkness

- **GetDrunkness(PlayerControllerB Player)** > `float`
  - Set the player's drunkness

- **IsDrunk(PlayerControllerB Player)** > `bool`
  - Check if player is drunk

- **SetDrunknessInertia(PlayerControllerB Player, float DrunknessInertia)** > `void`
  - Set the player's drunkness inertia

- **GetDrunknessInertia(PlayerControllerB Player)** > `float`
  - Get the player's drunkness inertia

- **SetDrunkRecoveryTime(PlayerControllerB Player, float DrunknessSpeed)** > `void`
  - Set the player's drunkness recovery time

- **GetDrunkRecoveryTime(PlayerControllerB Player)** > `float`
  - Get the player's drunkness recovery time

- **SetGrabDistance(PlayerControllerB Player, float GrabDistance)** > `void`
  - Set the player's grab distance

- **GetGrabDistance(PlayerControllerB Player)** > `float`
  - Get the player's grab distance

- **SetHinderedMultiplier(PlayerControllerB Player, float HinderedMultiplier)** > `void`
  - Set the player's hindered multiplier

- **GetHinderedMultiplier(PlayerControllerB Player)** > `float`
  - Get the player's hindered multiplier

- **SetHindered(PlayerControllerB Player, int IsHindered)** > `void`
  - Set the player's hindered status

- **IsHindered(PlayerControllerB Player)** > `int`
  - Get the player's hindered status

- **IsInTerminalMenu(PlayerControllerB Player)** > `bool`
  - Check if the player is in the Terminal menu

- **SetExhausted(PlayerControllerB Player, bool isExhausted)** > `void`
  - Set player's exhaustion

- **IsExhausted(PlayerControllerB Player)** > `bool`
  - Get player's exhaustion

- **SetInsanitySpeedMultiplier(PlayerControllerB Player, float InsanitySpeedMultiplier)** > `void`
  - Set the player's insanity speed multiplier

- **GetInsanitySpeedMultiplier(PlayerControllerB Player)** > `float`
  - Get the player's insanity speed multiplier

- **SetMaxInsanity(PlayerControllerB Player, float MaxInsanity)** > `void`
  - Set the player's max insanity 

- **GetMaxInsanity(PlayerControllerB Player)** > `float`
  - Get the player's max insanity

- **SetMinVelocityToTakeDamage(PlayerControllerB Player, float MinVelocityToTakeDamage)** > `void`
  - Set min velocity to take damage

- **GetMinVelocityToTakeDamage(PlayerControllerB Player)** > `float`
  - Get min velocity to take damage

- **IsTypingInChat(PlayerControllerB Player)** > `bool`
  - Check if player is typing in chat

- **SetUnderWater(PlayerControllerB Player, bool IsUnderWater)** > `void`
  - Set if player is under water

- **IsUnderWater(PlayerControllerB Player)** > `bool`
  - Check if player is under water
 
- **SetDead(PlayerControllerB Player, bool IsDead)** > `void`
  - Set if player is dead

- **IsDead(PlayerControllerB Player)** > `bool`
  - Check if player is dead

- **SetSliding(PlayerControllerB Player, bool IsSliding)** > `void`
  - Set player's sliding status

- **IsSliding(PlayerControllerB Player)** > `bool`
  - Check if player is sliding

- **SetSinking(PlayerControllerB Player, bool IsSinking)** > `void`
  - Set player's sinking status

- **IsSinking(PlayerControllerB Player)** > `bool`
  - Check if the player is sinking

- **SetSinkingSpeedMultiplier(PlayerControllerB Player, float SinkingSpeedMultiplier)** > `void`
  - Set player's sinking speed multiplier

- **GetSinkingSpeedMultiplier(PlayerControllerB Player)** > `float`
  - Get player's sinking speed multiplier

- **GetPlaceOfDeath(PlayerControllerB Player)** > `Vector3`
  - Get player's place of death

- **SetLevelNumber(PlayerControllerB Player, int LevelNumber)** > `void`
  - Set player's level number

- **GetLevelNumber(PlayerControllerB Player)** > `int`
  - Get player's level number

- **GetRigidbody(PlayerControllerB Player)** > `Rigidbody`
  - Get player's Rigidbody

- **IsSpeakingIntoWalkieTalkie(PlayerControllerB Player)** > `bool`
  - Check if player is speaking into walkie talkie

- **GetPlayerPosition(PlayerControllerB Player)** > `Vector3`
  - Get player's server position

- **GetSpawnPoint(PlayerControllerB Player)** > `Vector3`
  - Get the spawn point of the player

- **IsAlone(PlayerControllerB Player)** > `bool`
  - Check if player is alone

- **IsInsideFactory(PlayerControllerB Player)** > `bool`
  - Check if player is inside the factory

- **IsInsideElevator(PlayerControllerB Player)** > `bool`
  - Check if player is inside the elevator

- **IsInspectingItem(PlayerControllerB Player)** > `bool`
  - Check if player is inspecting an item

- **IsClimbingLadder(PlayerControllerB Player)** > `bool`
  - Check if player is climbing a ladder

- **IsHoldingItem(PlayerControllerB Player)** > `bool`
  - Check if player is holding an item

- **SetJetpackControls(PlayerControllerB Player, bool JetpackControls)** > `void`
  - Set the player's jetpackcontrols status

- **GetJetpackControls(PlayerControllerB Player)** > `bool`
  - Get the player's jetpackcontrols status

- **SetHealthRegenTimer(PlayerControllerB Player, float HealthRegenTimer)** > `void`
  - Set the player's health regen timer

- **GetHealthRegenTimer(PlayerControllerB Player)** > `float`
  - Get the player's health regen timer

- **IsInsideShip(PlayerControllerB Player)** > `bool`
  - Check if player is inside the ship

- **JustConnected(PlayerControllerB Player)** > `bool`
  - Check if player just connected

- **HasDisconnected(PlayerControllerB Player)** > `bool`
  - Check if player has disconnected

- **SetSprintMeterValue(PlayerControllerB Player, float SprintMeterValue)** > `void`
  - Set player's sprint meter value

- **GetSprintMeterValue(PlayerControllerB Player)** > `float`
  - Get the player's sprint meter value

- **SetThrowPower(PlayerControllerB Player, float ThrowPower)** > `void`
  - Set player's throw power

- **GetThrowPower(PlayerControllerB Player)** > `float`
  - Get the player's throw power

- **SetTwoHanded(PlayerControllerB Player, bool TwoHanded)** > `void`
  - Set player's twohanded value

- **IsTwoHanded(PlayerControllerB Player)** > `bool`
  - Check player's twohanded value

- **SetVoiceMuffeled(PlayerControllerB Player, bool VoiceMuffeled)** > `void`
  - Set if player's voice is muffeled

- **IsVoiceMuffeled(PlayerControllerB Player)** > `bool`
  - Check if player's voice is muffeled

- **AddBloodToPlayerBody(PlayerControllerB Player)** > `void`
  - Add blood to player body

- **RemoveBloodFromPlayerBody(PlayerControllerB Player)** > `void`
  - Remove blood from player body

- **Crouch(PlayerControllerB Player, bool IsCrouching)** > `void`
  - Set player's crouch status

- **IsCrouching(PlayerControllerB Player)** > `bool`
  - Check if player is crouching

- **DamagePlayer(PlayerControllerB Player, int Damage)** > `void`
  - Damage player

- **KillPlayer(PlayerControllerB Player)** > `void`
  - Kill player

- **DropAllHeldItems(PlayerControllerB Player)** > `void`
  - Drop all held items

- **GetPlayerID(PlayerControllerB Player)** > `ulong`
  - Get the player's client id

- **SetPlayerSuitID(PlayerControllerB Player, int SuitID)** > `void`
  - Set the player's suit id

- **GetPlayerSuitID(PlayerControllerB Player)** > `int`
  - Get the player's suit id

- **SetPlayerCarryWeight(PlayerControllerB Player, float CarryWeight)** > `void`
  - Set the player's carry weight

- **GetPlayerCarryWeight(PlayerControllerB Player)** > `float`
  - DETAILS

- **TeleportPlayer(PlayerControllerB Player, Vector3 Position)** > `void`
  - Teleport player

- **SetPlayerController(PlayerControllerB Player, bool PlayerControllerEnabled)** > ``void``
  - Set the player's playercontroller status

- **GetPlayerController(PlayerControllerB Player)** > `bool`
  - Get the player's playercontroller status

- **ToggleNoclip(PlayerControllerB Player, bool mode)** > `void`
  - Toggles noclip

- **IsNoClip(PlayerControllerB Player, bool mode)** > `bool`
  - Checks if current player is has noclip on
 
- **ToggleInfiniteSprint(bool mode)** > `void`
  - Toggles infinite sprint
 
- **IsInfiniteSprint()** > `bool`
  - Checks if player has infinite sprint
    
## Graphics

<br>

> [!NOTE]
> **Functions that handle the in-game graphics**

<br>

- **RemoveVolumetricLighting()** > `void`
  - Remove volumetric lighting

- **SetAntiAliasingMethod(HDAdditionalCameraData hDAdditionalCameraData, string AntiAliasingMode)** > `void`
  - Set Anti-Aliasing method

- **GetAntiAliasingMethod(HDAdditionalCameraData hDAdditionalCameraData)** > `HDAdditionalCameraData.AntialiasingMode`
  - Get Anti-Aliasing method

## Camera

<br>

> [!NOTE]
> **Functions that handle the in-game player camera**

<br>

- **GetCamera(PlayerControllerB Player)** > `Camera`
  - Get the player's Camera

- **GetHDAdditionalCameraData(Camera Camera)** > `HDAdditionalCameraData`
  - Get HDAdditionalCameraData

- **SetFOV(Camera Camera, float FOV)** > `void`
  - Set the player's Camera FOV

- **GetFOV(Camera Camera)** > `float`
  - Get the player's Camera FOV

- **SetNearClipPlane(Camera Camera, float NearClipPlane)** > `void`
  - Set the player's Camera near clip plane

- **GetNearClipPlane(Camera Camera)** > `float`
  - Get the player's Camera near clip plane

- **SetFarClipPlane(Camera Camera, float FarClipPlane)** > `void`
  - Set the player's Camera far clip plane

- **GetFarClipPlane(Camera Camera)** > `float`
  - Get the player's Camera far clip plane

- **SetLookSensitivity(PlayerControllerB Player, float LookSensitivity)** > `void`
  - Set look sensitivity

- **GetLookSensitivity(PlayerControllerB Player)** > `float`
  - Get look sensitivity

- **SetSmoothLookMultiplier(PlayerControllerB Player, float SmoothLookMultiplier)** > `void`
  - Set smooth look multiplier

- **GetSmoothLookMultiplier(PlayerControllerB Player)** > `float`
  - Get smooth look multiplier

## Terminal

<br>

> [!NOTE]
> **Functions that handle the in-game terminal properties**

<br>

- **GetTerminal()** > `Terminal`
  - Get Terminal Reference

- **SetGroupCredits(Terminal Terminal, int GroupCredits)** > `void`
  - Set Group Credits from Terminal

- **GetGroupCredits(Terminal Terminal)** > `int`
  - Get Group Credits from Terminal
    
- **IsTerminalInUse(Terminal Terminal)** > `bool`
  - Check if Terminal is in use
    
- **GetQuotaSettings(Terminal Terminal)** > `QuotaSettings`
  - Get QuotaSettings reference
    
- **SetGroupStartingCredits(QuotaSettings QuotaSettings, int GroupStartingCredits)** > `void`
  - Set the groups starting credits
    
- **GetGroupStartingCredits(QuotaSettings QuotaSettings)** > `int`
  - Get the groups starting credits
    
- **SetGroupStartingQuota(QuotaSettings QuotaSettings, int GroupStartingQuota)** > `void`
  - Set the groups starting quota
    
- **GetGroupStartingQuota(QuotaSettings QuotaSettings)** > `int`
  - Get the groups starting quota
    
- **SetQuotaBaseIncrease(QuotaSettings QuotaSettings, int QuotaBaseIncrease)** > `void`
  - Set quota base increase
    
- **GetQuotaBaseIncrease(QuotaSettings QuotaSettings)** > `float`
  - Get quota base increase
    
- **SetQuotaBaseIncreaseMultiplier(QuotaSettings QuotaSettings, float QuotaBaseIncreaseMultiplier)** > `void`
  - Set quota base increase multiplier
    
- **GetQuotaBaseIncreaseMultiplier(QuotaSettings QuotaSettings)** > `float`
  - Get quota base increase multiplier
    
- **SetQuotaDeadline(QuotaSettings QuotaSettings, int Days)** > `void`
  - Set quota deadline
    
- **GetQuotaDeadline(QuotaSettings QuotaSettings)** > `int`
  - Get quota deadline
