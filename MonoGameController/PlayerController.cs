using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameController
{
    class PlayerController : Microsoft.Xna.Framework.GameComponent
    {
        private Player player;

        


        public PlayerController(Game game) : base(game)
        {
            player = new Player(game);        
        }

        public void MovePlayer(float time)
        {
            player.MovePlayer(time);
        }

        public Texture2D GetPlayerTexture()
        {
            return player.GetTexture();
        }

        public void SetPlayerTexture(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            player.SetTexture(content);
        }

        public Vector2 GetPlayerPosition()
        {
            return player.GetPosition();
        }

        public void KeepInBoundries()
        {
            player.KeepInBoundries();
        }

        public Player GetPlayer()
        {
            return player;
        }

        public Vector2 GetPlayerDirection()
        {
            return player.GetPlayerDirection();
        }

        float time;
        public override void Update(GameTime gameTime)
        {
            time = (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            MovePlayer(time);

            KeepInBoundries();

            base.Update(gameTime);
        }
    }
}
