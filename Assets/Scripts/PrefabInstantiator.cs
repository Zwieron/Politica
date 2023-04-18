using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabInstantiator : MonoBehaviour
{
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
        Instantiate(prefab);
    }
    public void instantiatePrefab(Transform prefab)
    {
        Instantiate(prefab);
    }
    public void instantiatePrefab(Transform prefab, Vector2 position)
    {
        Instantiate(prefab, position, Quaternion.identity);
    }
    void instantiatePrefabMultipleTimes(int i)
    {
        for(int j = 0; j < i; j++)
        {
            Instantiate(prefab);
        }
    }
}
