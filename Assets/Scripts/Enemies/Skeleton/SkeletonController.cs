using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


/*
 * LINK PARA DOWNLOAD DO NAVMESHPLUS 2D
 *  https://github.com/h8man/NavMeshPlus 
 */

public class SkeletonController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private SkeletonAnimControl _animationControl;

    private PlayerController _player;

    private void Start() {
        _player = FindObjectOfType<PlayerController>();

        //nao atualiza a rotacao do eixo z do inimigo(por padrao o navmesh faz isso),
        //como é um jogo 2d, tem que ser configurado para nao rotacionar
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }

    private void Update() {
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
