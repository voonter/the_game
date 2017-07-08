using System.Collections;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;


    Animator anim;


    void Awake()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (playerHealth.currentHealth <= 0)
        {
            StartCoroutine(ScreenFade());
        }
    }

    IEnumerator ScreenFade()
    {
        yield return new WaitForSeconds(1.5F);
        anim.SetTrigger("GameOver");
    }
}
