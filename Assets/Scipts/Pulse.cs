using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Pulse : MonoBehaviour
{
    public float Duration = 1f; // in seconds
    public float TimeBetweenPulsations = 1f; // in seconds
    public float MaxScale = 1.5f;

    private GameObject _pulse;
    private bool _startPulsing = true;
    private Sprite _sprite;

    private void Start()
    {
        _pulse = transform.GetChild(0).gameObject;
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
        var renderer = _pulse.GetComponent<Image>();
        var color = renderer.color;

        while (Time.time - startTime <= Duration)
        {
            var t = (Time.time - startTime) / Duration;
            var scale = Mathf.Lerp(1, MaxScale, t);
            color.a = Mathf.Lerp(1, 0, t);
            _pulse.transform.localScale = new Vector3(scale, scale, 1);
            renderer.color = color;
            yield return null;
        }

        _pulse.transform.localScale = Vector3.one;
        color.a = 1;
        renderer.color = color;
        yield return new WaitForSeconds(TimeBetweenPulsations);
        _startPulsing = true;
    }
}