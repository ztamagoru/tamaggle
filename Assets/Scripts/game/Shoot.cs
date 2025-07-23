using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject ball;

    public float offset;

    [SerializeField] private AudioClip shootSFX;

    private GameObject currentBall;

    void Update()
    {
        if(BallCounter.counter.numBall > 0 && currentBall == null)
        {
            if (Input.GetMouseButton(0))
            {
                if (shootSFX != null)
                    AudioSource.PlayClipAtPoint(shootSFX, transform.position);

                currentBall = Instantiate(ball);
                currentBall.transform.position = transform.position - transform.up * offset;

                BallCounter.counter.RemoveBall();
                currentBall.GetComponent<Rigidbody2D>().AddForce(-transform.up * 9.81f, ForceMode2D.Impulse);
            }
        }
    }
}
