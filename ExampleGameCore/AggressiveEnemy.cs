using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RogueSharp;

namespace ExampleGame
{
   public class AggressiveEnemy : Figure
   {
      private readonly PathToPlayer _path;
      private readonly IMap _map;
      private bool _isAwareOfPlayer;
      
      public AggressiveEnemy( IMap map, PathToPlayer path )
      {
         _map = map;
         _path = path;
      }
      public void Draw( SpriteBatch spriteBatch )
      {
         spriteBatch.Draw( 
            texture: Sprite, 
            position: new Vector2( X * Sprite.Width, Y * Sprite.Height ), 
            sourceRectangle: null, 
            color: Microsoft.Xna.Framework.Color.White, 
            rotation: 0.0f, 
            origin: Vector2.Zero, 
            scale: 1f, 
            effects: Microsoft.Xna.Framework.Graphics.SpriteEffects.None, 
            layerDepth: LayerDepth.Figures
         );
         _path.Draw( spriteBatch );
      }
      public void Update()
      {
         if ( !_isAwareOfPlayer )
         {
            if ( _map.IsInFov( X, Y ) )
            {
               _isAwareOfPlayer = true;
            }
         }

         if ( _isAwareOfPlayer )
         {
            _path.CreateFrom( X, Y );
            if ( Global.CombatManager.IsPlayerAt( _path.FirstCell.X, _path.FirstCell.Y ) )
            {    
               Global.CombatManager.Attack( this, Global.CombatManager.FigureAt( _path.FirstCell.X, _path.FirstCell.Y ) );
            }
            else
            {
               X = _path.FirstCell.X;
               Y = _path.FirstCell.Y;
            }
         }
      }
   }
}