using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackScript : MonoBehaviour
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

    public Transform playerTrans;
    public float attackTriggerDistance = 1.5f;
    public AudioSource stabSFX;
    public AudioSource hitSFX;
    public AudioSource missedSFX;

    // Update is called once per frame
    void Update()
    {
        if (duration >= attackDuration)
        {
            attacking = false;
            duration = 0;
        }

        anim.SetBool("Attack", false);
        if (timeBtwAttack <= 0)
        {
            //if (Input.GetMouseButton(0))
            if (Vector2.Distance(transform.position, playerTrans.position) <= attackTriggerDistance)
            {
                anim.SetBool("Attack", true);
                stabSFX.Play();
                attacking = true;
                timeBtwAttack = startTimeBtwAttack;
            }
        }
        else
            timeBtwAttack -= Time.deltaTime;


        Debug.Log(transform.eulerAngles.z);
        if (attacking)
        {
            Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(RangeX, RangeY), transform.eulerAngles.z, enemies);

            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                if (enemiesToDamage[i].gameObject.tag == "Player")
                {
                    // WHAT should happen to player?;
                }
            }
            duration -= Time.deltaTime;
        }
    }



    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPos.position, new Vector3(RangeX, RangeY, 1));
    }
}
