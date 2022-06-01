using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Dialogue : MonoBehaviour
{
    [SerializeField] private float _dialogueRange;
    [SerializeField] private LayerMask _playerLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        ShowDialogue();
    }

    private void ShowDialogue() {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, _dialogueRange, _playerLayer);

        if (hit != null){
            print("player na area de colisao");
        } else {

        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(transform.position, _dialogueRange);
    }
}
