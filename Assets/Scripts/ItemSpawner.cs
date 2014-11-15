using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemSpawner : MonoBehaviour {
    private List<GameObject> items;
    private List<Vector3> locations;
    private Dictionary<int, int> locationToObjectId;
    private GameObject chocolate;
    private float lastSpawnTime;

    /// <summary>
    /// Seconds per item
    /// </summary>
    public float SpawnPeriod;

	void Start () {
        chocolate = Resources.Load("Objects/Chocolate") as GameObject;
        SpawnPeriod = 5; 
        items = new List<GameObject>();
        locations = new List<Vector3>();
        locationToObjectId = new Dictionary<int,int>();

	    lastSpawnTime = Time.time;
        foreach(GameObject go in GameObject.FindGameObjectsWithTag("ItemSpawn"))
            locations.Add(go.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
	    if((Time.time - lastSpawnTime) > SpawnPeriod)
            SpawnItem();
	}

    void SpawnItem()
    {
        if(items.Count == locations.Count)
            return;

        int locationInd = Random.Range(0, locations.Count - 1);
        while(locationToObjectId.ContainsKey(locationInd))
        {
            locationInd = (++locationInd)%locations.Count;
        }
        Vector3 pos = locations[locationInd];
        GameObject item = Instantiate(chocolate, pos, Quaternion.Euler(270,0,0)) as GameObject;
        
        Chocolate chococompo = item.GetComponent<Chocolate>();
        if(chococompo != null)
        {
            chococompo.itemSp = this;
            chococompo.locationId = locationInd;
        }

        items.Add(item);
        locationToObjectId.Add(locationInd, item.GetInstanceID());
        lastSpawnTime = Time.time;
    }

    public void RemoveItemAtLocation(GameObject obj, int locid)
    {
        items.Remove(obj);
        locationToObjectId.Remove(locid);
    }
}
