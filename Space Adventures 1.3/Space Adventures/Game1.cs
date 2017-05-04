using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Space_Adventures
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D playerTex, platTex, backgroundTex, chickenTex;

        GameWorld gameWorld;

        Background backGround;

        Camera camera;
        Viewport view;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            playerTex = Content.Load<Texture2D>("PlayerAnimation");
            platTex = Content.Load<Texture2D>("Platform1");
            backgroundTex = Content.Load<Texture2D>("DesertBackground");
            chickenTex = Content.Load<Texture2D>("ChickenWalkFull");
            backGround = new Background(Content, Window);

            view = GraphicsDevice.Viewport;
            camera = new Camera(view);

            gameWorld = new GameWorld(playerTex, platTex, backgroundTex, chickenTex, Window, camera);
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            gameWorld.Update(gameTime);
            backGround.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, camera.GetTransform());

            backGround.Draw(spriteBatch);
            gameWorld.Draw(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
