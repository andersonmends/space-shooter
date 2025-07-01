using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private float _rotateSpeed = 3f;
    [SerializeField]
    private GameObject _explosion;
    [SerializeField]
    private SpawnManager _spawnManager;
    // private AudioSource _explosionAudioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

        if (_spawnManager == null)
        {
            Debug.LogError("Spawn manager is NULL");
        }

        // _explosionAudioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * _rotateSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Laser")
        {
            Instantiate(_explosion, transform.position, Quaternion.identity);
            _spawnManager.StartSpawning();
            // _explosionAudioSource.Play();
            Destroy(other);
            Destroy(this.gameObject,0.25f);
        }
    }
}
