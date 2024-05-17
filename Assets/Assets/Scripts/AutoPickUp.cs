using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AutoPickup : MonoBehaviour
{
    public Image pickupImage; // Eşyayı toplamak için ekranda gösterilecek metin
    public TMP_Text itemCounterText; // Toplanan eşya sayısını göstermek için UI Text
    private GameObject nearbyItem; // Yakındaki eşya
    private bool isNearItem = false; // Yakında eşya var mı?
    private int itemCount = 0; // Toplanan eşya sayısı

    private void Update()
    {
        if (isNearItem)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                CollectItem();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            nearbyItem = other.gameObject;
            isNearItem = true;
            pickupImage.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == nearbyItem)
        {
            nearbyItem = null;
            isNearItem = false;
            pickupImage.gameObject.SetActive(false);
        }
    }

    private void CollectItem()
    {
        if (nearbyItem != null)
        {
            // Eşyayı topla
            Destroy(nearbyItem);
            nearbyItem = null;
            isNearItem = false;
            pickupImage.gameObject.SetActive(false);

            // Toplanan eşya sayısını artır
            itemCount++;
            itemCounterText.text = "Toplanan Eşyalar: " + itemCount;
        }
    }
}
