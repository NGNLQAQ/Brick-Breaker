using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public Rigidbody2D rig { get; private set; }

    public Vector2 dir { get; private set; }

    public float speed = 30f;

    public float maxAngle = 75f;

    private void Awake()
    {
        this.rig = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            this.dir = Vector2.left;
        }
        else if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            this.dir = Vector2.right;
        }
        else
        {
            this.dir = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        if(this.dir != Vector2.zero)
        {
            this.rig.AddForce(this.dir * speed);
        }
    }

    public void ResetPaddle()
    {
        this.transform.position = new Vector2(0f, this.transform.position.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();

        if (ball != null)
        {
            Vector3 paddlePos = this.transform.position;
            Vector2 contackPoint = collision.GetContact(0).point;

            float offset = paddlePos.x - contackPoint.x;
            float width = collision.otherCollider.bounds.size.x / 2;

            float currentAngle = Vector2.SignedAngle(Vector2.up, ball.rig.velocity);
            float bounceAngle = offset / width * this.maxAngle;
            float newAngle = Mathf.Clamp(currentAngle + bounceAngle, -this.maxAngle, this.maxAngle);

            Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
            ball.rig.velocity = rotation * Vector2.up * ball.rig.velocity.magnitude;
        }
    }
}
