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

        private State _currentState;
        private State _nextState;

        public MouseState MouseState;

        private Texture2D _backgroundTexture;
        private bool _isFinished;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        public void ChangeState(State state) => _nextState = state;

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = 1440;
            _graphics.PreferredBackBufferHeight = 700;
            _graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _backgroundTexture = Content.Load<Texture2D>("Background");

            _currentState = new MenuState(this, Content, _graphics.GraphicsDevice);

            //var boxTexture = Content.Load<Texture2D>("Box");
            //var playerTexture = Content.Load<Texture2D>("Player");
            //var targetTexture = Content.Load<Texture2D>("Target");
            //var wallTexture = Content.Load<Texture2D>("Wall");
            //_sprites = new List<Sprite>()
            //{
            //    new Player(playerTexture, new Vector2(100, 100),Color.White),
            //    new Box(boxTexture, new Vector2(100, 200),Color.White),
            //    new Wall(wallTexture, new Vector2(200, 200),Color.White),
            //    new Target(targetTexture, new Vector2(0, 200),Color.White),
            //};
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            //    Exit();
            //foreach (var sprite in _sprites)
            //{
            //    sprite.Update(gameTime, _sprites);
            //    if(sprite is Box)
            //    {
            //        //if (sprite.IsOnTarget());
            //    }
            //}
            //// TODO: Add your update logic here
            if(_nextState != null)
            {
                _currentState = _nextState;
                _nextState = null;
            }
            _currentState.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            //GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(SpriteSortMode.BackToFront);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 6; j++)
                    _spriteBatch.Draw(_backgroundTexture, new Vector2(j * _backgroundTexture.Width * 0.5f, i * _backgroundTexture.Width * 0.5f), null, Color.White, 0, Vector2.Zero, 0.8f, SpriteEffects.None, 1);

            }
            _currentState.Draw(gameTime, _spriteBatch);
            //foreach (var sprite in _sprites)
            //    sprite.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
