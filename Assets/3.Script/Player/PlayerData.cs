using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    public int Player_HP = 100;
    public int Player_Oxygen = 500;
    //보석 위치 Y = -75.81
    


    public float fristDelay = 1f;
    private float lastDelay = 0f;

    public GameObject player;

    public Slider HPslider;
    public Slider OxygenSlider;
    public Slider deepSlider;


    private void Update()
    {

        decreaseOxygen();
        playerDeep();
    }
    void playerDeep()
    {
        Transform Player_Y = player.transform;
        float playerY = Player_Y.position.y;
        
        deepSlider.value = 76 + playerY;
        Debug.Log("슬라이더 바" + deepSlider.value);



    }
    void decreaseOxygen()
    {
        //플레이어의 Y값
        Transform Player_Y = player.transform;
        float playerY = Player_Y.position.y;
        if (lastDelay >= fristDelay)
        {
            if (Player_Oxygen > 0)
            {
                if (playerY < 0 && playerY > -7)
                {
                    Player_Oxygen -= 2;
                }
                else if (playerY <= -7 && playerY > -21)
                {
                    Player_Oxygen -= 5;
                }
                else if (playerY <= -21)
                {
                    Player_Oxygen -= 10;
                }
                lastDelay = 0f;
            }
            else if(Player_HP >0)
            {
                Player_HP -= 5;
                lastDelay = 0f;
            }

            SetHealth(Player_HP,Player_Oxygen);

            if (playerY >= 0)
            {
                Player_Oxygen = 500;
            }
        }   
        lastDelay += Time.deltaTime;
    }
    public void  SetMaxHealth(int Player_HP)
    {
        HPslider.maxValue = Player_HP;
        HPslider.value = Player_HP;
    }
    public void SetHealth(int Player_HP,int Player_Oxygen)
    {
        HPslider.value = Player_HP;
        OxygenSlider.value = Player_Oxygen;
    }
}
