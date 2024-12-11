using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sokoban.States;

namespace Sokoban
{
    public class Game1 : Game
    {
        public static readonly DBContext db = new DBContext();

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private State _currentState;
        private State _nextState;

        private Texture2D _backgroundTexture;
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
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            _graphics.PreferredBackBufferWidth = 1450;
            _graphics.PreferredBackBufferHeight = 700;
            _graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _backgroundTexture = Content.Load<Texture2D>("Background");

            _currentState = new LogInState(this, Content, _graphics.GraphicsDevice);

            
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            //// TODO: Add your update logic here
            if (_nextState != null)
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
