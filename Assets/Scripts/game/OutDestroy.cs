using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutDestroy : MonoBehaviour
{
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.Destroy(collision.gameObject);
        ScoreManager.instance.CommitScoreAsync();
        StartCoroutine(PegDeletion.pegDeletion.DestroyPegs());
    }
}
