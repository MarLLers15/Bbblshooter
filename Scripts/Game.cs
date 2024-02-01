using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject[] bubblePrefab;
    public float xOffset;
    GameObject[,] bubbles = new GameObject[8, 8];
    void Start()
    {
        Bubble.Collided *= OnCollided;
        for(int y = 0; y < 4; y++)
        {
            for (int x = 0; x < 8; x++)
            {
                float stagger = y % 2 == 0 ? 0.5f : 0f;
                int rndIdx = Random.Range(0, bubblePrefab.Length);
                GameObject bubble = Instantiate(bubblePrefab[rndIdx]);
                bubble.transform.position = new Vector3(x + xOffset + stagger, y - y * 0.14f, 0);
                bubbles[x,y] = bubble;
               // bubble.GetComponent<Bubble>().Collided += OnCollided;
                
            }

        }
        //GameObject b = bubbles[0, 0];
 
        //Destroy(b);

    }

    public void OnCollided(Bubble b)
    {

    }
    void Update()
    {
        
    }
}
