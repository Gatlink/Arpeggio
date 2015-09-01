using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class FadeOut : MonoBehaviour
{
    public float Duration = 3f; // in seconds

    public void Start()
    {
        StartCoroutine(FadeInTime());
    }

    public IEnumerator FadeInTime()
    {
        var canvasGroup = GetComponent<CanvasGroup>();
        var startTime = Time.unscaledTime;
        while (canvasGroup.alpha > 0)
        {
            var t = (Time.unscaledTime - startTime) / Duration;
            canvasGroup.alpha = Mathf.Lerp(1, 0, t);
            yield return null;
        }
    }
}