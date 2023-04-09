using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator _animator;
    private int _animIDAttack;
    private GameObject playerCameraRoot;
    private GameObject attackCollision;

    private void Awake()
    {
        _animator= GetComponent<Animator>();
        _animIDAttack = Animator.StringToHash("Attack");
        attackCollision = this.transform.Find("AttackCollision").gameObject;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _animator.SetBool(_animIDAttack, true);
        }
        else
        {
            _animator.SetBool(_animIDAttack, false);
        }
    }
}
