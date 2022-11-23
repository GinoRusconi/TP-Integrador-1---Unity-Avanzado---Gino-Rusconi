using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMVC : MonoBehaviour
{
    public Item item;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ManagerControllerLvl1.Instance.PickItem(item);
            Destroy(this.gameObject);
        }
    }
}
