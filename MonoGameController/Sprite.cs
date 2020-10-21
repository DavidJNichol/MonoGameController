using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameController
{
    class Sprite : Microsoft.Xna.Framework.GameComponent
    {
        // game object logic, movement, speed, keep on screen etc
        protected Texture2D spriteTexture;
        protected SpriteEffects spriteEffects;
        protected float speed { get; set; }
        protected float acceleration { get; set; }
        protected float velocity { get; set; }
        protected Vector2 direction { get; set; }
        protected Vector2 startPosition { get; set; }
        protected Vector2 currentPosition { get; set; }
        protected Rectangle collisionBox { get; set; }

        public Sprite(Game game) : base(game)
        {
            spriteEffects = new SpriteEffects();
        }

        public bool IsOffScreen(Vector2 spritePosition, Texture2D spriteTexture, GraphicsDeviceManager graphics)
        {
            if (spritePosition.X > graphics.GraphicsDevice.Viewport.Width - spriteTexture.Width 
                || spritePosition.X < 0 
                || spritePosition.Y > graphics.GraphicsDevice.Viewport.Height - spriteTexture.Height 
                || spritePosition.Y < 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
