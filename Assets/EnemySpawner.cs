using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public enum Direction
    {
        LEFT,
        RIGHT
    }
    public List<GameObject> enemyList;
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

        }
	}
}
