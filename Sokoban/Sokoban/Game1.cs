using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Sokoban
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private List<Sprite> _sprites;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            var boxTexture = Content.Load<Texture2D>("Box");
            var playerTexture = Content.Load<Texture2D>("Player");
            var targetTexture = Content.Load<Texture2D>("Target");
            var wallTexture = Content.Load<Texture2D>("Wall");

            _sprites = new List<Sprite>()
            {
                new Player(playerTexture, new Vector2(100, 100),Color.White),
                new Box(boxTexture, new Vector2(100, 200),Color.White),
                new Wall(wallTexture, new Vector2(200, 200),Color.White),
                new Target(targetTexture, new Vector2(0, 200),Color.White),
            };
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            foreach (var sprite in _sprites)
                sprite.Update(gameTime, _sprites);
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(SpriteSortMode.BackToFront);
            foreach (var sprite in _sprites)
                sprite.Draw(_spriteBatch);
            // TODO: Add your drawing code here
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
