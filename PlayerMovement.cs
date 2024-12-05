using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;


public class Playermovement : MonoBehaviour
{
    public Animator  animator;
    public float speed = 7f;
    private Rigidbody2D playerRB;
    private Collider2D playerC;
    public float jumpForce = 5f;
    private bool facingRight = true;
    public GameObject PinPrefab;
    public Transform FirePoint;
    public AudioSource ShootingSound;
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        animator.SetFloat("Speed",Mathf.Abs(moveX));
        playerRB.linearVelocity = new Vector2(moveX * speed,playerRB.linearVelocity.y);
        if(Input.GetKeyDown(KeyCode.Space)){
            playerRB.linearVelocity = new Vector2(playerRB.linearVelocity.x,jumpForce);
        }
        if(moveX > 0 && !facingRight){
            Flip();
        }
        if(moveX < 0 && facingRight){
            Flip();
        }
        if(Input.GetKeyDown(KeyCode.J)){
            if(ShootingSound != null){
                ShootingSound.Play();
            }
            ShootPin();
        }

        

    }
    void Flip(){
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void ShootPin(){
        GameObject pin = Instantiate(PinPrefab, FirePoint.position, Quaternion.identity);
        Destroy(pin,1.5f);
        PinMovement pinMovement = pin.GetComponent<PinMovement>();
        if(pinMovement != null){
            pinMovement.PinDirection(facingRight);
        }
        
    }
}
