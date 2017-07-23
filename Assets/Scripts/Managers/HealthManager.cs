using UnityEngine;

public class HealthManager : MonoBehaviour
{
	public PlayerHealth playerHealth;
	public GameObject firstAidKit;
	public float spawnTime = 120f;
	public Transform[] spawnPoints;


	void Start ()
	{
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}


	void Spawn ()
	{
		if(playerHealth.currentHealth <= 0f)
		{
			return;
		}

		int spawnPointIndex = Random.Range (0, spawnPoints.Length);

		Instantiate (firstAidKit, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
	}
}
