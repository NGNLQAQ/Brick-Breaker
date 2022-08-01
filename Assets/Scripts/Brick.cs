using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    //public int health { get; private set; }

    public int points = 100;
    private void Hit()
    {
        this.gameObject.SetActive(false);
        FindObjectOfType<GameManager>().Hit(this);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Ball")
        {
            Hit();
        }
    }
}


