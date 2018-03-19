using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalTestTalk : MonoBehaviour
{
    string url = "ws://localhost:8080/";

    IEnumerator Start()
    {
        WebSocket ws = new WebSocket(new Uri(url));

        yield return StartCoroutine(ws.Connect());

        ws.SendString("lwj");

        while (true)
        {
            string reply = ws.RecvString();
            if (reply != null)
            {
                Debug.Log("Received: " + reply);
                ws.SendString("lwj");
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
