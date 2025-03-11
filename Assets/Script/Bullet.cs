using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class Bullet : MonoBehaviour
{
    /*
        実験：
        １：ちゃんとインスタンシエイトできるかどうか。：完了

        ２：start関数がその時に始まることの確認：完了

        2.5：初速を与える：未完了
        →方向が渡せない

        ３：移動距離を変数に格納(距離じゃなくても、存在時間でもいい)：未完了

        ４：当たったオブジェクトをリストに格納して被弾と貫通の再現：未完了
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
        コンポーネントのadd、getの類はstart()よりもawake()内で処理したほうが良いっぽい
        他所からInstantiateしてpublicメソッドを呼ぶ場合、そのメソッドよりも早く呼ばれるのがawake()
        startは後に呼ばれる模様。
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
