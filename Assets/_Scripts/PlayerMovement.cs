using UnityEngine;

public class PlayerMovement : MonoBehaviour{
    private Rigidbody2D body;
    private Vector2 gravity = new Vector2(-9.81f, -9.81f);
    private Vector2 direction;
    private bool canJump = true;

    private int groundLayer = 6;

    private void Start() {
        body = GetComponent<Rigidbody2D>();

        direction = Vector2.left;
        // Physics2D.gravity = gravity * direction;
    }

    private void Update() {
        if(Input.GetButtonDown("Jump") && canJump){
            canJump = false;
            direction = (direction == Vector2.left) ? Vector2.right : (direction == Vector2.right) ? Vector2.left : Vector2.right;
            // Physics2D.gravity = gravity * direction;
        }
    }

    private void FixedUpdate() {
        body.AddForce(gravity * (direction * body.mass), ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.layer == 6){
            canJump = true;
        }
    }
}