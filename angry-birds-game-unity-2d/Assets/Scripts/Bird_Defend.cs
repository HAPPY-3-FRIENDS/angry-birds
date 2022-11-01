using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird_Defend : MonoBehaviour
{
    public Sprite halfDefendSprite;

    public float defend;
    public float realDefend;
    float halfDefend;
    SpriteRenderer spriteRenderer;

    public Ani1 animationSource;
    Ani1 animation;

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        realDefend = defend;
        halfDefend = defend / 2;
        animation = Instantiate(animationSource, transform.position, Quaternion.identity);
    }

    void Update()
    {
        if (defend < halfDefend)
        {
            spriteRenderer.sprite = halfDefendSprite;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "BirdProtector")
        {
            if (collision.relativeVelocity.magnitude >= defend)
            {
                Destroy(gameObject, 0.1f);
                animation = Instantiate(animationSource, transform.position, Quaternion.identity);
            }
            else
            {
                defend -= collision.relativeVelocity.magnitude;
            }
        }
    }
}
