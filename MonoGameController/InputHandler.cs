using Microsoft.Xna.Framework.Input;

namespace MonoGameController
{
    class InputHandler
    {
        public enum Direction
        {
            Up,
            Left,
            Down,
            Right,
            None
        }

        public Direction direction { get; set; }

        public Direction GetMovementDirection()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W) || Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                return Direction.Up;                
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.A) || Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                return Direction.Left;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S) || Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                return Direction.Down;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D) || Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                return Direction.Right;
            }
            else
            {
                return Direction.None;
            }
        }
    }
}
