using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SnakeGame;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D _radialGradientTexture;

    private Texture2D _spriteSheet;
    private Texture2D _background;
    
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;

        // * set the window size
        _graphics.PreferredBackBufferWidth = 700;
        _graphics.PreferredBackBufferHeight = 800;
        _graphics.ApplyChanges();



    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        // TODO: use this.Content to load your game content here

        //* load the radial gradient
        _radialGradientTexture = CreateRadialGradientTexture(GraphicsDevice, 700, 800);
        _spriteSheet = Content.Load<Texture2D>("snake");
        _background = Content.Load<Texture2D>("playingField");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();
        _spriteBatch.Draw(_radialGradientTexture, new Rectangle(0, 0, 700, 800), Color.White);
        _spriteBatch.End();


        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }

    private Texture2D CreateRadialGradientTexture(GraphicsDevice graphicsDevice, int width, int height)
    {
        Texture2D texture = new Texture2D(graphicsDevice, width, height);
        Color[] colorData = new Color[width * height];

        Vector2 center = new Vector2(width / 2f, height / 2f);
        float maxDistance = Vector2.Distance(Vector2.Zero, center);

        Color startColor = new Color(0, 100, 0);
        Color endColor = new Color(144, 238, 144);

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Vector2 position = new Vector2(x, y);
                float distance = Vector2.Distance(position, center);
                float t = distance / maxDistance;
                Color color = Color.Lerp(startColor, endColor, t);
                colorData[y * width + x] = color;
            }
        }

        texture.SetData(colorData);
        return texture;
    }
}
