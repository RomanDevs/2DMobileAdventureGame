using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _anim;
    private SpriteRenderer _playerSprite;
    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        if(_anim == null)
        {
            Debug.LogError("Animator is NULL");
        }
        _playerSprite = GetComponentInChildren<SpriteRenderer>();
        if (_playerSprite == null)
        {
            Debug.LogError("Sprite Renderer is NULL");
        }    
    }

    void Update()
    {

    }

    public void Jump(bool TorF)
    {
        _anim.SetBool("Jump", !TorF);
    }
    public void Move(float horizontal)
    {
        _anim.SetFloat("Speed", Mathf.Abs(horizontal));
        FaceDirection(horizontal);
    }

    private void FaceDirection(float horizontal)
    {
        if(horizontal > 0)
        {
            _playerSprite.flipX = false;
        }

        if(horizontal < 0)
        {
            _playerSprite.flipX = true;
        }
    }
}
