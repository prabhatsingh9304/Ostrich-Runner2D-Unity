using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float speed=10f;
    public Animator anim;
    private Rigidbody2D rb;
    private int damage=50; // Damage cause by bombing
    public GameObject impactEffect;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Bombing();
        
    }

    private void Bombing(){
        rb.velocity = transform.right * speed;
        Destroy(gameObject,8f);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if(enemy != null){
            enemy.TakeDamage(damage);
        }
        anim.SetTrigger("explode");
        //Instantiate(impactEffect,transform.position,transform.rotation);
        Destroy(gameObject);
    }


}