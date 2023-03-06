using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private int oranges = 0;
    [SerializeField] private TMP_Text orangesText;
    [SerializeField] private AudioSource pickupItem;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Orange"))
        {
            pickupItem.Play();
            Destroy(collision.gameObject);
            oranges++;
            orangesText.text = "Oranges: " + oranges;
        }
    }
}
