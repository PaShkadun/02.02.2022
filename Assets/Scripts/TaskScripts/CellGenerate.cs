using UnityEngine;
using UnityEngine.UI;

public class CellGenerate : MonoBehaviour
{
    [SerializeField] private Sprite[] images;
    [SerializeField] private GameObject[] cells;
    private CellInfo cellInfo;

    private void Awake()
    {
        for (var i = 0; i < cells.Length; i++)
        {
            if (Random.Range(0, 4) == 2)
            {
                cellInfo = cells[i].GetComponent<CellInfo>();

                cellInfo.cost = Random.Range(1, 25);
                cellInfo.health = Random.Range(-10, 25);
                cellInfo.armor = Random.Range(-10, 25);
                cellInfo.speed = Random.Range(-10, 25);
                cellInfo.isExist = true;

                cells[i].GetComponent<Image>().sprite = images[Random.Range(0, images.Length)];
            }
            else
            {
                cells[i].GetComponent<Image>().color = Color.gray;
            }
        }
    }
}