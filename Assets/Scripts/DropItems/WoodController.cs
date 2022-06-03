using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _timeMove;

    private float _timeCount;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timeCount += Time.deltaTime;

        if (_timeCount < _timeMove) {
            transform.Translate(Vector2.right * _speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            collision.GetComponent<Items>().TotalWood++;
            Destroy(gameObject);
        }
    }
}
