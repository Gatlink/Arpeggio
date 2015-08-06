using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Pulse : MonoBehaviour
{
    public float Duration = 1f; // in seconds
    public float TimeBetweenPulsations = 1f; // in seconds
    public float MaxScale = 1.5f;

    private bool _startPulsing = true;
    private Sprite _sprite;

    private void Start()
    {
        _sprite = GetComponent<Image>().sprite;
    }

    private void Update()
    {
        if (_startPulsing)
            StartCoroutine(Pulsation());
    }

    private IEnumerator Pulsation()
    {
        _startPulsing = false;
        var startTime = Time.time;
        var copy = new GameObject("Pulse");
        var renderer = copy.AddComponent<Image>();
        renderer.sprite = _sprite;
        ((RectTransform)copy.transform).sizeDelta = ((RectTransform)transform).sizeDelta;
        copy.transform.position = transform.position;
        copy.transform.SetParent(transform);

        while (Time.time - startTime <= Duration)
        {
            var t = (Time.time - startTime) / Duration;
            var scale = Mathf.Lerp(1, MaxScale, t);
            var color = renderer.color;
            color.a = Mathf.Lerp(1, 0, t);
            copy.transform.localScale = new Vector3(scale, scale, 1);
            renderer.color = color;
            yield return null;
        }

        Destroy(copy);
        yield return new WaitForSeconds(TimeBetweenPulsations);
        _startPulsing = true;
    }
}