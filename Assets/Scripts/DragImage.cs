using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragImage : MonoBehaviour
{
    [SerializeField] public Camera camera;
    [SerializeField] public Image image;

    public void PotentialDrag()
    {
        image.color = Color.red;
    }

    public void BeginDrag()
    {
        transform.localScale = Vector3.one * 1.3f;
    }

    public void Drag()
    {
        var pos = camera.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0f;
        transform.position = pos;
    }

    public void EndDrag()
    {
        transform.localScale = Vector3.one;
    }

    public void Drop()
    {
        image.color = Color.white;
    }
}
