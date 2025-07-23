using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegManager : MonoBehaviour
{
    public static PegManager instance;

    [SerializeField] private GameObject orangePegPrefab;
    [SerializeField] private int _orangePegCount;

    public int CurrentOrangePegs => GetRemainingOrangePegs();
    public int TotalOrangePegs => _orangePegCount;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        Peg[] bluePegs = FindObjectsOfType<Peg>();
        System.Random rand = new System.Random();

        List<Peg> bluePegList = new List<Peg>(bluePegs);

        for (int i = 0; i < bluePegList.Count; i++)
        {
            int j = rand.Next(i, bluePegList.Count);
            Peg temp = bluePegList[i];
            bluePegList[i] = bluePegList[j];
            bluePegList[j] = temp;
        }

        for (int i = 0; i < Mathf.Min(_orangePegCount, bluePegList.Count); i++)
        {
            Vector3 position = bluePegList[i].transform.position;
            Quaternion rotation = bluePegList[i].transform.rotation;
            Destroy(bluePegList[i].gameObject);
            Instantiate(orangePegPrefab, position, rotation);
        }
    }

    public int GetRemainingOrangePegs()
    {
        Peg[] allPegs = FindObjectsOfType<Peg>();
        int count = 0;

        foreach (Peg peg in allPegs)
        {
            if (peg.isOrange && peg.gameObject.activeInHierarchy)
            {
                count++;
            }
        }

        return count;
    }
}
