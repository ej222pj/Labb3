using Labb3._3.Content.Model;
using Labb3._3.Content.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Labb3._3.Content.Controller
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private MouseStateView mouse;
        Camera camera;
        private float runTime;
        private List<GameSystem> effects;
        private SoundEffect fire;
        private BallSimulation ballSimulation;
        private BallView ballView;
        private Texture2D pixel;
        private static int offSet = 10;
        private Texture2D aimTexture;

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 500 + offSet;
            graphics.PreferredBackBufferHeight = 500 + offSet;
            this.IsMouseVisible = true;
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            pixel = new Texture2D(GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            pixel.SetData(new[] { Color.White });

            camera = new Camera(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height, offSet);
            ballSimulation = new BallSimulation();
            ballView = new BallView(GraphicsDevice, Content, camera);
            mouse = new MouseStateView(camera, GraphicsDevice);
            effects = new List<GameSystem>();
            fire = Content.Load<SoundEffect>("firee");
            aimTexture = Content.Load<Texture2D>("Aim");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            runTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            // TODO: Add your update logic here

            if (mouse.IsButtonPressed())
            {
                Vector2 mousePosition = mouse.GetMousePos();

                effects.Add(new GameSystem(Content, mousePosition, camera));
                fire.Play();
                ballSimulation.ballsInsideMouseArea(mousePosition);
            }

            foreach (var particle in effects)
            {
                particle.Update(runTime);
            }

            ballSimulation.update(runTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);
            Rectangle titleSafeRectangle = GraphicsDevice.Viewport.TitleSafeArea;
            
            // TODO: Add your drawing code here
            foreach (var particle in effects)
            {
                particle.Draw(spriteBatch);
            }

            ballView.drawLevel(titleSafeRectangle, offSet, Color.Cyan, pixel, 1);
            mouse.drawMouseAim(aimTexture, ballSimulation.getMouseDiameter);
            foreach (var ball in ballSimulation.ballList) 
            {
                ballView.drawBall(ball.CenterX, ball.CenterY, ball.Diameter, ball.IsDead);
            }
           
            base.Draw(gameTime);
        }
    }                                                                                            
}
