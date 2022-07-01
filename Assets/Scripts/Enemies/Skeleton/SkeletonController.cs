using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

/*
 * LINK PARA DOWNLOAD DO NAVMESHPLUS 2D
 *  https://github.com/h8man/NavMeshPlus 
 */

public class SkeletonController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private SkeletonAnimControl _animationControl;
    [SerializeField] private Image _healthBar;
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _layerPlayer;

    private float _totalHealth = 10f;
    private float _health;
    private bool _isDead;
    private bool _detectPlayer;

    private PlayerController _player;
    

    public float Health { get => _health; set => _health = value; }
    public Image HealthBar { get => _healthBar; set => _healthBar = value; }
    public float TotalHealth { get => _totalHealth; set => _totalHealth = value; }
    public bool IsDead { get => _isDead; set => _isDead = value; }

    private void Start() {
        _health = _totalHealth;

        _player = FindObjectOfType<PlayerController>();

        //nao atualiza a rotacao do eixo z do inimigo(por padrao o navmesh faz isso),
        //como é um jogo 2d, tem que ser configurado para nao rotacionar
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }

    private void Update() {
        if (!_isDead && _detectPlayer) {
            _agent.isStopped = false;
            _agent.SetDestination(_player.transform.position);

            if (Vector2.Distance(transform.position, _player.transform.position) <= _agent.stoppingDistance) {
                //chegou no limite de distancia, esta parado
                _animationControl.PlayAnim(2);// 2 - attack

            } else {
                //segue o player
                _animationControl.PlayAnim(1);// 1 - walk
            }

            #region VERIFICACAO POSICAO DO PLAYER AO SKELETON

            // FORMA 1 DA VERIFICACAO SE O PLAYER ESTA A DIREITA OU A ESQUERDA DO SKELETON
            if (_player.transform.position.x < transform.position.x) {
                //esquerda
                transform.eulerAngles = new Vector2(0, -180);
            } else {
                //direita
                transform.eulerAngles = new Vector2(0, 0);
            }

            // FORMA 2 DA VERIFICACAO SE O PLAYER ESTA A DIREITA OU A ESQUERDA DO SKELETON
            //float posX = _player.transform.position.x - transform.position.x;

            //if (posX > 0) {
            //    //direita
            //    transform.eulerAngles = new Vector2(0, 0);
            //} else {
            //    //esquerda
            //    transform.eulerAngles = new Vector2(0, -180);
            //}

            #endregion
        }
    }

    private void FixedUpdate() {
        DetectPlayer();
    }

    public void DetectPlayer() {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, _radius, _layerPlayer);

        if (hit != null) {
            _detectPlayer = true;
        } else {
            _detectPlayer = false;
            _animationControl.PlayAnim(0);
            _agent.isStopped = true;
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
