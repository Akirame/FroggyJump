using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    #region singleton
    private static CameraController instance;
    public static CameraController Get()
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


    public Transform firstWall;
    public Transform secondWall;
    private Transform playerToFollow;
    private float min;
    private float max;
    public float num;

    void Start()
    {
        playerToFollow = Player.Get().gameObject.transform;
        min = firstWall.position.y + num;
        max = secondWall.position.y - num;
    }

    void Update()
    {
        if (playerToFollow.transform.position.y > min && playerToFollow.transform.position.y < max)
        {
            Vector3 newPos = new Vector3(0, playerToFollow.transform.position.y, -10);
            transform.position = newPos;
        }
    }
    public Camera GetViewport()
    {
        return GetComponent<Camera>();
    }
}
