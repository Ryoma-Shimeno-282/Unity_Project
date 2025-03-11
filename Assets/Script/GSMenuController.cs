using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class GSMenuController : MonoBehaviour
{
    public Canvas canvas;

    public Button primary;
    public Button secondary;

    public Button ar_fifteen;
    GameObject ar_fifteen_gameObject;
    public Button glock_nineteen;
    GameObject glock_nineteen_gameObject;

    GenerateWeapon generateWeapon;

    GameObject _weaponRoot;

    public InputActionAsset _playerInput;
    InputActionMap _playerUI;
    InputAction _leftClick;
    InputAction _mouseMove;

    //Vector3 gunRotation = new Vector3();
    float gunRotationX;
    float gunRotationY;

    void Awake() {

        generateWeapon = gameObject.AddComponent<GenerateWeapon>();

        _playerUI = _playerInput.FindActionMap("Player_UI");
        _leftClick = _playerUI.FindAction("LeftClick");
        _mouseMove = _playerUI.FindAction("Move_Mouse");
    }

    void Start()
    {
        ar_fifteen_gameObject = ar_fifteen.gameObject;
        ar_fifteen_gameObject.SetActive(false);
        glock_nineteen_gameObject = glock_nineteen.gameObject;
        glock_nineteen_gameObject.SetActive(false);

    }

    
    void Update()
    {
        RotateGun();   
    }

    void OnEnable() {
        _playerUI.Enable();
    }

    void OnDisable() {
        _playerUI.Disable();    
    }

    public void OnPrimaryButtonClicked() {
        ar_fifteen_gameObject.SetActive(true);
        if (glock_nineteen_gameObject.activeSelf) {
            glock_nineteen_gameObject.SetActive(false);
        }
    }

    public void OnSecondaryButtonClicked() {
        glock_nineteen_gameObject.SetActive(true);
        if (ar_fifteen_gameObject.activeSelf) {
            ar_fifteen_gameObject.SetActive(false);
        }
    }

    public void OnAR15Selected() {
        _weaponRoot = generateWeapon.BuildMk18();
        generateWeapon.InitiateGunPosition();
    }

    void RotateGun() {

        if (_weaponRoot) {
            if (_leftClick.IsPressed()) {
                gunRotationY = _mouseMove.ReadValue<Vector2>().x * Time.deltaTime * 15 * -1;
                gunRotationX = _mouseMove.ReadValue<Vector2>().y * Time.deltaTime * 15 * -1;
                _weaponRoot.transform.Rotate(gunRotationX, 0f, 0f);
                _weaponRoot.transform.Rotate(0f, gunRotationY, 0f, Space.World);

                

                //ズーム作る
                //回転リセットボタン作る
            }
        }
    }

    public void OnGlock19Selected() {
        Debug.Log("Sorry but Glock19 is not available now");
    }

}
