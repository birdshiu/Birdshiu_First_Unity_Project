using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public GameScript gameScript;

    private void Start()
    {
        gameScript = FindObjectOfType<GameScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (this.name.Equals("Moose Variant(Clone)"))
        {
            gameScript.AddScore(20);
        }
        else if (this.name.Equals("Fox Variant(Clone)"))
        {
            gameScript.AddScore(10);
        }
        else if (this.name.Equals("Dog Variant(Clone)"))
        {
            gameScript.AddScore(5);
        }

        Destroy(gameObject);
    }
}
