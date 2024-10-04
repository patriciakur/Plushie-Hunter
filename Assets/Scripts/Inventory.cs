using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour
{
    [Serializable] public class Plushie{
        public string name;
        public GameObject contentChildElement;
        public bool isOwned;
        public GameObject plushiePrefab;
    }
    public Plushie[] plushies;

    // Start is called before the first frame update
    void Start()
    {
        /*foreach (Plushie plushie in plushies){
            plushie.contentChildElement.SetActive(false);
            plushie.isOwned = false;
        }
        foreach (string plushieName in GameManager.Instance.ownedPlushieNames){
            AddPlushie(plushieName);
        }*/
    }

    public void AddPlushie(string name){
        Plushie current = Array.Find(plushies, x => x.name == name);
        if (current != null){
            current.isOwned = true;
            current.contentChildElement.SetActive(true);
        }
    }
}
