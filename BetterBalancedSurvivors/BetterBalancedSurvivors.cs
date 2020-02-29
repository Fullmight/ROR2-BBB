using System;
using System.Reflection;
using System.Collections.Generic;
using System.IO;
using BepInEx;
using RoR2;
using R2API;
using UnityEngine;

namespace BetterBalancedSurvivors
{

    // This is a "balance" mod, which is primarily for my own play group but I thought I'd upload it
    // in order to give people an idea of how to adjust survivor base stats.
    // This is made off of the example plugin you can find for the bepin loader.

    
    [BepInDependency("com.bepis.r2api")]
    //[R2APISubmoduleDependency("SurvivorAPI", "DifficultyAPI")]

    //This attribute is required, and lists metadata for your plugin.
    //The GUID should be a unique ID for this plugin, which is human readable (as it is used in places like the config). I like to use the java package notation, which is "com.[your name here].[your plugin name here]"
    //The name is the name of the plugin that's displayed on load, and the version number just specifies what version the plugin is.
    [BepInPlugin("com.yakri.barelybalancedsurvivors", "BarelyBalancedSurvivors", "1.2.1")]

    //This is the main declaration of our plugin class. BepInEx searches for all classes inheriting from BaseUnityPlugin to initialize on startup.
    //BaseUnityPlugin itself inherits from MonoBehaviour, so you can use this as a reference for what you can declare and use in your plugin class: https://docs.unity3d.com/ScriptReference/MonoBehaviour.html
    public class BetterBalancedSurvivors : BaseUnityPlugin
    {
        //internal static void SetHooks()
        //{
            //SurvivorCatalog.getAdditionalSurvivorDefs += AddSurvivorAction;
        //}
        //The Awake() method is run at the very start when the game is initialized.
        public void Start()
        {

            //Here we are subscribing to the SurvivorCatalogReady event, which is run when the subscriber catalog can be modified.
            //We insert Bandit as a new character here, which is then automatically added to the internal game catalog and reconstructed.
            //R2API.SurvivorAPI.SurvivorCatalogReady += (s, e) =>
            //{

            //On.RoR2.SurvivorCatalog.Init += (s) =>
            //{
            ///What I'm doing here is accessing the bodyPrefab that the R2API loads up
            ///Since I know there's a unity3D component called CharacterBody, I'm using a unity
            ///function to search the survivor body prefab for it.
            ///Then I'm altering the public variables that the developers
            ///use to set survivor stats.

            //engineer 2.8 dmg / level, all others 2.4 per level base.

            ///commando
            //var commando = R2API.SurvivorAPI.SurvivorDefinitions[0];
            var cBody1 = FetchBody("commando");//commando.bodyPrefab.GetComponent<CharacterBody>();
                if(cBody1 != null)
                { 
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
                }
                ///engineer
                //var engineer = R2API.SurvivorAPI.SurvivorDefinitions[1];
                var cBody2 = FetchBody("engineer");//engineer.bodyPrefab.GetComponent<CharacterBody>();
                if (cBody2 != null)
                {
                    {
                        cBody2.baseMoveSpeed = 7f;
                        cBody2.baseMaxHealth = 130f;
                        cBody2.baseDamage = 13f;
                        cBody2.baseArmor = 10f;
                    }
                }

                ///huntress
                //var huntress = R2API.SurvivorAPI.SurvivorDefinitions[2];
                var cBody3 = FetchBody("huntress");
                if (cBody3 != null)
                {
                    {
                        cBody3.baseMoveSpeed = 8f;
                        cBody3.baseMaxHealth = 110f;
                        cBody3.baseRegen = 1f;
                        cBody3.baseMaxShield = 0f;
                        cBody3.levelMaxShield = 0f;
                        cBody3.baseJumpPower = 16f;
                        cBody3.baseAcceleration = 100f;
                        cBody3.baseDamage = 13f;
                        cBody3.levelDamage = 2.6f;
                        cBody3.baseAttackSpeed = 1f;
                        cBody3.baseCrit = 10f;
                    }
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
                //var artificer = R2API.SurvivorAPI.SurvivorDefinitions[3];
                var cBody5 = FetchBody("artificer");//artificer.bodyPrefab.GetComponent<CharacterBody>();
                if (cBody5 != null)
                {
                    {
                        //cBody5.baseMoveSpeed = 7f;
                        cBody5.baseMaxHealth = 100f;
                        cBody5.baseRegen = 1.0f;
                        cBody5.baseMaxShield = 0f;
                        cBody5.levelMaxShield = 0f;
                        cBody5.baseJumpPower = 16f;
                        //cBody5.baseAcceleration = 60f;
                        cBody5.baseDamage = 14f;
                        //cBody5.baseAttackSpeed = 1f;
                        //cBody5.baseCrit = 1f;
                        //cBody5.baseArmor = 1f;
                        cBody5.levelDamage = 3.0f;
                    }
                }
                ///mercenary
                //var mercenary = R2API.SurvivorAPI.SurvivorDefinitions[4];
                var cBody6 = FetchBody("mercenary");//mercenary.bodyPrefab.GetComponent<CharacterBody>();
                if (cBody6 != null)
                {
                    {
                        cBody6.baseMoveSpeed = 8.5f;
                        cBody6.baseMaxHealth = 150f;
                        cBody6.baseRegen = 3f;
                        cBody6.baseJumpPower = 19f;
                        cBody6.baseAcceleration = 100f;
                        cBody6.baseDamage = 13f;
                        cBody6.baseAttackSpeed = 1.05f;
                        cBody6.baseCrit = 10f;
                        cBody6.baseArmor = 20f;
                        cBody6.levelDamage = 2.6f;
                    }
                }
                ///mercenary
                //var mercenary = R2API.SurvivorAPI.SurvivorDefinitions[4];
                var cBody7 = FetchBody("bandit");//mercenary.bodyPrefab.GetComponent<CharacterBody>();
                if (cBody7 != null)
                {
                    {
                        cBody7.baseMoveSpeed = 7.5f;
                        //cBody6.baseMaxHealth = 100f;
                        //cBody6.baseRegen = 1.5f;
                        //cBody6.baseJumpPower = 16f;
                        //cBody6.baseAcceleration = 100f;
                        //cBody7.baseDamage = 12f;
                        //cBody6.baseAttackSpeed = 1.00f;
                        cBody7.baseCrit = 20f;
                        //cBody6.baseArmor = 1f;
                        cBody7.levelDamage = 2.6f;
                        //cBody7.
                    }
                }
                ///Mul-T 
                //var MulT = R2API.SurvivorAPI.SurvivorDefinitions[5];
                var cBody8 = FetchBody("mul-t");//MulT.bodyPrefab.GetComponent<CharacterBody>();
                if (cBody8 != null)
                {
                    {
                        ///cBody7.baseMaxHealth = 200f;
                        cBody8.baseMoveSpeed = 8f;
                        cBody8.baseDamage = 12f;
                        cBody8.baseRegen = 1.5f;
                    }
                }

            var cBody9 = FetchBody("loader");//mercenary.bodyPrefab.GetComponent<CharacterBody>();
            if (cBody9 != null)
            {
                {
                    //cBody9.baseMoveSpeed = 8.5f;
                    //cBody9.baseMaxHealth = 150f;
                    cBody9.baseRegen = 3f;
                    cBody9.baseJumpPower = 19f;
                    //cBody9.baseAcceleration = 100f;
                    cBody9.baseDamage = 13f;
                    //cBody9.baseAttackSpeed = 1.05f;
                    //cBody9.baseCrit = 10f;
                    //cBody9.baseArmor = 20f;
                    cBody9.levelDamage = 2.6f;
                }
            }

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
            //};
        }
        /// <summary>
        /// Searches by displayed survivor name and accesses their CharacterBody
        /// component in order to edit stats on it.
        /// Theoretically works with modding characters.
        /// </summary>
        /// <param name="charName"></param>
        /// <returns></returns>
        public CharacterBody FetchBody(String charName)
        {
            CharacterBody returnChar = null;
            var survArr = SurvivorCatalog.allSurvivorDefs; //R2API.SurvivorAPI.SurvivorDefinitions;

            //for (int i = 0; i < survArr.Length; i++)
            foreach (SurvivorDef survivor in survArr)
            {
                if(survivor.displayNameToken.ToLower() == charName)
                {
                    returnChar = survivor.bodyPrefab.GetComponent<CharacterBody>();
                }
            }

            return returnChar;
        }
        
    }
}