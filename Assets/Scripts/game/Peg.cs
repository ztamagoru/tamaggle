using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peg : MonoBehaviour
{
    [SerializeField] protected int value;

    [SerializeField] private AudioClip pegHitSFX;

    public GameObject shinePrefab;

    public bool deleteOnFall = false;
    public bool isOrange = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball") && !deleteOnFall)
        {
            deleteOnFall = true;

            if (pegHitSFX != null)
                AudioSource.PlayClipAtPoint(pegHitSFX, transform.position);

            GameObject shine = Instantiate(shinePrefab, transform.position, Quaternion.identity, transform);
            ScoreManager.instance.AddScore(value);
        }
    }
}
