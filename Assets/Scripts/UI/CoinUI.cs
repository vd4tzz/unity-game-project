using System.Collections;
using System.Collections.Generic;
using Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinUI : MonoBehaviour
{
    [SerializeField] PlayerController player;
    [SerializeField] TMP_Text coinText;

    void Start()
    {
        coinText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = player.Coin.ToString();
    }
}
