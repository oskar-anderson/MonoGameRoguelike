using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RogueSharp;

namespace ExampleGame
{
   public class PathToPlayer
   {
      private readonly Player _player;
      private readonly IMap _map;
      private readonly Texture2D _sprite;
      private readonly PathFinder _pathFinder;
      private IEnumerable<Cell> _cells;

      public PathToPlayer( Player player, IMap map, Texture2D sprite )
      {
         _player = player;
         _map = map;
         _sprite = sprite;
         _pathFinder = new PathFinder( map );
      }
      public Cell FirstCell
      {
         get
         {
            return _cells.First();
         }
      }
      public void CreateFrom( int x, int y )
      {
         _cells = _pathFinder.ShortestPath( _map.GetCell( x, y ), _map.GetCell( _player.X, _player.Y ) );
      }
      public void Draw( SpriteBatch spriteBatch )
      {
         if ( _cells != null && Global.GameState == GameStates.Debugging )
         {
            foreach ( Cell cell in _cells )
            {
               if ( cell != null )
               {
                  float multiplier = _sprite.Width;

                  spriteBatch.Draw( 
                     texture: _sprite, 
                     position: new Vector2( cell.X * multiplier, cell.Y * multiplier ), 
                     sourceRectangle: null, 
                     color: Microsoft.Xna.Framework.Color.Blue * .2f, 
                     rotation: 0.0f, 
                     origin: Vector2.Zero, 
                     scale: 1f, 
                     effects: Microsoft.Xna.Framework.Graphics.SpriteEffects.None, 
                     layerDepth: LayerDepth.Paths 
                     );
               }
            }
         }
      }
   }
}
