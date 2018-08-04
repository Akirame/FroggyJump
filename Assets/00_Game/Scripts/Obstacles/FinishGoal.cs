using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGoal : MonoBehaviour
{
    public delegate void FinishAction (FinishGoal f);
    public static FinishAction Finished;

    private Color spriteColor;
    private BoxCollider2D boxColl;
    private SpriteRenderer rend;

    private void Start()
    {
        boxColl = GetComponent<BoxCollider2D>();
        rend = GetComponent<SpriteRenderer>();
        spriteColor = rend.color;
        spriteColor.a = 0f;
        rend.color = spriteColor;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            spriteColor.a = 1f;
            rend.color = spriteColor;
            boxColl.enabled = false;
            Finished(this);
        }
    }
}
