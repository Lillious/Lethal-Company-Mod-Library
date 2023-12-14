using MelonLoader;
using Lethal_Library;
using GameNetcodeStuff;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
[assembly: MelonInfo(typeof(Library), "Lethal Company Mod Library", "1.0.0", "Lillious & .Zer0")]
[assembly: MelonGame("ZeekerssRBLX", "Lethal Company")]

namespace Lethal_Library
{
    public class Library : MelonMod
    {
        /* System */

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

        // Notification System
        public void SendNotification(string MessageBody, string ButtonText)
        {
            GetCanvas().transform.Find("MenuManager").gameObject.GetComponent<MenuManager>().DisplayMenuNotification($"{MessageBody}", $"{ButtonText}");
        }

        // Get Reference to Canvas
        public GameObject GetCanvas()
        {
            return GameObject.Find("Canvas").gameObject;
        }

        /* Player */

        // Returns the player controller of the player
        public PlayerControllerB GetPlayer(string PlayerID)
        {
            int PlayerIDInt = int.Parse(PlayerID); 

            if (PlayerIDInt == 1)
            {
                return GameObject.Find("Player").gameObject.GetComponent<PlayerControllerB>();
            } else if (PlayerIDInt > 1)
            {
                return GameObject.Find($"Player ({PlayerIDInt - 1})").gameObject.GetComponent<PlayerControllerB>();
            } else
            {
                return null;
            }
        }

        public bool IsCurrentPlayer(PlayerControllerB Player)
        {
            return Player.isPlayerControlled;
        }

        public PlayerControllerB SearchForControlledPlayer()
        {
            for (int i = 0; i < 4; i++)
            {
                if (GetPlayer(i.ToString()) != null)
                {
                    if (IsCurrentPlayer(GetPlayer(i.ToString())))
                    {
                        return GetPlayer(i.ToString());
                    }
                }
            }
            return null;
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

        // Remove the player's helmet
        public void RemoveHelmet(PlayerControllerB Player)
        {
            GameObject PlayerHUDHelmetModel = GameObject.Find("PlayerHUDHelmetModel").gameObject;
            PlayerHUDHelmetModel.SetActive(false);
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

        // Set the player's drunkness speed
        public void SetDrunknessSpeed(PlayerControllerB Player, float DrunknessSpeed)
        {
            Player.drunknessSpeed = DrunknessSpeed;
        }

        // Get the player's drunkness speed
        public float GetDrunknessSpeed(PlayerControllerB Player)
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
        public void SetExhaustion(PlayerControllerB Player, bool isExhausted)
        {
            Player.isExhausted = isExhausted;
        }

        // Get player's exhaustion
        public bool GetExhaustion(PlayerControllerB Player)
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

        // Get if player is under water
        public bool GetUnderWater(PlayerControllerB Player)
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

        // Get player's sliding status
        public bool GetSliding(PlayerControllerB Player)
        {
            return Player.isPlayerSliding;
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
        public Vector3 GetServerPosition(PlayerControllerB Player)
        {
            return Player.serverPlayerPosition;
        }

        // Set player's server position
        public void SetServerPosition(PlayerControllerB Player, Vector3 ServerPosition)
        {
            Player.serverPlayerPosition = ServerPosition;
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

        // Check player's sprint meter value
        public float GetSprintMeterValue(PlayerControllerB Player)
        {
            return Player.sprintMeter;
        }

        // Set player's sprint meter value
        public void SetSprintMeterValue(PlayerControllerB Player, float SprintMeterValue)
        {
            Player.sprintMeter = SprintMeterValue;
        }

        // Check player's throw power
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
        public bool IsVoiceMuffeled(PlayerControllerB Player)
        {
            return Player.voiceMuffledByEnemy;
        }

        // Set if player's voice is muffeled
        public void SetVoiceMuffeled(PlayerControllerB Player, bool VoiceMuffeled)
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
            Player.DamagePlayer(Damage);
        }

        // Drop all held items
        public void DropAllHeldItems(PlayerControllerB Player)
        {
            Player.DropAllHeldItems();
        }

        // Get the player's id
        public ulong GetPlayerID(PlayerControllerB Player)
        {
            return Player.playerClientId;
        }
        
        // Teleport player
        public void TeleportPlayer(PlayerControllerB Player, Vector3 Position)
        {
            Player.TeleportPlayer(Position);
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
            return Player.transform.Find("ScavengerModel").transform.Find("metarig").transform.Find("CameraContainer").transform.Find("MainCamera").GetComponent<Camera>();
        }

        // Get HDAdditionalCameraData
        public HDAdditionalCameraData GetHDAdditionalCameraData(Camera Camera)
        {
            return Camera.GetComponent<HDAdditionalCameraData>();
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

        // Get Terminal Reference
        public Terminal GetTerminal()
        {
            return Object.FindObjectOfType<Terminal>().gameObject.GetComponent<Terminal>();
        }

        // Get Group Credits from Terminal
        public int GetGroupCredits(Terminal Terminal)
        {
            return Terminal.groupCredits;
        }

        // Set Group Credits from Terminal
        public void SetGroupCredits(Terminal Terminal, int GroupCredits)
        {
            Terminal.groupCredits = GroupCredits;
        }
    }
}
