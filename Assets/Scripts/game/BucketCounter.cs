using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketCounter : MonoBehaviour
{
    //MnE_Dia_pos

    [SerializeField] private AudioClip bucketSFX;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (bucketSFX != null)
            AudioSource.PlayClipAtPoint(bucketSFX, transform.position);

        BallCounter.counter.AddBall();
        GameObject.Destroy(collision.gameObject);
        ScoreManager.instance.CommitScoreAsync();
        StartCoroutine(PegDeletion.pegDeletion.DestroyPegs());
    }
}
