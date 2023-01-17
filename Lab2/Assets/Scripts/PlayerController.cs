using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private LayerMask groundLayers;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float moveThrust = 5f;
    [SerializeField] private float jumpThrust = 5f;
    private Rigidbody rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (OnGround() && Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        var direction = new Vector3(horizontal, 0, vertical);
        var moveVector = transform.TransformDirection(direction) * moveThrust;
        rigidBody.velocity = new Vector3(moveVector.x, rigidBody.velocity.y, moveVector.z);
    }

    private void Jump()
    {
        rigidBody.AddForce(Vector3.up * jumpThrust, ForceMode.VelocityChange);
    }

    private bool OnGround()
    {
        return Physics.CheckSphere(groundCheck.position, 0.05f, groundLayers, QueryTriggerInteraction.Ignore);
    }

}
