using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// �v���C���[����̓��͂��󂯎���āA�v���C���[�L�����ɔ��f����
/// </summary>
public class PlayerInputController : MonoBehaviour
{
    public Camera headCamera;
    public InputActionAsset playerInput;

    PlayerStatus _playerStatus;
    PrimaryGun _primaryGun;

    //�ړ��Ɋւ��邱��
    InputAction _playerMoveAction;
    Vector2 _moveDir;
    public float walkSpeed;

    //���_�Ɋւ��邱��
    InputAction _playerLookAction;
    Vector2 _lookDir;
    float rot_hr = 0f;
    float rot_vt = 0f;
    public float sensitivityX;
    public float sensitivityY;
    public float upperAngle;//���グ�����p�x(�Ȃ����}�C�i�X(�r���[�|�[�g��̖��))
    public float lowerAngle;//�������鉺���p�x(�Ȃ����v���X)

    //�X�v�����g(����)�Ɋւ��邱��
    InputAction _playerSprintAction;
    float _isSprinting;
    public float sprintRate = 1.2f;

    //�ˌ��Ɋւ��邱��
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
            Debug.Log("playerStatus��null");
        }

        _primaryGun = _playerStatus.PrimaryGun;
        if (_primaryGun == null) {
            Debug.Log("primaryGun��null");
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
            Debug.Log("���b�Z�[�W�FupperAngle��0");
        }
        if(lowerAngle == 0f) {
            Debug.Log("���b�Z�[�W�FminAngle��0");
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
        
        if(_isSprinting == 1) {//���蒆�Ȃ�
            transform.Translate(moveDir.x * walkSpeed * Time.deltaTime,
                                0,
                                moveDir.y * walkSpeed * sprintRate * Time.deltaTime);
        }
    }

    void PlayerLook(Vector2 lookDir) {

        if (_playerLookAction.inProgress == true) {
            //���p�x
            rot_hr += lookDir.x * sensitivityX * Time.deltaTime;
            //�c�p�x
            rot_vt -= lookDir.y * sensitivityY * Time.deltaTime;

            float vt = ClampRotationValue(rot_vt);//��x���l�����u�����Ă���
            

            headCamera.transform.rotation = Quaternion.Euler(vt, rot_hr, 0);
            transform.rotation = Quaternion.Euler(0, rot_hr, 0);
            rot_vt = vt;//�N�����v�����l����(�łȂ��Ɠ��͒l�ƃJ������rotation���ꗂ��o��)
        }
    }

    /// <summary>
    /// �J�����̉�]�l���N�����v
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    float ClampRotationValue(float value) {
        if(value < upperAngle) {//max���傫�����(max�͐���Ńz���g�̓}�C�i�X) 
            value = upperAngle;
            
        }
        if(value > lowerAngle) {//min��菬�������(min�͘���)
            value = lowerAngle;
        }

        return value;
    }

    /// <summary>
    /// �����Ă�Ƃ��ɃJ������h�炻���Ƃ������
    /// </summary>
    /// <param name="moveDir"></param>
    /// <param name="isSprinting"></param>
    void WaveCameraWhileMoving(Vector2 moveDir ,float isSprinting) {
        
        if(moveDir != new Vector2(0, 0)) {//�����Ă���
            if(isSprinting == 0) {//�����ĂȂ����

            } else {//�����Ă�Ȃ�

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
