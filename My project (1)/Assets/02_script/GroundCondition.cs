using UnityEngine;

public class GroundCondition : MonoBehaviour
{
    [Header("체크시 그라운드 설정됨")]
    public bool groundStatus = false;

    void Awake()
    {
        int layerIndex = LayerMask.NameToLayer("ground");


        //레이어가 유효한지 확인 (-1 은 유효하지 않음)
        if (groundStatus == false)
        {
            layerIndex = LayerMask.NameToLayer("Default");
        }

        gameObject.layer = layerIndex; //게임 오브젝트 레이어 변경
    }

}
