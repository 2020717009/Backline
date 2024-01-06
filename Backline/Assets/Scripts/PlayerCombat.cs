using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private Animator anim;
    private Transform attackPoint;
    public float attackRange = 0.5f;
    private string isAttacking = "isAttacking";
    public float swordAttackPower = 10f;

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
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool(isAttacking, true);
            Attack();
        }
    }

    void Attack()
    {
        // Sald�r� ger�ekle�tirme
        Debug.Log("Attack with power: " + swordAttackPower);

        // Burada sald�r�n�n etkilerini uygulayabilirsiniz, d��manlara zarar verebilirsiniz, vb.
    }
}
