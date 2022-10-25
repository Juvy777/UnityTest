using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class BuyItem : MonoBehaviour
{

    [SerializeField]
    TMP_Text txtName, txtMoney,txtCost, amountText;

    [SerializeField]
    Image image;

    [SerializeField]
    Slider amountSlide;

    [SerializeField]
    PlayerResources manager;
    // Start is called before the first frame update


    private void Update()
    {
        amountText.text = amountSlide.value.ToString();
    }

    public void GetNewItem(Item item, int cost)
    {

        txtName.text = item.name;
        txtMoney.text = "Your  money: " + cost.ToString();
        image.sprite = item.ArtIcon;
        txtCost.text = "Price: " + item.Cost.ToString();

    }

    public void TransactionStart()
    {
        manager.SwipeState(true);
        manager.BuyItem((int)amountSlide.value);
    }



    public void EndBuy()
    {
        
        gameObject.SetActive(false);
    }
}
