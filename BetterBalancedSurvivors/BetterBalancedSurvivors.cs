using System;
using System.Reflection;
using System.Collections.Generic;
using System.IO;
using BepInEx;
using RoR2;
using UnityEngine;

namespace BetterBalancedSurvivors
{

    //This is a "balance" mod, which is primarily for my own play group but I thought I'd upload it
    // in order to give people an idea of how to adjust survivor base stats.
    // This is made off of the example plugin you can find for the bepin loader.

    
    [BepInDependency("com.bepis.r2api")]

    //This attribute is required, and lists metadata for your plugin.
    //The GUID should be a unique ID for this plugin, which is human readable (as it is used in places like the config). I like to use the java package notation, which is "com.[your name here].[your plugin name here]"
    //The name is the name of the plugin that's displayed on load, and the version number just specifies what version the plugin is.
    [BepInPlugin("com.yakri.betterbalancedsurvivors", "BetterBalancedSurvivors", "1.0")]

    //This is the main declaration of our plugin class. BepInEx searches for all classes inheriting from BaseUnityPlugin to initialize on startup.
    //BaseUnityPlugin itself inherits from MonoBehaviour, so you can use this as a reference for what you can declare and use in your plugin class: https://docs.unity3d.com/ScriptReference/MonoBehaviour.html
    public class BetterBalancedSurvivors : BaseUnityPlugin
    {
        //The Awake() method is run at the very start when the game is initialized.
        public void Awake()
        {
            //Here we are subscribing to the SurvivorCatalogReady event, which is run when the subscriber catalog can be modified.
            //We insert Bandit as a new character here, which is then automatically added to the internal game catalog and reconstructed.
            R2API.SurvivorAPI.SurvivorCatalogReady += (s, e) =>
            {
                ///What I'm doing here is accessing the bodyPrefab that the R2API loads up
                ///Since I know there's a unity3D component called CharacterBody, I'm using a unity
                ///function to search the survivor body prefab for it.
                ///Then I'm altering the public variables that the developers
                ///use to set survivor stats.


                ///commando
                var commando = R2API.SurvivorAPI.SurvivorDefinitions[0];
                var cBody1 = commando.bodyPrefab.GetComponent<CharacterBody>();
                {
                    cBody1.baseMoveSpeed = 7.5f;
                    cBody1.baseMaxHealth = 120f;
                    cBody1.baseRegen = 1.5f;
                    cBody1.baseJumpPower = 15f;
                    cBody1.baseAcceleration = 80f;
                    cBody1.baseDamage = 12f;
                    cBody1.baseAttackSpeed = 1.15f;
                    cBody1.baseCrit = 1f;
                    cBody1.baseArmor = 5f;
                }
                ///engineer
                var engineer = R2API.SurvivorAPI.SurvivorDefinitions[1];
                var cBody2 = engineer.bodyPrefab.GetComponent<CharacterBody>();
                {
                    cBody2.baseMoveSpeed = 7f;
                    cBody2.baseMaxHealth = 130f;
                    cBody2.baseDamage = 13f;
                    cBody2.baseArmor = 10f;
                }
                ///huntress
                var huntress = R2API.SurvivorAPI.SurvivorDefinitions[2];
                var cBody3 = huntress.bodyPrefab.GetComponent<CharacterBody>();
                {
                    cBody3.baseMoveSpeed = 8f;
                    cBody3.baseMaxHealth = 110f;
                    cBody3.baseRegen = 1.5f;
                    cBody3.baseMaxShield = 0f;
                    cBody3.levelMaxShield = 0f;
                    cBody3.baseJumpPower = 16f;
                    cBody3.baseAcceleration = 100f;
                    cBody3.baseDamage = 13f;
                    cBody3.levelDamage = 2.6f;
                    cBody3.baseAttackSpeed = 1f;
                    cBody3.baseCrit = 10f;
                }
                /* bandit
                characterTemp = R2API.SurvivorAPI.SurvivorDefinitions[3];
                cBody = characterTemp.bodyPrefab.GetComponent<CharacterBody>();
                {
                    cBody.baseMoveSpeed = 7.5f;
                    cBody.baseMaxHealth = 121f;
                    cBody.baseRegen = 1.5f;
                    cBody.baseJumpPower = 15f;
                    cBody.baseAcceleration = 80f;
                    cBody.baseDamage = 12f;
                    cBody.baseAttackSpeed = 1.15f;
                    cBody.baseCrit = 1f;
                    cBody.baseArmor = 5f;
                }*/
                ///artificer / Mage
                var artificer = R2API.SurvivorAPI.SurvivorDefinitions[3];
                var cBody5 = artificer.bodyPrefab.GetComponent<CharacterBody>();
                {
                    cBody5.baseMoveSpeed = 7f;
                    cBody5.baseMaxHealth = 100f;
                    cBody5.baseRegen = 1.0f;
                    cBody5.baseMaxShield = 0f;
                    cBody5.levelMaxShield = 0f;
                    cBody5.baseJumpPower = 15f;
                    cBody5.baseAcceleration = 60f;
                    cBody5.baseDamage = 16f;
                    cBody5.baseAttackSpeed = 1f;
                    cBody5.baseCrit = 1f;
                    cBody5.baseArmor = 1f;
                    cBody5.levelDamage = 3.4f;
                }
                ///mercenary
                var mercenary = R2API.SurvivorAPI.SurvivorDefinitions[4];
                var cBody6 = mercenary.bodyPrefab.GetComponent<CharacterBody>();
                {
                    cBody6.baseMoveSpeed = 9f;
                    cBody6.baseMaxHealth = 160f;
                    cBody6.baseRegen = 3f;
                    cBody6.baseJumpPower = 19f;
                    cBody6.baseAcceleration = 100f;
                    cBody6.baseDamage = 14f;
                    cBody6.baseAttackSpeed = 1.05f;
                    cBody6.baseCrit = 15f;
                    cBody6.baseArmor = 5f;
                    cBody6.levelDamage = 2.8f;
                }
                ///Mul-T 
                /*
                var MulT = R2API.SurvivorAPI.SurvivorDefinitions[5];
                var cBody7 = MulT.bodyPrefab.GetComponent<CharacterBody>();
                {
                    cBody7.baseMaxHealth = 207f;
                    cBody7.baseMoveSpeed = 8f;
                    cBody7.baseDamage = 12f;
                    cBody7.baseRegen = 1.5f;
                }*/
                /*
                var survivor = new SurvivorDef
                {
                    bodyPrefab = BodyCatalog.FindBodyPrefab("BanditBody"),
                    descriptionToken = "BANDIT_DESCRIPTION",
                    displayPrefab = Resources.Load<GameObject>("Prefabs/Characters/BanditDisplay"),
                    primaryColor = new Color(0.8039216f, 0.482352942f, 0.843137264f),
                    unlockableName = ""
                };

               

                R2API.SurvivorAPI.SurvivorDefinitions.Insert(3, survivor);*/
            };
        }

        //The Update() method is run on every frame of the game.
        public void Update()
        {

        }
    }
}