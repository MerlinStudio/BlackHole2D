using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Buttons;

public sealed class MoveCharacter : MonoBehaviour
{
    public static MoveCharacter instance = null;

    [SerializeField] private GameObject Char;
    [SerializeField] public Sprite[] CharSprites;

    [SerializeField] private Transform GroundCheck;
    public static float _checkRadius;
    [SerializeField] private LayerMask GroundLayer;
    private bool isGrounded;

    private bool onMoving;
    private bool directionRight;

    public static float _moveSpeed;
    public static float _powerJump;

    public static Rigidbody2D _rigidbody2D;
    public static CircleCollider2D _circleCollider2D;

    private float timeCode;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (timeCode > 0)
        {
            timeCode -= Time.fixedDeltaTime;
        }

        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, _checkRadius, GroundLayer);
        if (onMoving)
        {
            if (directionRight)
            {
                transform.Translate(Vector2.right * _moveSpeed * Time.fixedDeltaTime);
            }
            else
            { 
                transform.Translate(Vector2.left * _moveSpeed * Time.fixedDeltaTime);                
            }
            AnimationIdle();
        }
        else
        {
            Char.GetComponent<Transform>().localScale = new Vector3(1f, 1f, 1f);           
        }

        if (!isGrounded)
        {
            Char.GetComponent<Transform>().localScale = new Vector3(1f, 1.1f, 1f);
        }

        //IdlePC();
    }

    public void OnDoAction(int actionId)
    {
        OnDoAction((ActionType)actionId);
    }

    public void OnDoAction(ActionType action)
    {
        if (action == ActionType.MoveRight)
        {
            Char.GetComponent<SpriteRenderer>().flipX = true;
            onMoving = directionRight = true;
            AnimationIdle();
        }
        else if (action == ActionType.MoveLeft)
        {
            Char.GetComponent<SpriteRenderer>().flipX = false;
            directionRight = false;
            onMoving = true;
            AnimationIdle();
        }
        else if (action == ActionType.None)
        {
            Char.GetComponent<Transform>().localScale = new Vector3(1f, 1f, 1f);
            Char.GetComponent<SpriteRenderer>().sprite = CharSprites[0];
            onMoving = false;
        }

        if (action == ActionType.Jump && isGrounded)
        {
            _rigidbody2D.AddForce(Vector2.up * _powerJump, ForceMode2D.Impulse);
        }
    }

    private void IdlePC()
    {
        //  idle left
        if (Input.GetKey(KeyCode.A))
        {
            AnimationIdle();
            Char.GetComponent<SpriteRenderer>().flipX = false;
            directionRight = false;
            onMoving = true;
        }

        // idle right
        if (Input.GetKey(KeyCode.D))
        {
            AnimationIdle();
            Char.GetComponent<SpriteRenderer>().flipX = true;
            onMoving = directionRight = true;
        }

        if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A) && isGrounded)
        {
            Char.GetComponent<Transform>().localScale = new Vector3(1f, 1f, 1f);
            Char.GetComponent<SpriteRenderer>().sprite = CharSprites[0];
            onMoving = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            _rigidbody2D.AddForce(Vector2.up * _powerJump, ForceMode2D.Impulse);
        }
    }

    private void AnimationIdle()
    {
        Char.GetComponent<Transform>().localScale = new Vector3(1.1f, 1f, 1f);
        Char.GetComponent<SpriteRenderer>().sprite = CharSprites[1];
    }
}
