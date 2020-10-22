using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameController
{
    class Enemy : Sprite
    {
        float turnAmount;
        public Enemy(Game game) : base(game)
        {
            direction = new Vector2(1, 0);
            startPosition = new Vector2(20, -20);
            currentPosition = startPosition;
            speed = 0;

            turnAmount = 2f;

            collisionBox = new Rectangle((int)currentPosition.X, (int)currentPosition.Y, 75, 90);
        }

        public void ChasePlayer(Player player, float time)
        {

            
            if (player.GetPosition().Y > currentPosition.Y)
            {
                direction.Y = 1;
                currentPosition.Y = MathHelper.Clamp(currentPosition.Y += turnAmount, -50, player.GetPosition().Y + 200);
            }
            else
            {
                //direction.Y = -1;
                currentPosition.Y = MathHelper.Clamp(currentPosition.Y -= turnAmount, -50, player.GetPosition().Y + 200);
            }
            if (player.GetPosition().X > currentPosition.X)
            {
                //direction.X = 1;
                currentPosition.X = MathHelper.Clamp(currentPosition.X += turnAmount, player.GetPosition().X -400, 800);
            }
            else
            {
                //direction.X = -1;
                currentPosition.X = MathHelper.Clamp(currentPosition.X -= turnAmount, player.GetPosition().X -400, 800);
            }
            //MoveEnemy(time);

        }

        public void MoveEnemy(float time)
        {
            velocity = 0;
            acceleration = .01f;
            acceleration += .5f;

            velocity += acceleration * acceleration * (time / 1000);
            currentPosition += (direction * speed) * (time / 1000);
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
