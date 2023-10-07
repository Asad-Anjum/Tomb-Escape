using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public float RangeX;
    public float RangeY;
    public LayerMask enemies;
    public Animator anim;

    private float duration;
    public float attackDuration = 0.2f;
    private bool attacking = false;

    // Update is called once per frame
    void Update()
    {
        if(duration >= attackDuration) {
            attacking = false;
            duration = 0;
        }

        anim.SetBool("Attack", false);
        if(timeBtwAttack <= 0)
        {
            if(Input.GetMouseButton(0))
            {
                anim.SetBool("Attack", true);
                attacking = true;
                timeBtwAttack = startTimeBtwAttack;
            }
        }
        else
            timeBtwAttack -= Time.deltaTime;


        Debug.Log(transform.eulerAngles.z);
        if(attacking)
        {
            Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(RangeX, RangeY), transform.eulerAngles.z, enemies);
            for(int i = 0; i < enemiesToDamage.Length; i++)
            {
                Destroy(enemiesToDamage[i].gameObject);
            }
            duration -= Time.deltaTime;
        }
    }



    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPos.position, new Vector3(RangeX, RangeY, 1));
    }
}
