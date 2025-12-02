using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float _speed = 4.0f;

    private Player _player;
    private Animator _anim;
    private AudioSource _explosionSound;

    [SerializeField]
    private GameObject _laserPrefab;
    private float _fireRate = 3.0f;
    private float _canFire = -1;

    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        if (_player == null)
        {
            Debug.LogError("Player is Null");

        }

        _anim = GetComponent<Animator>();

        if (_anim == null)
        {
            Debug.LogError("Anim is NULL");
        }

        _explosionSound = GetComponent<AudioSource>();

        if (_explosionSound == null)
        {
            Debug.LogError("Audio Sourcer is NULL");
        }
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMoviment();

        if (Time.deltaTime > _canFire)
        {
            _fireRate = Random.Range(3.0f, 7.0f);
            _canFire = Time.deltaTime + _fireRate;
            Instantiate(_laserPrefab, transform.position, Quaternion.identity);
        }

    }

    void CalculateMoviment()
    {
        transform.Translate(Vector3.down * Time.deltaTime * _speed);

        if (transform.position.y < -5.0f)
        {
            float randomX = Random.Range(-8.0f, 8.0f);
            transform.position = new Vector3(randomX, 7, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {

            Player player = other.transform.GetComponent<Player>();

            if (player != null)
            {
                player.Damage();
            }


            _anim.SetTrigger("OnEnemyDeath");
            _speed = 0.1f;
            _explosionSound.Play();
            Destroy(this.gameObject, 2.5f);

        }

        if (other.gameObject.CompareTag("Laser"))
        {
            Destroy(other.gameObject);
            if (_player != null)
            {
                _player.AddScore(10);
            }

            _anim.SetTrigger("OnEnemyDeath");
            _speed = 0.1f;
            _explosionSound.Play();

            Destroy(GetComponent<Collider2D>());
            Destroy(this.gameObject, 2.5f);
        }
    }
}
