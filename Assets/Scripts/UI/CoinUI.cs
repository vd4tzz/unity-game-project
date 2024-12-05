using Player;
using TMPro;
using UnityEngine;


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
