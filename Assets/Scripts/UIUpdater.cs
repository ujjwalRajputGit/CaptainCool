using TMPro;
using UnityEngine;

public class UIUpdater : MonoBehaviour
{
    public TextMeshProUGUI coinsText;
    private int noOfCoins;

    private void Update()
    {
        noOfCoins = CoinCollector.getNoOfCoins();
        coinsText.text = ""+noOfCoins;
    }

}
