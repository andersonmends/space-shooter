using Unity.VisualScripting;
using UnityEngine;

public class Laser : MonoBehaviour
{

    private float _speed = 8.2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * _speed);

    if (transform.position.y > 8f)
    {
            Destroy(this.gameObject);
    }


    }
}
