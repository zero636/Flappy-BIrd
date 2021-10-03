using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.TextCore;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject container;
    [SerializeField] private int capacity;

    private Camera _camera;

    private List<GameObject> pool = new List<GameObject>();

    protected void Initialized(GameObject prefab)
    {
        _camera = Camera.main;

        for (int i = 0; i < capacity; i++)
        {
            var spawned = Instantiate(prefab, container.transform);
            spawned.SetActive(false);
            
            pool.Add(spawned);
        }
    }


    protected bool TryGetObject(out GameObject result)
    {
        result = pool.FirstOrDefault(p => p.activeSelf == false);

        return result != null;
    }


    protected void DisableObjectAbroadScreen()
    {
        var disablePoint = _camera.ViewportToWorldPoint(new Vector2(0, 0.5f));

        foreach (var item in pool)
        {
            if (item.activeSelf)
            {

                if (item.transform.position.x < disablePoint.x)
                    item.SetActive(false);
            }
        }
    }
    
    public void ResetPool()
    {
        foreach (var item in pool)
        {
            item.SetActive(false);
        }
    }
}
