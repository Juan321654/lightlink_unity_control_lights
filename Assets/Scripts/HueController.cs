using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class HueController : MonoBehaviour
{
    private string bridgeIp = "192.168.0.189";
    private string userToken = "YQC2nfg1xA9Exie0K80JOWgE5dY67thE8Q-WMoXK";
    private int lightId = 3; // pick one of your bulbs

    public void SetLightOn(bool on)
        {
            string url = $"http://{bridgeIp}/api/{userToken}/lights/{lightId}/state";
            string json = $"{{\"on\":{on.ToString().ToLower()} }}";

            StartCoroutine(SendRequest(url, json));
        }

    private IEnumerator SendRequest(string url, string json)
    {
        UnityWebRequest req = UnityWebRequest.Put(url, json);
        req.method = "PUT";
        yield return req.SendWebRequest();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
