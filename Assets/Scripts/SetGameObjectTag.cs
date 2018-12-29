using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGameObjectTag : MonoBehaviour {
    public enum Tags { Item_1, Item_2, Item_3, Item_4, Item_5, Item_6, Item_7, Item_8, Item_9 , Item_10 };
    public Tags ItemTag = new Tags();

   
    void Start () {
        this.gameObject.tag = ItemTag.ToString();
    }
	
}
