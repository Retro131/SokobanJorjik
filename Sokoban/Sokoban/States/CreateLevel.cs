using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sokoban.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Sokoban
{
    public class CreateLevel : State
    {
        private List<Button> buttons;
        private List<Sprite> _sprites;
        private Level createdLevel;

        Texture2D boxTexture;
        Texture2D playerTexture;
        Texture2D targetTexture;
        Texture2D wallTexture;
        public CreateLevel(Game1 game, ContentManager contentManager, GraphicsDevice graphics) : base(game, contentManager, graphics)
        {
            LoadContent();
        }
        public override void LoadContent()
        {
            boxTexture = _contentManager.Load<Texture2D>("Box");
            playerTexture = _contentManager.Load<Texture2D>("Player");
            targetTexture = _contentManager.Load<Texture2D>("Target");
            wallTexture = _contentManager.Load<Texture2D>("Wall");

            buttonTexture = _contentManager.Load<Texture2D>("ButtonContent/Button");
            buttonFont = _contentManager.Load<SpriteFont>("ButtonContent/ButtonFont");

            var toMainMenu = CreateButton("Menu", new Vector2(10, 10));
            var createLevel = CreateButton("Create Level", new Vector2(650, 600));
            createLevel.Click += CreateLevelButton;
            toMainMenu.Click += ToMainMenu;
            buttons = new List<Button>()
            {
                toMainMenu,createLevel,
            };
            var lvlId = !Game1.db.Levels.Any() ? 0 : Game1.db.Levels.Max(x => x.Id) + 1;
            createdLevel = new Level(lvlId);
            _sprites = createdLevel.Sprites = new List<Sprite>() { new PlayerCreator(playerTexture, new Vector2(650, 300), Color.White, createdLevel, new List<Texture2D>() { boxTexture, wallTexture, targetTexture }) };
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (var button in buttons)
                button.Draw(gameTime, spriteBatch);
            foreach (var sprite in _sprites)
                sprite.Draw(spriteBatch);
        }
        public override void Update(GameTime gameTime)
        {
            foreach (var button in buttons)
                button.Update(gameTime);
            foreach (var sprite in _sprites)
                sprite.Update(gameTime,_sprites);
        }
        private void CreateLevelButton(object sender, EventArgs e)
        {
            LevelManager.AddLevel(createdLevel);
            _game.ChangeState(new MenuState(_game, _contentManager, _graphics));
        }
    }
}
