using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;


namespace Sokoban
{
    public class GameState : State
    {
        private List<Sprite> _sprites;
        private LevelManager _levelManager;
        private LinkedListNode<Level> _currentLevel;
        private int fixedBoxes;
        private bool IsFinished;
        private List<Button> buttons;
        public GameState(Game1 game, ContentManager contentManager, GraphicsDevice graphics) : base(game, contentManager, graphics)
        {
            var buttonTexture = _contentManager.Load<Texture2D>("ButtonContent/Button");
            var buttonFont = _contentManager.Load<SpriteFont>("ButtonContent/ButtonFont");
            var skipLevel = new Button(buttonTexture, buttonFont, "Skip", new Vector2(100, 10));
            skipLevel.Click += SkipLevel;
            var toMainMenu = new Button(buttonTexture, buttonFont, "Menu", new Vector2(10, 10));
            toMainMenu.Click += ToMainMenu;
            buttons = new List<Button>()
            {
                toMainMenu,skipLevel
            };
            LoadContent();
        }
        public override void LoadContent()
        {
            _levelManager = new LevelManager(_contentManager);
            _currentLevel = _levelManager.Levels.First;
            _sprites = _currentLevel.Value.Sprites;
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (var sprite in _sprites)
                sprite.Draw(spriteBatch);
            foreach (var button in buttons)
                button.Draw(gameTime, spriteBatch);
        }
        public override void Update(GameTime gameTime)
        {
            foreach (var button in buttons)
                button.Update(gameTime);
            if (_currentLevel.Value.IsFinished)
            {
                if (_currentLevel.Next is not null)
                {
                    _sprites.Clear();
                    _currentLevel = _currentLevel.Next;
                    _sprites = _currentLevel.Value.Sprites;
                }
                else
                {
                    _game.ChangeState(new MenuState(_game, _contentManager, _graphics));
                }
            }

            foreach (var sprite in _sprites)
            {
                if (sprite is Box)
                {
                    if (!sprite.IsOnTarget(_sprites))
                        fixedBoxes = 0;
                    else fixedBoxes++;
                }
                sprite.Update(gameTime, _sprites);
                foreach (var button in buttons)
                    button.Update(gameTime);
            }
            if (fixedBoxes == _currentLevel.Value.BoxCount)
            {
                _currentLevel.Value.IsFinished = true;
                fixedBoxes = 0;
            }
        }
        public void ToMainMenu(object sender, EventArgs e)
        {
            _game.ChangeState(new MenuState(_game, _contentManager, _graphics));
        }
        public void SkipLevel(object sender, EventArgs e)
        {
            _currentLevel.Value.IsFinished = true; fixedBoxes = 0;
        }
    }
}
