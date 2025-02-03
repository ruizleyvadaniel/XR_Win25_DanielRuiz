using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class JumpLocomotion : MonoBehaviour
{
    [SerializeField] InputActionReference jumpInput;


    private void Awake()
    {
        //gt componet 
    }
    private void OnEnable()
    {
        jumpInput.action.performed +=Jump;
    }

    private void Jump(InputAction.CallbackContext context)
    {
        Debug.Log("Jump is performed");
    }
}
