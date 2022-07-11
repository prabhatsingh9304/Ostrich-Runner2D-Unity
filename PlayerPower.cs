using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPower : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D player;
    public float flySpeed=7f;
    private Animator anim; 
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(Input.GetKey(KeyCode.W))
        {
            Fly();
        }
        
    }

    private void Fly()
    {
        player.velocity = new Vector2(player.velocity.x,flySpeed);
       // anim.SetTrigger("fly");
    }
}
