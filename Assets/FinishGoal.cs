using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGoal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Win");
            Player.Get().ResetPosition();
            CameraController.Get().ResetPosition();
        }
    }
}
