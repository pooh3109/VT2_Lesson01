using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

[RequireComponent(typeof(NavMeshAgent), typeof(Rigidbody), typeof(BoxCollider))]
public class Enemy : MonoBehaviour
{
    // ナビメッシュ
    public NavMeshAgent agent;
    public Rigidbody rb;
    public MiniCharacter player;

    // 目的地
    public Vector3 targetPoint;

    // 巡回座標
    public Vector3[] patrolPoint;
    public int currentIndex;

    void Start()
    {
        // agent = GetComponent<NavMeshAgent>と一緒
        // NULLチェックも同時にできる　→　outキーワード
        TryGetComponent<NavMeshAgent>(out agent);

        // rigidbodyのヴェロシティを所得
        TryGetComponent<Rigidbody>(out rb);

        // シーン上からminicaharaのコンポーネントを持つオブジェクトを取得する
        player = GameObject.FindAnyObjectByType<MiniCharacter>();
    }

    void Update()
    {
        // RigitBodyの影響を軽減
        rb.linearVelocity = Vector3.zero;

        // playerの距離
        Vector3 posA = player.transform.position;
        Vector3 posB = transform.position;
        float distance = Vector3.Distance(posA, posB);

        if(distance < 3)
        {
            // プレイヤーの座標
            targetPoint = posA;
        }
        else
        {
            // エネミーの座標
            targetPoint = patrolPoint[currentIndex % patrolPoint.Length];
        }

        // 
        float patrolDistance = Vector3.Distance(patrolPoint[currentIndex % patrolPoint.Length], transform.position);

        if(patrolDistance < 1.0f)
        {
            currentIndex++;
        }

        // エージェントに目的地を設定
        agent.SetDestination(targetPoint);
    }
}
