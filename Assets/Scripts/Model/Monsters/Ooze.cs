﻿using RogueSharp.DiceNotation;
using RogueSharpTutorial.Controller;

namespace RogueSharpTutorial.Model
{
    public class Ooze : Monster
    {
        public Ooze(Game game) : base(game) { }

        public static Ooze Create(Game game, int level)
        {
            int health = Dice.Roll("4D5");

            return new Ooze (game)
            {
                Attack          = Dice.Roll("1D2") + level / 3,
                AttackChance    = Dice.Roll("10D5"),
                Awareness       = 10,
                Color           = Colors.OozeColor,
                Defense         = Dice.Roll("1D2") + level / 3,
                DefenseChance   = Dice.Roll("10D4"),
                Gold            = Dice.Roll("1D20"),
                Health          = health,
                MaxHealth       = health,
                Name            = "Ooze",
                Speed           = 14,
                Symbol          = 'o'
            };
        }

        public override void PerformAction(CommandSystem commandSystem)
        {
            var splitOozeBehavior = new SplitOoze();

            if (!splitOozeBehavior.Act(this, commandSystem, game))
            {
                base.PerformAction(commandSystem);
            }
        }
    }
}