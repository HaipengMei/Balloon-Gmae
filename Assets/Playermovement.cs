using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public GameObject PINPrefab;
    public Transform firePoint;
    private Rigidbody2D player;
    private bool facingRight = true;
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        player.velocity = new Vector2(moveX * moveSpeed,player.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space)){
            player.velocity = new Vector2(player.velocity.x, jumpForce);
        }
        if(moveX >0 && !facingRight){
            Flip();
        }
        if(moveX <0 && facingRight){
            Flip();
        }
        if(Input.GetButtonDown("Fire1")){
            ShootPin();
        }
    }
    void Flip(){
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *=-1;
        transform.localScale = theScale;
    }
    void ShootPin(){
        GameObject PIN = Instantiate(PINPrefab, firePoint.position,Quaternion.identity);
    }
}
