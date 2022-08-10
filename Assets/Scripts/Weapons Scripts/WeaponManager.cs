using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _projectiles;
    [SerializeField] private Transform[] _projectileSpawnPoints;
    [SerializeField] private float _shootTimerThreshold = 0.2f;

    private float _shootTimer;
    private bool _canShoot;

    private void Update()
    {
        if (Time.time > _shootTimer)
            _canShoot = true;

        HandlePlayerShooting();
    }

    private void HandlePlayerShooting()
    {
        if (!_canShoot)
            return;

        //shoot blaster 1
        if (Input.GetKeyDown(KeyCode.J))
        {
            Instantiate(_projectiles[0], _projectileSpawnPoints[0].position, Quaternion.identity);

            Instantiate(_projectiles[0], _projectileSpawnPoints[1].position, Quaternion.identity);

            ResetShootingTimer();
        }

        //shoot blaster 2
        if (Input.GetKeyDown(KeyCode.K))
        {
            Instantiate(_projectiles[1], _projectileSpawnPoints[0].position, Quaternion.identity);

            Instantiate(_projectiles[1], _projectileSpawnPoints[1].position, Quaternion.identity);

            ResetShootingTimer();
        }

        // shoot laser
        if (Input.GetKeyDown(KeyCode.L))
        {
            Instantiate(_projectiles[2], _projectileSpawnPoints[0].position, Quaternion.identity);

            Instantiate(_projectiles[2], _projectileSpawnPoints[1].position, Quaternion.identity);

            ResetShootingTimer();
        }

        // shoot rocket
        if (Input.GetKeyDown(KeyCode.O))
        {
            Instantiate(_projectiles[3], _projectileSpawnPoints[2].position, Quaternion.identity);
          
            ResetShootingTimer();
        }

        // shoot mesile
        if (Input.GetKeyDown(KeyCode.P))
        {
            Instantiate(_projectiles[4], _projectileSpawnPoints[2].position, Quaternion.identity);

            ResetShootingTimer();
        }
    }

    void ResetShootingTimer()
    {
        _canShoot = false;
        _shootTimer = Time.time + _shootTimerThreshold;
    }

}
