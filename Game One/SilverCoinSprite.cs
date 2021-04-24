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
        public Vector2 position { get; set; }

        private Texture2D texture;

        private BoundingCircle bounds;

        public BoundingCircle Bounds => bounds;

        public bool Collected { get; set; } = false;

        public SilverCoinSprite(Vector2 position)
        {
            this.position = position;
            this.bounds = new BoundingCircle(position + new Vector2(64, 64), 11);
        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("SilverCoin");
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (Collected) return;
            var source = new Rectangle(0, 0, 64, 64);
            spriteBatch.Draw(texture, position, source, Color.White, 0, new Vector2(0, 0), 2f, SpriteEffects.None, 0);
            //spriteBatch.Draw(texture, position, null, Color.White);
        }
    }
}
