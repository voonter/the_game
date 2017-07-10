using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    public AudioClip deathClip;
	public AudioClip damageClip;

    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    public float sinkSpeed = 1.5f;

    Animator anim;
    AudioSource playerAudio;

    //PlayerShooting playerShooting;
    bool isDead;
    bool damaged;


    void Awake ()
    {
        anim = GetComponent <Animator> ();
        playerAudio = GetComponent <AudioSource> ();
        //playerShooting = GetComponentInChildren <PlayerShooting> ();
        currentHealth = startingHealth;
    }


    void Update ()
    {
        if(damaged)
        {
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
            
        }
        damaged = false;
    }


    public void TakeDamage (int amount)
    {
        damaged = true;

        currentHealth -= amount;

        healthSlider.value = currentHealth;

        playerAudio.Play ();

        if(currentHealth <= 0 && !isDead)
        {
            Death ();
        }
    }

    public bool isPlayerDead()
    {
        return isDead;
    }


    void Death ()
    {
        int i;
        isDead = true;

        //playerShooting.DisableEffects ();
   

        playerAudio.clip = deathClip;
        playerAudio.Play ();

        //playerMovement.enabled = false;
        //playerShooting.enabled = false;
        StartCoroutine(AnimateDeath());
//		SceneManager.LoadScene (0);
//		AppQuit;

    }

    IEnumerator AnimateDeath()
    {
        GameObject mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        GameObject weapon = GameObject.FindGameObjectWithTag("Weapon");
        GameObject player = GameObject.FindGameObjectWithTag("PlayerFPS");

        GameObject.Find("Crosshair").GetComponent<Image>().enabled = false;
        mainCamera.GetComponent<MouseLook> ().enabled = false;
        weapon.GetComponent<PlayerShooting>().enabled = false;
        player.GetComponent<MouseLook>().enabled = false;
        player.GetComponent<CharacterMotor>().enabled = false;

        for (int i = 0; i < 50; i++)
        {
            yield return new WaitForSeconds(0.01F);
            mainCamera.transform.Rotate(Vector3.left, 1);
            mainCamera.transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
            mainCamera.transform.Translate(-Vector3.forward * sinkSpeed * Time.deltaTime);
            weapon.transform.Translate(-Vector3.up * 6 * sinkSpeed * Time.deltaTime);
        }

    }


    public void RestartLevel ()
    {
        SceneManager.LoadScene (0);
    }
}
