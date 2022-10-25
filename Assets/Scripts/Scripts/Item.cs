using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    [SerializeField]
    new string name;

    [SerializeField]
    Sprite artIcon;

    [SerializeField]
    int cost, currency;

    public int Currency { get => currency; set => currency = value; }
    public Sprite ArtIcon { get => artIcon; set => artIcon = value; }
    public int Cost { get => cost; set => cost = value; }
}
