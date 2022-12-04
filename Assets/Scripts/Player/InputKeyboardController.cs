using Magic;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace InputSpace
{
    public class InputKeyboardController : InputController
    {


        private Dictionary<KeyButton, KeyCode> _configurations = new Dictionary<KeyButton, KeyCode>()
        {
            { KeyButton.Jump, KeyCode.Space},
            { KeyButton.InvokeFire, KeyCode.Alpha1},
            { KeyButton.InvokeWater, KeyCode.Alpha2},
            { KeyButton.InvokeEarth, KeyCode.Alpha3},
            { KeyButton.InvokeCombination, KeyCode.Alpha4}
        };

        private Dictionary<string, Elements> _elementsMap = new Dictionary<string, Elements>()//this dictionaty need for replace Input.getStringButton on Element
        {
            { "1", Elements.Fire },
            { "2", Elements.Water },
            { "3", Elements.Earth }
        };

        private void Start()
        {
            _magicController = GetComponent<MagicController>();          
        }

        private void LateUpdate()
        {
            CheckElementInvoke_ButtonPressed();
            CheckCombinationInvoke_ButtonPressed();
        }

        private void CheckElementInvoke_ButtonPressed()
        {
            if (isElementKeysPressed())
            {
                Elements element = _elementsMap[Input.inputString];
                _magicController.AddElementToQueue(element);
            }
        }

        private bool isElementKeysPressed() =>
         Input.GetKeyDown(_configurations[KeyButton.InvokeFire]) ||
         Input.GetKeyDown(_configurations[KeyButton.InvokeWater]) ||
         Input.GetKeyDown(_configurations[KeyButton.InvokeEarth]);

        private void CheckCombinationInvoke_ButtonPressed()
        {
            if (InvokeCombinationKey_IsPressed())
            {
                _magicController.InvokeCombination();
            }
        }

        private bool InvokeCombinationKey_IsPressed() => Input.GetKeyDown(_configurations[KeyButton.InvokeCombination]);

        private void FixedUpdate()
        {
            CheckMoveX();
        }

        private float moveX;

        public override float GetMoveX() => moveX;

        private void CheckMoveX()
        {
            moveX = Input.GetAxis("Horizontal");
        }

    }
}