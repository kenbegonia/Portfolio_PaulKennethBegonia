using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public int m_damage;
    public Unit m_caster;
    private float m_speed = 7.5f;
    private ParticleSystem particle;

    private void Start()
    {
        particle = GetComponent<ParticleSystem>();
        //particle.startColor = new Color(0.2f, 0.3f, 0.4f);
        this.transform.rotation = m_caster.transform.rotation;
        particle.transform.rotation = this.transform.rotation;
    }

    void Update()
    {
        this.transform.Translate(Vector3.forward * m_speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == null)
        {
            Debug.Log("Hit nothing");
            Destroy(gameObject, 3.0f);
        }

        Unit unit = other.gameObject.GetComponent<Unit>();

        //Dont deduct if it hits the caster's collider
        if (unit != m_caster)
            unit.DeductHealth(m_damage);

        Debug.Log("Hit!");
        Destroy(gameObject);
    }
}
