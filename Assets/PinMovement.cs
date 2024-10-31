using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PinMovement : MonoBehaviour
{
    public float Speed = 10f;
    public AudioSource audioSound;
    public ScoreManager scoreManager;
    // Update is called once per frame
    void Start()
    {
    if (scoreManager == null)
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }
    }
    void Update()
    {
        transform.Translate(Vector3.right * Speed * Time.deltaTime);
    }
     void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Ballon")){
            if(audioSound != null){
                audioSound.Play();
            }
            if (scoreManager != null)
            {
                scoreManager.addScore(other.transform.localScale.x);
            }
            Destroy(other.gameObject);
            Destroy(gameObject);

        }
        if(other.gameObject.CompareTag("Distractor")){
            if(audioSound != null){
                audioSound.Play();
            }
            if (scoreManager != null)
            {
                scoreManager.addScore(-5);
            }
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
     }
}
