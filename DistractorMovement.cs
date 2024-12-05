using UnityEngine;

public class DistractorMovement : MonoBehaviour
{
    public float speed = 5f;
    public float boundary = 8f;
    private bool movingRight = true;

    public float growthRate = 0.1f;
    public float MaxSize = 3.0f;

    void Start()
    {
        InvokeRepeating("Grow",0f,1f); //InvokeRepeating(string methodName, float time, float repeatRate);

    }

    // Update is called once per frame
    void Update()
    {
        if(movingRight){
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }else{
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        if(transform.position.x >= boundary){
            movingRight = false;
        }else if(transform.position.x <= -boundary){
            movingRight = true;
        }
    }
    void Grow(){
        transform.localScale += new Vector3(growthRate,growthRate,0);
        if(transform.localScale.x >= MaxSize){
            CancelInvoke("Grow");//Stop repeat method name"grow"
            Destroy(gameObject);

        }
    }
}
