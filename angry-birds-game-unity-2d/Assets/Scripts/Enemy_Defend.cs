using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Defend : MonoBehaviour
{
    public Sprite halfDefendSprite;
    public AudioSource audio;

    public float defend;
    float halfDefend;
    SpriteRenderer spriteRenderer;

    public Ani1 animationSource;
    Ani1 animation;

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
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
        if (collision.relativeVelocity.magnitude >= defend)
        {
            Destroy(gameObject, 0.1f);
            audio.Play();
            animation = Instantiate(animationSource, transform.position, Quaternion.identity);
        }
        else
        {
            defend -= collision.relativeVelocity.magnitude;
        }

        if (collision.gameObject.tag == "LimitWall")
        {
            Destroy(gameObject, 0.1f);
            audio.Play();
            Instantiate(animationSource, transform.position, Quaternion.identity);
        }
    }
}
