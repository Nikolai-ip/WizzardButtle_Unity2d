using InputSpace;
using Unity.Mathematics;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AnimatorController))]
public class MoveController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private AnimatorController _animations;
    [SerializeField] private float _speed;
    private InputController _input;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animations = GetComponent<AnimatorController>();
        _input = GetComponent<InputController>();
    }

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        try
        {
            TryToMove();
        }
        catch
        {
            Debug.Log("InputController is not found");
        }
    }
    private void TryToMove()
    {
        float moveX = _input.GetMoveX();
        _rb.velocity = new Vector3(moveX * _speed, 0, 0);
        MoveCheck(moveX);
    }

    private void MoveCheck(float moveX)
    {
        bool playerIsMoving = !Mathf.Approximately(moveX, 0f);
        _animations.SetRunAnim(playerIsMoving);
        if (playerIsMoving)
            Flip(moveX);
    }

    private void Flip(float moveX) => transform.localScale = new Vector3(math.sign(moveX), 1, 1);
}