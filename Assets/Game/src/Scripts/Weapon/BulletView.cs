using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletView : MonoBehaviour
{
    
    private Rigidbody rigidBodyRef;
    public PoolManager poolManager;

    void Awake()
    {
        rigidBodyRef = transform.GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
       poolManager = GameObject.Find("PoolManager").GetComponent<PoolManager>();
    }

    void OnEnable()
    {
        rigidBodyRef.velocity = Vector3.forward * 100;
        StartCoroutine(Timeout());
    }

    void OnDisable()
    {
         rigidBodyRef.velocity = Vector3.zero;
    }
    private void OnTriggerEnter(Collider other)
    {
        if( other.CompareTag("Wall"))
        {
            Debug.Log("BatinaBatata");
            poolManager.Add("bullet", gameObject);
        }

    }

    public IEnumerator Timeout()
    {
        yield return new WaitForSeconds(3.0f);
        poolManager.Add("bullet", gameObject);
    }
    
}
