using UnityEngine;
using System.Collections;

public class PlayerHealthRescue : MonoBehaviour
{
	public int amount = 10;

	public AudioClip rescueClip;

	Animator anim;
	GameObject player;
	PlayerHealth playerHealth;
	bool playerInRange;
	float timer;
	UnityEngine.AI.NavMeshAgent nav;

	AudioSource audio;

	void Awake ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent<PlayerHealth>();
		anim = GetComponent <Animator> ();
//		nav = GetComponent<UnityEngine.AI.NavMeshAgent>();

		audio = GetComponent <AudioSource> ();

		Debug.Log ("test");
	}


	void applyRescue() { 
		playerHealth.rescue (amount);
		playerInRange = true;
//		nav.enabled = false;


		audio.clip = rescueClip;
		audio.Play ();


		GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
	}

	void OnCollisionEnter(Collision collision)
	{
		applyRescue ();
		Debug.Log ("collision enter");
	}



	void Update ()
	{
		playerHealth = player.GetComponent<PlayerHealth>();
	
	}



	void OnTriggerEnter (Collider other)
	{
		applyRescue ();
		Debug.Log ("trigger enter");
	}

}
