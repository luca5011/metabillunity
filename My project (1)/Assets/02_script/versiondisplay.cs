using UnityEngine;
using UnityEngine.UI;
public class versiondisplay : MonoBehaviour
{
    public Text versionText;
    private void Start()
    {
        string version = Application.version;
        versionText.text = "Version: " + version;
    }
}
