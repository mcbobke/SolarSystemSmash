﻿using UnityEngine;
using System.Collections;

public class SunPlayerWithSound : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movement;
    private bool inputFlipped;
    private Vector3 mousePosition;

    public GameObject projPrefab;
    public GameObject projSpawnPoint;
    public SoundEffectManager soundPlayer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movement = new Vector2(0f, 5f);
        inputFlipped = false;
        mousePosition = Input.mousePosition;
    }

    private void Update()
    {
        // Input for movement
        if (!inputFlipped)
        {
            if (Input.GetKey(KeyCode.UpArrow))
                rb.AddForce(movement);
            else if (Input.GetKey(KeyCode.DownArrow))
                rb.AddForce(-movement);
        }

        else
        {
            if (Input.GetKey(KeyCode.UpArrow))
                rb.AddForce(-movement);
            else if (Input.GetKey(KeyCode.DownArrow))
                rb.AddForce(movement);
        }

        // Testing out a looping sound effect
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            soundPlayer.PlaySoundEffectLoop("moon_grab", 0.8f);
        }
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            soundPlayer.StopLoopingPlayback();
        }

        // Getting mouse position and then making sure that the sun faces the mouse with it's "up" vector
        mousePosition = Input.mousePosition;

        Vector3 diff = Camera.main.ScreenToWorldPoint(mousePosition) - transform.position;
        diff.Normalize();

        float rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ - 90);

        // Fire
        if (Input.GetMouseButtonDown(0))
            Fire(mousePosition);
    }

    private void Fire(Vector3 mousePosition)
    {
        Quaternion projRotation = transform.rotation;
        GameObject proj = (GameObject)Instantiate(projPrefab, projSpawnPoint.transform.position, projRotation);
        proj.GetComponent<Rigidbody2D>().AddForce(proj.transform.up * 500f);
        soundPlayer.PlaySoundEffect("sun_shoot", 0.5f);
    }
}
