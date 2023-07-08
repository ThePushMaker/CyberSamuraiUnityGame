using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntScript : MonoBehaviour
{
    
    public GameObject John;
    public GameObject BulletPrefab;

    private int Health = 3;
    private float LastShoot;

    // Update is called once per frame
    private void Update()
    {
        if (John == null) return; //esta linea saca de la función
        
        // Transform position es la posición del grunt
        // al retarlas obtenemos el vector que va de nosotros hacia john
        Vector3 direction = John.transform.position - transform.position;
        if (direction.x  >= 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        else transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

        // la funcion Mathf.Abs permite obtener siempre el valor absoluto (positivo)
        float distance = Mathf.Abs(John.transform.position.x - transform.position.x);

        if (distance < 5.0f && Time.time > LastShoot + 2.0f) {
            Shoot();
            LastShoot = Time.time;
        }

    }
    private void Shoot()
    {
        // Debug.Log("Shoot");

        Vector3 direction = new Vector3 (transform.localScale.x, 0.0f, 0.0f);


        // if (transform.localScale.x == 1.0f) direction=Vector2.right;
        // else direction= Vector2.left;

        // Esta funcion instantiate, lo que hace es toma un prefab, en este caso la bala y lo duplica en algun sitio del mundo
        // valores: QueObjeto, QueUbicacion, QueRotacion
        // Transform.position quiere decir que en nuestra ubicacion 
        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        // con esto obtenemos el componenteBulletScript
        bullet.GetComponent<BulletScript>().SetDirection(direction);

    }

    public void Hit() 
    {
        Health -= 1;
        if(Health == 0) Destroy(gameObject, 0);
    }
}
