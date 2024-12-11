using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sokoban.States;
using System;
using System.Collections.Generic;


namespace Sokoban
{
    public class MenuState : State
    {
        private List<Button> buttons;
        public MenuState(Game1 game, ContentManager contentManager, GraphicsDevice graphics) : base(game, contentManager, graphics)
        {
            LoadContent();
        }
        public override void LoadContent()
        {
            buttonTexture = _contentManager.Load<Texture2D>("ButtonContent/Button");
            buttonFont = _contentManager.Load<SpriteFont>("ButtonContent/ButtonFont");
            var startGame = CreateButton("Start game", new Vector2(650, 250));
            startGame.Click += StartGame;
            var createLevel = CreateButton("Create level", new Vector2(650, 250 + 50));
            createLevel.Click += CreateLevel;
            var resultButton = CreateButton("Results", new Vector2(650, 250 + 100));
            resultButton.Click += Results;
            var quit = CreateButton("Quit game", new Vector2(650, 250 + 150));
            quit.Click += Quit;
            buttons = new List<Button>()
            {
                startGame, createLevel, resultButton, quit,
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
        public void Results(object sender, EventArgs e)
        {
            _game.ChangeState(new ResultsState(_game, _contentManager, _graphics));
        }
        public void Quit(object sender, EventArgs e)
        {
            _game.Exit();
        }
    }
}
