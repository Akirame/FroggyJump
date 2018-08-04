using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderWater : MonoBehaviour
{

    public float time;

    private float timer;
    private bool flip;
    private SpriteRenderer rend;
    private BoxCollider2D col;

    private void Start()
    {
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
            flip = true;
            ChangeAnimation();
        }
    }
    private void ChangeAnimation()
    {
        this.GetComponent<Animator>().SetTrigger("changeAnim");
    }
    private void FlipFlopColliders()
    {
        if (col.enabled)
            col.enabled = false;
        else
            col.enabled = true;
        timer = 0;
        flip = false;
    }
}
