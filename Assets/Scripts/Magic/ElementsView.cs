using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Magic
{
    public class ElementsView : MonoBehaviour
    {
        [Header("Points positon for spheres")]
        [SerializeField] private Transform[] _slotsPosition;
        [SerializeField] private float _timeMoveElements;
        private enum Index
        {
            firstElem,
            secondElem,
            lastElem
        }
        [SerializeField] private GameObject[] _elementsPrefabs;
        ElementsQueue<GameObject> _elementQueue = new ElementsQueue<GameObject>();
        private Dictionary<Elements, GameObject> _elementPrefabMap;
        void Start()
        {
            _elementPrefabMap = new Dictionary<Elements, GameObject>()
            {
                {Elements.Fire, _elementsPrefabs[0]},
                {Elements.Water, _elementsPrefabs[1]},
                {Elements.Earth, _elementsPrefabs[2]},
            };
        }
        public void ResetElementsPositions(ElementsQueue<Elements> elements)
        {
            if (_elementQueue.Count == 3)
                DeleteLastElement();
            if (_elementQueue.Count>0)
                MoveFirstAndSecondElementToNextSlot();   
            InsertingFirstElementAtBeginning(elements[(int)Index.firstElem]);
        }
        private void DeleteLastElement()
        {
            var lastElement = _slotsPosition[(int)Index.lastElem].GetChild(0).gameObject;
            Destroy(lastElement);
        }
        private void InsertingFirstElementAtBeginning(Elements insertedElem)
        {
            var element = Instantiate(_elementPrefabMap[insertedElem], _slotsPosition[0]);
            element.transform.localPosition = new Vector3(0, 0, 0);
            _elementQueue.Add(element);
        }
        private void MoveFirstAndSecondElementToNextSlot()
        {
            int count = _elementQueue.Count>2 ? 2 : _elementQueue.Count;
            StopAllCoroutines();
            for (int i = 0; i < count; i++)
            {              
                _elementQueue[i].transform.parent = _slotsPosition[i+1].transform;
                StartCoroutine(MoveToPoint(_elementQueue[i].transform, _slotsPosition[i + 1].transform));
            }
        }
        private IEnumerator MoveToPoint(Transform element, Transform point)
        {
            float elapsedTime = 0;
            while (elapsedTime < _timeMoveElements)
            {
                elapsedTime += Time.deltaTime;
                float step = elapsedTime / _timeMoveElements;
                Vector3 moveLerp = Vector3.Lerp(element.position, point.position, step);
                element.position = moveLerp;
                yield return null;
            }
            yield break;
        }
    }
}

