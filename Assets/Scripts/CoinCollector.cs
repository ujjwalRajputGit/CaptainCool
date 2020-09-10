using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    private static int noOfCoins;

    private void Start()
    {
        noOfCoins = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            noOfCoins++;
            //Debug.Log("coins ==" + noOfCoins);
        }
    }

    public static int getNoOfCoins()
    {
        return noOfCoins;
    }
}
