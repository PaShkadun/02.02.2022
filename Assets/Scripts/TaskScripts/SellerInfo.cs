using System;
using UnityEngine;
using UnityEngine.UI;

public class SellerInfo : MonoBehaviour
{
    [SerializeField] public int money;
    [SerializeField] public Text text;

    private void Update()
    {
        text.text = $"{money}";
    }
}