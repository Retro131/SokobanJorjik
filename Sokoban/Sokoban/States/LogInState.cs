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
            var toMainMenu = CreateButton("Enter", new Vector2(550, 250));
            string name = UserName.getInstance();
            toMainMenu.Click += ToMainMenu;
            buttons = new List<Button>()
            {
                toMainMenu,
            };
        }

        protected override void ToMainMenu(object sender, EventArgs e)
        {
            Game1.db.Add();
            base.ToMainMenu(sender, e);
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(buttonFont, "Sorry its not done, so only guests without name", new Vector2(650, 200), Color.Black);
            foreach (var button in buttons)
                button.Draw(gameTime, spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var button in buttons)
                button.Update(gameTime);
        }

    }
}
