using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed=10f;
    public Animator anim;
    private Rigidbody2D rb;
    private int damage=5; // Damage cause by bombing
    //public GameObject impactEffect;
    [SerializeField] private ParticleSystem muzzleFlash;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Shooting();
        
    }

    private void Shooting(){
        muzzleFlash.Play();
        rb.velocity = transform.right * speed;
        Destroy(gameObject,8f);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if(enemy != null){
            enemy.TakeDamage(damage);
        }
        //anim.SetTrigger("explode");
        //Instantiate(impactEffect,transform.position,transform.rotation);
        Destroy(gameObject);
    }
    
}
