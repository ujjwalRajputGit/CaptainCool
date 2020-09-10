using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollector : MonoBehaviour
{
    static bool haveRightKey;

    private void Start()
    {
        haveRightKey = false;
    }
    public static bool HaveRightKey ()
    {
        return haveRightKey;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            haveRightKey = true;
            //Debug.Log("have right key " + haveRightKey);
        }
    }
    
}
