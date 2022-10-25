using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerResources : MonoBehaviour
{
    [SerializeField]
    Item[] myItems;

    [SerializeField]
    TMP_Text[] itemsUI;

    [SerializeField]
    DiscoverItem newItem;

    [SerializeField]
    BuyItem newSell;

    [SerializeField]
    GameObject particles;

    int currentItem;
    enum Materials
    {
        Gold,
        Wood,
        Coal,
        Iron,
        Diamond
    }
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < myItems.Length; ++i)
        {
            itemsUI[i].text = myItems[i].Currency.ToString(); 
        }
    }

    public void DiscoverItem(int item)
    {
        SwipeState(false);
        particles.GetComponent<ParticleSystem>().Play();
        int randItems = Random.Range(0, 20);
        newItem.GetNewItem(myItems[item], randItems);
        newItem.gameObject.SetActive(true);
        myItems[item].Currency += randItems;
        itemsUI[item].text = myItems[item].Currency.ToString();
    }

    public void ActiveBuying(int item)
    {
        SwipeState(false);
        currentItem = item;
        newSell.gameObject.SetActive(true);
        newSell.GetNewItem(myItems[item], myItems[0].Currency);

    }

    public void BuyItem(int amount)
    {
        int realCost = myItems[currentItem].Cost * amount;
        if (myItems[0].Currency > realCost)
        {

            myItems[0].Currency -= realCost;
            myItems[currentItem].Currency += amount;
            itemsUI[0].text = myItems[0].Currency.ToString();
            itemsUI[currentItem].text = myItems[currentItem].Currency.ToString();

            newSell.gameObject.SetActive(false);
            particles.GetComponent<ParticleSystem>().Play();
        }
    }

    public void SwipeState(bool active)
    {
        GetComponent<SwipeScript>().CanSwipe = active;
    }
}
