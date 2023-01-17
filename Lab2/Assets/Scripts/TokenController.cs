using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TokenController : MonoBehaviour
{
    [SerializeField] private int points = 1;

    private InterfaceController interfaceController;

    private void OnTriggerEnter(Collider other)
    {
        interfaceController = FindObjectOfType<InterfaceController>();
        if (other.gameObject.CompareTag("Player"))
        {
            interfaceController.Add(points);
            Destroy(gameObject);
        }
    }

}
