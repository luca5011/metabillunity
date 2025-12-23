using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPattern1_Control : MonoBehaviour
{
    public bool Pattern1_Active = false;
    private List<Vector2> vector2List = new List<Vector2>()
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

    public float Speed = 5f;
    public float DelayTime_P1 = 0.5f;
    public float DelayTime_P2 = 0.3f;
    public GameObject pattern_1_C1;
    public GameObject pattern_1_C2;

    public GameObject bulletPrefab;

    void Start()
    {
        Pattern_Play();
    }

    public void Pattern_Play()
    {
        Pattern1_Active = true;
        StartCoroutine(Pattern1());
    }
    public void Pattern_Stop()
    {
        Pattern1_Active = false;
    }

    IEnumerator Pattern1()
    {
       
        for (int i = 0; i < vector2List.Count; i++)
        {
            if(i%2 == 1)
            {
                //홀수
                PatternShot(i);
            }
        }

        //기다리기
        yield return new WaitForSeconds(DelayTime_P1);

        for (int i = 0; i < vector2List.Count; i++)
        {
            if (i % 2 == 0)
            {
                //짝수
                PatternShot(i);
            }
        }

        yield return new WaitForSeconds(DelayTime_P2);

       
        while (Pattern1_Active)
        {
            //회전
            pattern_1_C1.transform.Rotate(0, 0, 30f * Time.deltaTime);
            yield return null;
        }

        //패턴 종료시 패턴 모두 삭제
        for (int i = 0; i < pattern_1_C1.transform.childCount; i++)
        {
            Destroy(pattern_1_C1.transform.GetChild(i).gameObject);
        }
       
        yield break;
    }


    void PatternShot(int index)
    {
        //짝수
        Vector2 dir = vector2List[index];
        GameObject bulletCreat = Instantiate(bulletPrefab,
            transform.position,
            Quaternion.identity,
            pattern_1_C1.transform);

        bulletCreat.GetComponent<Rigidbody2D>().linearVelocity = dir * Speed;
    }



}
