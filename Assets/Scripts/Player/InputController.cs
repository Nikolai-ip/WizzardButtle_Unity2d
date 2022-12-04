using Magic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace InputSpace
{
    public abstract class InputController: MonoBehaviour
    {
        public abstract float GetMoveX();

        protected MagicController _magicController;

        protected enum KeyButton
        {
            Jump,
            InvokeFire,
            InvokeWater,
            InvokeEarth,
            InvokeCombination,
        }

    }
}
