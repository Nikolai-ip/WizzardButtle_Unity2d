using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Magic
{
    public class DictionarySpells : MonoBehaviour
    {
        private Dictionary<ElementsQueue<Elements>, Spell> _spellsDictionaty;

        [SerializeField] private List<Spell> _spells = new List<Spell>();
        void Start()
        {
            CreateSpellDictionaty();
        }
        enum SpellsName
        {
            FireMeteor
        }
        private void CreateSpellDictionaty()
        {         
            _spellsDictionaty = new Dictionary<ElementsQueue<Elements>, Spell>()
            {
                { new ElementsQueue<Elements>() { Elements.Fire, Elements.Fire, Elements.Earth }, _spells[(int)SpellsName.FireMeteor] }
            };
        }
        public bool ContainKey(ElementsQueue<Elements> elementsQueue)
        {
            return _spellsDictionaty.ContainsKey(elementsQueue);
        }
        public Spell GetSpell(ElementsQueue<Elements> magicCombination)
        {
            return _spellsDictionaty[magicCombination];
        }

    }
}


