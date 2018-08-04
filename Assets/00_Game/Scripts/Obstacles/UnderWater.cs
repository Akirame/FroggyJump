using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderWater : MonoBehaviour
{

    public float time;

    private float timer;
    private bool flip;
    private bool underwater;
    private SpriteRenderer rend;
    private BoxCollider2D col;

    private void Start()
    {
        underwater = false;
        timer = 0;
        flip = false;
        rend = GetComponent<SpriteRenderer>();
        col = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        if (timer < time || flip)
        {
            timer += Time.deltaTime;
        }
        else
        {
            if (Random.Range(0,2) == 0 || underwater)
            {
                flip = true;
                ChangeAnimation();
            }
            else
                timer = 0;
        }
    }
    private void ChangeAnimation()
    {
        this.GetComponent<Animator>().SetTrigger("changeAnim");
    }
    private void FlipFlopColliders()
    {
        if (col.enabled)
        {
            col.enabled = false;
            underwater = true;
        }
        else
        {
            col.enabled = true;
            underwater = false;
        }
        timer = 0;
        flip = false;
    }
}
