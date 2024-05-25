using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{

    [field :SerializeField]

    public Vector2 MovementVector {  get; private set; }

    public event Action OnAttack, OnJumpPressed, OnJumpReleased, OnWeaponchange;

    public event Action<Vector2> OnMovement;

    public KeyCode jumpKey, attackKey, menuKey;

    public UnityEvent OnMenuKeyPressed;

    private void Update()
    {
        if(Time.timeScale > 0)
        {
            GetMovementInput();
            GetJumpInput();
            GetAttackInput();
            
            GetWeaponSwapInput();
        }
        
        
        GetMenuInput();

    }

    private void GetWeaponSwapInput()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            OnWeaponchange?.Invoke();
        }
    }

    private void GetMenuInput()
    {
        if(Input.GetKeyDown(menuKey))
            { OnMenuKeyPressed?.Invoke(); }
        
    }


    private void GetAttackInput()
    {
        if( Input.GetKeyDown(attackKey))
            { OnAttack?.Invoke(); }
    }

    private void GetJumpInput()
    {
        if (Input.GetKeyDown(jumpKey))
            { OnJumpPressed?.Invoke(); }
        if (Input.GetKeyDown(jumpKey))

        { OnJumpReleased?.Invoke(); }
       
    }

    private void GetMovementInput()
    {
        MovementVector=GetMovementVector();
        OnMovement?.Invoke(MovementVector);
    }

    protected Vector2 GetMovementVector() => new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
}
  