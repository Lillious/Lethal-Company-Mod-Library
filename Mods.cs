using System;
using System.Collections.Generic;
using GameNetcodeStuff;
using Lethal_Library;
using MelonLoader;
using UnityEngine.InputSystem;

/******************************
 *      Lethal Company Developer Console 1.0.0
 *      Authors: Lillious & .Zer0
 *      Updated As Of: 13/12/23
 *     
 *          Mod Capabilities
 *      - 
 * 
 *              TO:DO
 *          MAJOR
 *      - Build the console UI
 *      - Add "Commands" class.
 *      - Create "Terminal" section in Lethal_Library
 *      
 *          MINOR
 *      - Import onUpdate() method into class. Fix method inputs to take player input from console (infinite health and sprint)
 *      - Unlimited and increase credits, Unlimited Battery, Jump Height, noclip
 *      - ABILITY TO MANIPULATE THE TERMINAL FROM ANYWHERE USING THE DEV CONSOLE
 * 
 *      
 *          Future Features
 *      - Change TimeOfDay (Inaccurate in WeMod software, really bugs the fuck out of me so I wanna do it right in ours)
 *      - Possibly implement HD as default within the mod? Not sure how to make work but could also be toggled in console
 *      - 
 * 
 * 
 *                                          DON'T FORGET TO PUSH THIS TO THE GITHUB SO LILLIOUS HAS THIS TOO
 *****************************/

namespace Lethal_Library
{
    public class Mod : MelonMod
    {
        static Library LC_Lib = new Library();
        PlayerControllerB Player = LC_Lib.GetPlayer("Player");

        private static bool infSprintToggle = false;
        private static bool infHealthToggle = false;

        public override void OnUpdate()
        {
            if (Keyboard.current.homeKey.wasPressedThisFrame)  // HOME KEY
            {
                if (infSprintToggle)
                {
                    MelonLogger.Msg("Infinite Sprint has been toggled off");
                    infSprintToggle = false;
                }
                else
                {
                    MelonLogger.Msg("Infinite Sprint has been toggled <3");
                    infSprintToggle = true;
                }
            }
            else if (Keyboard.current.insertKey.wasPressedThisFrame)  // INSERT KEY
            {
                if (infHealthToggle)
                {
                    MelonLogger.Msg("Infinite Health has been toggled off");
                    infHealthToggle = false;
                }
                else
                {
                    MelonLogger.Msg("Infinite Health has been toggled on <3");
                    infHealthToggle = true;
                }
            }


            // Methods that run the cheats
            // Infinite Sprint Toggle
            if (infSprintToggle)
            {
                infiniteSprint(Player);
            }


        }

        // PATCHES
        // Infinite Sprint
        void infiniteSprint(PlayerControllerB Player)
        {
            Player.isSprinting = false;
        }

        // Infinite Health + No Fall Damage
        void infiniteHealth(PlayerControllerB Player)
        {
            if (Player.takingFallDamage)
            {
                Player.takingFallDamage = false;
            }
            if(Player.health <= 100)
            {
                LC_Lib.SetPlayerHealth(Player, 100);
            }
        }
     }
}




/*using MelonLoader;
using Lethal_Company;
using GameNetcodeStuff;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

[assembly: MelonInfo(typeof(Mod), "Felix's Fine Mod", "1.0.0", "Felix")]
[assembly: MelonGame("ZeekerssRBLX", "Lethal Company")]

/******************************
 *     STARTING MOD
 * Infinite Health [x] (UPDATE FOR QUICKSAND / DROWNING)
 * Infinite Sprint [x]
 * Infinite Battery []
 * Add 100 credits [x]
 *
 * 
 * 



namespace Lethal_Company
{
    public class Mod : MelonMod
    {
        private static bool infSprintToggle = false;
        private static bool infHealthToggle = false;
        private bool inGame = false;
        private bool initialized = false;
        public int HP_Old = 100;



        // Create global reference to PlayerController that becomes available after the Initialize method is called
        GameNetcodeStuff.PlayerControllerB PlayerController;

        public Keyboard keyboard = new Keyboard();

        // GameNetcodeStuff.PlayerControllerB PlayerController2;

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            // MelonLogger.Msg($"[SCENE LOADED] Name: {sceneName} Index: {buildIndex}");
            if (!inGame) return;
            if (PlayerController != null)
            {
                // Player Controller Events
            }
        }

        public override void OnSceneWasUnloaded(int buildIndex, string sceneName)
        {
            // MelonLogger.Msg($"[SCENE UNLOADED] Name: {sceneName} Index: {buildIndex}");
            if (!inGame) return;
            if (PlayerController != null)
            {
                // Player Controller Events
            }
        }

        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
        {
            // MelonLogger.Msg($"[SCENE INITIALIZED] Name: {sceneName} Index: {buildIndex}");
            if (sceneName == "SampleSceneRelay")
            {
                inGame = true;
                // Call the Initialize method when the player is in the game before anything else runs
                Initialize();
            }

            if (sceneName == "MainMenu")
            {
                // Code to run when the player is in the main menu
            }
        }

        public override void OnUpdate()
        {
            // Ensure the proper code has run during initialization so we can access it here
            if (initialized && inGame)
            {
                // Player Controller Events to run every frame
                if (PlayerController != null)
                {
                    //KEYSTROKE DETECTION
                    if (Keyboard.current.homeKey.wasPressedThisFrame)
                    {
                        if (infSprintToggle)
                        {
                            MelonLogger.Msg("Infinite Sprint has been toggled off");
                            infSprintToggle = false;
                        }
                        else
                        {
                            MelonLogger.Msg("Infinite Sprint has been toggled <3");
                            infSprintToggle = true;
                        }
                    }
                    if (Keyboard.current.insertKey.wasPressedThisFrame)
                    {
                        if (infHealthToggle)
                        {
                            MelonLogger.Msg("Infinite Health has been toggled off");
                            infHealthToggle = false;
                        }
                        else
                        {
                            MelonLogger.Msg("Infinite Health has been toggled on <3");
                            infHealthToggle = true;
                            MelonLogger.Msg("At toggle: " + PlayerController.health);
                            MelonLogger.Msg("MinVelocity: " + PlayerController.minVelocityToTakeDamage);
                        }
                    }
                    if (Keyboard.current.pageUpKey.wasPressedThisFrame)
                    {
                        add100Credits();
                    }

                    // TOGGLES
                    if (infSprintToggle)
                    {
                        infiniteSprint();
                    }
                    if (infHealthToggle)
                    {
                        infiniteHealth();
                    }
                }
            }
        }

        public void Initialize()
        {
            if (!inGame) return;
            // Set the global reference to PlayerController
            GameObject Player = GameObject.Find("Player").gameObject;
            PlayerController = Player.GetComponent<PlayerControllerB>();
            PlayerController.health = 100;
            HP_Old = PlayerController.health;

            /*
            GameObject Player2 = GameObject.Find("Player (1)").gameObject;
            PlayerController2 = Player2.GetComponent<PlayerControllerB>();
            

            MelonLogger.Msg("Felix's Fine Mod has been loaded into the game with no errors");

            // Set the initialized flag for the OnUpdate method
            initialized = true;
        }

        // PATCHES
        // Infinite Sprint
        void infiniteSprint()
        {
            if (PlayerController.isSprinting)
            {
                PlayerController.isSprinting = false;
            }
        }

        // Infinite Health + Fall Damage Negation
        void infiniteHealth()
        {
            if (PlayerController.takingFallDamage)
            {
                PlayerController.takingFallDamage = false;
            }
            if (Math.Abs(HP_Old - PlayerController.health) > 1)
            {
                PlayerController.health = 100;

            }
        }

        // CREDIT MANIPULATION

        void add100Credits()
        {
            foreach (Terminal Terminal in UnityEngine.Object.FindObjectsOfType<Terminal>())
            {
                if (Terminal != null)
                {
                    if (GameNetworkManager.Instance.localPlayerController.IsServer)
                    {
                        Terminal.groupCredits += 100;
                        MelonLogger.Msg("Terminal Group Credits: " + Terminal.groupCredits);
                    }
                    else
                    {
                        Terminal.groupCredits += 100;
                        Terminal.SyncGroupCreditsServerRpc(Terminal.groupCredits, Terminal.numberOfItemsInDropship);
                    }
                }
            }
        }

        /*void add100Profit()
        {
            MelonLogger.Msg("Original Fulfilled: " + TimeOfDay.quotaFulfilled);
            TimeOfDay.quotaFulfilled += 100;
            MelonLogger.Msg("New Fulfilled: " + TimeOfDay.quotaFulfilled);
        }
        
    }
}*/