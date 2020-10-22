using Microsoft.Xna.Framework;

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
