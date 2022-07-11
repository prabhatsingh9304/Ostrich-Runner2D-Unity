using System.Runtime.ExceptionServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHealth = 40;
    public int currentHealth;
    public HealthBar healthBar;
    [SerializeField] private Animator anim;
    public Transform enemyFirePoint;    
    [SerializeField] private Transform target;
    [SerializeField] private float fireRange =50f;
    [SerializeField] public float fireRate = 0.5f;
    [SerializeField] private float nextFire = 0.0f;
    [SerializeField] private int damage = 1;
    public LineRenderer line;

    public void TakeDamage(int damage){
        currentHealth -= damage;           // Decreasing the health by damage
        healthBar.SetHealth(currentHealth);
        if(currentHealth <= 0f ){
            Die();
        }
    }

    public void Die(){
        //Animation Statement Here
        healthBar.enabled = false;
        Destroy(gameObject,0f);
    }

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        
    }
    
    void Update(){
        if(Vector2.Distance(transform.position,target.position) < fireRange && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            StartCoroutine(Attack());
        }     
    
    }

 

    IEnumerator Attack()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(enemyFirePoint.position,enemyFirePoint.right);
        if(hitInfo)
        {
            PlayerHealth playerHealth = hitInfo.transform.GetComponent<PlayerHealth>();
            if(playerHealth != null){
                playerHealth.TakeDamage(damage);          
            }
            line.SetPosition(0,enemyFirePoint.position);
            line.SetPosition(1,hitInfo.point);
        }
        else
        {
            line.SetPosition(0,enemyFirePoint.position);
            line.SetPosition(1,enemyFirePoint.position + enemyFirePoint.right * 1000);
        }
        line.enabled = true;

        yield return new WaitForSeconds(0.02f);  // for Time lag between enabling disabling line renderer

        line.enabled = false; 
               
    }
    


    
    
     

}
