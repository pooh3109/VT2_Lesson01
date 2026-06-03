using UnityEngine;
using UnityEngine.InputSystem;

public class MiniCharactor : MonoBehaviour
{
public float moveSpeed = 2.0f;
public float turnSpeed = 90.0f;

[Header("** Shot Settings **")]
    public Transform shotPoint;         // 撃ちだし座標
    public GameObject bulletPrefab;     // 弾丸のプレハブ

    void Update()
    {
        
        Movement();
        Turn();
        Shot();
    }

    void Movement()
    {
        float deltaMoveSpeed = moveSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, deltaMoveSpeed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -deltaMoveSpeed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(deltaMoveSpeed, 0, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-deltaMoveSpeed, 0, 0);
        }
    }

    void Turn()
    {
         float deltaTurnSpeed = turnSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -deltaTurnSpeed, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, deltaTurnSpeed, 0);
        }
    }

    void Shot()
    {
        if (Input.GetMouseButton(0))
        {
            // 弾丸を生成する
            GameObject origin   = bulletPrefab;
            Vector3 position    = shotPoint.position;
            Quaternion rotation = shotPoint.rotation;

            GameObject bullet = Instantiate(origin, position, rotation);

            // 弾丸を飛ばす
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(shotPoint.forward * 50, ForceMode.Impulse);
            
            Destroy(bullet, 5f);
        }
    }
    void OnMOve(InputValue value)
    {
        
    }

    void OnnLook(InputValue value)
    {
        
    }

    void OnAttack(InputValue value)
    {
        
    }
}
