using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DiceHandler : MonoBehaviour
{
    public GameObject Dice;
    private Image dice_image;
    public Sprite dice_one;
    public Sprite dice_two;
    public Sprite dice_three;
    public Sprite dice_four;
    public Sprite dice_five;
    public Sprite dice_six;
    private int roll_res;

    // Start is called before the first frame update
    void Start()
    {
        dice_image = Dice.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RollDice()
    {
        roll_res = Random.Range(1, 6);
        switch (roll_res)
        {
            case 1:
                dice_image.sprite = dice_one;
                break;
            case 2:
                dice_image.sprite = dice_two;
                break;
            case 3:
                dice_image.sprite = dice_three;
                break;
            case 4:
                dice_image.sprite = dice_four;
                break;
            case 5:
                dice_image.sprite = dice_five;
                break;
            case 6:
                dice_image.sprite = dice_six;
                break;
            default:
                dice_image.sprite = dice_one;
                break;
        }       
    }
}
