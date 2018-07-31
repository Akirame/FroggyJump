using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region singleton
    static private Player instance;
    static public Player Get()
    {
        return instance;
    }
    private void Awake()
    {
        if (!instance)
            instance = this;
        else
            Destroy(this);
    }
    #endregion

    public float time;
    public float speed;

    private float timer;
    private bool moving;
    private Vector2 moveDir;
    private bool stopped;

    private void Start()
    {        
        timer = 0;
        moving = false;
        stopped = false;
    }
    void Update ()
    {
        MoveController();        
	}

    private void MoveController()
    {
        if (!moving)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                moving = true;
                moveDir = Vector2.up;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                moving = true;
                moveDir = Vector2.down;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                moving = true;
                moveDir = Vector2.left;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                moving = true;
                moveDir = Vector2.right;
            }
        }
        else
        {
            if (timer < time)
            {
                timer += Time.deltaTime;
                Vector3 dir = moveDir;
                transform.position += dir * speed * Time.deltaTime;
            }
            else
            {
                timer = 0;
                moving = false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        Destroy(this.gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
            stopped = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
            stopped = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wood" && !(collision.gameObject.tag == "Water") && !moving && !stopped)
        {
            transform.parent = collision.transform;
        }
        else
            transform.parent = null;
    }
}
