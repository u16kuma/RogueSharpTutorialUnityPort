﻿using RogueSharp;
using RogueSharpTutorial.Controller;
using RogueSharpTutorial.Model;

namespace RogueSharpTutorial.Utilities
{
    public static class ActorGenerator
    {
        private static Player _player = null;

        public static Monster CreateMonster(Game game, int level, Point location)
        {
            GamePool<Monster> monsterPool = new GamePool<Monster>();
            monsterPool.Add(Kobold.Create(game, level), 25);
            monsterPool.Add(Ooze.Create(game, level), 25);
            monsterPool.Add(Goblin.Create(game, level), 50);

            Monster monster = monsterPool.Get();
            monster.X = location.X;
            monster.Y = location.Y;

            return monster;
        }

        public static Player CreatePlayer(Game game)
        {
            _player = game.Player;

            if (_player == null)
            {
                _player = new Player(game)
                {
                    Attack = 2,
                    AttackChance = 50,
                    Awareness = 15,
                    Color = Colors.Player,
                    Defense = 2,
                    DefenseChance = 40,
                    Gold = 0,
                    Health = 50,
                    MaxHealth = 50,
                    Name = "Rogue",
                    Speed = 10,
                    Symbol = '@',

                    QAbility = new DoNothing(game),
                    WAbility = new DoNothing(game),
                    EAbility = new DoNothing(game),
                    RAbility = new DoNothing(game),

                    Item1 = new NoItem(game),
                    Item2 = new NoItem(game),
                    Item3 = new NoItem(game),
                    Item4 = new NoItem(game),

                    Head = HeadEquipment.None(game),
                    Body = BodyEquipment.None(game),
                    Hand = HandEquipment.None(game),
                    Feet = FeetEquipment.None(game)
                };
            }

            return _player;
        }
    }
}