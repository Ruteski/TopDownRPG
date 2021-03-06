using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogControl : MonoBehaviour
{
    [System.Serializable]
    public enum Idiom {
        pt,
        eng
    }

    public Idiom language;

    [Header("Components")]
    public GameObject dialogueObj; //janela do dialogo
    public Image profileSprite; //sprite do perfil
    public Text speechText; //texto da fala
    public Text actorNameText; //nome do npc

    [Header("Settings")]
    public float typingSpeed; //velocidade da fala

    //variaveis de controle
    private bool _isShowing; //se a janela esta visivel
    private int _index; //index das sentenšas
    private string[] _sentences;

    public static DialogControl instance;

    public bool IsShowing { get => _isShowing; set => _isShowing = value; }

    private void Awake() {
        instance = this;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    IEnumerator TypeSentence() {
        //mostra letra por letra do dialogo
        foreach (char letter in _sentences[_index].ToCharArray()) {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        } 
    }

    //pula pra proxima frase/fala
    public void NextSentence() {
        if (speechText.text == _sentences[_index]) {
            if (_index < _sentences.Length - 1) {
                _index++;
                speechText.text = "";
                StartCoroutine(TypeSentence());
            } else { // quando terminam os textos
                speechText.text = "";
                _index = 0;
                dialogueObj.SetActive(false);
                _sentences = null;
                _isShowing = false;
            }
        }
    }

    //chamar a fala do npc
    public void Speech(string[] txt) {
        if (!_isShowing) { 
            dialogueObj.SetActive(true);
            _sentences = txt;

            StartCoroutine(TypeSentence());
            _isShowing = true;
        }
    }
}
