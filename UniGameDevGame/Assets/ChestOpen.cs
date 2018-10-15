using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpen : MonoBehaviour {

    public Sprite openedChest;
    private GameObject target;

    private void Start()
    {
        target = GameObject.Find("Player");
    }

    public void OpenChest()
    {
        GetComponent<SpriteRenderer>().sprite = openedChest;
        target.GetComponent<Animator>().SetBool("Equipped", true);
    }
}
