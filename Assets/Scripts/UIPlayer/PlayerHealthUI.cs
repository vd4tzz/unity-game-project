using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField] private Sprite    fullHeart;
    [SerializeField] private Sprite    emptyHeart;
    [SerializeField] private Image     heartPrefab;
    [SerializeField] private Transform heartFrame;
    
    private List<Image> hearts;

    [SerializeField] private PlayerController player;
    private float maxHealth;
    private float currentHealth;
    


    void Start()
    {
        maxHealth     = player.Health;
        currentHealth = maxHealth;

        hearts = new List<Image>();
        for(int i = 0; i < maxHealth; i++)
        {
            // Instantiate heart as Image in prefab to parent heartFrame
            Image heart = Instantiate(heartPrefab, heartFrame);

            // Add to list
            hearts.Add(heart);
        }
    }

    
    void Update()
    {
        // Get current health from player
        currentHealth = player.Health;

        // If current index is less than currentHealth, then the heart is full
        // If current index is equal or greater than currentHealth, then the heart is empty
        for(int i = 0; i < hearts.Count; i++)
        {
            if(i < currentHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
    }
}
