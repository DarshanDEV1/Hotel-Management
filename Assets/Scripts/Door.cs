using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] Transform _Door;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.GetComponent<Collider>().CompareTag("Player") || collision.GetComponent<Collider>().CompareTag("Customer"))
        {
            StartCoroutine(Door_Open(1f));
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.GetComponent<Collider>().CompareTag("Player") || collision.GetComponent<Collider>().CompareTag("Customer"))
        {
            StartCoroutine(Door_Open(1f));
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.GetComponent<Collider>().CompareTag("Player") || collision.GetComponent<Collider>().CompareTag("Customer"))
        {
            StartCoroutine(Door_Close(1f));
        }
    }

    private IEnumerator Door_Close(float _t)
    {
        Quaternion startRotation = _Door.rotation;
        Quaternion endRotation = Quaternion.Euler(0, 0, 0);

        for (float t = 0; t < _t; t += Time.deltaTime)
        {
            float progress = t / _t;
            _Door.rotation = Quaternion.Lerp(startRotation, endRotation, progress);
            yield return null;
        }

        // Ensure the rotation is exactly the end rotation when the duration is over
        _Door.rotation = endRotation;
    }

    private IEnumerator Door_Open(float _t)
    {
        float _i_t = 0f;
        Quaternion startRotation = _Door.rotation;
        Quaternion endRotation = Quaternion.Euler(0, -90, 0);

        while (_i_t < _t)
        {
            _i_t += Time.deltaTime;
            float progress = _i_t / _t;

            _Door.rotation = Quaternion.Lerp(startRotation, endRotation, progress);

            yield return null;
        }
    }

}
