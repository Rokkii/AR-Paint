using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenshotButton : MonoBehaviour
{
    public void TakeScreenshot()
    {
        StartCoroutine("Screenshot");
    }

    IEnumerator Screenshot()
    {
        string timeStamp = System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");

        string fileName = "Screenshot" + timeStamp + ".png";

        string pathToSave = fileName;

        ScreenCapture.CaptureScreenshot(pathToSave);

        yield return new WaitForEndOfFrame();
    }
}
