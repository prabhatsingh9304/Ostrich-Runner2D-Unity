using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform firePoint;
    public Transform gun;
    Vector2 direction;

    public GameObject bomb;
    public GameObject bullet;
    //private int damage = 10;     uncomment for bullet damage while using raycast
    //public LineRenderer line;    for raycast shooting

    //[SerializeField] private float bulletRange = 40f; 

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosi = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePosi - (Vector2)firePoint.position;
        gun.transform.right = direction;

        if(Input.GetKeyDown(KeyCode.F)){
            throwBomb();
        }
        if(Input.GetButtonDown("Fire1")){
           //StartCoroutine(fireBullet());
           fireBullet();
        }
    }
    public void throwBomb(){
        Instantiate(bomb,firePoint.position,firePoint.rotation);
    }

    public void fireBullet()
    {
        Instantiate(bullet,firePoint.position,firePoint.rotation);
    }

}
