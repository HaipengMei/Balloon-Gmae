using UnityEngine;

public class DistractorSpwaner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int MaxNumber = 5;
    [SerializeField] GameObject Balloon;
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Spawn(){
        int xMin = -5;
        int xMax = 5;
        int yMin = -3;
        int yMax = 5;
        for(int i = 0; i< MaxNumber; i++){
            Vector2 position = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
            Instantiate(Balloon,position,Quaternion.identity);
        }
    }
}
