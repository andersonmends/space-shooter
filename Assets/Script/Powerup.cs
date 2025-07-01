using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;
    [SerializeField]
    private int _powerupID; //0: tripleshot 1: speedup 2:shieldup
    [SerializeField]
    private AudioClip _powerupSound;
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

        AudioSource.PlayClipAtPoint(_powerupSound, transform.position);

        if (other.tag == "Player")
        {

            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                switch (_powerupID)
                {

                    case 0:
                        player.TripleShotActive();
                        break;
                    case 1:
                        player.SpeedupActive();
                        break;
                    case 2:
                        player.ShieldupActive();
                        break;

                }


            }
            Destroy(this.gameObject);
        }

    }
}
