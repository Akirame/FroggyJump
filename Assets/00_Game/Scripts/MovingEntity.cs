using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEntity : MonoBehaviour {
    public delegate void EnemyDeath(MovingEntity e);
    public EnemyDeath OutOfScreen;

    public float speed;

    private Vector3 dir;
    private bool toRight;
    private Camera cam;

    private void Start()
    {
        cam = CameraController.Get().GetViewport();
    }
    void Update ()
    {
        transform.position += dir * Time.deltaTime * speed;
        CheckOOB();
	}

    private void CheckOOB()
    {        
        Vector3 OOBPos = cam.WorldToViewportPoint(transform.position);
        if (toRight)
        {
            if (OOBPos.x > 1.05f)
            {                
                OutOfScreen(this);
            }
        }
        else
        {
            if (OOBPos.x < -0.05f)
            {
                OutOfScreen(this);
            }
        }
    }

    public void SetDirection(int direction)
    {        
        switch (direction)
        {
            case 0:
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
