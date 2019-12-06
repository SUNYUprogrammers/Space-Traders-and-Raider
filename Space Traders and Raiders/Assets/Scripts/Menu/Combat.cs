using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Combat : MonoBehaviour
{
    Text info;
    private void OnMouseDown()
    {
        info = GameObject.Find("Text").GetComponent<Text>();
        /*info.text = "If you end a turn with a ship placed on the same tile as another player’s ship, and then select to initiate combat, you activate the “combat stage”. \n" +
        "Each ship that is engaged in combat is allowed to select one target for an attack, and if you have multiple ships engaged in this combat, you are allowed to target one ship multiple times, if able.At the start of each combat stage, each participating player is given 30 seconds to select their targets and which ships will be attacking them. Afterwards, players will be given the chance to select which of their available weapons(guns, missiles) they would like to use.This choice is important, as, if your opponent has a defensive system that counters your chosen weapon type, the weapon could be countered. \n" +
        "To begin combat, the player who began the combat(hereby referred to as Player 1) will select their attacking units, and then select a specific part of the enemy ship they wish to target, and are given a 30 second timer. Afterwards, the defending player(Player 2) will have a chance to set up a counter attack, also given 30 seconds to plan their moves.Once the time is up for both players, the game will run a damage calculation, and then report all damage to both players via a “Post Action Report”. \n" +
        "Weapons and Counters: \n" +
        "There are up to three weapon types a player can have access to, Guns, Missiles, and Space Marines.However, there are specific counters to each weapon type that a defending player may use, if they have access to them. Guns are countered by Shields, Missiles are countered with Anti - Missiles, and Space Marines are countered by Space Marines. Defense is automatically applied when the player is attacked. \n" +
        "Calculating Damage: \n" +
        "At the end of a battle sequence, the damage is calculated and then displayed to all participating players. Attacks have a 50 % chance of successfully landing, and after that is calculated, if the enemy ship has a defensive counter, that defense has an additional 50 % chance to block the attack. (To put this in simple terms, this means that an attack has a normal chance of 50 % to land an attack, and if the opponent has a counter, then the likelihood of your attack landing drops to 25 %). If an attack lands successfully, than it will: \n" +
        "A)	Remove a piece of armor from the ship. No damage can be done until all pieces of armor have been removed from the target. \n"+
        "B)	If there is no armor on the target ship, than the attacks will land the remaining attacks at their targeted locations. \n" +
        "a. If the area being damaged has a part equipped to it, the first hit to that sector will damage that part, and reveal its location to the attacker. \n" +
        "b.If the area being damaged has a part equipped to it that is currently damaged, that part is destroyed. \n" +
        "c.If the area being damaged has a destroyed ship part, or no part at all, than it will deal damage to the ship directly(See Hull Damage) \n" +
        "Hull Damage: \n" +
        "The Hull of the ship can only be damaged if the area damaged is an empty sector of the ship(or a destroyed part, as that is considered an empty sector). Hull damage works as follows: \n" +
        "A)	Frigates can be destroyed with only a single hit to the hull. \n" +
        "B)	Destroyers will be destroyed with two hits to the hull. \n" +
        "C)	Cruisers require three hits to their hull to be destroyed. \n" +
        "D)	Battleships are destroyed after taking four hits to their hull. \n" +
        "E)	Dreadnoughts are destroyed after taking five hits of hull damage. \n" +
        "Once a ship is destroyed, the attacking player who destroyed it will get any available resources that the ship contained, assuming that their ships were not destroyed in the process of the battle. \n" +
        "Post - Action Report: \n" +
        "After every round of combat, a Post-Action Report is given to give specific details on what took place during the round. The information contained in this report explains information on attacks(Whether an attack connected or was blocked, and where your ship was damaged, if it was hit at all), Damage(Which parts of the ship are damaged, which parts are destroyed, and the location of any damage parts), and Winnings(Display any resources collected during that round of combat, and, at the end of Combat, how many victory points were gained or lost). \n";
        */

        if(info.text == "If you end a turn with a ship placed on the same tile as another player’s ship, and then select to initiate combat, you activate the “combat stage”. \n" +
        "Each ship that is engaged in combat is allowed to select one target for an attack, and if you have multiple ships engaged in this combat, you are allowed to target one ship multiple times, if able.At the start of each combat stage, each participating player is given 30 seconds to select their targets and which ships will be attacking them. Afterwards, players will be given the chance to select which of their available weapons(guns, missiles) they would like to use.This choice is important, as, if your opponent has a defensive system that counters your chosen weapon type, the weapon could be countered. \n")
        {
            info.text = "To begin combat, the player who began the combat(hereby referred to as Player 1) will select their attacking units, and then select a specific part of the enemy ship they wish to target, and are given a 30 second timer. Afterwards, the defending player(Player 2) will have a chance to set up a counter attack, also given 30 seconds to plan their moves.Once the time is up for both players, the game will run a damage calculation, and then report all damage to both players via a “Post Action Report”. \n" + "Weapons and Counters: \n" +
        "There are up to three weapon types a player can have access to, Guns, Missiles, and Space Marines.However, there are specific counters to each weapon type that a defending player may use, if they have access to them. Guns are countered by Shields, Missiles are countered with Anti - Missiles, and Space Marines are countered by Space Marines. Defense is automatically applied when the player is attacked. \n";
        }
        else if (info.text == "Weapons and Counters: \n" +
        "There are up to three weapon types a player can have access to, Guns, Missiles, and Space Marines.However, there are specific counters to each weapon type that a defending player may use, if they have access to them. Guns are countered by Shields, Missiles are countered with Anti - Missiles, and Space Marines are countered by Space Marines. Defense is automatically applied when the player is attacked. \n")
        {
            info.text = "Calculating Damage: \n" +
        "At the end of a battle sequence, the damage is calculated and then displayed to all participating players. Attacks have a 50 % chance of successfully landing, and after that is calculated, if the enemy ship has a defensive counter, that defense has an additional 50 % chance to block the attack. (To put this in simple terms, this means that an attack has a normal chance of 50 % to land an attack, and if the opponent has a counter, then the likelihood of your attack landing drops to 25 %). If an attack lands successfully, than it will: \n";
        } else if (info.text == "Calculating Damage: \n" +
        "At the end of a battle sequence, the damage is calculated and then displayed to all participating players. Attacks have a 50 % chance of successfully landing, and after that is calculated, if the enemy ship has a defensive counter, that defense has an additional 50 % chance to block the attack. (To put this in simple terms, this means that an attack has a normal chance of 50 % to land an attack, and if the opponent has a counter, then the likelihood of your attack landing drops to 25 %). If an attack lands successfully, than it will: \n")
        {
            info.text = "A)	Remove a piece of armor from the ship. No damage can be done until all pieces of armor have been removed from the target. \n" +
        "B)	If there is no armor on the target ship, than the attacks will land the remaining attacks at their targeted locations. \n" +
        "a. If the area being damaged has a part equipped to it, the first hit to that sector will damage that part, and reveal its location to the attacker. \n" +
        "b.If the area being damaged has a part equipped to it that is currently damaged, that part is destroyed. \n" +
        "c.If the area being damaged has a destroyed ship part, or no part at all, than it will deal damage to the ship directly(See Hull Damage) \n";
        } else if (info.text == "A)	Remove a piece of armor from the ship. No damage can be done until all pieces of armor have been removed from the target. \n" +
        "B)	If there is no armor on the target ship, than the attacks will land the remaining attacks at their targeted locations. \n" +
        "a. If the area being damaged has a part equipped to it, the first hit to that sector will damage that part, and reveal its location to the attacker. \n" +
        "b.If the area being damaged has a part equipped to it that is currently damaged, that part is destroyed. \n" +
        "c.If the area being damaged has a destroyed ship part, or no part at all, than it will deal damage to the ship directly(See Hull Damage) \n")
        {
            info.text = "Hull Damage: \n" +
        "The Hull of the ship can only be damaged if the area damaged is an empty sector of the ship(or a destroyed part, as that is considered an empty sector). Hull damage works as follows: \n" +
        "A)	Frigates can be destroyed with only a single hit to the hull. \n" +
        "B)	Destroyers will be destroyed with two hits to the hull. \n" +
        "C)	Cruisers require three hits to their hull to be destroyed. \n" +
        "D)	Battleships are destroyed after taking four hits to their hull. \n" +
        "E)	Dreadnoughts are destroyed after taking five hits of hull damage. \n";
        } else if(info.text == "Hull Damage: \n" +
        "The Hull of the ship can only be damaged if the area damaged is an empty sector of the ship(or a destroyed part, as that is considered an empty sector). Hull damage works as follows: \n" +
        "A)	Frigates can be destroyed with only a single hit to the hull. \n" +
        "B)	Destroyers will be destroyed with two hits to the hull. \n" +
        "C)	Cruisers require three hits to their hull to be destroyed. \n" +
        "D)	Battleships are destroyed after taking four hits to their hull. \n" +
        "E)	Dreadnoughts are destroyed after taking five hits of hull damage. \n")
        {
            info.text = "Once a ship is destroyed, the attacking player who destroyed it will get any available resources that the ship contained, assuming that their ships were not destroyed in the process of the battle. \n" +
        "Post - Action Report: \n" +
        "After every round of combat, a Post-Action Report is given to give specific details on what took place during the round. The information contained in this report explains information on attacks(Whether an attack connected or was blocked, and where your ship was damaged, if it was hit at all), Damage(Which parts of the ship are damaged, which parts are destroyed, and the location of any damage parts), and Winnings(Display any resources collected during that round of combat, and, at the end of Combat, how many victory points were gained or lost). \n";
        }
        else
        {
            info.text = "If you end a turn with a ship placed on the same tile as another player’s ship, and then select to initiate combat, you activate the “combat stage”. \n" +
        "Each ship that is engaged in combat is allowed to select one target for an attack, and if you have multiple ships engaged in this combat, you are allowed to target one ship multiple times, if able.At the start of each combat stage, each participating player is given 30 seconds to select their targets and which ships will be attacking them. Afterwards, players will be given the chance to select which of their available weapons(guns, missiles) they would like to use.This choice is important, as, if your opponent has a defensive system that counters your chosen weapon type, the weapon could be countered. \n";
        }
    }
}
