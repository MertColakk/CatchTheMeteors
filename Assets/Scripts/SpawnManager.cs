using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Variables
    ObjectPooler objectPooler;
    int spawnChance;

    void Start(){
        objectPooler = ObjectPooler.Instance;
        if (objectPooler == null)
            return;
        else
            StartCoroutine(spawnObject());
    }

    IEnumerator spawnObject(){
        while(true){
            spawnChance = spawnItemChance();

            if(spawnChance>=90)
                objectPooler.SpawnFromPool("GemStone",new Vector3(Random.Range(-10f,10f),7,0),Quaternion.identity);
            else if(spawnChance>=80)
                objectPooler.SpawnFromPool("Planet",new Vector3(Random.Range(-10f,10f),7,0),Quaternion.identity);
            else
                objectPooler.SpawnFromPool("Meteor",new Vector3(Random.Range(-10f,10f),7,0),Quaternion.identity);

            yield return new WaitForSeconds(1.2f);
        }
    }

    int spawnItemChance(){
        int rate = Random.Range(0,101);

        return rate;
    }

    

    
}

