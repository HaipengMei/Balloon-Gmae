using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DistractorMovement : MonoBehaviour
{
    public float speed;
    public float boundary = 10f;
    private bool MovingRight = true;
    int level;
    // Update is called once per frame
    void Start()
    {
        level = SceneManager.GetActiveScene().buildIndex;
        switch(level+1){
            case 1:
                speed = 2f;
                break;
            case 2:
                speed = 5f;
                break;
            case 3:
                speed = 10f;
                break;
            default:
                speed = 5f; 
                break;
        }        
    }
    void Update()
    {
        if(MovingRight){
            transform.Translate(Vector2.right * speed *Time.deltaTime);
        }else{
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        if(transform.position.x >= boundary){
            MovingRight = false;
        }else if(transform.position.x <= -boundary){
            MovingRight = true;
        }
    }
}
