using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ExampleGame
{
   public class Player
   {
      public int X { get; set; }
      public int Y { get; set; }
      public float Scale { get; set; }
      public Texture2D Sprite { get; set; }
      public void Draw( SpriteBatch spriteBatch )
      {
         float multiplier = Scale * Sprite.Width;
         spriteBatch.Draw( Sprite, new Vector2( X * multiplier, Y * multiplier ), null, null, null, 0.0f, new Vector2( Scale, Scale ), Color.White, SpriteEffects.None, 0.5f );
      }
      public void HandleInput( InputState inputState )
      {
         if ( inputState.IsLeft( PlayerIndex.One ) )
         {
            X--;
         }
         else if ( inputState.IsRight( PlayerIndex.One ) )
         {
            X++;
         }
         else if ( inputState.IsUp( PlayerIndex.One ) )
         {
            Y--;
         }
         else if ( inputState.IsDown( PlayerIndex.One ) )
         {
            Y++;
         }
      }
   }
}
