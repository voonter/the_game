using UnityEngine;
using System.Collections;

public class PlayerHealthRescue : MonoBehaviour
{
	public int amount = -20;

	public AudioClip rescueClip;

	Animator anim;
	GameObject player;
	PlayerHealth playerHealth;
	bool taken;
	float timer;
	UnityEngine.AI.NavMeshAgent nav;

	AudioSource audio;

	void Awake ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent<PlayerHealth>();
//		anim = GetComponent <Animator> ();
//		nav = GetComponent<UnityEngine.AI.NavMeshAgent>();

		audio = GetComponent <AudioSource> ();
	
	}


	void applyRescue() { 
		playerHealth.rescue (amount);
		nav.enabled = false;


		audio.clip = rescueClip;
		audio.Play ();

		GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;

	
		taken = true;


//		StartCoroutine(MakeDisappear());
	}

	void OnCollisionEnter(Collision collision)
	{
//		applyRescue ();
	}



//	void Update ()
//	{
//		playerHealth = player.GetComponent<PlayerHealth>();

//	}



	void OnTriggerEnter (Collider other)
	{

		playerHealth = player.GetComponent<PlayerHealth>();
		applyRescue ();
//		Destroy(GetComponent<BoxCollider>());
//		Destroy (other.gameObject);
		DestroyImmediate (gameObject);
	}


	IEnumerator MakeDisappear()
	{
		if (taken)
		{
			// Find and disable the Nav Mesh Agent.
			GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;

			// Find the rigidbody component and make it kinematic (since we use Translate to sink the enemy).

					BoxCollider collider = gameObject.GetComponent<BoxCollider>();
					collider.enabled = false;
//			CapsuleCollider capsuleCollider = gameObject.GetComponent<CapsuleCollider>();
//			capsuleCollider.enabled = false;

			// Increase the score by the enemy's score value.
//			ScoreManager.score += scoreValue;

			yield return new WaitForSeconds(1); //this will wait 5 seconds  

			// The enemy should no sink.
//			isSinking = true;

//			yield return new WaitForSeconds(2); //this will wait 5 seconds  
			Destroy(gameObject);
		}
	}


	void Update() { 
		StartCoroutine (MakeDisappear());
	}
}
