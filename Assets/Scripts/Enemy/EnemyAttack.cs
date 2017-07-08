using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 1f;
    public int attackDamage = 10;


    Animator anim;
    GameObject player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    bool playerInRange;
    float timer;
    UnityEngine.AI.NavMeshAgent nav;


    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player");
        playerHealth = player.GetComponent <PlayerHealth> ();
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent <Animator> ();
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }


    void OnTriggerEnter (Collider other)
    {
        if(other.gameObject == player)
        {
            anim.SetTrigger("Attack");
            playerInRange = true;
            nav.enabled = false;
        }
    }


    void OnTriggerExit (Collider other)
    {
        if(other.gameObject == player)
        {
            anim.SetTrigger("Walk");
            playerInRange = false;
            nav.enabled = true;
        }
    }


    void Update ()
    {
        timer += Time.deltaTime;

        if(timer >= timeBetweenAttacks && playerInRange/* && enemyHealth.currentHealth > 0*/)
        {
            Attack ();
        }

        if(playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger("PlayerDead");
            nav.enabled = false;
        }
    }


    void Attack ()
    {
        timer = 0f;

        if(playerHealth.currentHealth > 0 && enemyHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage (attackDamage);
        }
    }
}
