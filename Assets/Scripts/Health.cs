using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Health : MonoBehaviour
{

    public int HealthValue;
    public int MaxHearts;

    public Image[] Hearts;
    public Sprite EmptyHeart;
    public Sprite FullHeart;


    public int AmmoValue;
    public int MaxAmmo;

    public Image[] Ammo;
    public Sprite EmptyAmmo;
    public Sprite FullAmmo;

    private void Start()
    {
        HealthValue=PlayerPrefs.GetInt("health", MaxHearts);
        AmmoValue=PlayerPrefs.GetInt("ammo", MaxAmmo);
    }

    void Update()
    {

        for (int i = 0; i < Hearts.Length; i++)
        {

            if (i < HealthValue)
            {
                Hearts[i].sprite = FullHeart;
            }
            else
            {
                Hearts[i].sprite = EmptyHeart;
            }
            if (i < MaxHearts)
            {
                Hearts[i].enabled = true;
            }
            else
            {
                Hearts[i].enabled = false;
            }

            if (HealthValue > MaxHearts)
            {
                HealthValue = MaxHearts;
            } 
           



            for (int r = 0; r < Ammo.Length; r++)
            {

                if (r < AmmoValue)
                {
                    Ammo[r].sprite = FullAmmo;
                }
                else
                {
                    Ammo[r].sprite = EmptyAmmo;
                }
                if (r < MaxAmmo)
                {
                    Ammo[r].enabled = true;
                }
                else
                {
                    Ammo[r].enabled = false;
                }
                if (AmmoValue > MaxAmmo)
                {
                    AmmoValue = MaxAmmo;
                }

            }
            


        }

    }
}
