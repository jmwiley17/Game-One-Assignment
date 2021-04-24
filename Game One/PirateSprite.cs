using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Game_One.Collisions;

namespace Game_One
{
    public class PirateSprite
    {
 
        private KeyboardState keyboardState;

        private Texture2D texture;

        private Vector2 position = new Vector2(200, 200);

        private bool flipped;

        private BoundingCircle bounds;

        public BoundingCircle Bounds => bounds;

        public PirateSprite(Vector2 position)
        {
            this.position = position;
            this.bounds = new BoundingCircle(position + new Vector2(40, 30), 20);
        }

        public Color Color { get; set; } = Color.White;

        private int count = 1;

        public void GetCount(int coinCount)
        {
            count = coinCount;
        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("Pirate");
        }

        public void Update(GameTime gameTime)
        {
            keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Up) || keyboardState.IsKeyDown(Keys.W)) position += new Vector2(0, -1 * count);
            if (keyboardState.IsKeyDown(Keys.Down) || keyboardState.IsKeyDown(Keys.S)) position += new Vector2(0, 1 * count);
            if (keyboardState.IsKeyDown(Keys.Left) || keyboardState.IsKeyDown(Keys.A))
            {
                position += new Vector2(-1 * count, 0);
                flipped = true;
            }
            if (keyboardState.IsKeyDown(Keys.Right) || keyboardState.IsKeyDown(Keys.D))
            {
                position += new Vector2(1 * count, 0);
                flipped = false;
            }
            bounds.Center = new Vector2(position.X + 40, position.Y + 30);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            SpriteEffects spriteEffects = (flipped) ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
            spriteBatch.Draw(texture, position, null, Color, 0, new Vector2(0, 0), 2f, spriteEffects, 0);
        }
    }
}
