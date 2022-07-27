using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class OpenAPI : MonoBehaviour
{
    private void Start()
    {
        PostData();
    }
    void PostData() => StartCoroutine(PostData_Coroutine());

    IEnumerator PostData_Coroutine()
    {
        string url = "https://my-json-server.typicode.com/jeterwin/testdatabase";
        WWWForm form = new WWWForm();
        using(UnityWebRequest request = UnityWebRequest.Post(url, form))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
                Debug.Log(request.error);
            else
                Debug.Log(request.downloadHandler.text);
        }
    }
}
