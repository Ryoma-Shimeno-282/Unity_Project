using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Mk18�A�T���g���C�t���i�e�X�g�p�j
/// </summary>
public class Mk18 : PrimaryGun
{

    public int magazineSize;
    //���U�ʂƌ��ݑ��U���͕ʂ����J�X�^���ŕς��\��������̂ŁA�z���g�͂���ȕ��ɂ͒�`���Ȃ�

    public GameObject bullet;
    //�Ȃ��C���X�^���V�G�C�g�ł���H
    //�N���X�^�Ȃ̂ɁA�X�N���v�g�ł͂Ȃ��Q�[���I�u�W�F�N�g�̔���ɂȂ��Ă���
    //�C���X�y�N�^�ɂ����Ċe���肪�N����̂́A�X�N���v�g�̒��ڂ̃A�^�b�`��������Ă��Ȃ����炾�낤
    //�����牺�͕s�\�B�Ȃ����͂킩��Ȃ�

    //��̂́A���̃N���X���R���|�[�l���g�Ƃ��Ď����Ă���Q�[���I�u�W�F�N�g�𔻒肵�āA�A�^�b�`���Ă���H
    //�Ƃ������Ƃ́A�Q�[���I�u�W�F�N�g�ɂ���Ă͕����X�N���v�g�R���|�[�l���g���A�^�b�`����Ă���Ƃ���
    //���Ƃ����蓾��̂ŁA�����̃N���X�^�ϐ��ɃA�^�b�`(���)�ł���Ƃ������ƁH

    //�ł͑��̏ꍇ��GameObject�^�ŕϐ��������āA�C���X�y�N�^�ŃA�^�b�`����̂��悢�H
    //����̃N���X�^�ϐ������������b�g
    //���̃N���X���A�^�b�`����Ă���I�u�W�F�N�g�Ɍ���ł���B�����l�ŊJ�����Ă���Ƃ���
    //�~�X���N����ɂ���
    //������������A���̕����y����������Ȃ��B�C���X�^���X������f�[�^�ɍ������邩��
    //�R�[�h���ň����ꍇ�A�^���Ⴄ�̂ŕK�R�I�Ɉ����郁�\�b�h��ϐ��̎�ނ␔�ɍ�������B
    //�Q�[���I�u�W�F�N�g�^�ŃC���X�y�N�^����A�^�b�`���A�X�N���v�g��getcomponet���Ĉ����̂�����



    //public PlayerStatus ps;
    //�Ȃ��X�N���v�g���A�^�b�`�ł��Ȃ��H
    //getcomponent�͂ł���B�܂�X�N���v�g���ŃN���X�������邱�Ƃ͂ł���B
    //getcomponent�̓X�N���v�g���猩�ăA�^�b�`��ł���Q�[���I�u�W�F�N�g�ɁA
    //�������A�^�b�`����Ă��鑼�̃R���|�[�l���g���������ăR�[�h���ň�����悤�ɂ��邽�߂̂���

    //�X�N���v�g�i�N���X�j���N���X�^�ϐ��ɃC���X�y�N�^����A�^�b�`�ł��Ȃ��H
    //������������K�v���Ȃ��B
    //new����΍ςޘb�Bnew���Ȃ��Ă��Ⴆ��public�N���X��public���\�b�h�i�v���p�e�B�j
    //�Ȃǂɂ͊ȒP�ɃA�N�Z�X�ł���

    //������A�C���X�y�N�^�ł̑���́A�A�Z�b�g�Ƃ��v���n�u�Ƃ��Q�[���I�u�W�F�N�g���m���֘A�t���邽�߂�
    //���̂ł����āA�X�N���v�g���m�̊֘A�t���̂��߂̂��̂ł͂Ȃ��B

    [NonSerialized] Bullet _bulletScript;
    Vector3 dirTest;

    [SerializeField] GameObject muzzle;

    GameObject _bulletInsta;
    

    void Start()
    {
        if(magazineSize <= 0) {
            Debug.Log("�}�K�W���T�C�Y�̒l���s��");
        }
        if (bullet == null) {
            Debug.Log("�e�򂪎w�肳��Ă��Ȃ�");
        }
        
        
        //_bulletScript = bullet.GetComponent<Bullet>();
        //Debug.Log("mk18:pullTrigger()" + _bulletScript.Direction);
        

    }

    void Update()
    {
        
    }

    public override void PullTrigger() {
        //Debug.Log("mk18:pullTrigger()" + _bulletScript.Direction);
        
        //_bulletScript.Direction = transform.rotation.eulerAngles;
        
        
        //Debug.Log("mk18:pullTrigger()" + _bulletScript.Direction);

        _bulletInsta = Instantiate(bullet, muzzle.transform.position, Quaternion.identity);
        _bulletScript = _bulletInsta.GetComponent<Bullet>();
        _bulletScript.Direction = transform.rotation.eulerAngles;
        _bulletScript.AccelerateBullet();

    }

    public override void Reload() {
        
    }

}
