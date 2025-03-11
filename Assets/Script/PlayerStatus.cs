using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーキャラの情報を格納し、各種処理をする
/// </summary>
public class PlayerStatus : MonoBehaviour
{
    [SerializeField] float _health;

    //メイン銃の情報
    [SerializeField] PrimaryGun _primaryGun;

    //ボディアーマー等ダメージ減衰用情報
    //

    //bool _isDead = false;

    void Start()
    {
        if (_health <= 0) {
            Debug.Log("healthの値が不正");
        }
        if(_primaryGun == null) {
            Debug.Log("メインウェポンが設定されていない");
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
