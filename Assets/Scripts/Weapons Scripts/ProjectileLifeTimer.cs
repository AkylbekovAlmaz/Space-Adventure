using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLifeTimer : MonoBehaviour
{

    [SerializeField] private float _timer = 3f;

    /*
    private void Start()
    {
        Destroy(gameObject, _timer);
    }
    */

    private void OnEnable()
    {
        Invoke("DeactivateProjectile", _timer) ;
    }

    private void OnDisable()
    {
        CancelInvoke("DeactivateProjectile");
    }

    void DeactivateProjectile()
    {
        if (gameObject.activeInHierarchy)
            gameObject.SetActive(false);
    }
}
