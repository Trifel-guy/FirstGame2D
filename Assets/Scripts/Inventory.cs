using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int numberCoins;
    public Text numberCoinsText;
    public static Inventory instance;
    

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Il y'a plus d'un inventaire");
            return;
        }
        instance = this;
    }

    public void addCoins(int num)
    {
        numberCoins += num;
        numberCoinsText.text = numberCoins.ToString();
    }
}
