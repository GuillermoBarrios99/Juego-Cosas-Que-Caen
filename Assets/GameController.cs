using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public float TimeToSpawn;
    public float TimeToSpawnEnd;
    public float Points;
    public float SpawnNumber;
    public float SpawnNumberBadBox;
    public GameObject Canvas;
    public GameObject Box;
    public GameObject BadBox;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeToSpawn > TimeToSpawnEnd){
            TimeToSpawn = 0;
            Debug.Log("Spawn Coso");
            if (SpawnNumber == SpawnNumberBadBox){
                Instantiate(BadBox, new Vector3(Random.Range(-10,10),6,0), Quaternion.identity);
                SpawnNumber = 0;
                SpawnNumberBadBox = Random.Range(2,5);
            } else {
                Instantiate(Box, new Vector3(Random.Range(-10,10),6,0), Quaternion.identity);
                SpawnNumber++;
            }
        }
        TimeToSpawn += Time.deltaTime;
        Canvas.GetComponent<Text>().text= "PUNTOS: "+Points;
    }
}
