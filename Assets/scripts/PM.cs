using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PM : MonoBehaviour
{
    public float speed = 100;
    private Vector2 direction,pointer;
    public Rigidbody rb;
    private Vector3 camrot;
    public float jumpP;
    public bool onGround = true,running=false;
    public float runMult=2;
    void Start()
    {
        camrot=Camera.main.transform.localEulerAngles;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Vector3 dir = speed * (transform.right * direction.x + transform.forward*direction.y).normalized;
        if (running)
        {
            dir *= runMult;
        }
        dir.y = rb.velocity.y;
        rb.velocity = dir;
        if (!Cursor.visible)
        {
            transform.eulerAngles += new Vector3(0, pointer.x, 0);
            camrot.x -= pointer.y;
            camrot.x = Mathf.Clamp(camrot.x, -90, 90);
            Camera.main.transform.localRotation = Quaternion.Euler(camrot);
        }
    }
    public void Move(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();
    }

    public void Look(InputAction.CallbackContext context)
    {
        pointer = context.ReadValue<Vector2>();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        if (!onGround) return;
        rb.AddForce(Vector3.up * jumpP, ForceMode.Impulse);
        onGround = false;  
    }

    public void Run(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            running = true;
        }
        else if (context.canceled)
        {
            running = false;
        }
        
    }
}
