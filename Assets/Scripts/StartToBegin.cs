﻿using UnityEngine;

[RequireComponent(typeof(FadeOut))]
public class StartToBegin : MonoBehaviour
{
    public GameObject CommandSpawner;

    private FadeOut _fadeOut;

    public void Start()
    {
        _fadeOut = GetComponent<FadeOut>();
    }

    public void Update()
    {
        if (Input.GetAxis("Start") > 0)
            GetComponent<FadeOut>().enabled = true;

        if (_fadeOut.Faded)
            CommandSpawner.SetActive(true);
    }
}