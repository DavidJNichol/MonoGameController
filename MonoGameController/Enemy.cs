using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameController
{
    class Enemy : Sprite
    {
        float turnAmount;

        public State state;

        public enum State
        {
            chasing,
            roving,
        }

        public Enemy(Game game) : base(game)
        {
            direction = new Vector2(0, 1);
            startPosition = new Vector2(50, 50);
            currentPosition = startPosition;
            speed = 200;

            state = State.roving;

            turnAmount = 1.2f;

            collisionBox = new Rectangle((int)currentPosition.X, (int)currentPosition.Y, 75, 90);
        }

        public bool CheckCollision(Player player)
        {
            if(collisionBox.Intersects(player.GetCollisionBox()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Rove(Player player, float time)
        {
            state = State.roving;

            //Moves enemy up and down v
            velocity = 0;
            acceleration = .01f;
            acceleration += .5f;

            velocity += acceleration * acceleration * (time / 1000);
            currentPosition += (direction * speed) * (time / 1000);

            if (state == State.roving && currentPosition.Y > 200)
            {
                direction = new Vector2(0, -1);
            }
            if(state == State.roving && currentPosition.Y < 10)
            {
                direction = new Vector2(0, 1);
            }
            //Moves enemy up and down ^

            Vector2 loc = new Vector2(this.currentPosition.X, this.currentPosition.Y);
            while (loc.X < this.Game.GraphicsDevice.Viewport.Width &&
                  loc.X > 0 &&
                  loc.Y < this.Game.GraphicsDevice.Viewport.Height &&
                  loc.Y > 0)
            {
                //If enemy collides with player, set to chasing
                if (collisionBox.Intersects(player.GetCollisionBox()))
                {
                    state = State.chasing;
                    //ChasePlayer(player, time);
                    break;
                }
                loc += direction;
            }
        }

        public void ChasePlayer(Player player, float time)
        {
            if (player.GetPosition().Y > currentPosition.Y)
            {
                currentPosition.Y = MathHelper.Clamp(currentPosition.Y += turnAmount, -50, player.GetPosition().Y + 200);               
            }
            else
            {
                currentPosition.Y = MathHelper.Clamp(currentPosition.Y -= turnAmount, -50, player.GetPosition().Y + 200);
            }
            if (player.GetPosition().X > currentPosition.X)
            {
                currentPosition.X = MathHelper.Clamp(currentPosition.X += turnAmount, player.GetPosition().X -400, 800);
            }
            else
            {
                currentPosition.X = MathHelper.Clamp(currentPosition.X -= turnAmount, player.GetPosition().X -400, 800);
            }
        }

        public void ResetPosition()
        {
            currentPosition = startPosition;
            state = State.roving;
        }

        public void CheckState(Player player, float time)
        {
            switch(state)
            {
                case State.roving:
                    Rove(player, time);
                    break;
                case State.chasing:
                    ChasePlayer(player, time);
                    break;
            }
        }

        public void UpdateCollisionBox()
        {
            this.collisionBox.X = (int)currentPosition.X;
            this.collisionBox.Y = (int)currentPosition.Y;
        }

        public Texture2D GetTexture()
        {
            return spriteTexture;
        }

        public void SetTexture(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            spriteTexture = content.Load<Texture2D>("Enemy");
        }

        public Vector2 GetPosition()
        {
            return currentPosition;
        }              
    }
}
