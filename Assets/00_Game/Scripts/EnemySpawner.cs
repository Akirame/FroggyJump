using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public enum Direction
    {
        LEFT,
        RIGHT
    }
    public GameObject Enemy;
    public Direction dir;
    public int quantity;
    public float delayTime1;
    public float delayTime2;
    private float timer1;
    private float timer2;
    private int conta;

    void Start()
    {
        timer1 = 0;
        timer2 = 0;
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
                GameObject e = Instantiate(Enemy, transform.position, Quaternion.identity, this.transform);
                e.GetComponent<Enemy>().SetDirection((int)dir);
                e.GetComponent<Enemy>().OutOfScreen += EnemyDeath;
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
    private void EnemyDeath(Enemy e)
    {
        Destroy(e.gameObject);
    }
}
