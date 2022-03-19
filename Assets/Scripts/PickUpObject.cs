using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public GameObject winScreen = null;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        this.winScreen.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Inventory.instance.addCoins(1);
            Destroy(gameObject);
        }

        if(Inventory.instance.numberCoins == Inventory.instance.numberCoinsForWin )
        {
            this.winScreen.SetActive(true);
        }
    }
}
