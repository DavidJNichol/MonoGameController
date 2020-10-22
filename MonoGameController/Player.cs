using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameController
{
    class Player  : Sprite
    {
        private InputHandler inputHandler;

        private State state;

        public Player(Game game) : base(game)
        {
            inputHandler = new InputHandler();

            direction = new Vector2(1, 0);
            startPosition = new Vector2(450, 300);
            currentPosition = startPosition;
            speed = 250;

            collisionBox = new Rectangle((int)currentPosition.X, (int)currentPosition.Y, 53, 85);
        }

        public enum State
        {
            moving,
            idle,
        }

        public void UpdatePlayerRectangle()
        {
            this.collisionBox.X = (int)currentPosition.X;
            this.collisionBox.Y = (int)currentPosition.Y;
        }

        public void SetTexture(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            spriteTexture = content.Load<Texture2D>("Player");
        }

        public Rectangle GetCollisionBox()
        {
            return collisionBox; 
        }

        public Texture2D GetTexture()
        {
            return spriteTexture;
        }
        // Input handler Direction will switch player direction
        public void CheckDirection()
        {
            switch(inputHandler.GetMovementDirection())
            {
                case InputHandler.Direction.Up:
                    direction = new Vector2(0, -1);
                    state = State.moving;
                    break;
                case InputHandler.Direction.Left:
                    direction = new Vector2(-1, 0);
                    state = State.moving;
                    break;
                case InputHandler.Direction.Down:
                    direction = new Vector2(0, 1);
                    state = State.moving;
                    break;
                case InputHandler.Direction.Right:
                    direction = new Vector2(1, 0);
                    state = State.moving;
                    break;
                case InputHandler.Direction.None:
                    direction = Vector2.Zero;
                    state = State.idle;
                    break;
            }            
        }
        // Player Movement
        public void MovePlayer(float time)
        {
            CheckDirection();
            UpdatePlayerRectangle();

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

        public Vector2 GetCollisionBoxLoc()
        {
            Vector2 cbl = new Vector2(collisionBox.X, collisionBox.Y);
            return cbl;
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

        public State GetState()
        {
            return state;
        }
    }
}
