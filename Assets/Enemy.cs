using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public delegate void Death(Enemy e);
    public Death OutOfScreen;

    public float speed;

    private Vector3 dir;
    private bool toRight;

    private void Start()
    {
        toRight = false;
        dir = Vector3.zero;
    }
    void Update ()
    {
        transform.position += dir * Time.deltaTime * speed;        
	}

    private void CheckOOB()
    {
        Vector3 OOBPos = CameraController.Get().GetViewport().ViewportToWorldPoint(transform.position);
        if (toRight)
        {
            if (OOBPos.x > 1)
                OutOfScreen(this);
        }
        else
        {
            if (OOBPos.x < 0)
                OutOfScreen(this);
        }
    }

    public void SetDirection(int direction)
    {
        switch (direction)
        {
            case -1:
                toRight = false;
                GetComponent<SpriteRenderer>().flipX = true;
                dir = Vector2.left;
                break;
            case 1:
                toRight = true;
                GetComponent<SpriteRenderer>().flipX = false;
                dir = Vector2.right;
                break;
        }
    }
}
