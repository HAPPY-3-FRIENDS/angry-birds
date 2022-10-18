using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    Vector3 InitialPos;
    public float defend = 20;

    private void Start()
    {
        InitialPos = transform.position;
    }

    private void OnMouseDrag()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePos.x, mousePos.y);
    }

    private void OnMouseUp()
    {
        Vector3 vectorForce = InitialPos - transform.position;
        GetComponent<Rigidbody2D>().AddForce(vectorForce * 350);
        GetComponent<Rigidbody2D>().gravityScale = 1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > defend)
        {
            Destroy(gameObject, 0.7f);
        }
        else
        {
            defend -= collision.relativeVelocity.magnitude;
        }
    }
}
