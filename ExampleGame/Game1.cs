#region Using Statements
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RogueSharp;

#endregion

namespace ExampleGame
{
   /// <summary>
   /// This is the main type for your game
   /// </summary>
   public class Game1 : Game
   {
      GraphicsDeviceManager graphics;
      SpriteBatch spriteBatch;

      private Texture2D _floor;
      private Texture2D _wall;
      private IMap _map;

      public Game1()
         : base()
      {
         graphics = new GraphicsDeviceManager( this );
         Content.RootDirectory = "Content";

      }

      /// <summary>
      /// Allows the game to perform any initialization it needs to before starting to run.
      /// This is where it can query for any required services and load any non-graphic
      /// related content.  Calling base.Initialize will enumerate through any components
      /// and initialize them as well.
      /// </summary>
      protected override void Initialize()
      {
         // TODO: Add your initialization logic here
         IMapCreationStrategy<Map> mapCreationStrategy = new RandomRoomsMapCreationStrategy<Map>( 50, 30, 100, 7, 3 );
         _map = Map.Create( mapCreationStrategy );

         base.Initialize();
      }

      /// <summary>
      /// LoadContent will be called once per game and is the place to load
      /// all of your content.
      /// </summary>
      protected override void LoadContent()
      {
         // Create a new SpriteBatch, which can be used to draw textures.
         spriteBatch = new SpriteBatch( GraphicsDevice );

         // TODO: use this.Content to load your game content here
         _floor = Content.Load<Texture2D>( "Floor" );
         _wall = Content.Load<Texture2D>( "Wall" );
      }

      /// <summary>
      /// UnloadContent will be called once per game and is the place to unload
      /// all content.
      /// </summary>
      protected override void UnloadContent()
      {
         // TODO: Unload any non ContentManager content here
      }

      /// <summary>
      /// Allows the game to run logic such as updating the world,
      /// checking for collisions, gathering input, and playing audio.
      /// </summary>
      /// <param name="gameTime">Provides a snapshot of timing values.</param>
      protected override void Update( GameTime gameTime )
      {
         if ( GamePad.GetState( PlayerIndex.One ).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown( Keys.Escape ) )
            Exit();

         // TODO: Add your update logic here

         base.Update( gameTime );
      }

      /// <summary>
      /// This is called when the game should draw itself.
      /// </summary>
      /// <param name="gameTime">Provides a snapshot of timing values.</param>
      protected override void Draw( GameTime gameTime )
      {
         GraphicsDevice.Clear( Color.CornflowerBlue );

         // TODO: Add your drawing code here
         spriteBatch.Begin( SpriteSortMode.BackToFront, BlendState.AlphaBlend );

         int sizeOfSprites = 64;
         foreach ( Cell cell in _map.GetAllCells() )
         {
            if ( cell.IsWalkable )
            {
               var position = new Vector2( cell.X * sizeOfSprites, cell.Y * sizeOfSprites );
               spriteBatch.Draw( _floor, position, Color.White );
            }
            else
            {
               var position = new Vector2( cell.X * sizeOfSprites, cell.Y * sizeOfSprites );
               spriteBatch.Draw( _wall, position, Color.White );
            }
         }

         spriteBatch.End();

         base.Draw( gameTime );
      }
   }
}
