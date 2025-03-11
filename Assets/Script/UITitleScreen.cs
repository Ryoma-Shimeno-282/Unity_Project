using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using TMPro;

public class UITitleScreen : MonoBehaviour
{

    public InputActionAsset playerInput;
    InputActionMap _playerUIInput;
    InputAction _selectMouse;
    InputAction _leftClick;

    //public EventSystem eventSystem;

    public Button playTestButton;
    public Button gunSmithButton;
    TextMeshProUGUI _playTest;
    TextMeshProUGUI _gunSmith;
    Color textColor;
    

    

    void Start()
    {
        _playerUIInput = playerInput.FindActionMap("Player_UI");
        _selectMouse = _playerUIInput.FindAction("Select_Mouse");
        _leftClick = _playerUIInput.FindAction("LeftClick");

        _playTest = playTestButton.GetComponentInChildren<TextMeshProUGUI>();
        _playTest.alpha = 0;
        _gunSmith = gunSmithButton.GetComponentInChildren<TextMeshProUGUI>();
        _gunSmith.alpha = 0;
        textColor = _playTest.color;
    }

    void OnEnable() {
        //_playerUIInput.Enable();
        //_selectMouse.Enable();    
    }

    void OnDisable() {
        //_playerUIInput.Disable();
        //_selectMouse.Disable();
    }

    void Update()
    {
        //OnClick();
    }

    public void OnTestPlayButtonClicked() {
        
        //Debug.Log("TestPlay button is now clicked");
        //_playTest.alpha = 255;
    }

    void OnClick() {

        if (_leftClick.WasPressedThisFrame()) {
            Debug.Log("Left clicked");
            
            
        }

    }

    
}
