using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class SFXManagement : MonoBehaviour
{
    [SerializeField] private GameObject objectToPool;
    [SerializeField] private SoundEffect[] sfx;
    [Range(1, 100)][SerializeField]private int amountToPool;
    private List<GameObject> pooledObjects;

    

    void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }

        sfx = new SoundEffect[transform.childCount];
        for (int i = 0; i < sfx.Length; i++)
        {
            sfx[i] = transform.GetChild(i).GetComponent<SoundEffect>();
        }
    }

    public void PlaySFX(string sfxName)
    {
        for(int i = 0; i < sfx.Length; i++)
        {
            if(sfxName == sfx[i].sfxName)
            {
                AudioSource playerSource = GetPooledObject().GetComponent<AudioSource>();
                playerSource.clip = sfx[i].sfx;
                playerSource.volume = sfx[i].sfxVolume;
                playerSource.gameObject.SetActive(true);
                playerSource.Play();
            }
        }
    }

    private GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return AddNew();
    }

    private GameObject AddNew()
    {
        //Debug.Log("CreatedNew");
        GameObject tmp;
        tmp = Instantiate(objectToPool);
        tmp.SetActive(false);
        pooledObjects.Add(tmp);
        return tmp;
    }
}
