using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    float speed;
    public Ani1 animationSource;
    public bool isFly;
    bool callAnimation;

    void Start()
    {
        isFly = false;
        Instantiate(animationSource, transform.position, Quaternion.identity);
        callAnimation = false;
    }

    void Update()
    {
        speed = GetComponent<Rigidbody2D>().velocity.magnitude;
        if ((speed < 1.2) && (isFly == true))
        {
/*            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);*/
            Destroy(gameObject, 2);
            if (callAnimation == false)
            {
                Invoke("DoAnimation", 1.7f);
                callAnimation=true;
            }
        }
    }

    void DoAnimation()
    {
        Instantiate(animationSource, transform.position, Quaternion.identity);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "LimitWall")
        {
            Destroy(gameObject, 2f);
            Invoke("DoAnimation", 1.7f);
        }
    }
}