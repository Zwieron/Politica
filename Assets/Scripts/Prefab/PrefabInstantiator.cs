using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabInstantiator : MonoBehaviour
{
    GameObject lastPrefab;
    public Transform prefab;
    public List<Transform> prefabList;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void instantiatePrefab()
    {
        lastPrefab = Instantiate(prefab).gameObject;
        //  Instantiate(prefab).gameObject;
    }
    public void instantiatePrefab(Transform prefab)
    {
        lastPrefab =Instantiate(prefab).gameObject;
    }
    public void instantiatePrefab(Transform prefab, Vector2 position)
    {
        lastPrefab = Instantiate(prefab, position, Quaternion.identity).gameObject;
    }
    void instantiateManyPrefabs(int i)
    {
        for(int j = 0; j < i; j++)
        {
            Instantiate(prefab);
        }
    }
    public GameObject getLastPrefab()
    {
        return lastPrefab;
    }

}
