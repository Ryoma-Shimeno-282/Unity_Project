using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �v���C���[�L�����̏����i�[���A�e�폈��������
/// </summary>
public class PlayerStatus : MonoBehaviour
{
    [SerializeField] float _health;

    //���C���e�̏��
    [SerializeField] PrimaryGun _primaryGun;

    //�{�f�B�A�[�}�[���_���[�W�����p���
    //

    //bool _isDead = false;

    void Start()
    {
        if (_health <= 0) {
            Debug.Log("health�̒l���s��");
        }
        if(_primaryGun == null) {
            Debug.Log("���C���E�F�|�����ݒ肳��Ă��Ȃ�");
        }
    }

    void Update()
    {
        
    }

    public PrimaryGun PrimaryGun {
        get { return _primaryGun; }
        set { _primaryGun = value; } 
    }
    

}
