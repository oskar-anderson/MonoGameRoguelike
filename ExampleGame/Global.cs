﻿using RogueSharp.Random;

namespace ExampleGame
{
   public enum GameStates
   {
      None = 0,
      PlayerTurn = 1,
      EnemyTurn = 2,
      Debugging = 3
   }
   public class Global
   {
      public static readonly IRandom Random = new DotNetRandom();
      public static GameStates GameState { get; set; }
   }
}
