using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private Animator anim;
    private Transform attackPoint;
    public float attackRange = 0.5f;
    private string isAttacking = "isAttacking";

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool(isAttacking, false);
        if (Input.GetKeyDown(KeyCode.X))
        {
            anim.SetBool(isAttacking, true);
        }
    }
}
