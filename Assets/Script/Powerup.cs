using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if (transform.position.y <= -5f)
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // other.TripleShortEnable();
        if (other.tag == "Player")
        {

            Player player = other.GetComponent<Player>();

            if (player!= null)
            {
                player.TripleShotActive();
            }
            Destroy(this.gameObject);
        }

    }
}
