using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private GameObject healthBar;

    private Vector3 healthBarScale;

    [SerializeField] private float health = 100f;

    [SerializeField] private GameObject destroyEffect;
    [SerializeField] private GameObject hitEffect;

    public void TakeDamage(float damageAmount, float damageResistance)
    {
        damageAmount -= damageResistance;
        health -= damageAmount;

        if (health <= 0)
        {
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
            SoundManager.instance.PlayDestroySound();
            Destroy(gameObject);

        } else
        {
            SoundManager.instance.PlayDamageSound();
            Instantiate(hitEffect, transform.position, Quaternion.identity);
        }

        SetHealthBar();
    }

    void SetHealthBar()
    {
        if (!healthBar)
            return;

        healthBarScale = healthBar.transform.localScale;
        healthBarScale.x = health / 100f;
        healthBar.transform.localScale = healthBarScale;
    }

}
