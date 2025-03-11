using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// メインウェポンの共通動作を定める抽象クラス
/// </summary>
public abstract class PrimaryGun : MonoBehaviour
{
    //セレクトファイア(セミフルの切り替え)などの機構は、
    //それも持たないメインウェポンもあるので、
    //インターフェースとして別に定義などし、
    //それぞれの具体クラスで適宜実装する。

    
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public abstract void PullTrigger();

    public abstract void Reload();

    

}
