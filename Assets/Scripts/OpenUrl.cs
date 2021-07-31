using UnityEngine;

public class OpenUrl : MonoBehaviour
{
    public string url;

    public void Open()
    {
        Application.OpenURL(url);
    }

}
