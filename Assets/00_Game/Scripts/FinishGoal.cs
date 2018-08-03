using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGoal : MonoBehaviour
{
    public delegate void FinishAction (FinishGoal f);
    public static FinishAction Finished;

    private BoxCollider2D coll;
    private SpriteRenderer rend;
    private void Start()
    {
        coll = GetComponent<BoxCollider2D>();
        rend = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rend.color = Color.black;
            coll.enabled = false;
            Finished(this);
        }
    }
}
