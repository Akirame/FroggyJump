using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetect : MonoBehaviour {

    public BoxCollider2D waterDetector;
    public BoxCollider2D woodDetector;

    private void OnTriggerStay2D(Collider2D collision)
    {        
        if (collision.tag == waterDetector.tag)
            Player.Get().OnWater();
        else if (collision.tag == woodDetector.tag)
            Player.Get().OnWood(collision.gameObject);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == waterDetector.tag)
            Player.Get().OffWater();
        else if (collision.tag == woodDetector.tag)
            Player.Get().OffWood();
    }
}
