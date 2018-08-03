using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderWater : MonoBehaviour {

    public float time;

    private float timer;
    private bool underWater;
    private SpriteRenderer rend;
    private BoxCollider2D col;

    private void Start()
    {
        timer = 0;
        underWater = false;
        rend = GetComponent<SpriteRenderer>();
        col = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        if (timer < time)
        {
            timer += Time.deltaTime;
        }
        else
        {
            if (!underWater)
            {
                rend.enabled = false;
                col.enabled = false;
                underWater = true;
            }
            else
            {
                rend.enabled = true;
                col.enabled = true;
                underWater = false;
            }
            timer = 0;
        }
    }
}
