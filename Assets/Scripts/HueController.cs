using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class HueController : MonoBehaviour
{
    private string bridgeIp = "192.168.0.189";
    private string userToken = "YQC2nfg1xA9Exie0K80JOWgE5dY67thE8Q-WMoXK";

    public void SetLightColor(int r, int g, int b, int lightId)
    {
        // Philips Hue expects xy color or hue/sat, but for demo, send RGB as 'xy' placeholder
        // You should convert RGB to xy for real Hue API, but here is a simple example:
        string url = $"http://{bridgeIp}/api/{userToken}/lights/{lightId}/state";
        string json = $"{{\"on\":true, \"bri\":254, \"xy\":[0.5,0.5]}}"; // Replace with real conversion if needed
        StartCoroutine(SendRequest(url, json));
    }

    public void SetLightBrightness(int brightness, int lightId)
    {
        string url = $"http://{bridgeIp}/api/{userToken}/lights/{lightId}/state";
        string json = $"{{\"bri\":{brightness}}}";
        StartCoroutine(SendRequest(url, json));
    }

    public void SetLightOn(bool on, int lightId)
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
