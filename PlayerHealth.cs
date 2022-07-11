using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 40;
    public int currentHealth;
    public HealthBar healthBar;
    private Animator anim;
    
    void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        healthBar.SetMaxHealth(maxHealth);
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;           // Decreasing the health by damage
        healthBar.SetHealth(currentHealth);
        if(currentHealth <= 0f ){
            Die();
        }
    }
    public void Die(){
        //Animation Statement Here
        anim.SetBool("die",true);
        //Destroy(gameObject,0f);
    }

}
