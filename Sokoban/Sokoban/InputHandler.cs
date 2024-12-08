using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    public class InputHandler
    {
        KeyboardState currentState;
        KeyboardState previousState;

        public void Update()
        {
            previousState = currentState;
            currentState = Keyboard.GetState();
        }
        public bool IsKeyWasPressed(Keys key)
        {
            return currentState.IsKeyDown(key) && !previousState.IsKeyDown(key);
        }
    }
}
