using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public string[] ownedPlushieNames;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void AddPlushie(string plushieName)
    {
        ownedPlushieNames.Append(plushieName);
        Debug.Log("Plushie added: " + plushieName); 
    }

}
