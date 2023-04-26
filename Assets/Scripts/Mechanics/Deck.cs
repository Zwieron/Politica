using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{   
    public List<Transform> prefabList = new List<Transform>();
    public List<int> prefabCountList = new List<int>();
    Transform lastDrawCard;
    // Start is called before the first frame update
    void Start()
    {
        addPrefabsAndCountToList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void addPrefabsAndCountToList()
    {
        Dictionary<Transform, int> prefabDictionary = new Dictionary<Transform, int>();
        for(int i = 0; i< prefabList.Count; i++)
        {
            prefabDictionary.Add(prefabList[i], prefabCountList[i]);
        }
        prefabList.Clear();
        foreach(KeyValuePair<Transform, int> prefab in prefabDictionary)
        {
            for(int i = 0; i< prefab.Value; i++)
            {
                prefabList.Add(prefab.Key);
            }
        }
    }
    
    public Card drawCard()
    {
        int i = Random.Range(0, prefabList.Count);
        return prefabList[i].GetComponent<Card>();
    }
    public Transform drawTransform()
    {
        int i = Random.Range(0, prefabList.Count);
        lastDrawCard = prefabList[i];
        return prefabList[i];
    }
    public int getDeckCount()
    {
        return prefabList.Count;
    }

    public void removeLastDrawnCard()
    {
        prefabList.Remove(lastDrawCard);
    }
}
