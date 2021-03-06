﻿using UnityEngine;
using System.Collections;

public class ExitButton : MonoBehaviour
{
    //public Renderer rend;
    public GameObject myVisible;

    private void Start()
    {
        //rend = GetComponent<Renderer>();
        myVisible.SetActive(false);
    }

    private void OnMouseEnter()
    {
        myVisible.SetActive(true);
    }

    private void OnMouseExit()
    {
        myVisible.SetActive(false);
    }

    private void OnMouseDown()
    {
        Application.Quit();
    }
}
