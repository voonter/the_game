using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{

    Transform player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    UnityEngine.AI.NavMeshAgent nav;


    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player").transform;
        playerHealth = player.GetComponent <PlayerHealth> ();
        enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
    }

	void Start()
	{
		Animator anim = GetComponent <Animator> ();

		int scene_id = SceneManager.GetActiveScene ().buildIndex;

		UnityEngine.AI.NavMeshAgent nav = GetComponent <UnityEngine.AI.NavMeshAgent> (); 
		Debug.Log (scene_id);
		if (scene_id== 1) 
		{
			nav.speed = 1;
			anim.speed = 1;
		}
		else if ( scene_id == 2)
		{
			nav.speed = 3;
			anim.speed = 3;
		}
	}


    void Update ()
    {
		
        if(enemyHealth.currentHealth > 0 /*&& playerHealth.currentHealth > 0*/)
        {
            if (nav.enabled)
                nav.SetDestination (player.position);
        }
        else
        {
            nav.enabled = false;
        }
    }
}
