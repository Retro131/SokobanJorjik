using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.States
{
    internal class LogInState : State
    {
        private List<Button> buttons;
        public LogInState(Game1 game, ContentManager contentManager, GraphicsDevice graphics) : base(game, contentManager, graphics)
        {
            LoadContent();
            
        }
        public override void LoadContent()
        {
            buttonTexture = _contentManager.Load<Texture2D>("ButtonContent/Button");
            buttonFont = _contentManager.Load<SpriteFont>("ButtonContent/ButtonFont");
            var toMainMenu = CreateButton("Menu", new Vector2(10, 10));
            toMainMenu.Click += ToMainMenu;
            buttons = new List<Button>()
            {
                toMainMenu,
            };
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (var button in buttons)
                button.Draw(gameTime, spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
        }

    }
}
