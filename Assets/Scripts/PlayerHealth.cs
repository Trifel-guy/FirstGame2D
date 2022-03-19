using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBarre healthBarre;
    public bool isInvicible = false;
    public SpriteRenderer spriteRenderer;
    public float flashDelay = 0.2f;//delay for flash player
    public float invincibilityTime = 3f;
    public GameObject deathScreen = null;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBarre.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(20);
        }
    }

    public void TakeDamage(int damage)
    {
        if(!isInvicible)
        {
            currentHealth -= damage;
            healthBarre.SetHealth(currentHealth);
            isInvicible = true;
            if (currentHealth == 0){
                //show death screen
                this.deathScreen.SetActive(true);
            }
            StartCoroutine(InvicibilityFlash());
            StartCoroutine(offInvincibilityDelay());
        }
        
    }

    //Coroutine who make allow us to make a break time
    public IEnumerator InvicibilityFlash()
    {
        while(isInvicible)
        {
            spriteRenderer.color = new Color(1f,1f,1f,0f);
            yield return new WaitForSeconds(flashDelay);
            spriteRenderer.color = new Color(1f,1f,1f,1f);
            yield return new WaitForSeconds(flashDelay);
        }
    }

    public IEnumerator offInvincibilityDelay()
    {
        yield return new WaitForSeconds(invincibilityTime);
        isInvicible = false;
    }
}
