using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _anim;
    private SpriteRenderer _playerSprite;
    private Animator _swordArcAnim;
    private SpriteRenderer _swordArcSprite;
    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        if(_anim == null)
        {
            Debug.LogError("Player Animator is NULL");
        }
        _playerSprite = GetComponentInChildren<SpriteRenderer>();
        if (_playerSprite == null)
        {
            Debug.LogError("Player Sprite Renderer is NULL");
        }
        _swordArcAnim = transform.GetChild(1).GetComponent<Animator>();
        if(_swordArcAnim == null)
        {
            Debug.LogError("Sword Arc Animator is NULL");
        }
        _swordArcSprite = transform.GetChild(1).GetComponent<SpriteRenderer>();
        if(_swordArcSprite == null)
        {
            Debug.LogError("Sword Arc Sprite Renderer is NULL");
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

    public void TriggerAttack()
    {
        _anim.SetTrigger("Attack");
        _swordArcAnim.SetTrigger("SwordAnimation");
    }

    private void FaceDirection(float horizontal)
    {
            Vector3 sSPos = _swordArcSprite.transform.localPosition;
        if(horizontal > 0)
        {
            _playerSprite.flipX = false;
            _swordArcSprite.flipY = false;
            if(sSPos.x < 1)
            {
                sSPos.x = sSPos.x * -1;
                _swordArcSprite.transform.localPosition = sSPos;
            }
        }

        if(horizontal < 0)
        {
            _playerSprite.flipX = true;
            _swordArcSprite.flipY = true;
            if(sSPos.x > 1)
            {
                sSPos.x = sSPos.x * -1;
                _swordArcSprite.transform.localPosition = sSPos;
            }
        }
    }
}
