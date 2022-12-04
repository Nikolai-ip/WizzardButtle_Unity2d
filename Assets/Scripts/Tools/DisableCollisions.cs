using Magic;
using UnityEngine;

public class DisableCollisions : MonoBehaviour
{

    private void Start()
    {
        Collider2D _firstCollider = GetComponent<Collider2D>();
        Collider2D _secondCollider = GameObject.FindWithTag(GetComponent<Spell>().wizardTag).GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(_firstCollider, _secondCollider);
    }
}
