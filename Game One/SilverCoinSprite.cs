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
    public class SilverCoinSprite
    {
        private Vector2 position;

        private Texture2D texture;

        private BoundingRectangle bounds;

        public BoundingRectangle Bounds => bounds;

        public bool Collected { get; set; } = false;

        public SilverCoinSprite(Vector2 position)
        {
            this.position = position;
            this.bounds = new BoundingRectangle(position, 24, 24);
        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("SilverCoin");
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (Collected) return;
            var source = new Rectangle(0, 0, 64, 64);
            spriteBatch.Draw(texture, position, source, Color.White);
        }
    }
}
