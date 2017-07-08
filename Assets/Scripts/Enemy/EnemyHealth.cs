using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 1.5f;
    public int scoreValue = 10;
    public AudioClip deathClip;


    Animator anim;
    AudioSource enemyAudio;
    CapsuleCollider capsuleCollider;
    bool isDead;
    bool isSinking;


    void Awake ()
    {
        anim = GetComponent <Animator> ();
        enemyAudio = GetComponent <AudioSource> ();
        capsuleCollider = GetComponent <CapsuleCollider> ();

        currentHealth = startingHealth;
    }


    void Update ()
    {
        if(isSinking)
        {
            transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }


    public void TakeDamage (int amount)
    {
        if(isDead)
            return;

        enemyAudio.Play ();

        currentHealth -= amount;
            
        if(currentHealth <= 0)
        {
            Death ();
        }
    }


    void Death ()
    {
        isDead = true;

        capsuleCollider.isTrigger = true;

        anim.SetTrigger ("Dead");

        enemyAudio.clip = deathClip;
        enemyAudio.Play ();

        StartCoroutine(DestroyZombie());
    }

    IEnumerator DestroyZombie()
    {
        if (isDead)
        {
            // Find and disable the Nav Mesh Agent.
            GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;

            // Find the rigidbody component and make it kinematic (since we use Translate to sink the enemy).
            GetComponent<Rigidbody>().isKinematic = true;

            SphereCollider sphereCollider = gameObject.GetComponent<SphereCollider>();
            sphereCollider.enabled = false;

            CapsuleCollider capsuleCollider = gameObject.GetComponent<CapsuleCollider>();
            capsuleCollider.enabled = false;

            // Increase the score by the enemy's score value.
            ScoreManager.score += scoreValue;

            yield return new WaitForSeconds(1); //this will wait 5 seconds  

            // The enemy should no sink.
            isSinking = true;

            yield return new WaitForSeconds(2); //this will wait 5 seconds  
            Destroy(gameObject);
        }
    }



}
