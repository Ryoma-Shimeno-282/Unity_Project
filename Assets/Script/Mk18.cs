using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Mk18アサルトライフル（テスト用）
/// </summary>
public class Mk18 : PrimaryGun
{

    public int magazineSize;
    //装填量と現在装填数は別だしカスタムで変わる可能性もあるので、ホントはこんな風には定義しない

    public GameObject bullet;
    //なぜインスタンシエイトできる？
    //クラス型なのに、スクリプトではなくゲームオブジェクトの判定になっている
    //インスペクタにおいて各種問題が起きるのは、スクリプトの直接のアタッチが許されていないからだろう
    //だから下は不可能。なぜかはわからない

    //上のは、そのクラスをコンポーネントとして持っているゲームオブジェクトを判定して、アタッチしている？
    //ということは、ゲームオブジェクトによっては複数スクリプトコンポーネントがアタッチされているという
    //こともあり得るので、複数のクラス型変数にアタッチ(代入)できるということ？

    //では大抵の場合はGameObject型で変数を書いて、インスペクタでアタッチするのがよい？
    //特定のクラス型変数を書くメリット
    //そのクラスがアタッチされているオブジェクトに限定できる。複数人で開発しているときに
    //ミスが起こりにくい
    //もしかしたら、その方が軽いかもしれない。インスタンス化するデータに差があるかも
    //コード内で扱う場合、型が違うので必然的に扱えるメソッドや変数の種類や数に差がある。
    //ゲームオブジェクト型でインスペクタからアタッチし、スクリプトはgetcomponetして扱うのが無難



    //public PlayerStatus ps;
    //なぜスクリプトをアタッチできない？
    //getcomponentはできる。つまりスクリプト内でクラスを代入することはできる。
    //getcomponentはスクリプトから見てアタッチ先であるゲームオブジェクトに、
    //同じくアタッチされている他のコンポーネントを検索してコード内で扱えるようにするためのもの

    //スクリプト（クラス）をクラス型変数にインスペクタからアタッチできない？
    //そもそもする必要がない。
    //newすれば済む話。newしなくても例えばpublicクラスのpublicメソッド（プロパティ）
    //などには簡単にアクセスできる

    //だから、インスペクタでの操作は、アセットとかプレハブとかゲームオブジェクト同士を関連付けるための
    //ものであって、スクリプト同士の関連付けのためのものではない。

    [NonSerialized] Bullet _bulletScript;
    Vector3 dirTest;

    [SerializeField] GameObject muzzle;

    GameObject _bulletInsta;
    

    void Start()
    {
        if(magazineSize <= 0) {
            Debug.Log("マガジンサイズの値が不正");
        }
        if (bullet == null) {
            Debug.Log("弾薬が指定されていない");
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
