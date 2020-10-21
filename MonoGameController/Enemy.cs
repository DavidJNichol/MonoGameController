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
        public Enemy(Game game) : base(game)
        {
            direction = new Vector2(1, 0);
            startPosition = new Vector2(100, 100);
            currentPosition = startPosition;
            speed = 220;

            collisionBox = new Rectangle((int)currentPosition.X, (int)currentPosition.Y, 75, 90);
        }

        public void ChasePlayer(Player player, float time)
        {
            direction = player.GetPlayerDirection();

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
