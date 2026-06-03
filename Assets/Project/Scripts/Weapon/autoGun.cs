using UnityEngine;

public class autoGun : BaseWeapon
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    //トリガーアクション(オーバーライド)
    public override void OnTriggerAction()
    {
        Debug.Log("オートアクション");

        InstantiateBullet();

        //オートガンのトリガーアクションのロジックをここに追加
        base.OnTriggerAction();
    }
}
