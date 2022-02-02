using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ShopLogic : MonoBehaviour
{
    [SerializeField] private Text speedItem;
    [SerializeField] private Text healthItem;
    [SerializeField] private Text armorItem;
    [SerializeField] private Text costItem;
    [SerializeField] private GameObject cell;
    [SerializeField] private Camera camera;
    [SerializeField] private GameObject[] cells;
    [SerializeField] private GameObject buyer;
    [SerializeField] private GameObject seller;
    
    private Vector3 offset;
    private CellInfo info;
    private Color cellColor;
    private Vector3 oldPos;
    private float radius = 1f;
    
    private string speedText = " speed";
    private string healthText = " health";
    private string armorText = " armor";
    private string costText = " cost";

    private void Awake()
    {
        info = GetComponent<CellInfo>();
        cellColor = cell.GetComponent<Image>().color;
    }

    private void OnMouseDown()
    {
        if (info.isExist)
        {
            speedItem.text = info.speed + speedText;
            healthItem.text = info.health + healthText;
            armorItem.text = info.armor + armorText;
            costItem.text = info.cost + costText;

            oldPos = transform.position;

            var pos = camera.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0f;
            offset = transform.position - pos;
        
            transform.DOScale(Vector3.one * 1.5f, 0.3f);
        }
        else
        {
            speedItem.text = string.Empty;
            healthItem.text = string.Empty;
            armorItem.text = string.Empty;
            costItem.text = string.Empty;
        }
    }
    
    private void OnMouseDrag()
    {
        if (info.isExist)
        {
            var pos = camera.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0f;
            pos += offset;

            transform.position = pos;
        }
    }

    private void OnMouseUp()
    {
        var buyerInfo = buyer.GetComponent<SellerInfo>();

        if (buyerInfo.money < info.cost)
        {
            transform.position = oldPos;

            return;
        }
        
        for (var i = 0; i < cells.Length; i++)
        {
            if (transform.position == cells[i].transform.position)
            {
                continue;
            }
            
            var d = (transform.position - cells[i].transform.position).sqrMagnitude;
                
            if (d < radius && !cells[i].GetComponent<CellInfo>().isExist)
            {
                var cellInfo = cells[i].GetComponent<CellInfo>();
                cellInfo.isExist = true;
                cellInfo.armor = info.armor;
                cellInfo.speed = info.speed;
                cellInfo.health = info.health;
                cellInfo.cost = info.cost;
                
                Debug.Log(cells[i].gameObject.name);
                Debug.Log(cell.gameObject.name);

                var img = cell.GetComponent<Image>();
                var cellImg = cells[i].GetComponent<Image>();
                    
                cellImg.sprite = img.sprite;
                cellImg.color = Color.white;
                
                img.sprite = null;
                img.color = Color.gray;
                
                cell.transform.position = oldPos;
                info.isExist = false;

                buyerInfo.money -= info.cost;
                seller.GetComponent<SellerInfo>().money += info.cost;

                return;
            }
        }

        if (info.isExist)
        {
            transform.position = oldPos;
        }
    }

    private void OnMouseEnter()
    {
        transform.DOScale(Vector3.one * 1.2f, 0.3f);
    }
    
    private void OnMouseExit()
    {
        transform.DOScale(Vector3.one, 0.3f);
    }
}
