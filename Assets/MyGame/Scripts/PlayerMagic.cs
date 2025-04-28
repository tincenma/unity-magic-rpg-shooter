using UnityEngine;

public class PlayerMagic : MonoBehaviour
{
    [Header("References")]
    public Transform firePoint;              // ваш FirePoint (рука)
    public GameObject projectilePrefab;      // префаб MagicProjectile
    public GameObject shootSplashPrefab;     // StarShootSplash
    public GameObject inHandEffectPrefab;    // StarInHand

    [Header("Sound")]
    public AudioClip shootClip;         // звук выстрела
    private AudioSource _audioSource;

    [Header("Settings")]
    public float projectileSpeed = 10f;

    private Animator _anim;
    private GameObject _currentInHandEffect;

    void Start()
    {
        _anim = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
            _audioSource = gameObject.AddComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _anim.SetTrigger("CastSpell");

            if (inHandEffectPrefab != null && _currentInHandEffect == null)
            {
                _currentInHandEffect = Instantiate(
                    inHandEffectPrefab,
                    firePoint.position,
                    firePoint.rotation,
                    firePoint
                );
            }
        }
    }

    public void ShootMagic()
    {
        if (_currentInHandEffect != null)
        {
            Destroy(_currentInHandEffect);
            _currentInHandEffect = null;
        }

        if (shootClip != null)
            _audioSource.PlayOneShot(shootClip);

        if (shootSplashPrefab != null)
            Instantiate(shootSplashPrefab, firePoint.position, firePoint.rotation);

        if (projectilePrefab != null)
        {
            var proj = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            var rb = proj.GetComponent<Rigidbody>();
            if (rb != null)
                rb.velocity = firePoint.forward * projectileSpeed;
        }
    }
}
