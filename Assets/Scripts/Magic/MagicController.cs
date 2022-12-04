using InputSpace;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

namespace Magic
{
    [RequireComponent(typeof(ElementsView))]
    [RequireComponent(typeof(DictionarySpells))]
    public class MagicController : MonoBehaviour
    {
        private ElementsQueue<Elements> _setOfElements = new ElementsQueue<Elements>();
        private HandAnimatorController _handAnimator;
        private event Action<ElementsQueue<Elements>> ResetElementPositionView;

        private DictionarySpells spells;
        private void Start()
        {
            ResetElementPositionView += GetComponent<ElementsView>().ResetElementsPositions;
            spells = GetComponent<DictionarySpells>();
            _handAnimator = GetComponentInChildren<HandAnimatorController>();
        }
        public void AddElementToQueue(Elements element)
        {
            _handAnimator.ReproduceElementInvokeAnimation(element);
            _setOfElements.Add(element);
            ResetElementPositionView(_setOfElements);
        }
     
        public void InvokeCombination()
        {
            try
            {
                TryCastSpell();
            }
            catch
            {
                CombinationIsDontExist();
            }
        }

        private void TryCastSpell()
        {
            _handAnimator.RandomSpellAnimation();
            var spell = spells.GetSpell(_setOfElements);
            spell.InstantiateSpell(gameObject.tag);
        }

        private void CombinationIsDontExist()
        {
            Debug.Log("Combo dont exist");
        }

    }
}