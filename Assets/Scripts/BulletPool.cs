using UnityEngine;
using System.Collections.Generic;

public class BulletPool : MonoBehaviour
{
    public static BulletPool instance;
    public GameObject bulletPrefab;
    public int amount = 20;

    private List<GameObject> pooledBullets = new List<GameObject>();

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        for (int i= 0; i < amount; i++)
        {
            GameObject obj = Instantiate(bulletPrefab);
            obj.SetActive(false);
            pooledBullets.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for(int i = 0; i < pooledBullets.Count; i++){
            if (!pooledBullets[i].activeInHierarchy)
            {
                return pooledBullets[i];
            }
        }
        return null;
    }
}
