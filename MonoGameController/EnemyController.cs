using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameController
{
    class EnemyController : Microsoft.Xna.Framework.GameComponent
    {
        Enemy enemy;

        PlayerController playerController;

        public EnemyController(Game game) : base(game)
        {
            enemy = new Enemy(game);

            playerController = new PlayerController(game);
        }

        public void ChasePlayer(Player player, float time)
        {
            enemy.ChasePlayer(player, time);
        }

        public void SetEnemyTexture(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            enemy.SetTexture(content);
        }

        public Texture2D GetEnemyTexture()
        {
            return enemy.GetTexture();
        }

        public Vector2 GetPosition()
        {
            return enemy.GetPosition();
        }
    }
}
