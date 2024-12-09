using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Sokoban
{
    public class Button
    {
        private MouseState currentState;
        private MouseState previousState;
        private SpriteFont _font { get; set; }
        private Texture2D _texture;
        private bool IsHovering { get; set; }
        public string Text { get; set; }
        public event EventHandler Click;
        public Vector2 Position { get; set; }
        public Rectangle HitBox
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
            }
        }

        public Button(Texture2D texture, SpriteFont font, string text, Vector2 position)
        {
            _texture = texture;
            _font = font;
            Text = text;
            Position = position;
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            var color = Color.White;
            if (IsHovering)
            {
                color = Color.Gray;
            }
            spriteBatch.Draw(_texture, HitBox, color);
            if (Text is not null or "")
            {
                var x = (HitBox.X + (HitBox.Width / 2)) - (_font.MeasureString(Text).X / 2);
                var y = (HitBox.Y + (HitBox.Height / 2)) - (_font.MeasureString(Text).Y / 2);
                spriteBatch.DrawString(_font, Text, new Vector2(x, y), Color.Black);
            }
        }
        public void Update(GameTime gameTime)
        {
            previousState = currentState;
            currentState = Mouse.GetState();
            var mouseHitBox = new Rectangle(currentState.X, currentState.Y, 1, 1);

            IsHovering = false;

            if (mouseHitBox.Intersects(HitBox))
            {
                IsHovering = true;

                if(currentState.LeftButton == ButtonState.Released && previousState.LeftButton == ButtonState.Pressed)
                    Click?.Invoke(this, new EventArgs());
            }

        }
    }
}
