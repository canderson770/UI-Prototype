using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PoolerScript : MonoBehaviour
{
	public static PoolerScript current;
	public GameObject pooledObject;
	public int pooledAmount = 20;
	public bool canGrow = true;

	public List<GameObject> pooledObjects;

	void Awake()
	{
		current = this;
	}

	void Start()
	{
		pooledObjects = new List<GameObject> ();
		for (int i = 0; i < pooledAmount; i++) 
		{
			GameObject obj = Instantiate (pooledObject) as GameObject;
			obj.SetActive (false);
			obj.transform.parent = gameObject.transform;
			pooledObjects.Add (obj);
		}
	}

	public GameObject GetPooledObject()
	{
		for (int i = 0; i < pooledObjects.Count; i++) 
		{
			if (!pooledObjects [i].activeInHierarchy) 
			{
				return pooledObjects [i];
			}
		}

		if (canGrow) 
		{
			GameObject obj = Instantiate (pooledObject) as GameObject;
			obj.SetActive (false);
			obj.transform.parent = gameObject.transform;
			pooledObjects.Add (obj);
			return obj;
		}

		return null;
	}
}
