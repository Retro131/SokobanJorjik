using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    public class ResultsState : State
    {
        private List<Button> buttons;
        public ResultsState(Game1 game, ContentManager contentManager, GraphicsDevice graphics) : base(game, contentManager, graphics)
        {
            LoadContent();
        }
        public override void LoadContent()
        {
            buttonTexture = _contentManager.Load<Texture2D>("ButtonContent/Button");
            buttonFont = _contentManager.Load<SpriteFont>("ButtonContent/ButtonFont");
            var toMainMenu = new Button(buttonTexture, buttonFont, "Menu", new Vector2(10, 10));
            toMainMenu.Click += ToMainMenu;
            buttons = new List<Button>()
            {
                toMainMenu,
            };
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach(var button in buttons)
                button.Draw(gameTime,spriteBatch);
            var i = 0;
            foreach(var info in Game1.db.Results)
            {
                var UserId = info.UserId;
                var LevelId = info.LevelId;
                spriteBatch.DrawString(buttonFont, info.Id.ToString(), new Vector2(500, 200 + i), Color.AliceBlue);
                spriteBatch.DrawString(buttonFont, info.Users.Name, new Vector2(550, 200 + i), Color.AliceBlue);
                spriteBatch.DrawString(buttonFont, LevelId.ToString(), new Vector2(650, 200 + i), Color.AliceBlue);
                spriteBatch.DrawString(buttonFont, info.Steps.ToString(), new Vector2(700, 200 + i), Color.AliceBlue);
                spriteBatch.DrawString(buttonFont, info.date.ToString(), new Vector2(750, 200 + i), Color.AliceBlue);
                i += 20;
            }
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var button in buttons)
                button.Update(gameTime);
        }
    }
}
