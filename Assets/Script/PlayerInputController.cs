using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// プレイヤーからの入力を受け取って、プレイヤーキャラに反映する
/// </summary>
public class PlayerInputController : MonoBehaviour
{
    public Camera headCamera;
    public InputActionAsset playerInput;

    PlayerStatus _playerStatus;
    PrimaryGun _primaryGun;

    //移動に関すること
    InputAction _playerMoveAction;
    Vector2 _moveDir;
    public float walkSpeed;

    //視点に関すること
    InputAction _playerLookAction;
    Vector2 _lookDir;
    float rot_hr = 0f;
    float rot_vt = 0f;
    public float sensitivityX;
    public float sensitivityY;
    public float upperAngle;//見上げる上限角度(なぜかマイナス(ビューポート上の問題))
    public float lowerAngle;//見下げる下限角度(なぜかプラス)

    //スプリント(走り)に関すること
    InputAction _playerSprintAction;
    float _isSprinting;
    public float sprintRate = 1.2f;

    //射撃に関すること
    InputAction _playerFireAction;
    InputAction _playerSwitchFireModeAction;
    bool _isSemi = true;


    void Awake() {
        _playerMoveAction = playerInput.FindActionMap("player_onfoot").FindAction("move");
        _playerLookAction = playerInput.FindActionMap("player_onfoot").FindAction("look");
        _playerSprintAction = playerInput.FindActionMap("player_onfoot").FindAction("sprint");
        _playerFireAction = playerInput.FindActionMap("player_onfoot").FindAction("fire");
        _playerSwitchFireModeAction = playerInput.FindActionMap("player_onfoot").FindAction("switchfiremode");

    }

    void Start()
    {
        Init();

        _playerStatus = GetComponent<PlayerStatus>();

        if(_playerStatus == null) {
            Debug.Log("playerStatusがnull");
        }

        _primaryGun = _playerStatus.PrimaryGun;
        if (_primaryGun == null) {
            Debug.Log("primaryGunがnull");
        }
    }

    void Update()
    {
        _moveDir = _playerMoveAction.ReadValue<Vector2>();
        _lookDir = _playerLookAction.ReadValue<Vector2>();
        _isSprinting = _playerSprintAction.ReadValue<float>();

        PlayerMove(_moveDir);
        PlayerLook(_lookDir);
        PlayerFire(_playerFireAction);
        PlayerSwitchFireMode(_playerSwitchFireModeAction);
    }

    void OnEnable() {
        playerInput.FindActionMap("player_onfoot").Enable();
    }

    void OnDisable() {
        playerInput.FindActionMap("player_onfoot").Disable();
    }

    void Init() {
        if(upperAngle == 0f) {
            Debug.Log("メッセージ：upperAngleが0");
        }
        if(lowerAngle == 0f) {
            Debug.Log("メッセージ：minAngleが0");
        }

        //if(sprintRate == 0f) {
        //    sprintRate = 2f;
        //}
    }

    void PlayerMove(Vector2 moveDir) {

        if (_isSprinting == 0) {
            transform.Translate(moveDir.x * walkSpeed * Time.deltaTime,
                                0,
                                moveDir.y * walkSpeed * Time.deltaTime);
        }
        
        if(_isSprinting == 1) {//走り中なら
            transform.Translate(moveDir.x * walkSpeed * Time.deltaTime,
                                0,
                                moveDir.y * walkSpeed * sprintRate * Time.deltaTime);
        }
    }

    void PlayerLook(Vector2 lookDir) {

        if (_playerLookAction.inProgress == true) {
            //横角度
            rot_hr += lookDir.x * sensitivityX * Time.deltaTime;
            //縦角度
            rot_vt -= lookDir.y * sensitivityY * Time.deltaTime;

            float vt = ClampRotationValue(rot_vt);//一度数値を取り置きしておく
            

            headCamera.transform.rotation = Quaternion.Euler(vt, rot_hr, 0);
            transform.rotation = Quaternion.Euler(0, rot_hr, 0);
            rot_vt = vt;//クランプした値を代入(でないと入力値とカメラのrotationに齟齬が出る)
        }
    }

    /// <summary>
    /// カメラの回転値をクランプ
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    float ClampRotationValue(float value) {
        if(value < upperAngle) {//maxより大きければ(maxは煽りでホントはマイナス) 
            value = upperAngle;
            
        }
        if(value > lowerAngle) {//minより小さければ(minは俯瞰)
            value = lowerAngle;
        }

        return value;
    }

    /// <summary>
    /// 動いてるときにカメラを揺らそうとしたやつ
    /// </summary>
    /// <param name="moveDir"></param>
    /// <param name="isSprinting"></param>
    void WaveCameraWhileMoving(Vector2 moveDir ,float isSprinting) {
        
        if(moveDir != new Vector2(0, 0)) {//動いていて
            if(isSprinting == 0) {//走ってなければ

            } else {//走ってるなら

            }
        }
    }

    void PlayerFire(InputAction playerFireAction) {

        if (_isSemi) {
            if (playerFireAction.WasPressedThisFrame()) {
                _primaryGun.PullTrigger();
            }
        } else {
            if (playerFireAction.IsInProgress()) {
                
            }
        }

    }

    void PlayerSwitchFireMode(InputAction playerSwtichFireModeAction) {
        if (_isSemi) {
            if (playerSwtichFireModeAction.WasPressedThisFrame()) {
                _isSemi = false;
                Debug.Log("Full Auto");
            }
        } else {
            if (playerSwtichFireModeAction.WasPressedThisFrame()) {
                _isSemi = true;
                Debug.Log("Semi Auto");
            }
        }
            
    }
    
}
