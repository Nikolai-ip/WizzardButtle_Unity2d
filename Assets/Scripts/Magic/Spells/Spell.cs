using UnityEngine;

namespace Magic
{
    public abstract class Spell : MonoBehaviour
    {
        [SerializeField] protected float timeToAppeareanceSpell;
        [SerializeField] protected int damage;
        [SerializeField] protected int timeToDestroy;
        [SerializeField] protected float AppeareanceOffSetX;
        [SerializeField] protected float AppeareanceOffSetY;
        protected float direction;
        public string wizardTag;

        protected virtual void SetStartTransform(Transform tr)
        {
            transform.position = new Vector3(tr.position.x + AppeareanceOffSetX, tr.position.y + AppeareanceOffSetY, 0);
        }

        protected bool parentTransformIsWizzard;

        public void InstantiateSpell(string wizardTag)
        {
            this.wizardTag = wizardTag;
            Instantiate(this);
        }
    }
}