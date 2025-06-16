using Unity.VisualScripting;
using UnityEngine;

public class Laser : MonoBehaviour
{

    private float _speed = 8.2f;
   
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * _speed);

    if (transform.position.y > 8f)
    {
        if (transform.parent != null)
        {
            
            Destroy(transform.parent.gameObject);
        }
            Destroy(this.gameObject);
    }


    }
}
