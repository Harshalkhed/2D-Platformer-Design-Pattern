using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public Rigidbody2D agentRigidbody;
    public PlayerInput playerInput;
    [SerializeField]
    float speed=5.0f;


    private void Awake()
    {
        playerInput = GetComponentInParent<PlayerInput>();
        agentRigidbody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        playerInput.OnMovement += HandleMovement;


    }

    private void HandleMovement(Vector2 input)
    {
        if (Math.Abs(input.x) > 0)
        {
            agentRigidbody.velocity = new Vector2(input.x * speed, agentRigidbody.velocity.y);
        }
        else
        {
            agentRigidbody.velocity = new Vector2(0, agentRigidbody.velocity.y);
        }
    }
}
