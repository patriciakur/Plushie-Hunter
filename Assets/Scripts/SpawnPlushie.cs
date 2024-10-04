using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlushie : MonoBehaviour
{
    [SerializeField] public GameObject plushiePrefab;

    // Start is called before the first frame update
    public void Spawn()
    {
        Vector3 tempPosition = new Vector3(0, 0.1f, 0.3f);
        Instantiate(plushiePrefab, transform.position+tempPosition, Quaternion.identity);
    }
}
