using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public enum Direction
    {
        LEFT,
        RIGHT
    }
    public GameObject toSpawn;
    public Direction dir;
    public int quantity;
    public float delayTime1;
    public float delayTime2;
    private float timer1;
    private float timer2;
    private int conta;

    void Start()
    {
        transform.position = new Vector3(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y), transform.position.z);
        timer1 = delayTime1;
        timer2 = delayTime2;
        conta = 1;
    }
    void Update()
    {
        if (timer1 < delayTime1)
        {
            timer1 += Time.deltaTime;
        }
        else
        {
            if (timer2 < delayTime2)
            {
                timer2 += Time.deltaTime;
            }
            else
            {
                GameObject e = Instantiate(toSpawn, transform.position, Quaternion.identity, this.transform);
                e.GetComponent<MovingEntity>().SetDirection((int)dir);
                e.GetComponent<MovingEntity>().OutOfScreen += OutOfScreenDestroy;
                timer2 = 0;
                if (conta < quantity)
                    conta++;
                else
                {
                    timer1 = 0;
                    conta = 1;
                }
            }
        }
    }
    private void OutOfScreenDestroy(MovingEntity e)
    {
        Destroy(e.gameObject);
    }
}
