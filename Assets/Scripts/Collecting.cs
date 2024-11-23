using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Collecting : MonoBehaviour
{
    int Coins = 0;

    [SerializeField] TextMeshProUGUI CoinsText;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            Coins++;

            CoinsText.text = " : " + Coins;
        }
    }

}
