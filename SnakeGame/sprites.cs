namespace SnakeGame;

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
public class Sprites : Game {
    public Texture2D SpriteSheet {get;set;}
    private SpriteBatch _spriteBatch;
    public Sprites()
    {
        Console.WriteLine( GraphicsDevice.GraphicsDeviceStatus);
        _spriteBatch = new(GraphicsDevice);
        Content.RootDirectory = "Content";
        SpriteSheet = Content.Load<Texture2D>("snake");
    }
    public void Draw(){
        Console.WriteLine( GraphicsDevice.GraphicsDeviceStatus);
        _spriteBatch.Begin();
        _spriteBatch.Draw(SpriteSheet,new Rectangle(50,50,50,50),Color.White);
        _spriteBatch.End();
        
    }

}