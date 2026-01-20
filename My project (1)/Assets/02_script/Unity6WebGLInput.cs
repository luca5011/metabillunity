using System.Runtime.InteropServices;
using UnityEngine;
using TMPro;

public class Unity6WebGLInput : MonoBehaviour
{
    private TMP_InputField inputField;

    [DllImport("__Internal")]
    private static extern void OpenPrompt(string title, string defaultText, string objectName);

    void Awake()
    {
        // 스크립트가 붙은 오브젝트의 InputField를 자동으로 가져옵니다.
        inputField = GetComponent<TMP_InputField>();
    }

    public void OnClickInput()
    {
#if !UNITY_EDITOR && UNITY_WEBGL
        // 자기 자신(gameObject.name)의 이름을 보냅니다.
        OpenPrompt("내용을 입력하세요", inputField.text, gameObject.name);
#endif
    }

    // JS에서 호출할 콜백 함수
    public void SetInputText(string text)
    {
        if (inputField != null)
        {
            inputField.text = text;
        }
    }
}
