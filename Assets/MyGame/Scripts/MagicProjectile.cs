using UnityEngine;

public class MagicProjectile : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 5f;
    public GameObject hitEffectPrefab;
    public AudioClip hitClip;   // звук попадания

    private float _timer;

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        _timer += Time.deltaTime;
        if (_timer > lifetime) Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (hitEffectPrefab != null)
            Instantiate(hitEffectPrefab, transform.position, Quaternion.identity);

        if (hitClip != null)
            AudioSource.PlayClipAtPoint(hitClip, transform.position);

        Destroy(gameObject);
    }
}
