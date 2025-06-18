using System.Collections;
using System.Numerics;
using System.Text.RegularExpressions;
using Unity.Mathematics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UIElements;
using UnityEngine.Windows;
using Input = UnityEngine.Input;
using Vector3 = UnityEngine.Vector3;

public class Player : MonoBehaviour
{

    [SerializeField]
    private float _speed = 3.5f;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _tripleShotPrefab;
    private float _canFire = -1f;
    [SerializeField]
    private float _fireRate = 0.5f;
    [SerializeField]
    private int _lives = 3;
    private SpawnManager _spawnManager;
    [SerializeField]
    private bool _isTripleShotActived = false;
    [SerializeField]
    private bool _isShieldupActived = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()

    {
        transform.position = new Vector3(0, -3, 0);
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

        if (_spawnManager == null)
        {
            Debug.LogError("Spawn NULL");
        }
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
        FireLaser();

    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);

        transform.Translate(direction * _speed * Time.deltaTime);

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.8f, 0), 0);

        if (transform.position.x > 11.3f)
        {
            transform.position = new Vector3(-11.3f, transform.position.y, 0);
        }
        else if (transform.position.y < -11.3f)
        {
            transform.position = new Vector3(11.3f, transform.position.y, 0);
        }
    }

    void FireLaser()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            _canFire = Time.time + _fireRate;


            if (_isTripleShotActived == true)
            {
                Instantiate(_tripleShotPrefab, transform.position + new Vector3(0.6f, 0.8f, 0), UnityEngine.Quaternion.identity);
            }
            else
            {
                Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.8f, 0), UnityEngine.Quaternion.identity);

            }

        }
    }

    public void Damage()
    {

        if (_isShieldupActived == true)
        {
            _isShieldupActived = false;
            return;
        }
        
        _lives--;

        if (_lives < 1)
        {
            Destroy(this.gameObject);
            _spawnManager.OnPlayerDeath();
        }
    }

    public void TripleShotActive()
    {
        _isTripleShotActived = true;
        StartCoroutine(TripleShotDownRoutine());
    }

    IEnumerator TripleShotDownRoutine()
    {

        yield return new WaitForSeconds(5.0f);
        _isTripleShotActived = false;
    }

    public void SpeedupActive()
    {
        _speed = 7.0f;
        StartCoroutine(SpeedupDownRoutine());
    }

    IEnumerator SpeedupDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        _speed = 3.5f;
    }
    

    public void ShieldupActive()
    {
        _isShieldupActived = true;
        
    }

}
