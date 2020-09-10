using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : KeyCollector
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(HaveRightKey());
        if (HaveRightKey() && collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    
}
