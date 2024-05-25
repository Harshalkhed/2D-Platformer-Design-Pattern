using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public Rigidbody2D agentRigidbody;
    public PlayerInput playerInput;
    [SerializeField]
    float speed= 5.0f;
    public AgentAnimation agentManager;
    public AgentRenderer agentRenderer;


    private void Awake()
    {
        playerInput = GetComponentInParent<PlayerInput>();
        agentRigidbody = GetComponent<Rigidbody2D>();
        agentManager = GetComponentInChildren<AgentAnimation>();
        agentRenderer = GetComponentInChildren<AgentRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        playerInput.OnMovement += HandleMovement;
        playerInput.OnMovement += agentRenderer.FaceDirection;

    }

    private void HandleMovement(Vector2 input)
    {
        if (Math.Abs(input.x) > 0)
        {
            if(Mathf.Abs(agentRigidbody.velocity.x)<0.01f)
            {
                agentManager.PlayerAnimation(PlayerAnimationEnum.run);
            }
            agentRigidbody.velocity = new Vector2(input.x * speed, agentRigidbody.velocity.y);

        }
        else
        {
            if (Mathf.Abs(agentRigidbody.velocity.x) > 0)
            {
                agentManager.PlayerAnimation(PlayerAnimationEnum.idle);
            }
            agentRigidbody.velocity = new Vector2(0, agentRigidbody.velocity.y);
        }
    }
}
