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


        if(attacking)
        {
            StartCoroutine(Hitting());
            // Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(RangeX, RangeY), transform.eulerAngles.z, enemies);
            // for(int i = 0; i < enemiesToDamage.Length; i++)
            // {
            //     if (enemiesToDamage[i].gameObject.tag == "enemy")
            //     {
            //         Destroy(enemiesToDamage[i].gameObject);
            //         StartCoroutine(Hitting());
            //     }
            //         // enemiesToDamage[i].gameObject.GetComponent<BossAttackScript>().HandleDamage(1f);
            // }
            duration -= Time.deltaTime;
            attacking = false;
        }
    }

    private IEnumerator Hitting()
    {
        yield return new WaitForSeconds(0.3f);
        Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(RangeX, RangeY), transform.eulerAngles.z, enemies);
            for(int i = 0; i < enemiesToDamage.Length; i++)
            {
                if (enemiesToDamage[i].gameObject.tag == "enemy")
                {
                    Destroy(enemiesToDamage[i].gameObject);
                    StartCoroutine(Hitting());                    
                }

                    // enemiesToDamage[i].gameObject.GetComponent<BossAttackScript>().HandleDamage(1f);
            }
        yield break;
    }



    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPos.position, new Vector3(RangeX, RangeY, 1));
    }
}
