using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetect : MonoBehaviour {

    public BoxCollider2D waterDetector;
    public BoxCollider2D woodDetector;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == woodDetector.tag)
        {
            waterDetector.enabled = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!Player.Get().Moving())
        {
            if (collision == woodDetector)
                Player.Get().OnWood(collision.gameObject);
            else if (collision == waterDetector)
                Player.Get().OnWater();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == woodDetector)
        {            
            waterDetector.enabled = true;
            Player.Get().OffWood();
        }
        else if (collision == waterDetector)
        {
            Player.Get().OffWater();
        }
    }
}
