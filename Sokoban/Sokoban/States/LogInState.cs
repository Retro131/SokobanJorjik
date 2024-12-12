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
    public class LogInState : State
    {
        private List<Button> buttons;
        private string Name = " ";
        public LogInState(Game1 game, ContentManager contentManager, GraphicsDevice graphics) : base(game, contentManager, graphics)
        {
            game.Window.TextInput += TextInputHandler;
            LoadContent();
        }
        public override void LoadContent()
        {
            buttonTexture = _contentManager.Load<Texture2D>("ButtonContent/Button");
            buttonFont = _contentManager.Load<SpriteFont>("ButtonContent/ButtonFont");
            var toMainMenu = CreateButton("Enter", new Vector2(650, 250));
            toMainMenu.Click += ToMainMenu;
            buttons = new List<Button>()
            {
                toMainMenu,
            };
        }

        protected override void ToMainMenu(object sender, EventArgs e)
        {
            if (Name == " " || Name is null)
            {
                return;
            }
            Game1.db.AddToDb(Name);
            base.ToMainMenu(sender, e);
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(buttonFont, Name, new Vector2(550, 200), Color.AliceBlue);
            foreach (var button in buttons)
                button.Draw(gameTime, spriteBatch);
            // Отобразим текущий вводимый текст
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var button in buttons)
                button.Update(gameTime);
        }



        private void TextInputHandler(object sender, TextInputEventArgs e)
        {
            char c = e.Character;

            if (c == '\b') 
            {
                if (Name.Length > 0)
                    Name = Name.Substring(0, Name.Length - 1);
            }
            else
            {
                Name += c;
            }
        }

    }
}
