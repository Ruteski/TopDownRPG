using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Dialogue : MonoBehaviour
{
    [SerializeField] private float _dialogueRange;
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private DialogueSettings _dialogue;

    private bool _playerHit;
    private List<string> _sentences = new List<string>();

    private void Start() {
        GetNPCInfo();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && _playerHit) {
            DialogControl.instance.Speech(_sentences.ToArray());
        }
    }

    private void GetNPCInfo() {
        for (int i = 0 ; i < _dialogue.dialogues.Count ; i++) {
            _sentences.Add(_dialogue.dialogues[i].sentence.portuguese);
        }
    }

    private void FixedUpdate() {
        ShowDialogue();
    }

    private void ShowDialogue() {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, _dialogueRange, _playerLayer);

        if (hit != null){
            _playerHit = true;
        } else {
            _playerHit = false;
            DialogControl.instance.dialogueObj.SetActive(false);
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(transform.position, _dialogueRange);
    }
}
