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
    private bool onWood;
    private bool onWater;

    private void Start()
    {
        timer = 0;
        moving = false;
        stopped = false;
        onWood = false;
        onWater = false;
    }
    void Update()
    {
        MoveController();
        if (!moving)
        {
            if (!onWood)
                transform.position = new Vector3(transform.position.x, Mathf.RoundToInt(transform.position.y), transform.position.z);
            else if (onWater)
            {                
                onWater = false;
            }
            else if (onWood && stopped)
            {                
                transform.parent = null;
                onWood = false;
            }
        }
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
        if (collision.gameObject.tag == "Enemy")
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
    public void OnWater()
    {        
        if (!moving)
            onWater = true;
    }
    public void OffWater()
    {
        onWater = false;
    }
    public void OnWood(GameObject gObj)
    {        
        if (!moving)
        {
            onWood = true;
            transform.parent = gObj.transform;
        }
    }
    public void OffWood()
    {
        onWood = false;
        transform.parent = null;
    }
}
