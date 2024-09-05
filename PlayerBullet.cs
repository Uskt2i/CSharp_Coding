using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public int attackDamage = 10;
    public GameObject destroyFX;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //Debug.Log("touch");
            GameObject newSpawnObject = Instantiate(destroyFX, transform.position, Quaternion.Euler(0f, 0f, 0f));

            collision.gameObject.GetComponent<Health>().TakeDamage(attackDamage);

            Destroy(gameObject);
        }
    }
}
