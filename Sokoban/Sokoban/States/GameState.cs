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
        private LinkedListNode<Level> _currentNode;
        private Level _currentLevel;
        private int fixedBoxes;
        private List<Button> buttons;

        public GameState(Game1 game, ContentManager contentManager, GraphicsDevice graphics) : base(game, contentManager, graphics)
        {
            LoadContent();
        }
        public override void LoadContent()
        {
            buttonTexture = _contentManager.Load<Texture2D>("ButtonContent/Button");
            buttonFont = _contentManager.Load<SpriteFont>("ButtonContent/ButtonFont");
            _levelManager = new LevelManager(_contentManager);
            _currentNode = _levelManager.Levels.First;
            _currentLevel = _currentNode.Value;
            _sprites = _currentLevel.Sprites;

            var skipLevel = CreateButton("Skip", new Vector2(100, 10));
            skipLevel.Click += SkipLevel;
            var toMainMenu = CreateButton("Menu", new Vector2(10, 10));
            toMainMenu.Click += ToMainMenu;
            buttons = new List<Button>()
            {
                toMainMenu,skipLevel
            };
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (var sprite in _sprites)
                sprite.Draw(spriteBatch);
            foreach (var button in buttons)
                button.Draw(gameTime, spriteBatch);
            spriteBatch.DrawString(buttonFont, $"Steps: {_currentLevel.TotalSteps}", new Vector2(_graphics.Viewport.Width/2,20), Color.Aquamarine);
        }
        public override void Update(GameTime gameTime)
        {
            foreach (var button in buttons)
                button.Update(gameTime);
            if (_currentLevel.IsFinished)
            {
                if (_currentNode.Next is not null)
                {
                    ChangeLevel();
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
            if (fixedBoxes == _currentLevel.BoxCount)
            {
                _currentLevel.IsFinished = true;
                fixedBoxes = 0;
            }
        }
        private void SkipLevel(object sender, EventArgs e)
        {
            _currentLevel.IsFinished = true; fixedBoxes = 0;
        }
        private void ChangeLevel()
        {
            _sprites.Clear();
            _currentLevel = _currentNode.Next.Value;
            _currentNode = _currentNode.Next;
            _sprites = _currentLevel.Sprites;
        }
    }
}
