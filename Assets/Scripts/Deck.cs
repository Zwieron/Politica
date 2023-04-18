using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{   public Dictionary<Transform, int> prefabDictionary = new Dictionary<Transform, int>();
    public List<Transform> prefabList = new List<Transform>();
    public List<int> prefabCountList = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void addPrefabsAndCountToDictionary(List<Transform> prefabList, List<int> prefabCountList)
    {
        for(int i = 0; i< prefabList.Count; i++)
        {
            prefabDictionary.Add(prefabList[i], prefabCountList[i]);
        }
    }
}
