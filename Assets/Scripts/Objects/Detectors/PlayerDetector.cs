using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDetector : MonoBehaviour
{
    // Variables publicas
    public float timeToFinish;
    public UnityEvent OnPlayerDetected, AfterTime;

    private void OnTriggerEnter(Collider other)
    {
        // Si el player colisiona con el trigger
        if (other.CompareTag("Player"))
        {
            // Activamos el primer evento
            OnPlayerDetected.Invoke();

            // Apagamos el collider
            GetComponent<Collider>().enabled = false;

            // Activamos la corrutina
            StartCoroutine(AfterTimeEvent());
        }
    }

    IEnumerator AfterTimeEvent()
    {
        // Esperamos el tiempo indicado
        yield return new WaitForSeconds(timeToFinish);

        // Activamos el segundo evento
        AfterTime.Invoke();

        // Desactivamos este objeto
        gameObject.SetActive(false);
    }
}
