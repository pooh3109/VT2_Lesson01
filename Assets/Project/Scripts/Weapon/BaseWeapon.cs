using System;
using Unity.VisualScripting;
using UnityEngine;

public class BaseWeapon : MonoBehaviour
{
    [Header("*** Base Settings ***")]
    [SerializeField] protected GameObject _bulletPrefab;
    [SerializeField] protected GameObject _shotPosition;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    //トリガーアクション
    public virtual void OnTriggerAction()
    {
        
    }

    protected void InstantiateBullet()
    {
        GameObject bullet = Instantiate(
            _bulletPrefab,
            _shotPosition.transform.position,
            Quaternion.identity
        );
        
        //弾丸の発射
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.AddForce(Camera.main.transform.forward * 50f, ForceMode.Impulse);

        Destroy(bullet,5f);
    }
}
