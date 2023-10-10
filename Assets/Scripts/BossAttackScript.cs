using System;
using UnityEngine;
using Pathfinding;
using System.Collections;

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
    private bool attacking;

    private Transform playerTrans;
    public float attackTriggerDistance = 1.5f;
    public AudioSource stabSFX;
    public AudioSource hitSFX;
    public AudioSource missedSFX;
    public AudioSource warningSFX;
    public AudioSource trapSFX;
    public float warningSFXDistance = 7f;
    public float voicelineCooldown = 7f;
    private float voicelineCDCountdown;
    public bool playWarningSFX;

    public float enragedSpeedMultiplier = 1.15f;
    public float enragedDuration = 5f;
    public float trapSpeedMultiplier = 0.15f;
    public float trapDuration = 4f;
    private float defaultSpeed;

    private bool alreadyHandledVoicelines;


    private void Start()
    {
        playerTrans = GameObject.Find("Player").transform;
        gameObject.GetComponent<AIDestinationSetter>().target = playerTrans;

        defaultSpeed = gameObject.GetComponent<AIPath>().maxSpeed;
    }

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

    public void HandleTrap(GameObject trap)
    {
        gameObject.GetComponent<AIPath>().maxSpeed = defaultSpeed * trapSpeedMultiplier;
        StartCoroutine(TrapCouroutine(trapDuration, trap));
    }

    public void HandleEnrange()
    {
        gameObject.GetComponent<AIPath>().maxSpeed = defaultSpeed * enragedSpeedMultiplier;
        StartCoroutine(EnrageCouroutine(enragedDuration));
    }

    private IEnumerator TrapCouroutine(float duration, GameObject trap)
    {
        yield return new WaitForSeconds(duration);
        gameObject.GetComponent<AIPath>().maxSpeed = defaultSpeed;
        Destroy(trap);
    }

    private IEnumerator EnrageCouroutine(float duration)
    {
        yield return new WaitForSeconds(duration);
        gameObject.GetComponent<AIPath>().maxSpeed = defaultSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            trapSFX.Play();
            HandleTrap(collision.gameObject);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPos.position, new Vector3(RangeX, RangeY, 1));
    }
}
