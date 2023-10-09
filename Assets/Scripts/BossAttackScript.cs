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
    public AudioSource warningSFX;
    public float warningSFXDistance = 7f;
    public float voicelineCooldown = 7f;
    private float voicelineCDCountdown = 0f;
    public bool playWarningSFX = false;

    private bool alreadyHandledVoicelines = false;
    void Update()
    {
        if (duration >= attackDuration)
        {
            attacking = false;
            alreadyHandledVoicelines = false;
            duration = 0;
        }

        if (voicelineCDCountdown <= 0 && Vector2.Distance(transform.position, playerTrans.position) <= warningSFXDistance && playWarningSFX) {
            warningSFX.Play();
            voicelineCDCountdown = voicelineCooldown;
        }

        anim.SetBool("Attack", false);
        if (timeBtwAttack <= 0)
        {
            if (Vector2.Distance(transform.position, playerTrans.position) <= attackTriggerDistance)
            {
                anim.SetBool("Attack", true);
                stabSFX.Play();
                attacking = true;
                alreadyHandledVoicelines = false;
                timeBtwAttack = startTimeBtwAttack;
            }
        }
        else
            timeBtwAttack -= Time.deltaTime;


        // Debug.Log(transform.eulerAngles.z);
        if (attacking)
        {
            Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(RangeX, RangeY), transform.eulerAngles.z, enemies);

            bool hitPlayer = false;

            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                if (enemiesToDamage[i].gameObject.tag == "Player")
                {
                    // WHAT should happen to player?;
                    Debug.Log("ENEMY HIT PLAYER!!!");
                    hitPlayer = true;
                }
            }

            if (!alreadyHandledVoicelines) {
                if (hitPlayer) {
                    hitSFX.Play();
                } else {
                    missedSFX.Play();
                }
                alreadyHandledVoicelines = true;
            }
            duration -= Time.deltaTime;
        }
        voicelineCDCountdown -= Time.deltaTime;
    }



    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPos.position, new Vector3(RangeX, RangeY, 1));
    }
}
