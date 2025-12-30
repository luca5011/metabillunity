using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackManager : MonoBehaviour
{
    public List<Vector2> vector2List = new List<Vector2>()
    {
        new Vector2(1,0), //오른쪽
        new Vector2(1,1), //오른쪽 위
        new Vector2(0,1), //위
        new Vector2(-1,1), //왼쪽 위
        new Vector2(-1,0), //왼쪽
        new Vector2(-1,-1), //왼쪽 아래
        new Vector2(0,-1), //아래
        new Vector2(1,-1) //오른쪽 아래
    };

    public GameObject pattern_1_Object;
    public GameObject bulletPrefab;

    void Start()
    {
        
    }

    
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            FireBullet();
        }*/
    }

    void FireBullet()
    {
        pattern_1_Object.transform.Rotate(0,0,Random.Range(0,180f));

        for (int i=0; i< vector2List.Count; i++)
        {
            Vector2 dir = vector2List[i];
            GameObject bulletCreat = Instantiate(bulletPrefab, 
                transform.position, 
                Quaternion.identity,
                pattern_1_Object.transform);

            bulletCreat.GetComponent<Rigidbody2D>().linearVelocity = dir * 5f;

        }

    }
}
