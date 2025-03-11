using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class Bullet : MonoBehaviour
{
    /*
        �����F
        �P�F�����ƃC���X�^���V�G�C�g�ł��邩�ǂ����B�F����

        �Q�Fstart�֐������̎��Ɏn�܂邱�Ƃ̊m�F�F����

        2.5�F������^����F������
        ���������n���Ȃ�

        �R�F�ړ�������ϐ��Ɋi�[(��������Ȃ��Ă��A���ݎ��Ԃł�����)�F������

        �S�F���������I�u�W�F�N�g�����X�g�Ɋi�[���Ĕ�e�Ɗђʂ̍Č��F������
     */
    public float velocity;
    public float timeOut;

    List<GameObject> _hitList;
    float _distance;
    [NonSerialized] float _damage;
    bool _canPenetrate;
    Rigidbody _rb;
    [NonSerialized] Vector3 _dir;
    

    void Awake() {
        _hitList = new List<GameObject>();
        gameObject.AddComponent<Rigidbody>();

        _rb = GetComponent<Rigidbody>();
        _rb.useGravity = false;

        /*
        �R���|�[�l���g��add�Aget�̗ނ�start()����awake()���ŏ��������ق����ǂ����ۂ�
        ��������Instantiate����public���\�b�h���Ăԏꍇ�A���̃��\�b�h���������Ă΂��̂�awake()
        start�͌�ɌĂ΂��͗l�B
        */

    }

    void Start()
    {
        
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        GameObject hit = other.gameObject;
        if (hit.CompareTag("enemy")) {
        _hitList.Add(hit);
        Debug.Log("bullet hit, target added to list");
        }
    }

    public float Damage {
        get { return _damage; }
        set { _damage = value; } 
    }

    public Vector3 Direction { 
        get { return _dir; }
        set { _dir = value; } 
    }

    public void AccelerateBullet() {
        Debug.Log("bullet:accelarateBullet()" + _dir);
        if(_rb == null) {
            Debug.Log("_rb not set");
        }
        _rb.AddRelativeForce(_dir, ForceMode.Impulse);
        
    }

    void TimeOut(float time) {
        
    }

    public void Test() { }

}
