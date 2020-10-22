using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameController
{
    class EnemyController : Microsoft.Xna.Framework.DrawableGameComponent
    {
        Enemy enemy;

        SpriteBatch spriteBatch;

        SpriteFont spriteFont;

        string displayText;

        Vector2 displayTextLoc;

        bool collisionDetected;

        public EnemyController(Game game) : base(game)
        {
            enemy = new Enemy(game);

            displayText = "";

            displayTextLoc = new Vector2(300, 35);
        }

        private void DrawDebugText()
        {
            spriteBatch.DrawString(spriteFont, displayText, displayTextLoc, Color.White);
        }

        private Vector2 GetPosition()
        {
            return enemy.GetPosition();
        }

        public void CheckCollisionWithPlayer(Player player)
        {
            if (enemy.state == Enemy.State.chasing && enemy.CheckCollision(player))
            {
                displayText = "Enemy Collided with player";
                collisionDetected = true;
            }
            else
            {
                collisionDetected = false;
            }           
        }

        public void SetFont(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            spriteFont = content.Load<SpriteFont>("Arial");
        }

        public void CheckState(Player player, float time)
        {
            enemy.CheckState(player, time);
        }

        public void UpdateEnemyCollisionBox()
        {
            enemy.UpdateCollisionBox();
        }        

        public void SetEnemyTexture(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            enemy.SetTexture(content);
        }

        public Texture2D GetEnemyTexture()
        {
            return enemy.GetTexture();
        }       

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(this.Game.GraphicsDevice);
            base.LoadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(GetEnemyTexture(), GetPosition(), Color.White);
            spriteBatch.DrawString(spriteFont, "Welcome to the Monogame controller demo! Get close to the monster for him to chase you.", 
                new Vector2(300, 20), Color.White);
            if (collisionDetected)
                //Enemy collided with player text
                DrawDebugText();
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
