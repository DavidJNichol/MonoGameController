using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameController
{
    class Player  : Sprite
    {
        private InputHandler inputHandler;

        public Player(Game game) : base(game)
        {
            inputHandler = new InputHandler();

            direction = new Vector2(1, 0);
            startPosition = new Vector2(200, 200);
            currentPosition = startPosition;
            speed = 250;

            collisionBox = new Rectangle((int)currentPosition.X, (int)currentPosition.Y, 53, 85);
        }
        //IMPLEMENT THIS
        public enum State
        {
            moving,
            idle
        }

        public void SetTexture(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            spriteTexture = content.Load<Texture2D>("Player");
        }

        public Texture2D GetTexture()
        {
            return spriteTexture;
        }

        public void CheckDirection()
        {
            switch(inputHandler.GetMovementDirection())
            {
                case InputHandler.Direction.Up:
                    direction = new Vector2(0, -1);
                    break;
                case InputHandler.Direction.Left:
                    direction = new Vector2(-1, 0);
                    break;
                case InputHandler.Direction.Down:
                    direction = new Vector2(0, 1);
                    break;
                case InputHandler.Direction.Right:
                    direction = new Vector2(1, 0);
                    break;
                case InputHandler.Direction.None:
                    direction = Vector2.Zero;
                    break;
            }
        }

        public void MovePlayer(float time)
        {
            CheckDirection();

            velocity = 0;
            acceleration = .01f;
            acceleration += .5f;

            velocity += acceleration * acceleration * (time / 1000);
            currentPosition += (direction * speed) * (time / 1000);
        }

        public Vector2 GetPosition()
        {
            return currentPosition;
        }

        public void KeepInBoundries()
        {
            if(IsOffScreen(currentPosition, spriteTexture))
                currentPosition = startPosition;            
        }

        public Vector2 GetPlayerDirection()
        {
            return direction;
        }
    }
}
