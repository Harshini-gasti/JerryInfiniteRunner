using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawnManager : MonoBehaviour
{
    bool spawn;
    [SerializeField] GameObject currentPool;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    IEnumerator SpawnObjects()
    {
        while(!spawn)
        {
            yield return new WaitForSeconds(Random.Range(0.5f, 1f));
            //float x = Random.Range(-2.9f, 2.9f);
           
            //transform.position = new Vector3(x, transform.position.y, transform.position.z);

            GameObject g = currentPool.GetComponent<BasicObjectPooling>().GetPooledObject();
            if (g != null)
            {
                g.transform.position = new Vector3(transform.position.x, g.transform.position.y, transform.position.z);
                g.transform.rotation = transform.rotation;
                //g.transform.SetParent(transform);
                g.SetActive(true);
            }

            //yield return new WaitForSeconds(Random.Range(0.3f, 0.8f));
        }
        


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
