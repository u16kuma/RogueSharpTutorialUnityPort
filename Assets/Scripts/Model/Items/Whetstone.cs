﻿using RogueSharp.DiceNotation;
using RogueSharpTutorial.Controller;

namespace RogueSharpTutorial.Model
{
    public class Whetstone : Item
    {
        public Whetstone(Game game) : base(game)
        {
            Name = "Whetstone";
            RemainingUses = 5;
        }

        protected override bool UseItem()
        {
            Player player = game.Player;

            if (player.Hand == HandEquipment.None(game))
            {
                game.MessageLog.Add($"{player.Name} is not holding anything they can sharpen");
            }
            else if (player.AttackChance >= 80)
            {
                game.MessageLog.Add($"{player.Name} cannot make their {player.Hand.Name} any sharper");
            }
            else
            {
                game.MessageLog.Add($"{player.Name} uses a {Name} to sharper their {player.Hand.Name}");
                player.Hand.AttackChance += Dice.Roll("1D3");
                RemainingUses--;
            }

            return true;
        }
    }
}
