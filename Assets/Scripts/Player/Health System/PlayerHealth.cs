using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth = 3;
    public int maximumHealth = 3;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    void Update()
    {
        if (playerHealth > maximumHealth)
        {
            playerHealth = maximumHealth;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < playerHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < maximumHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    public void DecreaseHealth(int amount){
        playerHealth -= amount;
        if(playerHealth <=0){
            playerHealth = 0;
            //Die();

        }
    }

    public void AddHealth(int amount){
        playerHealth += amount;
    }
}
