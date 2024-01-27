using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormsSpawner : MonoBehaviour
{
    public float interval = 1f;
    public int maxWorms = 1;
    public float intervalInc = 0.1f;
    public int wormIncrementor = 1;

    public Worm wormPrefab;
    public RectTransform[] spawnAreas;

    int incremations = 0;
    int wormsSpawned = 0;
    Coroutine loop;

    public List<string> goodWords = new List<string> { "good", "apple", "yay"};
    public List<string> badWords = new List<string> { "bad", "orange", "nay" };

    public List<string> nextGoodWorks = new List<string> ();
    public List<string> nextbadWorks = new List<string>();


    private void Start()
    {
        GetWords();
        loop = StartCoroutine(Spawner());
    }

    private void GetWords()
    {
        WordsCollection wc = new WordsCollection();
        int totalSubs = wc.ProcessText(0, out List<SubtituableWord> subs);
        //load good words
        goodWords.Clear();
        badWords.Clear();
        for (int i = 0; i < totalSubs; i++)
        {
            goodWords.Add(subs[i].originalWord);
            switch (subs[i].type)
            {
                case WordType.adjective:
                    badWords.Add(wc.BadAdjectives[Random.Range(0, wc.BadAdjectives.Length)]);
                    badWords.Add(wc.BadAdjectives[Random.Range(0, wc.BadAdjectives.Length)]); 
                    break;
                case WordType.noun:
                    badWords.Add(wc.BadVNouns[Random.Range(0, wc.BadVNouns.Length)]);
                    badWords.Add(wc.BadVNouns[Random.Range(0, wc.BadVNouns.Length)]);
                    break;
                case WordType.verb:
                    badWords.Add(wc.BadVerbs[Random.Range(0, wc.BadVerbs.Length)]);
                    badWords.Add(wc.BadVerbs[Random.Range(0, wc.BadVerbs.Length)]);
                    break;
            }
        }
        //load bad word
        
        goodWords.Shuffle();
        badWords.Shuffle();
    }

 


    IEnumerator Spawner()
    {
        yield return new WaitForSeconds(interval);
        int goodIdx = 0;
        int badIdx = 0;
        while (true)
        {
            for (int i = 0; i < maxWorms; ++i)
            {
                int area = Random.Range(0, Mathf.Min(incremations, spawnAreas.Length));
                Vector3 instaPoint = GetRandomPointInRect(spawnAreas[area]);
                Worm w = Instantiate(wormPrefab, instaPoint, Quaternion.identity, spawnAreas[area]);
                if (Random.value < (float)goodWords.Count / ((float)goodWords.Count + badWords.Count))
                {
                    string wrd = goodWords[goodIdx % goodWords.Count];
                    w.SetWord(wrd, true, ()=>nextGoodWorks.Add(wrd));
                    goodIdx++;
                }
                else
                {
                    string wrd = badWords[badIdx % badWords.Count];
                    w.SetWord(wrd, false, () => nextbadWorks.Add(wrd));
                    badIdx++;
                }
                w.Appear();
                ++wormsSpawned;
                yield return new WaitForSeconds(interval);
            }
            if (wormsSpawned > maxWorms)
            {
                incremations++;
                maxWorms += wormIncrementor;
                interval -= intervalInc;

                if (incremations >= 9)
                    StopCoroutine(loop);
                else
                    yield return new WaitForSeconds(interval);
            }
        }
    }

    public Vector3 GetRandomPointInRect(RectTransform rt)
    {
        Vector3[] corners = new Vector3[4];
        rt.GetWorldCorners(corners);

        Rect rect = rt.rect;
        float x = Random.Range(corners[0].x, corners[2].x);
        float y = Random.Range(corners[0].y, corners[2].y);

        return new Vector3(x, y, corners[0].z);
    }
}
