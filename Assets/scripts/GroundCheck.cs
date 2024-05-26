using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public PM pm;
    private void OnTriggerEnter(Collider other)
    {
        pm.onGround = true;
    }
}
