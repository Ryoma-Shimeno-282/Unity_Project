using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���C���E�F�|���̋��ʓ�����߂钊�ۃN���X
/// </summary>
public abstract class PrimaryGun : MonoBehaviour
{
    //�Z���N�g�t�@�C�A(�Z�~�t���̐؂�ւ�)�Ȃǂ̋@�\�́A
    //����������Ȃ����C���E�F�|��������̂ŁA
    //�C���^�[�t�F�[�X�Ƃ��ĕʂɒ�`�Ȃǂ��A
    //���ꂼ��̋�̃N���X�œK�X��������B

    
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public abstract void PullTrigger();

    public abstract void Reload();

    

}
