using System.Collections;
using UnityEngine;

namespace Magic
{
    public class Meteor : Spell
    {
        [SerializeField] private float _speedMove;
        private Rigidbody2D _rb;
        private Animator _animator;
        private Transform _spawnSpellPoint;
        private void Awake()
        {
            _spawnSpellPoint = GameObject.FindWithTag(wizardTag).transform;
            SetStartTransform(_spawnSpellPoint);
            _rb = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            
        }
        private void Start()
        {
            Debug.Log(wizardTag);
            StartCoroutine(CastSpell());
        }
        private IEnumerator CastSpell()
        {
            float time = 0;
            while (time < timeToAppeareanceSpell)
            {
                TrackingPlayer();
                time +=Time.deltaTime;
                yield return null;
            }
            _animator.SetBool("IsMove",true);
            StartCoroutine(Move());
        }
        private void TrackingPlayer()
        {
            transform.position = new Vector3(_spawnSpellPoint.position.x + (direction * AppeareanceOffSetX), _spawnSpellPoint.position.y + AppeareanceOffSetY, 0);
            direction = _spawnSpellPoint.transform.localScale.x;
        }
        private IEnumerator Move()
        {
            var fixedUpdateFrame = new WaitForFixedUpdate();
            float time = 0;
            while (time<timeToDestroy)
            {
                time+=Time.deltaTime;   
                SetVelocity();
                yield return fixedUpdateFrame;
            }
            Destroy(gameObject);
        }
        private void SetVelocity()
        {
            _rb.velocity = new Vector2(direction * _speedMove, _rb.velocity.y);
        }
        private void LateUpdate()
        {
            SetCorrectDirection();          
        }
        /// <summary>
        ///  Method set the correct direction move of the meteor (else, without this method, the meteor will move only to the right side)
        /// </summary>
        private void SetCorrectDirection()
        {
            transform.localScale = new Vector3(direction, 1, 1);
        }
    }
}