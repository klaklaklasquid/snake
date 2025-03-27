namespace SnakeGame;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
public class Sprites : Game {
    public Texture2D SpriteSheet {get;set;}
    public Sprites()
    {
      
        SpriteSheet = Content.Load<Texture2D>("snake");
    }
}