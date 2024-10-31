using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallonMovement : MonoBehaviour
{
    public float moveSpeed;
    public float boundary = 10f;
    private bool MovingRight =true;
    public float GrowAmount  = 0.1f;
    public float maxSize  = 2.0f;
    int level;

    void Start(){
        InvokeRepeating("Grow",0f,1f);
        level = SceneManager.GetActiveScene().buildIndex;
        switch(level+1){
            case 1:
                moveSpeed = 2f;
                break;
            case 2:
                moveSpeed = 5f;
                break;
            case 3:
                moveSpeed = 10f;
                break;
            default:
                moveSpeed = 5f; 
                break;
        }
    }
    void Update()
    {
        if(MovingRight){
            transform.Translate(Vector2.right * moveSpeed *Time.deltaTime);
        }else{
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }
        if(transform.position.x >= boundary){
            MovingRight = false;
        }else if(transform.position.x <= -boundary){
            MovingRight = true;
        }
    }
    void Grow(){

        transform.localScale += new Vector3(GrowAmount,GrowAmount,0);
        if(transform.localScale.x >= maxSize){
            CancelInvoke("Grow");
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
