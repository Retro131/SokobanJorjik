using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using System.Net;

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
        public virtual void LoadContent()
        {

        }
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
