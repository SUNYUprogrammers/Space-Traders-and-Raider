using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour
{
        Text info;
        private void OnMouseDown()
        {
            info = GameObject.Find("Text").GetComponent<Text>();
            if(info.text == "Facilities \n" +
"There are five different kinds of facilities:\n" +
"•	Mine - Produces resources at the start of each turn based on the color of the system.\n" +
"•	Space Dock-Allows the construction of ships and ship modules, as well as the configuration of ships you own. (See Ship Construction)\n" +
"•	Static Defense System - Provides defense against attack from enemy ships.(See Combat / Raiding)\n" +
"•	Barracks - Allows the player to purchase space marines.\n" +
"•	Trade Center-Allows trade with other players from further away.Cannot be built by players that have the raider penalty(See Trading)\n")
            {
                info.text = "The resource cost for each type of facility is as follows: \n" +
                    "Mine: 150 Common, 20 Rare, 10 Very Rare \n" +
                    "Space Dock: 150 Common, 20 Rare, 10 Very Rare \n" +
                    "Static Defence System: 30 Common, 10 Rare \n" +
                    "Barracks: 30 Common, 10 Rare \n" +
                    "Trade Center: 30 Common, 30 Rare, 30 Very Rare";
            } else if (info.text == "The resource cost for each type of facility is as follows: \n" +
                    "Mine: 150 Common, 20 Rare, 10 Very Rare \n" +
                    "Space Dock: 150 Common, 20 Rare, 10 Very Rare \n" +
                    "Static Defence System: 30 Common, 10 Rare \n" +
                    "Barracks: 30 Common, 10 Rare \n" +
                    "Trade Center: 30 Common, 30 Rare, 30 Very Rare")
            {
                info.text = "Improving \n" +
"During a player’s turn, they can spend resources to upgrade their facilities to improve their benefits.Each facility has a “Tech Level” that starts at 1 when it is built and maxes out at 5, upgrading increases the tech level by 1.Any given facility in a system can only be upgraded once per turn.";

            }else if (info.text == "Improving \n" +
"During a player’s turn, they can spend resources to upgrade their facilities to improve their benefits.Each facility has a “Tech Level” that starts at 1 when it is built and maxes out at 5, upgrading increases the tech level by 1.Any given facility in a system can only be upgraded once per turn.")
            {
                info.text = "The effects of improving a facility’s tech level is as follows: \n" +
"•	Mine: The number of resources produced by a mine increases by 50 % of the base value for every tech level over 1.For example, a yellow system with a tech level 3 mine would produce 40 of each resource instead of 20. \n" +
"•	Space Dock: The tech level of a space dock determines how many ships can be built in that system per turn(1 per tech level).In addition, it determines what ship hulls and modules are able to be built. (See Ship Construction) \n" +
"o   Tech Level 1 \n" +
"	Hull - Frigate \n" +
"	Modules - Engine, Armor, Beam Weapon \n" +
"o   Tech Level 2 \n" +
"	Hull - Destroyer \n" +
"	Modules - Shield Generator, Missile System, Colonization Module \n" +
"o   Tech Level 3 \n" +
"	Hull - Cruiser \n" +
"	Modules - Anti - Missile System \n" +
"o   Tech Level 4 \n" +
"	Hull - Battleship \n" +
"	Modules - System Repair Module \n" +
"o   Tech Level 5 \n" +
"	Hull - Dreadnought \n" +
"	Modules - N / A \n";
            } else if (info.text == "The effects of improving a facility’s tech level is as follows: \n" +
"•	Mine: The number of resources produced by a mine increases by 50 % of the base value for every tech level over 1.For example, a yellow system with a tech level 3 mine would produce 40 of each resource instead of 20. \n" +
"•	Space Dock: The tech level of a space dock determines how many ships can be built in that system per turn(1 per tech level).In addition, it determines what ship hulls and modules are able to be built. (See Ship Construction) \n" +
"o   Tech Level 1 \n" +
"	Hull - Frigate \n" +
"	Modules - Engine, Armor, Beam Weapon \n" +
"o   Tech Level 2 \n" +
"	Hull - Destroyer \n" +
"	Modules - Shield Generator, Missile System, Colonization Module \n" +
"o   Tech Level 3 \n" +
"	Hull - Cruiser \n" +
"	Modules - Anti - Missile System \n" +
"o   Tech Level 4 \n" +
"	Hull - Battleship \n" +
"	Modules - System Repair Module \n" +
"o   Tech Level 5 \n" +
"	Hull - Dreadnought \n" +
"	Modules - N / A \n")
            {
                info.text = "•	Static Defense System: tbd \n" +
"•	Barracks: tbd \n" +
"•	Trade Center: The number of spaces away from the system that another player’s ship needs to be to trade is equal to the trade centers tech level";
            }else if (info.text == "•	Static Defense System: tbd \n" +
"•	Barracks: tbd \n" +
"•	Trade Center: The number of spaces away from the system that another player’s ship needs to be to trade is equal to the trade centers tech level")
            {
                info.text = "The resource costs for upgrading a facility to each tier are as follows: \n" +
                    "Mine: \n" +
                    "Level 2: 70 Common, 20 Rare, 10 Very Rare \n" +
                    "Level 3: 100 Common, 50 Rare, 30 Very Rare \n" +
                    "Level 4: 120 Common, 80 Rare, 50 Very Rare \n" +
                    "Level 5: 150 Common, 100 Rare, 80 Very Rare";
            }
            else if (info.text == "The resource costs for upgrading a facility to each tier are as follows: \n" +
                    "Mine: \n" +
                    "Level 2: 70 Common, 20 Rare, 10 Very Rare \n" +
                    "Level 3: 100 Common, 50 Rare, 30 Very Rare \n" +
                    "Level 4: 120 Common, 80 Rare, 50 Very Rare \n" +
                    "Level 5: 150 Common, 100 Rare, 80 Very Rare")
            {
                info.text = "Space Dock: \n" +
                    "Level 2: 100 Common, 30 Rare, 10 Very Rare \n" +
                    "Level 3: 170 Common, 60 Rare, 30 Very Rare \n" +
                    "Level 4: 220 Common, 90 Rare, 60 Very Rare \n" +
                    "Level 5: 300 Common, 120 Rare, 90 Very Rare";
            }
            else if (info.text == "Space Dock: \n" +
                    "Level 2: 100 Common, 30 Rare, 10 Very Rare \n" +
                    "Level 3: 170 Common, 60 Rare, 30 Very Rare \n" +
                    "Level 4: 220 Common, 90 Rare, 60 Very Rare \n" +
                    "Level 5: 300 Common, 120 Rare, 90 Very Rare")
            {
                info.text = "Static Defense System: \n" +
                    "Level 2: 50 Common, 30 Rare, 30 Very Rare \n" +
                    "Level 3: 100 Common, 50 Rare, 50 Very Rare \n" +
                    "Level 4: 180 Common, 100 Rare, 80 Very Rare \n" +
                    "Level 5: 200 Common, 150 Rare, 120 Very Rare";
            }
            else if (info.text == "Static Defense System: \n" +
                    "Level 2: 50 Common, 30 Rare, 30 Very Rare \n" +
                    "Level 3: 100 Common, 50 Rare, 50 Very Rare \n" +
                    "Level 4: 180 Common, 100 Rare, 80 Very Rare \n" +
                    "Level 5: 200 Common, 150 Rare, 120 Very Rare")
            {
                info.text = "Barracks: \n" +
                    "Level 2: 50 Common, 30 Rare, 30 Very Rare \n" +
                    "Level 3: 100 Common, 50 Rare, 50 Very Rare \n" +
                    "Level 4: 180 Common, 100 Rare, 80 Very Rare \n" +
                    "Level 5: 200 Common, 150 Rare, 120 Very Rare";
            }
            else if (info.text == "Barracks: \n" +
                   "Level 2: 50 Common, 30 Rare, 30 Very Rare \n" +
                   "Level 3: 100 Common, 50 Rare, 50 Very Rare \n" +
                   "Level 4: 180 Common, 100 Rare, 80 Very Rare \n" +
                   "Level 5: 200 Common, 150 Rare, 120 Very Rare")
            {
                info.text = "Trade Center: \n" +
                    "Level 2: 20 Common, 20 Rare, 20 Very Rare \n" +
                    "Level 3: 40 Common, 40 Rare, 40 Very Rare \n" +
                    "Level 4: 80 Common, 80 Rare, 80 Very Rare \n" +
                    "Level 5: 150 Common, 150 Rare, 120 Very Rare";
            }else if(info.text == "Trade Center: \n" +
                    "Level 2: 20 Common, 20 Rare, 20 Very Rare \n" +
                    "Level 3: 40 Common, 40 Rare, 40 Very Rare \n" +
                    "Level 4: 80 Common, 80 Rare, 80 Very Rare \n" +
                    "Level 5: 150 Common, 150 Rare, 120 Very Rare")
        {
            info.text = "Ship Construction \n" +
                "Frigate: 50 Common, 30 Rare, 20 Very Rare \n" +
                "Destroyer: 100 Common, 60 Rare, 40 Very Rare \n" +
                "Cruiser: 150 Common, 90 Rare, 60 Very Rare \n" +
                "Battleship: 200 Common, 120 Rare, 80 Very Rare \n" +
                "Dreadnought: 250 Common, 150 Rare, 100 Very Rare";
        } else if(info.text == "Ship Construction \n" +
                "Frigate: 50 Common, 30 Rare, 20 Very Rare \n" +
                "Destroyer: 100 Common, 60 Rare, 40 Very Rare \n" +
                "Cruiser: 150 Common, 90 Rare, 60 Very Rare \n" +
                "Battleship: 200 Common, 120 Rare, 80 Very Rare \n" +
                "Dreadnought: 250 Common, 150 Rare, 100 Very Rare")
        {
            info.text = "Modules: \n" +
                "Engine: 40 Common, 20 Rare, 0 Very Rare" +
                "Armor: 30 Common, 0 Rare, 0 Very Rare" +
                "Beam Weapon: 30 Common, 20 Rare, 10 Very Rare" +
                "Shield Generator: 20 Common, 20 Rare, 30 Very Rare" +
                "Missile System: 50 Common, 30 Rare, 20 Very Rare" +
                "Colonization Module: 60 Common, 30 Rare, 20 Very Rare" +
                "Anti-Missile System: 60 Common, 20 Rare, 20 Very Rare" +
                "System Repair Module: 0 Common, 50 Rare, 50 Very Rare";
        }else
            {
                info.text = "Facilities \n" +
"There are five different kinds of facilities:\n" +
"•	Mine - Produces resources at the start of each turn based on the color of the system.\n" +
"•	Space Dock-Allows the construction of ships and ship modules, as well as the configuration of ships you own. (See Ship Construction)\n" +
"•	Static Defense System - Provides defense against attack from enemy ships.(See Combat / Raiding)\n" +
"•	Barracks - Allows the player to purchase space marines.\n" +
"•	Trade Center-Allows trade with other players from further away.Cannot be built by players that have the raider penalty(See Trading)\n";

            }
        }
}
