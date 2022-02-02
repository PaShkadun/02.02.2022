using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIRayCaster : MonoBehaviour
{
    [SerializeField] private GraphicRaycaster rayCaster;
    [SerializeField] private EventSystem eventSystem;

    private PointerEventData eventData;
    
    #if UNITY_EDITOR
    private void Reset()
    {
        rayCaster = GetComponent<GraphicRaycaster>();
        eventSystem = FindObjectOfType<EventSystem>();

        if (!rayCaster || !eventSystem)
        {
            EditorUtility.DisplayDialog("UI Raycaster", "Please, add UI!", "Ok");
            DestroyImmediate(this);
        }
    }
    #endif

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Mouse0))
        {
            return;
        }

        eventData = new PointerEventData(eventSystem)
        {
            position = Input.mousePosition
        };
        var result = new List<RaycastResult>();
        
        rayCaster.Raycast(eventData, result);

        foreach (var res in result)
        {
            Debug.Log($"Result {res.gameObject.name}");
        }
    }
}
