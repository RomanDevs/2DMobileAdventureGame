using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour, IDamagable
{
    private int _diamonds;

    private PlayerAnimation _pAScript;
    private Rigidbody2D _rb;
    private float _speed = 3f;
    private Vector2 _velocity;
    private float _jumpForce = 5;
    private bool _resetJump = false;
    [SerializeField] public int Health { get; set; }
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        if(_rb == null)
        {
            Debug.LogError("Rigid Body 2D is NULL");
        }
        _pAScript = GetComponent<PlayerAnimation>();
        if(_pAScript == null)
        {
            Debug.LogError("Player Animation Script is NULL");
        }
        Health = 4;
    }

    void Update()
    {
        Movement();
        Attack();
        
    }

    public void Damage()
    {
        Health--;
        UIManager.Instance.UpdateLives(Health);
        if(Health < 1)
        {
            _pAScript.TriggerDeath();
        }
    }

    private void Movement()
    {
        float horizontal = CrossPlatformInputManager.GetAxis("Horizontal"); //Input.GetAxisRaw("Horizontal");
        _pAScript.Move(horizontal);
        _velocity = new Vector2(horizontal * _speed, _rb.velocity.y);
        _pAScript.Jump(CheckGrounded());

        if (Input.GetKeyDown(KeyCode.Space) || CrossPlatformInputManager.GetButtonDown("BButton") && CheckGrounded() == true)
        {
            _velocity.y = _jumpForce;
            StartCoroutine(JumpReset());
        }


        _rb.velocity = _velocity;
    }

    private bool CheckGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x - 0.07f, transform.position.y - 0.71f), Vector2.down, 0.1f, 00001000);
        Debug.DrawRay(new Vector2(transform.position.x - 0.07f, transform.position.y - 0.71f), Vector2.down * 0.1f, Color.magenta);

        if (hit.collider != null)
        {
            if (_resetJump == false)
            {
                return true;
            }
        }
            return false;
    }

    private IEnumerator JumpReset()
    {
        _resetJump = true;
        yield return new WaitForSeconds(0.1f);
        _resetJump = false;
        StopCoroutine(JumpReset());
    }

    private void Attack()
    {
        if(/*Input.GetMouseButtonDown(0)*/CrossPlatformInputManager.GetButtonDown("AButton") && CheckGrounded())
        {
            _pAScript.TriggerAttack();
        }
    }

    public void AddDiamonds(int diamonds)
    {
        _diamonds += diamonds;
        UIManager.Instance.UpdateHUD(_diamonds);
    }

    public int GetDiamonds()
    {
        return _diamonds;
    }

}
