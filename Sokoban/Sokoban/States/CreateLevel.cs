using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;


namespace Sokoban
{
    public class CreateLevel : State
    {
        private List<Button> buttons;
        public CreateLevel(Game1 game, ContentManager contentManager, GraphicsDevice graphics) : base(game, contentManager, graphics)
        {
            var buttonTexture = _contentManager.Load<Texture2D>("ButtonContent/Button");
            var buttonFont = _contentManager.Load<SpriteFont>("ButtonContent/ButtonFont");
            var toMainMenu = new Button(buttonTexture, buttonFont, "Menu", new Vector2(10, 10));
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
            foreach (var button in buttons)
                button.Update(gameTime);
        }
        public void ToMainMenu(object sender, EventArgs e)
        {
            _game.ChangeState(new MenuState(_game, _contentManager, _graphics));
        }
    }
}
