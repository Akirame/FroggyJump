using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public enum Direction
    {
        LEFT,
        RIGHT
    }
    public GameObject Enemy;
    public Direction dir;
    public float delayTime;
    private float timer;

	void Start ()
    {
        timer = 0;
	}		
	void Update ()
    {
        if (timer < delayTime)
        {
            timer += Time.deltaTime;
        }
        else
        {
            GameObject e = Instantiate(Enemy, transform.position, Quaternion.identity, this.transform);
            e.GetComponent<Enemy>().SetDirection((int)dir);
            e.GetComponent<Enemy>().OutOfScreen += EnemyDeath;
            timer = 0;
        }
	}
    private void EnemyDeath(Enemy e)
    {
        Destroy(e.gameObject);
    }
}
