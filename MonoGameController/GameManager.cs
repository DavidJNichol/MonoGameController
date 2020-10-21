using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameController
{
    class GameManager
    {
        public PlayerController playerController;
        public EnemyController enemyController;

        public GameManager(Game game)
        {
            playerController = new PlayerController(game);
            enemyController = new EnemyController(game);
        }
    }
}
