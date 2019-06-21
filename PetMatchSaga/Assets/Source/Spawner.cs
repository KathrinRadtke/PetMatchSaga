using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] pets;
    private float range = 8f;
    private int petCount = 60;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Spawn(petCount);
    }

    public void Spawn(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Vector3 position = transform.position;
            
            //position = new Vector3(Random.Range(position.x - range, position.x + range), Random.Range(position.y - range, position.y + range), position.z);
            position = position + (Vector3)Random.insideUnitCircle * range;
            Instantiate(pets[Random.Range(0,pets.Length)], position, Quaternion.identity);
        }
    }
}
