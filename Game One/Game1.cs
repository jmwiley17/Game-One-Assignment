using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game_One
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch spriteBatch;
        private SilverCoinSprite[] silverCoins;
        private PirateSprite pirate;
        private SpriteFont spriteFont;
        private int count = 1;
        private float timeElapsed;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            System.Random rand = new System.Random();
            silverCoins = new SilverCoinSprite[]
            {
                new SilverCoinSprite(new Vector2((float)rand.NextDouble() * GraphicsDevice.Viewport.Width, (float)rand.NextDouble() * GraphicsDevice.Viewport.Height)),
                new SilverCoinSprite(new Vector2((float)rand.NextDouble() * GraphicsDevice.Viewport.Width, (float)rand.NextDouble() * GraphicsDevice.Viewport.Height)),
                new SilverCoinSprite(new Vector2((float)rand.NextDouble() * GraphicsDevice.Viewport.Width, (float)rand.NextDouble() * GraphicsDevice.Viewport.Height)),
                new SilverCoinSprite(new Vector2((float)rand.NextDouble() * GraphicsDevice.Viewport.Width, (float)rand.NextDouble() * GraphicsDevice.Viewport.Height)),
                new SilverCoinSprite(new Vector2((float)rand.NextDouble() * GraphicsDevice.Viewport.Width, (float)rand.NextDouble() * GraphicsDevice.Viewport.Height)),
                new SilverCoinSprite(new Vector2((float)rand.NextDouble() * GraphicsDevice.Viewport.Width, (float)rand.NextDouble() * GraphicsDevice.Viewport.Height)),
                new SilverCoinSprite(new Vector2((float)rand.NextDouble() * GraphicsDevice.Viewport.Width, (float)rand.NextDouble() * GraphicsDevice.Viewport.Height)),
                new SilverCoinSprite(new Vector2((float)rand.NextDouble() * GraphicsDevice.Viewport.Width, (float)rand.NextDouble() * GraphicsDevice.Viewport.Height)),
                new SilverCoinSprite(new Vector2((float)rand.NextDouble() * GraphicsDevice.Viewport.Width, (float)rand.NextDouble() * GraphicsDevice.Viewport.Height)),
                new SilverCoinSprite(new Vector2((float)rand.NextDouble() * GraphicsDevice.Viewport.Width, (float)rand.NextDouble() * GraphicsDevice.Viewport.Height))
            };
            pirate = new PirateSprite();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            foreach (var coin in silverCoins) coin.LoadContent(Content);
            pirate.LoadContent(Content);
            spriteFont = Content.Load<SpriteFont>("arial");
        }

        protected override void Update(GameTime gameTime)
        {
         
            // TODO: Add your update logic here
            pirate.Update(gameTime);

            //detect and process collisions
            pirate.Color = Color.White;
            foreach (var coin in silverCoins)
            {
                if (!coin.Collected && coin.Bounds.CollidesWith(pirate.Bounds))
                {
                    pirate.Color = Color.Red;
                    coin.Collected = true;
                    timeElapsed = (float)gameTime.TotalGameTime.TotalSeconds;
                    count++;
                    pirate.GetCount(count);
                    
                    
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            foreach (var coin in silverCoins) coin.Draw(gameTime, spriteBatch);
            pirate.Draw(gameTime, spriteBatch);
            spriteBatch.DrawString(spriteFont, $"Total Time Taken: {timeElapsed}", new Vector2(2, 2), Color.Silver);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
