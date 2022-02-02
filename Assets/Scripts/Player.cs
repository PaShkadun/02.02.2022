using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var playerInput = GetComponent<PlayerInput>();
        playerInput.onActionTriggered += OnInputAction;
    }

    private void OnInputAction(InputAction.CallbackContext context)
    {
        if (!context.performed)
        {
            return;
        }

        switch (context.action.name)
        {
            case "FireAction":
                OnFireButton();
                break;
            
            case "SkillAction":
                OnSkillAction();
                break;
            
            case "Horizontal":
                OnHorizontalAxis(context.action.ReadValue<float>());
                break;
        }
    }

    private void OnHorizontalAxis(float value)
    {
        Debug.Log(value);
    }

    private void OnSkillAction()
    {
        Debug.Log("Skill");
    }

    private void OnFireButton()
    {
        Debug.Log("Fire");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
