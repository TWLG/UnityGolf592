using UnityEngine;
using UnityEngine.InputSystem;

public class UIVisibilityToggler : MonoBehaviour
{
    [Header("Toggle Action (e.g. your VR button)")]
    public InputActionReference toggleMenuAction;

    [Header("Parent of all UI elements to hide/show")]
    public GameObject uiContainer;

    void OnEnable()
    {
        toggleMenuAction.action.performed += OnToggleMenu;
        toggleMenuAction.action.Enable();
    }

    void OnDisable()
    {
        toggleMenuAction.action.performed -= OnToggleMenu;
        toggleMenuAction.action.Disable();
    }

    void OnToggleMenu(InputAction.CallbackContext ctx)
    {
        bool isVisible = !uiContainer.activeSelf;
        uiContainer.SetActive(isVisible);
        Debug.Log($"UI container is now {(isVisible ? "visible" : "hidden")}");
    }
}