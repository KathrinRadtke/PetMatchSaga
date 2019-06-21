using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet : MonoBehaviour
{
    public enum Type
    {
        Cat,
        Deer,
        Dog,
        Duck,
        Frog
    }

    public Type type;
    [SerializeField] private GameObject destroyParticle;
    [SerializeField] private ParticleSystem selectParticle;

    public void Select()
    {
        transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        selectParticle.Play();
    }

    public void Deselect()
    {
        transform.localScale = Vector3.one;
        selectParticle.Stop();
    }

    public void Destroy()
    {
        Instantiate(destroyParticle, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
