using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public GameScript gameScript;

    private float topBoundary = 30f;
    private float lowerBound = -10f;

    private void Start()
    {
        gameScript = FindObjectOfType<GameScript>();
    }


    void Update()
    {
        if (transform.position.z > topBoundary)
        {
            //這邊是 pizza
            Destroy(gameObject);
        }else if(transform.position.z < lowerBound)
        {
            gameScript.DecreaseLife();
            Destroy(gameObject);
        }

        if (gameScript.isGameOver)
        {
            Destroy(gameObject);
        }
    }
}
