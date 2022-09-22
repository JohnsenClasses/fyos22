using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    List<GameObject> boxes = new List<GameObject>();
    int numHits = 0;
    float minTime = 1;
    float maxTime = 3;

    [SerializeField]
    GameObject boxToSpawn;
    [SerializeField]
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnBoxes());
    }

    IEnumerator spawnBoxes()
	{
		while (true)
		{
            yield return new WaitForSeconds(Random.Range(minTime, maxTime));
            GameObject box = Instantiate(boxToSpawn);
            boxes.Add(box);
            box.transform.position = player.position +
                                     player.forward * Random.Range(-1,1)+
                                     player.right * Random.Range(-1,1);
		}
        yield return null;
	}
}
