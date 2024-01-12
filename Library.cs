using MelonLoader;
using GameNetcodeStuff;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
using Lethal_Library;
using System.Collections.Generic;
#pragma warning disable CS0436 // Type conflicts with imported type
[assembly: MelonInfo(typeof(Library), "Lethal Company Mod Library", "1.0.0", "Lillious & .Zer0")]
[assembly: MelonGame("ZeekerssRBLX", "Lethal Company")]
namespace Lethal_Library {

    public class SharedData
    {
        public static bool IsInGame { get; set; }
        public static bool IsInMainMenu { get; set; }
        public static bool IsNoClip { get; set; }
        public static bool IsInfiniteSprint { get; set; }
        public static bool Initialized { get; set; }
    }

    public class Library : MelonMod
    {

        // Check if player is in game
        public bool IsInGame()
        {
            return SharedData.IsInGame;
        }

        // Check if player is in main menu
        public bool IsInMainMenu()
        {
            return SharedData.IsInMainMenu;
        }

        // Check if mod has been initialized
        public bool IsInitialized()
        {
            return SharedData.Initialized;
        }

        // Set the Initialzed status
        public void SetInitialized(bool Initialized)
        {
            SharedData.Initialized = Initialized;
        }

        public bool IsNoClip()
        {
            return SharedData.IsNoClip;
        }

        public bool IsInfiniteSprint()
        {
            return SharedData.IsInfiniteSprint;
        }

        // Set anti-cheat status
        public void SetAntiCheatStatus(PlayerControllerB Player, bool IsAntiCheatEnabled)
        {
            Player.isSpeedCheating = IsAntiCheatEnabled;
        }

        // Get anti-cheat status
        public bool IsAntiCheatEnabled(PlayerControllerB Player)
        {
            return Player.isSpeedCheating;
        }

        /* UI */

        // Send a notification popup on the MainMenu scene
        public void SendNotification(string MessageBody, string ButtonText)
        {
            GetCanvas().transform.Find("MenuManager")?.gameObject.GetComponent<MenuManager>()?.DisplayMenuNotification($"{MessageBody}", $"{ButtonText}");
        }

        // Get Reference to Canvas
        public GameObject GetCanvas()
        {
            return GameObject.Find("Canvas")?.gameObject;
        }

        /* Player */

        // Returns the players name
        public string GetPlayerName(PlayerControllerB Player)
        {
            try
            {
                if (Player == null) return null;
                return Player.playerUsername;
            }
            catch
            {
                return null;
            }
        }

        // Returns the player controller of the player by name
        public PlayerControllerB GetPlayerByName(string PlayerName)
        {
            try
            {
                // Create a list of all players in the game
                List<PlayerControllerB> Players = GetAllPlayers();
                // Loop through all players in the game
                foreach (PlayerControllerB Player in Players)
                {
                    // Check if player is null (shouldn't happen)
                    if (Player == null) continue;

                    // Check if the player's name matches the name we are searching for
                    if (GetPlayerName(Player) == PlayerName)
                    {
                        return Player;
                    }
                }

                return null;

            } catch
            {
                return null;
            }
        }

        // Returns the player controller of the player
        public PlayerControllerB GetPlayer(string PlayerID)
        {
            try
            {
                int PlayerIDInt = int.Parse(PlayerID);

                // PlayerIDInt is 1
                if (PlayerIDInt == 1)
                {
                    MelonLogger.Msg($"Searching for Player");
                    PlayerControllerB player = GameObject.Find("Player")?.gameObject?.GetComponent<PlayerControllerB>() ?? null;
                    MelonLogger.Msg($"Found {GetPlayerName(player)}");
                    return player;
                }

                // PlayerIDInt is anything greater than 1
                if (PlayerIDInt > 1)
                {
                    MelonLogger.Msg($"Searching for Player ({PlayerIDInt - 1})");
                    PlayerControllerB player = GameObject.Find($"Player ({PlayerIDInt - 1})")?.gameObject?.GetComponent<PlayerControllerB>() ?? null;
                    // Player controller exists
                    if (player != null)
                    {
                        // Check if player is being controlled by a player
                        if (SearchForPlayer(player))
                        {
                            MelonLogger.Msg($"Found {GetPlayerName(player)}");
                            return player;
                        }

                        // Player is not being controlled by a player
                        return null;
                    }
                    return null;
                }
            } catch
            {
                return null;
            }
            return null;
        }

        // Check if a given is being controlled by a player
        public bool SearchForPlayer(PlayerControllerB Player)
        {
            if (Player.isPlayerControlled)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Check if player is host
        public bool IsHost ()
        {
            return GameObject.Find("Player")?.transform?.Find("ScavengerModel")?.transform?.Find("metarig")?.transform?.Find("CameraContainer")?.transform.Find("MainCamera")?.GetComponent<Camera>().enabled ?? false;
        }

        // Search for the player controller of the player
        public PlayerControllerB SearchForControlledPlayer()
        {

            if (IsHost())
            {
                return GameObject.Find("Player").GetComponent<PlayerControllerB>();
            }

            for (int i = 0; i < 4; i++)
            {
                MelonLogger.Msg($"Searching for Player ({i})");
                var Player = GameObject.Find($"Player ({i})")?.transform?.Find("ScavengerModel")?.transform?.Find("metarig")?.transform?.Find("CameraContainer")?.transform.Find("MainCamera")?.GetComponent<Camera>().enabled ?? null;
                if (Player != null)
                {
                    return GameObject.Find($"Player ({i})").GetComponent<PlayerControllerB>();
                }
            }

            return null;
        }

        // Return all players in the game that are being controlled by a player
        public List<PlayerControllerB> GetAllPlayers()
        {
            List<PlayerControllerB> Players = new List<PlayerControllerB>
            {
                // Add host
                GameObject.Find("Player")?.GetComponent<PlayerControllerB>()
            };

            // Add all other players
            for (int i = 0; i < 4; i++)
            {
                var Player = GameObject.Find($"Player ({i})")?.transform?.Find("ScavengerModel")?.transform?.Find("metarig")?.transform?.Find("CameraContainer")?.transform.Find("MainCamera")?.GetComponent<Camera>().enabled ?? null;
                if (Player != null)
                {
                    Players.Add(GameObject.Find($"Player ({i})").GetComponent<PlayerControllerB>());
                }
            }

            return Players;
        }

        // Set the player's health
        public void SetPlayerHealth(PlayerControllerB Player, int Health)
        {
            Player.health = Health;
        }

        // Get the player's health
        public int GetPlayerHealth(PlayerControllerB Player)
        {
            return Player.health;
        }

        // Set the player's speed
        public void SetPlayerSpeed(PlayerControllerB Player, float Speed)
        {
            Player.movementSpeed = Speed;
        }

        // Get the player's speed
        public float GetPlayerSpeed(PlayerControllerB Player)
        {
            return Player.movementSpeed;
        }

        // Set the player's jump force
        public void SetPlayerJumpForce(PlayerControllerB Player, float JumpForce)
        {
            Player.jumpForce = JumpForce;
        }

        // Get the player's jump force
        public float GetPlayerJumpForce(PlayerControllerB Player)
        {
            return Player.jumpForce;
        }

        // Set the player's sprint state
        public void SetSprintState(PlayerControllerB Player, bool IsSprinting)
        {
            Player.isSprinting = IsSprinting;
        }

        // Get the player's sprint state
        public bool GetSprintState(PlayerControllerB Player)
        {
            return Player.isSprinting;
        }

        // Add the player's helmet
        public void AddHelmet()
        {
            GameObject PlayerHUDHelmetModel = GameObject.Find("PlayerHUDHelmetModel")?.gameObject;
            // Set scale back to normal to render it
            PlayerHUDHelmetModel.transform.localScale = new Vector3(0.36f, 0.49f, 0.49f);
        }

        // Remove the player's helmet
        public void RemoveHelmet()
        {
            GameObject PlayerHUDHelmetModel = GameObject.Find("PlayerHUDHelmetModel")?.gameObject;
            // Set scale to 0 to prevent it from being rendered
            PlayerHUDHelmetModel.transform.localScale = new Vector3(0, 0, 0);
        }

        // Set the player's climb speed
        public void SetClimbSpeed(PlayerControllerB Player, float ClimbSpeed)
        {
            Player.climbSpeed = ClimbSpeed;
        }

        // Get the player's climb speed
        public float GetClimbSpeed(PlayerControllerB Player)
        {
            return Player.climbSpeed;
        }

        // Set the player's drunkness
        public void SetDrunkness(PlayerControllerB Player, float Drunkness)
        {
            Player.drunkness = Drunkness;
        }

        // Get the player's drunkness
        public float GetDrunkness(PlayerControllerB Player)
        {
            return Player.drunkness;
        }

        // Check if player is drunk
        public bool IsDrunk(PlayerControllerB Player)
        {
            return Player.drunkness > 0;
        }

        // Set the player's drunkness inertia
        public void SetDrunknessInertia(PlayerControllerB Player, float DrunknessInertia)
        {
            Player.drunknessInertia = DrunknessInertia;
        }

        // Get the player's drunkness inertia
        public float GetDrunknessInertia(PlayerControllerB Player)
        {
            return Player.drunknessInertia;
        }

        // Set the player's drunkness recovery time
        public void SetDrunkRecoveryTime(PlayerControllerB Player, float DrunknessSpeed)
        {
            Player.drunknessSpeed = DrunknessSpeed;
        }

        // Get the player's drunkness recovery time
        public float GetDrunkRecoveryTime(PlayerControllerB Player)
        {
            return Player.drunknessSpeed;
        }

        // Set the player's grab distance
        public void SetGrabDistance(PlayerControllerB Player, float GrabDistance)
        {
            Player.grabDistance = GrabDistance;
        }

        // Get the player's grab distance
        public float GetGrabDistance(PlayerControllerB Player)
        {
            return Player.grabDistance;
        }

        // Set the player's hindered multiplier
        public float SetHinderedMultiplier(PlayerControllerB Player, float HinderedMultiplier)
        {
            return Player.hinderedMultiplier = HinderedMultiplier;
        }

        // Get the player's hindered multiplier
        public float GetHinderedMultiplier(PlayerControllerB Player)
        {
            return Player.hinderedMultiplier;
        }

        // Get the player's hindered status
        public int IsHindered(PlayerControllerB Player)
        {
            return Player.isMovementHindered;
        }

        // Set the player's hindered status
        public void SetHindered(PlayerControllerB Player, int IsHindered)
        {
            Player.isMovementHindered = IsHindered;
        }

        // Check if the player is in the terminal menu
        public bool IsInTerminalMenu(PlayerControllerB Player)
        {
            return Player.inTerminalMenu;
        }

        // Set player's exhaustion
        public void SetExhausted(PlayerControllerB Player, bool isExhausted)
        {
            Player.isExhausted = isExhausted;
        }

        // Get player's exhaustion
        public bool IsExhausted(PlayerControllerB Player)
        {
            return Player.isExhausted;
        }

        // Set the player's insanity speed multiplier
        public void SetInsanitySpeedMultiplier(PlayerControllerB Player, float InsanitySpeedMultiplier)
        {
            Player.insanitySpeedMultiplier = InsanitySpeedMultiplier;
        }

        // Get the player's insanity speed multiplier
        public float GetInsanitySpeedMultiplier(PlayerControllerB Player)
        {
            return Player.insanitySpeedMultiplier;
        }

        // Set the player's max insanity 
        public void SetMaxInsanity(PlayerControllerB Player, float MaxInsanity)
        {
            Player.maxInsanityLevel = MaxInsanity;
        }

        // Get the player's max insanity
        public float GetMaxInsanity(PlayerControllerB Player)
        {
            return Player.maxInsanityLevel;
        }

        // Set min velocity to take damage
        public void SetMinVelocityToTakeDamage(PlayerControllerB Player, float MinVelocityToTakeDamage)
        {
            Player.minVelocityToTakeDamage = MinVelocityToTakeDamage;
        }

        // Get min velocity to take damage
        public float GetMinVelocityToTakeDamage(PlayerControllerB Player)
        {
            return Player.minVelocityToTakeDamage;
        }

        // Check if player is typing in chat
        public bool IsTypingInChat(PlayerControllerB Player)
        {
            return Player.isTypingChat;
        }

        // Set if player is under water
        public void SetUnderWater(PlayerControllerB Player, bool IsUnderWater)
        {
            Player.isUnderwater = IsUnderWater;
        }

        // Check if player is under water
        public bool IsUnderWater(PlayerControllerB Player)
        {
            return Player.isUnderwater;
        }

        // Check if player is dead
        public bool IsDead(PlayerControllerB Player)
        {
            return Player.isPlayerDead;
        }

        // Set if player is dead
        public void SetDead(PlayerControllerB Player, bool IsDead)
        {
            Player.isPlayerDead = IsDead;
        }

        // Check if player is sliding
        public bool IsSliding(PlayerControllerB Player)
        {
            return Player.isPlayerSliding;
        }

        // Set player's sliding status
        public void SetSliding(PlayerControllerB Player, bool IsSliding)
        {
            Player.isPlayerSliding = IsSliding;
        }

        // Check if the player is sinking
        public bool IsSinking(PlayerControllerB Player)
        {
            return Player.isSinking;
        }

        // Set player's sinking status
        public void SetSinking(PlayerControllerB Player, bool IsSinking)
        {
            Player.isSinking = IsSinking;
        }

        // Get player's sinking speed multiplier
        public float GetSinkingSpeedMultiplier(PlayerControllerB Player)
        {
            return Player.sinkingSpeedMultiplier;
        }

        // Set player's sinking speed multiplier
        public void SetSinkingSpeedMultiplier(PlayerControllerB Player, float SinkingSpeedMultiplier)
        {
            Player.sinkingSpeedMultiplier = SinkingSpeedMultiplier;
        }

        // Get player's place of death
        public Vector3 GetPlaceOfDeath(PlayerControllerB Player)
        {
            return Player.placeOfDeath;
        }

        // Set player's level number
        public void SetLevelNumber(PlayerControllerB Player, int LevelNumber)
        {
            Player.playerLevelNumber = LevelNumber;
        }

        // Get player's level number
        public int GetLevelNumber(PlayerControllerB Player)
        {
            return Player.playerLevelNumber;
        }

        // Get player's rigidbody
        public Rigidbody GetRigidbody(PlayerControllerB Player)
        {
            return Player.playerRigidbody;
        }

        // Check if player is speaking into walkie talkie
        public bool IsSpeakingIntoWalkieTalkie(PlayerControllerB Player)
        {
            return Player.speakingToWalkieTalkie;
        }

        // Get player's server position
        public Vector3 GetPlayerPosition(PlayerControllerB Player)
        {
            return Player.transform.position;
        }

        // Get the spawn point of the player
        public Vector3 GetSpawnPoint(PlayerControllerB Player)
        {
            return new Vector3(7.5f, 0, -14.31f);
        }

        // Check if player is alone
        public bool IsAlone(PlayerControllerB Player)
        {
            return Player.isPlayerAlone;
        }

        // Check if player is inside the factory
        public bool IsInsideFactory(PlayerControllerB Player)
        {
            return Player.isInsideFactory;
        }

        // Check if player is inside the elevator
        public bool IsInsideElevator(PlayerControllerB Player)
        {
            return Player.isInElevator;
        }

        // Check if player is inspecting an item
        public bool IsInspectingItem(PlayerControllerB Player)
        {
            return Player.IsInspectingItem;
        }

        // Check if player is climbing a ladder
        public bool IsClimbingLadder(PlayerControllerB Player)
        {
            return Player.isClimbingLadder;
        }

        // Check if player is holding an item
        public bool IsHoldingItem(PlayerControllerB Player)
        {
            return Player.isHoldingObject;
        }

        // Get the player's jetpackcontrols status
        public bool GetJetpackControls(PlayerControllerB Player)
        {
            return Player.jetpackControls;
        }

        // Set the player's jetpackcontrols status
        public void SetJetpackControls(PlayerControllerB Player, bool JetpackControls)
        {
            Player.jetpackControls = JetpackControls;
        }

        // Get the player's health regen timer
        public float GetHealthRegenTimer(PlayerControllerB Player)
        {
            return Player.healthRegenerateTimer;
        }

        // Set the player's health regen timer
        public void SetHealthRegenTimer(PlayerControllerB Player, float HealthRegenTimer)
        {
            Player.healthRegenerateTimer = HealthRegenTimer;
        }

        // Set player is in hangar ship room
        public void SetIsInHangarShipRoom(PlayerControllerB Player, bool IsInHangarShipRoom)
        {
            Player.isInHangarShipRoom = IsInHangarShipRoom;
        }

        // Check if player is inside the ship
        public bool IsInsideShip(PlayerControllerB Player)
        {
            return Player.isInHangarShipRoom;
        }

        // Check if player just connected
        public bool JustConnected(PlayerControllerB Player)
        {
            return Player.justConnected;
        }

        // Check if player has disconnected
        public bool HasDisconnected(PlayerControllerB Player)
        {
            return Player.disconnectedMidGame;
        }

        // Get the player's sprint meter value
        public float GetSprintMeterValue(PlayerControllerB Player)
        {
            return Player.sprintMeter;
        }

        // Set player's sprint meter value
        public void SetSprintMeterValue(PlayerControllerB Player, float SprintMeterValue)
        {
            Player.sprintMeter = SprintMeterValue;
        }

        // Get the player's throw power
        public float GetThrowPower(PlayerControllerB Player)
        {
            return Player.throwPower;
        }

        // Set player's throw power
        public void SetThrowPower(PlayerControllerB Player, float ThrowPower)
        {
            Player.throwPower = ThrowPower;
        }

        // Check player's twohanded value
        public bool IsTwoHanded(PlayerControllerB Player)
        {
            return Player.twoHanded;
        }

        // Set player's twohanded value
        public void SetTwoHanded(PlayerControllerB Player, bool TwoHanded)
        {
            Player.twoHanded = TwoHanded;
        }

        // Check if player's voice is muffeled
        public bool IsVoiceMuffled(PlayerControllerB Player)
        {
            return Player.voiceMuffledByEnemy;
        }

        // Set if player's voice is muffeled
        public void SetVoiceMuffled(PlayerControllerB Player, bool VoiceMuffeled)
        {
            Player.voiceMuffledByEnemy = VoiceMuffeled;
        }

        // Add blood to player body
        public void AddBloodToPlayerBody(PlayerControllerB Player)
        {
            Player.AddBloodToBody();
        }

        // Remove blood from player body
        public void RemoveBloodFromPlayerBody(PlayerControllerB Player)
        {
            Player.RemoveBloodFromBody();
        }

        // Set player's crouch status
        public void Crouch(PlayerControllerB Player, bool IsCrouching)
        {
            Player.Crouch(IsCrouching);
        }

        // Check if player is crouching
        public bool IsCrouching(PlayerControllerB Player)
        {
            return Player.isCrouching;
        }

        // Damage player
        public void DamagePlayer(PlayerControllerB Player, int Damage)
        {
            // 1 damage = 2 health for some reason
            Player.DamagePlayerFromOtherClientServerRpc(Mathf.Abs(Damage / 2), Vector3.zero, 0);
        }

        // Heal player to full health
        public void HealPlayer(PlayerControllerB Player)
        {
            Player.DamagePlayerFromOtherClientClientRpc(0, Vector3.zero, 0, 100);
        }

        // Kill Player
        public void KillPlayer(PlayerControllerB Player)
        {
            Player.DamagePlayerFromOtherClientServerRpc(100, Vector3.zero, 0);
        }

        // Apply force to player
        public void ApplyForceToPlayer(PlayerControllerB Player, Vector3 Force)
        {
            Rigidbody rigidbody = Player.GetComponent<Rigidbody>();
            rigidbody.AddForce(Force);
        }

        // Drop all held items
        public void DropAllHeldItems(PlayerControllerB Player)
        {
            Player.DropAllHeldItems();
        }

        // Get the player's client id
        public ulong GetPlayerID(PlayerControllerB Player)
        {
            return Player.playerClientId;
        }

        // Get the player's suit id
        public int GetPlayerSuitID(PlayerControllerB Player)
        {
            return Player.currentSuitID;
        }

        // Set the player's suit id
        public void SetPlayerSuitID(PlayerControllerB Player, int SuitID)
        {
            Player.currentSuitID = SuitID;
        }

        // Get the player's carry weight
        public float GetPlayerCarryWeight(PlayerControllerB Player)
        {
            return Player.carryWeight;
        }

        // Set the player's carry weight
        public void SetPlayerCarryWeight(PlayerControllerB Player, float CarryWeight)
        {
            Player.carryWeight = CarryWeight;
        }
        
        // Teleport player
        public void TeleportPlayer(PlayerControllerB Player, Vector3 Position)
        {
            Player.TeleportPlayer(Position);
        }

        // Teleport to another player by name
        public void TeleportToPlayer(PlayerControllerB Player, string PlayerName)
        {
            PlayerControllerB PlayerToTeleportTo = GetPlayerByName(PlayerName);
            TeleportPlayer(Player, GetPlayerPosition(PlayerToTeleportTo));
        }

        // Teleport a player to another player by names
        public void TeleportPlayerToPlayer(string PlayerName, string PlayerToTeleportToName)
        {
            PlayerControllerB Player = GetPlayerByName(PlayerName);
            PlayerControllerB PlayerToTeleportTo = GetPlayerByName(PlayerToTeleportToName);
            TeleportPlayer(Player, GetPlayerPosition(PlayerToTeleportTo));
        }

        // Set the player's playercontroller status
        public void SetPlayerController(PlayerControllerB Player, bool PlayerControllerEnabled)
        {
            Player.enabled = PlayerControllerEnabled;
        }

        // Get the player's playercontroller status
        public bool GetPlayerController(PlayerControllerB Player)
        {
            return Player.enabled;
        }

        // Toggle noclip
        public void ToggleNoclip(PlayerControllerB Player, bool mode)
        {
            // Get player's rigidbody
            CharacterController characterController = Player.GetComponent<CharacterController>();
            if (mode)
            {
                characterController.enableOverlapRecovery = false;
                SharedData.IsNoClip = true;
            }
            else
            {
                characterController.enableOverlapRecovery = true;
                SharedData.IsNoClip = false;
            }
        }

        // Toggle Infinite Sprint
        public void ToggleInfiniteSprint(bool mode)
        {
            SharedData.IsInfiniteSprint = mode;
        }

        /* Graphics */

        // Remove volumetric lighting
        public void RemoveVolumetricLighting()
        {
            GameObject CustomPass = GameObject.Find("CustomPass").gameObject;
            CustomPass.SetActive(false);
        }

        // Set Anti-Aliasing method
        public void SetAntiAliasingMethod(HDAdditionalCameraData hDAdditionalCameraData, string AntiAliasingMode)
        {
            switch (AntiAliasingMode)
            {
                case "None":
                    hDAdditionalCameraData.antialiasing = HDAdditionalCameraData.AntialiasingMode.None;
                    break;
                case "Fast Approximate Antialiasing":
                    hDAdditionalCameraData.antialiasing = HDAdditionalCameraData.AntialiasingMode.FastApproximateAntialiasing;
                    break;
                case "Subpixel Morphological Antialiasing":
                    hDAdditionalCameraData.antialiasing = HDAdditionalCameraData.AntialiasingMode.SubpixelMorphologicalAntiAliasing;
                    break;
                case "Temporal Antialiasing":
                    hDAdditionalCameraData.antialiasing = HDAdditionalCameraData.AntialiasingMode.TemporalAntialiasing;
                    break;
                default:
                    hDAdditionalCameraData.antialiasing = HDAdditionalCameraData.AntialiasingMode.None;
                    break;
            }
        }

        // Get Anti-Aliasing method
        public HDAdditionalCameraData.AntialiasingMode GetAntiAliasingMethod(HDAdditionalCameraData hDAdditionalCameraData)
        {
            return hDAdditionalCameraData.antialiasing;
        }

        /* Camera */

        // Get the player's camera
        public Camera GetCamera(PlayerControllerB Player)
        {
            return Player.transform?.Find("ScavengerModel")?.transform?.Find("metarig")?.transform?.Find("CameraContainer")?.transform?.Find("MainCamera")?.GetComponent<Camera>();
        }

        // Get HDAdditionalCameraData
        public HDAdditionalCameraData GetHDAdditionalCameraData(Camera Camera)
        {
            return Camera?.GetComponent<HDAdditionalCameraData>();
        }

        // Set the player's camera FOV
        public void SetFOV(Camera Camera, float FOV)
        {
            Camera.fieldOfView = FOV;
        }

        // Get the player's camera FOV
        public float GetFOV(Camera Camera)
        {
            return Camera.fieldOfView;
        }

        // Set the player's camera near clip plane
        public void SetNearClipPlane(Camera Camera, float NearClipPlane)
        {
            Camera.nearClipPlane = NearClipPlane;
        }

        // Get the player's camera near clip plane
        public float GetNearClipPlane(Camera Camera)
        {
            return Camera.nearClipPlane;
        }

        // Set the player's camera far clip plane
        public void SetFarClipPlane(Camera Camera, float FarClipPlane)
        {
            Camera.farClipPlane = FarClipPlane;
        }

        // Get the player's camera far clip plane
        public float GetFarClipPlane(Camera Camera)
        {
            return Camera.farClipPlane;
        }

        // Set look sensitivity
        public void SetLookSensitivity(PlayerControllerB Player, float LookSensitivity)
        {
            Player.lookSensitivity = LookSensitivity;
        }

        // Get look sensitivity
        public float GetLookSensitivity(PlayerControllerB Player)
        {
            return Player.lookSensitivity;
        }

        // Set smooth look multiplier
        public void SetSmoothLookMultiplier(PlayerControllerB Player, float SmoothLookMultiplier)
        {
            Player.smoothLookMultiplier = SmoothLookMultiplier;
        }

        // Get smooth look multiplier
        public float GetSmoothLookMultiplier(PlayerControllerB Player)
        {
            return Player.smoothLookMultiplier;
        }

        /* Terminal */
        // Get Terminal Reference
        public Terminal GetTerminal()
        {
            return UnityEngine.Object.FindObjectOfType<Terminal>()?.gameObject?.GetComponent<Terminal>();
        }

        // Get Group Credits from Terminal
        public int GetGroupCredits(Terminal Terminal)
        {
            return Terminal.groupCredits;
        }

        // Set Group Credits from Terminal
        public void SetGroupCredits(Terminal Terminal, int GroupCredits)
        {
            Terminal.SyncGroupCreditsServerRpc(GroupCredits, GetDropshipItems(Terminal));
        }

        // Check if Terminal is in use
        public bool IsTerminalInUse(Terminal Terminal)
        {
            return Terminal.terminalInUse;
        }

        // Get number of items in dropship
        public int GetDropshipItems(Terminal Terminal)
        {
            return Terminal.numberOfItemsInDropship;
        }

        // Get QuotaSettings reference
        public QuotaSettings GetQuotaSettings()
        {
            QuotaSettings quotaSettings = new QuotaSettings();
            return quotaSettings;
        }
    
        // Set the groups starting credits
        public void SetGroupStartingCredits(QuotaSettings QuotaSettings, int GroupStartingCredits)
        {
            QuotaSettings.startingCredits = GroupStartingCredits;
        }

        // Get the groups starting credits
        public int GetGroupStartingCredits(QuotaSettings QuotaSettings)
        {
            return QuotaSettings.startingCredits;
        }

        // Set the groups starting quota
        public void SetGroupStartingQuota(QuotaSettings QuotaSettings, int GroupStartingQuota)
        {
            QuotaSettings.startingQuota = GroupStartingQuota;
        }

        // Get the groups starting quota
        public int GetGroupStartingQuota(QuotaSettings QuotaSettings)
        {
            return QuotaSettings.startingQuota;
        }

        // Set quota base increase
        public void SetQuotaBaseIncrease(QuotaSettings QuotaSettings, int QuotaBaseIncrease)
        {
            QuotaSettings.baseIncrease = QuotaBaseIncrease;
        }

        // Get quota base increase
        public float GetQuotaBaseIncrease(QuotaSettings QuotaSettings)
        {
            return QuotaSettings.baseIncrease;
        }

        // Set quota base increase multiplier
        public void SetQuotaBaseIncreaseMultiplier(QuotaSettings QuotaSettings, float QuotaBaseIncreaseMultiplier)
        {
            QuotaSettings.increaseSteepness = QuotaBaseIncreaseMultiplier;
        }

        // Get quota base increase multiplier
        public float GetQuotaBaseIncreaseMultiplier(QuotaSettings QuotaSettings)
        {
            return QuotaSettings.increaseSteepness;
        }

        // Set quota deadline
        public void SetQuotaDeadline(QuotaSettings QuotaSettings, int Days)
        {
            QuotaSettings.deadlineDaysAmount = Days;
        }

        // Get quota deadline
        public int GetQuotaDeadline(QuotaSettings QuotaSettings)
        {
            return QuotaSettings.deadlineDaysAmount;
        }

        /* Time Events */

        // Get TimeOfDay reference
        public TimeOfDay GetTimeReference()
        {
            return UnityEngine.Object.FindObjectOfType<TimeOfDay>();
        }

        /* Ship Events */

        // Eject all players from ship

        // Force all players to ship
        public void Eject ()
        {
            StartOfRound startOfRound = UnityEngine.Object.FindObjectOfType<StartOfRound>();
            startOfRound.ManuallyEjectPlayersServerRpc();
        }

        /*Unity functions*/
        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
        {
            if (sceneName == "SampleSceneRelay")
            {
                SharedData.IsInGame = true;
            }

            if (sceneName == "MainMenu")
            {
                SharedData.IsInMainMenu = true;
                SharedData.Initialized = false;
            }
        }

        public override void OnSceneWasUnloaded(int buildIndex, string sceneName)
        {
            if (sceneName == "SampleSceneRelay")
            {
                SharedData.IsInGame = false;
                SharedData.Initialized = false;
            }

            if (sceneName == "MainMenu")
            {
                SharedData.IsInMainMenu = false;
                SharedData.Initialized = false;
            }
        }
    }
}
