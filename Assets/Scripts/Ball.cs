using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rig { get; private set; }

    public float speed = 300f;

    private void Awake()
    {
        this.rig = GetComponent<Rigidbody2D>();
    }

    public void Start()
    {
        ResetBall();
    }

    public void ResetBall()
    {
        this.transform.position = Vector2.zero;
        this.rig.velocity = Vector2.zero;

        Invoke(nameof(SetBall), 1);
    }

    private void SetBall()
    {
        Vector2 force = Vector2.zero;
        force.x = Random.Range(-1f, 1f);
        force.y = -1f;

        this.rig.AddForce(force.normalized * this.speed);
    }
}
