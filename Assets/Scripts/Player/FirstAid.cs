using UnityEngine;
using System.Collections;

public class FirstAid : MonoBehaviour
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




	void OnTriggerEnter (Collider other)
	{

		playerHealth = player.GetComponent<PlayerHealth>();
		applyRescue ();
		//		Destroy(GetComponent<BoxCollider>());
		//		Destroy (other.gameObject);
		DestroyImmediate (gameObject);
	}



}
