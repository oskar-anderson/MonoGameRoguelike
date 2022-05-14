using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RogueSharp;

namespace ExampleGame
{
   public class Player : Figure
   {
      public void Draw( SpriteBatch spriteBatch )
      {
         spriteBatch.Draw(
            texture: Sprite,
            position: new Vector2(X * Sprite.Width, Y * Sprite.Height),
            sourceRectangle: null,
            color: Color.White,
            rotation: 0.0f,
            origin: Vector2.Zero,
            scale: 1f,
            effects: Microsoft.Xna.Framework.Graphics.SpriteEffects.None,
            layerDepth: LayerDepth.Figures
         );
      }
      public bool HandleInput( InputState inputState, IMap map )
      {
         if ( inputState.IsLeft( PlayerIndex.One ) )
         {
            int tempX = X - 1;
            if ( map.IsWalkable( tempX, Y ) )
            {
               var enemy = Global.CombatManager.EnemyAt( tempX, Y );
               if ( enemy == null )
               {
                  X = tempX;
               }
               else
               {
                  Global.CombatManager.Attack( this, enemy );
               }
               return true;
            }
         }
         else if ( inputState.IsRight( PlayerIndex.One ) )
         {
            int tempX = X + 1;
            if ( map.IsWalkable( tempX, Y ) )
            {
               var enemy = Global.CombatManager.EnemyAt( tempX, Y );
               if ( enemy == null )
               {
                  X = tempX;
               }
               else
               {
                  Global.CombatManager.Attack( this, enemy );
               }
               return true;
            }
         }
         else if ( inputState.IsUp( PlayerIndex.One ) )
         {
            int tempY = Y - 1;
            if ( map.IsWalkable( X, tempY ) )
            {
               var enemy = Global.CombatManager.EnemyAt( X, tempY );
               if ( enemy == null )
               {
                  Y = tempY;
               }
               else
               {
                  Global.CombatManager.Attack( this, enemy );
               }
               return true;
            }
         }
         else if ( inputState.IsDown( PlayerIndex.One ) )
         {
            int tempY = Y + 1;
            if ( map.IsWalkable( X, tempY ) )
            {
               var enemy = Global.CombatManager.EnemyAt( X, tempY );
               if ( enemy == null )
               {
                  Y = tempY;
               }
               else
               {
                  Global.CombatManager.Attack( this, enemy );
               }
               return true;
            }
         }
         return false;
      }
   }
}
