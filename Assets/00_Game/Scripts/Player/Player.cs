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

    public delegate void PlayerActions(Player p);
    public static PlayerActions OnDeath;

    public BoxCollider2D coll1;    
    public float time;
    public float speed;

    private int lives;
    private float timer;
    private bool moving;
    private Vector2 moveDir;
    private bool stopped;
    private bool onWood;
    private bool onWater;
    private Vector3 startPos;
    private Animator animController;
    private SpriteRenderer rend;
    private bool alive;

    private void Start()
    {        
        lives = 3;
        alive = true;
        timer = 0;
        moving = false;
        stopped = false;
        onWood = false;
        onWater = false;
        startPos = transform.position;
        animController = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (lives <= 0)
            alive = false;
        if (alive)
        {
            if (!onWood)
            {
                coll1.enabled = true;
            }
            else
                coll1.enabled = false;
            transform.position = new Vector3(transform.position.x, transform.position.y, 10);
            MoveController();
            if (!moving && !onWood && onWater)
            {
                DeathAnimation();
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
            animController.SetBool("moving", false);
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                moving = true;
                moveDir = Vector2.up;
                SetAnimParameters(true, false, true);
                rend.flipY = false;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                moving = true;
                moveDir = Vector2.down;
                SetAnimParameters(true, false, true);
                rend.flipY = true;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                moving = true;
                moveDir = Vector2.left;
                SetAnimParameters(false, true, true);
                rend.flipX = false;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                moving = true;
                moveDir = Vector2.right;
                SetAnimParameters(false, true, true);
                rend.flipX = true;
            }
        }
        else
        {
            animController.SetBool("moving", true);
            if (timer < time)
            {
                timer += Time.deltaTime;
                Vector3 dir = moveDir;
                transform.position += dir * speed * Time.deltaTime;
            }
            else
            {                
                transform.position = new Vector3(transform.position.x, Mathf.RoundToInt(transform.position.y), transform.position.z);
                timer = 0;
                moving = false;                
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            this.GetComponent<Animator>().SetTrigger("death");
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
        if (!moving && !onWood)
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
    public void ResetPosition()
    {
        transform.position = startPos;
    }
    public bool Moving()
    {
        if (moving)
            return true;
        else
            return false;
    }
    private void SetAnimParameters(bool vertical, bool horizontal, bool moving)
    {
        animController.SetBool("vertical", vertical);
        animController.SetBool("horizontal", horizontal);
        animController.SetBool("moving", moving);
    }
    private void DeathAnimation()
    {
        this.GetComponent<Animator>().SetTrigger("death");
        alive = false;
    }
    private void Death()
    {        
        SetAnimParameters(false, false, false);
        this.GetComponent<Animator>().SetTrigger("alive");
        OnDeath(this);
        lives--;
        alive = true;
    }
}
