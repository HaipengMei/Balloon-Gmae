using UnityEngine;

public class PinMovement : MonoBehaviour
{
    public float speed = 8f;
    private bool shootingRight;
    public AudioSource AttacktedSound;
    public AudioSource RavenSound;
    public ScoreManage Counter;
    void Start()
    {
        
    }

    // Update is called once per frame
    public void PinDirection(bool LeftOrRight){
        shootingRight = LeftOrRight;
    }
    
    void Update()
    {
        if(shootingRight){
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }else{
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Balloon")){
            if(AttacktedSound != null){
                AttacktedSound.Play();
            }
            Counter.addScore(other.transform.localScale.x);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }else if(other.CompareTag("distractor")){
            if(RavenSound != null){
                RavenSound.Play();
            }
            Counter.minuesScore(other.transform.localScale.x);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}