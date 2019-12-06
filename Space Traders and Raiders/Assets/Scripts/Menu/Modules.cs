using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Modules : MonoBehaviour
{
    Text info;
    private void OnMouseDown()
    {
        info = GameObject.Find("Text").GetComponent<Text>();
        /*info.text = "There are eight different types of modules: \n" +
"•	Engine - A ship’s speed is equal to the number of engine modules it has. \n" +
"o Note: ship hulls do not start with any engines and therefore cannot move out of the system until one is added. \n" +
"•	Armor - Provides generic defense for a ship. When a ship takes a hit during combat, any armor modules it has will be damaged first regardless of where the attack was targeted. \n" +
"•	Beam Weapon - Allows the ship to attack using lasers.During combat, one attack is made per beam weapon module on the ship if the player chooses to attack with lasers. \n" +
"•	Shield Generator-Protects against laser attacks, reducing the chance for enemy lasers to hit by 50 %.The effect does not stack with multiple shield generators. \n" +
"•	Missile System - Allows the ship to attack using missiles.During combat, one attack is made per missile system module on the ship if the player chooses to attack with missiles. \n" +
"•	Colonization Module-If a ship with a colonization module enters an unoccupied system, the player can take control of the system.This destroys the colonization module. \n" +
"•	Anti - Missile System - Protects against missile attacks, reducing the chance for enemy missiles to hit by 50 %.Having multiple anti - missile systems will not cause this effect to stack. \n" +
"•	System Repair Module - Repairs up to three broken modules on a ship per system Repair Module at the end of a round of combat.The modules that get repaired are chosen at random if there aren’t enough system repair modules to repair them all.";
*/

        if(info.text == "There are eight different types of modules: \n" +
"•	Engine - A ship’s speed is equal to the number of engine modules it has. \n" +
"o Note: ship hulls do not start with any engines and therefore cannot move out of the system until one is added. \n" +
"•	Armor - Provides generic defense for a ship. When a ship takes a hit during combat, any armor modules it has will be damaged first regardless of where the attack was targeted. \n" +
"•	Beam Weapon - Allows the ship to attack using lasers.During combat, one attack is made per beam weapon module on the ship if the player chooses to attack with lasers. \n" +
"•	Shield Generator-Protects against laser attacks, reducing the chance for enemy lasers to hit by 50 %.The effect does not stack with multiple shield generators. \n" +
"•	Missile System - Allows the ship to attack using missiles.During combat, one attack is made per missile system module on the ship if the player chooses to attack with missiles. \n")
        {
            info.text = "•	Colonization Module-If a ship with a colonization module enters an unoccupied system, the player can take control of the system.This destroys the colonization module. \n" +
"•	Anti - Missile System - Protects against missile attacks, reducing the chance for enemy missiles to hit by 50 %.Having multiple anti - missile systems will not cause this effect to stack. \n" +
"•	System Repair Module - Repairs up to three broken modules on a ship per system Repair Module at the end of a round of combat.The modules that get repaired are chosen at random if there aren’t enough system repair modules to repair them all.";
        } else
        {
            info.text = "There are eight different types of modules: \n" +
"•	Engine - A ship’s speed is equal to the number of engine modules it has. \n" +
"o Note: ship hulls do not start with any engines and therefore cannot move out of the system until one is added. \n" +
"•	Armor - Provides generic defense for a ship. When a ship takes a hit during combat, any armor modules it has will be damaged first regardless of where the attack was targeted. \n" +
"•	Beam Weapon - Allows the ship to attack using lasers.During combat, one attack is made per beam weapon module on the ship if the player chooses to attack with lasers. \n" +
"•	Shield Generator-Protects against laser attacks, reducing the chance for enemy lasers to hit by 50 %.The effect does not stack with multiple shield generators. \n" +
"•	Missile System - Allows the ship to attack using missiles.During combat, one attack is made per missile system module on the ship if the player chooses to attack with missiles. \n";
        }
    }
}
