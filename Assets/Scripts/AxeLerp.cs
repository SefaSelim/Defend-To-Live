using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeLerp : MonoBehaviour
{
    [SerializeField] private Transform Axe;
    public bool throwing = false;

    private void Start()
    {
    }

    private void Update()
    {
        if (!throwing)
        {
            Axe.position = Vector3.Lerp(Axe.position, transform.position, Time.deltaTime * 10f);
        }
    }


}
