using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
public class BuyItemShop : MonoBehaviour
{
    
    [SerializeField]
    private List<Item> shopItems;

    [SerializeField]
    private GameObject pfPurchaseButton;

    private List<GameObject> buttonObjs;

    private Inventory inventory;
    
    // Start is called before the first frame update
    void Start()
    {
        inventory = GameAssets.i.gameState.inventory;
        buttonObjs = new List<GameObject>();
        foreach(Item item in shopItems){
            CreateShopButton(item);
        }
    }

    private void CreateShopButton(Item item)
    {
        buttonObjs.Add(Instantiate(pfPurchaseButton, transform));
        buttonObjs[buttonObjs.Count - 1].GetComponent<ShopButton>().SetItem(item);
        
        buttonObjs[buttonObjs.Count - 1].GetComponent<Button_UI>().ClickFunc = () => {
            BuyItem(item);
        };
    }

    public void BuyItem(Item item)
    {
        if(inventory.gold >= item.price){
            inventory.gold -= item.price;
            inventory.AddItem(item, 1);
        }else{
            ErrorMessage.Create(Vector3.zero, "Insufficiant Gold");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
