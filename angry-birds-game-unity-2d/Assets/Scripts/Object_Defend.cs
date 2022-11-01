using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Defend : MonoBehaviour
{
    public AudioSource sound;
    public Sprite halfDefendSprite;

    public float defend;
    float halfDefend;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        halfDefend = defend / 2;
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
        sound.Play();
        if (collision.relativeVelocity.magnitude >= defend)
        {
            Destroy(gameObject, 0.1f);
        }
        else
        {
            defend -= collision.relativeVelocity.magnitude;
        }
    }
}
