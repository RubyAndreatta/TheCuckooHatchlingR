using UnityEngine;
using TMPro; 

public class Count : MonoBehaviour
{
    public TMP_Text moneyText;
    public int moneyValue = 0;

    public void MoneyAmount(int amount)
    {
        moneyValue += amount;
        moneyText.text = "" + moneyValue.ToString();
    }
}

