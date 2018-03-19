using System;
using System.Collections;
using UnityEngine;

public class LocalTestCount : MonoBehaviour {

    string url = "ws://localhost:8080/";

    IEnumerator Start()
    {
        WebSocket ws = new WebSocket(new Uri(url));

        yield return StartCoroutine(ws.Connect());

        while (true)
        {
            string reply = ws.RecvString();
            if (reply != null)
            {
                Debug.Log("Received: " + reply);
            }
            if (ws.error != null)
            {
                Debug.LogError("Error: " + ws.error);
                break;
            }
            yield return 0;
        }
        ws.Close();
    }
}
