using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class MiniCharacter : MonoBehaviour
{
    [Header("** Shooter Settings **")]
    public GameObject bulletPrefab;     // 弾丸のプレハブ
    public GameObject shotPoint;        // 撃ちだし座標
    public float shotForce = 10f;       // 発射の力

    [Header("** Camera Settings **")]
    public GameObject CameraJoint;    

    [Header("Weapon Settings")]
    public BaseWeapon weapon;


    private Vector2 _inputMoveValue;    // Moveの入力値
    private Vector2 _inputLookValue;    // Lookの入力値
    private float _inputAttackValue;    // Attackの入力値
    private Vector3 angles;             // キャラクターの向き

    

    void Start()
    {
        
    }

    void Update()
    {
        Move();     //移動メソッドを呼び出す

        Look();     //回転メソッドを呼び出す

        if(_inputAttackValue > 0.1f)
        {
            weapon.OnTriggerAction();   // 武器のトリガーアクションを呼び出す
        }
        
    }

    //移動メソッド
    //引数無し　戻り値無し
    public void Move()
    {
        Vector3 veloctiy = Vector3.zero;    //速度の変数
        veloctiy.z = _inputMoveValue.y;     //入力(上下)で前後移動
        veloctiy.x = _inputMoveValue.x;     //入力(左右)で左右移動

        transform.Translate(veloctiy * Time.deltaTime);
    }

    //移動メソッド
    //引数無し　戻り値無し
    public void Look()
    {
        angles.x +=  _inputLookValue.y * -1; //y入力でx回転
        angles.y +=  _inputLookValue.x; //x入力でy回転

        //x軸の角度に制限を設ける
        //範囲を設ける数学関数
        //[Mathf.Clamp(対象値, 最小値, 最大値)]
        angles.x = Mathf.Clamp(angles.x, -90, 90);
        
        //TpsPlyer(自分)のｙ軸だけ回転
        transform.eulerAngles = new Vector3(0, angles.y, 0); //角度を代入
        //CameraJointのｘ軸を回転]
        CameraJoint.transform.eulerAngles = new Vector3(angles.x, angles.y, 0);
    }

    void OnMove(InputValue value)
    {
        _inputMoveValue = value.Get<Vector2>();
    }

    void OnLook(InputValue value)
    {
        _inputLookValue = value.Get<Vector2>();
    }

    void OnAttack(InputValue value)
    {
        _inputAttackValue = value.Get<float>();
    }
}
