using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace Game_One
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch spriteBatch;
        private SilverCoinSprite[] silverCoins;
        private PirateSprite pirate;
        private SpriteFont spriteFont;
        private Texture2D ball;
        private SoundEffect pickup;
        private int count = 1;
        private float timeElapsed;
        private bool startGame;
        private bool endGame;
        private Vector2 test;
        

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
            endGame = false;
            startGame = true;
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
            pirate = new PirateSprite(new Vector2(200, 200));
            count = 1;
            timeElapsed = 0;

           

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            foreach (var coin in silverCoins) coin.LoadContent(Content);
            pirate.LoadContent(Content);
            spriteFont = Content.Load<SpriteFont>("arial");
            ball = Content.Load<Texture2D>("ball");
            pickup = Content.Load<SoundEffect>("Pickup_Coin");
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
                    coin.Collected = true;
                    pickup.Play();
                    count++;
                    pirate.GetCount(count);
                    test = coin.position;
                    
                    
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {

            if (startGame)
            {
                GraphicsDevice.Clear(Color.Blue);
                spriteBatch.Begin();
                spriteBatch.DrawString(spriteFont, $"ARGHHH I LOST ME COINS!", new Vector2(200, 25), Color.Black);
                spriteBatch.DrawString(spriteFont, $"Use WASD to move!", new Vector2(250, 100), Color.Black);
                spriteBatch.DrawString(spriteFont, $"Try to collect ME coins as fast as possible!", new Vector2(100, 200), Color.Black);
                spriteBatch.DrawString(spriteFont, $"Press Q when you collect all the coins!", new Vector2(100, 300), Color.Black);
                spriteBatch.DrawString(spriteFont, $"Press Enter to start the game!", new Vector2(200, 400), Color.Black);
                spriteBatch.End();
                base.Draw(gameTime);
                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    startGame = false;
                    Initialize();
                }
            }
            else if (endGame)
            {
                GraphicsDevice.Clear(Color.Blue);
                spriteBatch.Begin();
                spriteBatch.DrawString(spriteFont, $"You collected the coins in: {timeElapsed} seconds!", new Vector2(100, 200), Color.Black);
                spriteBatch.DrawString(spriteFont, $"Press R to restart", new Vector2(200, 300), Color.Black);
                spriteBatch.End();
                base.Draw(gameTime);
                if (Keyboard.GetState().IsKeyDown(Keys.R))
                {
                    endGame = false;
                    Initialize();
                }
            }
            else
            {
                GraphicsDevice.Clear(Color.Black);


                timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
                // TODO: Add your drawing code here
                spriteBatch.Begin();
                foreach (var coin in silverCoins)
                {
                    coin.Draw(gameTime, spriteBatch);
                    /*var rect2 = new Rectangle((int)(coin.Bounds.Center.X - coin.Bounds.Radius),
                                                 (int)(coin.Bounds.Center.Y - coin.Bounds.Radius),
                                                 (int)(2 * coin.Bounds.Radius), (int)(2 * coin.Bounds.Radius));
                    spriteBatch.Draw(ball, rect2, Color.White);*/
                }
                pirate.Draw(gameTime, spriteBatch);
                /*var rect = new Rectangle((int)(pirate.Bounds.Center.X - pirate.Bounds.Radius),
                                                 (int)(pirate.Bounds.Center.Y - pirate.Bounds.Radius),
                                                 (int)(2 * pirate.Bounds.Radius), (int)(2 * pirate.Bounds.Radius));
                spriteBatch.Draw(ball, rect, Color.White);*/

                System.Random rand = new System.Random();
                spriteBatch.DrawString(spriteFont, $"Total Time Taken: {timeElapsed}", new Vector2(2, 2), Color.Silver);
                spriteBatch.End();

                base.Draw(gameTime);
                if (Keyboard.GetState().IsKeyDown(Keys.Q))
                {
                    endGame = true;
                }
            }
            
        }
    }
}
