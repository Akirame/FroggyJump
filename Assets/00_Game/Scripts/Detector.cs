using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Detector : MonoBehaviour
{

    public enum TypeOf
    {
        WATER,
        WOOD,
    }
    public TypeOf type;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (type)
        {
            case TypeOf.WOOD:
                Player.Get().OnWood(collision.gameObject);
                break;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        switch (type)
        {
            case TypeOf.WATER:
                Player.Get().OnWater();
                break;
            case TypeOf.WOOD:
                Player.Get().OnWood(collision.gameObject);
                break;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (type)
        {
            case TypeOf.WATER:
                Player.Get().OffWater();
                break;
            case TypeOf.WOOD:
                Player.Get().OffWood();
                break;
        }
    }
}
