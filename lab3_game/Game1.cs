using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace lab3_game
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        Texture2D myTexture;
        //int frame = 3;

        Texture2D cloudTexture;
        Vector2[] scaleCloud, cloudPosition;
        int[] speed;
        Random r = new Random();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            //IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            myTexture = Content.Load<Texture2D>("NatureSprite");
            cloudTexture = Content.Load<Texture2D>("Cloud_Sprite");

            cloudPosition = new Vector2[4];
            scaleCloud = new Vector2[4];
            speed = new int[4];

            for (int i = 0; i < 4; i++)
            {
                speed[i] = r.Next(1, 10);
                cloudPosition[i].Y = r.Next(0, graphics.GraphicsDevice.Viewport.Height - cloudTexture.Height);
                scaleCloud[i].X = r.Next(1, 3);
                scaleCloud[i].Y = r.Next(1, 3);
            }
            //speed = 5;
        }

        protected override void UnloadContent()
        {
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            for(int i = 0; i < 4; i++)
            {
                cloudPosition[i].X += speed[i];


                if (cloudPosition[i].X > this.graphics.GraphicsDevice.Viewport.Width)
                {
                    cloudPosition[i].X = 0;
                    cloudPosition[i].Y = r.Next(0, graphics.GraphicsDevice.Viewport.Height - cloudTexture.Height);
                    speed[i] = r.Next(1, 10);
                    scaleCloud[i].X = r.Next(1, 3);
                    scaleCloud[i].Y = r.Next(1, 3);
                }
            }

            

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(85, 133, 50));
            spriteBatch.Begin();
            //spiral
            spriteBatch.Draw(myTexture, new Vector2(310, 250), new Rectangle(64, 0, 64, 64), Color.White);
            spriteBatch.Draw(myTexture, new Vector2(250, 250), new Rectangle(64, 0, 64, 64), Color.White);
            spriteBatch.Draw(myTexture, new Vector2(310, 190), new Rectangle(64, 0, 64, 64), Color.White);
            spriteBatch.Draw(myTexture, new Vector2(310, 130), new Rectangle(64, 0, 64, 64), Color.White);
            spriteBatch.Draw(myTexture, new Vector2(310, 70), new Rectangle(64, 0, 64, 64), Color.White);
            //log
            spriteBatch.Draw(myTexture, new Vector2(370, 70), new Rectangle(0, 0, 64, 64), Color.White);
            spriteBatch.Draw(myTexture, new Vector2(680, 300), new Rectangle(0, 0, 64, 64), Color.White);
            //smolTree
            spriteBatch.Draw(myTexture, new Vector2(500, 170), new Rectangle(128, 0, 64, 64), Color.White);
            spriteBatch.Draw(myTexture, new Vector2(400, 320), new Rectangle(128, 0, 64, 64), Color.White);
            //palmTree
            spriteBatch.Draw(myTexture, new Vector2(660, 110), new Rectangle(128, 256, 128, 128), Color.White);
            //mediumTree
            spriteBatch.Draw(myTexture, new Vector2(130, 360), new Rectangle(0, 192, 128, 128), Color.White);
            //bigTree
            spriteBatch.Draw(myTexture, new Vector2(0, 0), new Rectangle(256, 128, 256, 256), Color.White);
            //sign
            spriteBatch.Draw(myTexture, new Vector2(600, 300), new Rectangle(256, 64, 64, 64), Color.White);
            //flower
            spriteBatch.Draw(myTexture, new Vector2(560, 0), new Rectangle(196, 196, 64, 64), Color.White);
            spriteBatch.Draw(myTexture, new Vector2(-20, 300), new Rectangle(196, 196, 64, 64), Color.White);
            spriteBatch.Draw(myTexture, new Vector2(310, 400), new Rectangle(196,196, 64, 64), Color.White);
            spriteBatch.Draw(myTexture, new Vector2(700, 450), new Rectangle(196, 196, 64, 64), Color.White);

            //cloud
            for(int i = 0; i < 4; i++)
            {
                spriteBatch.Draw(cloudTexture, cloudPosition[i], null, Color.White, 0, Vector2.Zero, scaleCloud[i], 0, 0);
            }
            

            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
