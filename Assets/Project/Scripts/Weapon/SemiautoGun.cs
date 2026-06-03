using UnityEngine;

public class SemiautoGun : BaseWeapon
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
        Debug.Log("セミオートアクション");

        //セミオートガンのトリガーアクションのロジックをここに追加
        base.OnTriggerAction();
    }
}
