using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DiscoverItem : MonoBehaviour
{
    [SerializeField]
    TMP_Text txtName, quantity;

    [SerializeField]
    Image image;

    [SerializeField]
    PlayerResources manager;
    public void GetNewItem(Item item, int quant)
    {
        txtName.text = item.name;
        quantity.text = quant.ToString();
        image.sprite = item.ArtIcon;

    }

    public void EndDiscover()
    {
        manager.SwipeState(true);
        gameObject.SetActive(false);
    }
}
