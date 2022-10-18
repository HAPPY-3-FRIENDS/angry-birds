using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : MonoBehaviour
{
    public float defend = 15;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > defend)
        {
            Destroy(gameObject, 0.1f);
        } else
        {
            defend -= collision.relativeVelocity.magnitude;
        }
    }
}
