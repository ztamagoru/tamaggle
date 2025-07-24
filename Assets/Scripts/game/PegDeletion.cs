using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegDeletion : MonoBehaviour
{
    public static PegDeletion pegDeletion = new PegDeletion();
    //public static PegDeletion pegDeletion;

    private AudioClip pegDestroySFX;

    private float waitTime = 0.03f;

    public PegDeletion()
    {
        pegDestroySFX = Resources.Load<AudioClip>("SFX/pegpop");
    }

    public IEnumerator DestroyPegs()
    {
        Peg[] pegs = FindObjectsOfType<Peg>();
        foreach (Peg peg in pegs)
        {
            if (peg.deleteOnFall)
            {
                if (pegDestroySFX != null)
                    AudioSource.PlayClipAtPoint(pegDestroySFX, peg.transform.position);

                GameObject.Destroy(peg.gameObject);
                yield return new WaitForSeconds(waitTime);
            }
        }
    }
}
