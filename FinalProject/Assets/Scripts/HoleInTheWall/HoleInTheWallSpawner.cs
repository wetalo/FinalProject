using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleInTheWallSpawner : MonoBehaviour {

    public GameObject[] holeInTheWallPrefabs;
    public float holeSpeed;


    List<int> holesDone;

    public GameEvent beatGame;

    // Use this for initialization
    void Start () {
        holesDone = new List<int>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnHole()
    {
       if(holesDone.Count < holeInTheWallPrefabs.Length)
        {
            int currentHoleIndex;
            do {
                currentHoleIndex = Random.Range(0, holeInTheWallPrefabs.Length);
            } while (holesDone.Contains(currentHoleIndex));

            holesDone.Add(currentHoleIndex);
            GameObject currentHole = holeInTheWallPrefabs[currentHoleIndex];
            GameObject currentHoleInstance = Instantiate(currentHole, transform.position, currentHole.transform.rotation);
            currentHoleInstance.GetComponent<Rigidbody>().AddForce(transform.forward * holeSpeed, ForceMode.Impulse);
        } else
        {
            beatGame.Raise();
        }
        
    }
}
