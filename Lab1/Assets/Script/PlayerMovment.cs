using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public float speed = 5f;
    public float jumpSpeed = 8f;
    private float direction = 0f;
    private Rigidbody2D player;
    private bool isGrounded = true;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Ground")
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 0.1f, this.transform.position.z);

        if (collision.gameObject.tag == "Ground")
            isGrounded = true;

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            isGrounded = false;

    }

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.x > -1.94 && this.transform.position.x < 19.16)
            Camera.main.transform.position = new Vector3(this.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z);

        if (this.transform.position.y > 0)
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, this.transform.position.y, Camera.main.transform.position.z);

        direction = Input.GetAxis("Horizontal");

        if (direction > 0f)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            player.velocity = new Vector2(direction * speed, player.velocity.y);
        }
        else if (direction < 0f)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            player.velocity = new Vector2(direction * speed, player.velocity.y);
        }
        else
        {
            player.velocity = new Vector2(0, player.velocity.y);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);
        }
    }
}
