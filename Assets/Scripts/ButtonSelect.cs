using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ButtonSelect : MonoBehaviour
{
    [SerializeField] public Transform rotationImg;
    private Sequence sequence;
    
    public void Select()
    {
        transform.localScale = Vector3.one * 1.3f;
    }

    public void Deselect()
    {
        transform.localScale = Vector3.one;
    }

    public void UpdateSelect()
    {
        rotationImg.Rotate(Time.deltaTime * 90f * Vector3.forward);
    }

    public void Move()
    {
        sequence?.Kill();
        sequence = DOTween.Sequence();
        sequence.Append(transform.DOScale(Vector3.one * 0.8f, 0.3f));
        sequence.Append(transform.DOScale(Vector3.one, 0.3f));
    }

    public void Submit()
    {
        print("Submit");
    }

    public void Cancel()
    {
        print("Cancel");
    }
}
