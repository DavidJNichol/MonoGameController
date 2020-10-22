using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameController
{
    class PlayerController : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private Player player;

        private SpriteBatch spriteBatch;

        public PlayerController(Game game) : base(game)
        {
            player = new Player(game);        
        }
        private void MovePlayer(float time)
        {
            player.MovePlayer(time);
        }

        private Texture2D GetPlayerTexture()
        {
            return player.GetTexture();
        }

        private void KeepInBoundries()
        {
            player.KeepInBoundries();
        }

        public void SetPlayerTexture(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            player.SetTexture(content);
        }

        public Vector2 GetPlayerPosition()
        {
            return player.GetPosition();
        }       

        public Player GetPlayer()
        {
            return player;
        } 

        protected override void LoadContent()
        {
            base.LoadContent();
            spriteBatch = new SpriteBatch(this.Game.GraphicsDevice);
        }

        float time;
        public override void Update(GameTime gameTime)
        {
            time = (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            MovePlayer(time);

            KeepInBoundries();

            //Upate collision box location
            player.UpdatePlayerRectangle();

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(GetPlayerTexture(), GetPlayerPosition(), Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
