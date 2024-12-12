using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Sokoban
{
    public abstract class State
    {
        protected ContentManager _contentManager;
        protected GraphicsDevice _graphics;
        protected Game1 _game;

        protected Texture2D buttonTexture;
        protected SpriteFont buttonFont;
        public State(Game1 game, ContentManager contentManager, GraphicsDevice graphics)
        {
            _contentManager = contentManager;
            _graphics = graphics;
            _game = game;
        }
        public abstract void LoadContent();
        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);
        public abstract void Update(GameTime gameTime);
        protected virtual void ToMainMenu(object sender, EventArgs e)
        {
            _game.ChangeState(new MenuState(_game, _contentManager, _graphics));
        }
        public Button CreateButton(string Text, Vector2 Position)
        {
            return new Button(buttonTexture, buttonFont, Text, Position);
        }
    }
}
