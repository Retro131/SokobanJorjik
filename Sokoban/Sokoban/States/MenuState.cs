using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;


namespace Sokoban
{
    public class MenuState : State
    {
        private List<Button> buttons;
        public MenuState(Game1 game, ContentManager contentManager, GraphicsDevice graphics) : base(game, contentManager, graphics)
        {
            var buttonTexture = _contentManager.Load<Texture2D>("ButtonContent/Button");
            var buttonFont = _contentManager.Load<SpriteFont>("ButtonContent/ButtonFont");
            var startGame = new Button(buttonTexture, buttonFont, "Start game", new Vector2(650, 250));
            startGame.Click += StartGame;
            var createLevel = new Button(buttonTexture, buttonFont, "Create level", new Vector2(650, 250 + 50));
            createLevel.Click += CreateLevel;
            var quit = new Button(buttonTexture, buttonFont, "Quit game", new Vector2(650, 250 + 100));
            quit.Click += Quit;
            buttons = new List<Button>()
            {
                startGame, createLevel, quit,
            };
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach(var button in buttons)
                button.Draw(gameTime, spriteBatch);
        }
        public override void Update(GameTime gameTime)
        {
            foreach(var button in buttons)
                button.Update(gameTime);
        }
        public void StartGame(object sender, EventArgs e)
        {
            _game.ChangeState(new GameState(_game, _contentManager, _graphics));
        }
        public void CreateLevel(object sender, EventArgs e)
        {
            _game.ChangeState(new CreateLevel(_game, _contentManager, _graphics));
        }
        public void Quit(object sender, EventArgs e)
        {
            _game.Exit();
        }
    }
}
