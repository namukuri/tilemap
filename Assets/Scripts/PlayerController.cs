using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("�ړ����x")]
    public float moveSpeed;

    private Rigidbody2D rd; // �R���|�[�l���g�̎擾�p

    private float horizontal;  // x ��(�����E��)�����̓��͂̒l�̑���p
    private float vertical; //y ��(�����E�c)�����̓��͂̒l�̑���p

    private Animator anim;  // �R���|�[�l���g�̎擾�p

    private Vector2 lookDirection = new Vector2(0f, -1.0f);  // �L�����̌����̏��̐ݒ�p

    // Start is called before the first frame update
    void Start()
    {
        // ���̃X�N���v�g���A�^�b�`����Ă���Q�[���I�u�W�F�N�g�ɃA�^�b�`����Ă���R���|�[�l���g�̒�����A<�w��>�����R���|�[�l���g�̏����擾���āA���ӂɗp�ӂ����ϐ��ɑ��
        rd = GetComponent<Rigidbody2D>(); // ���邢�́ATryGeyComponent(out rb);�@�ł���

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // InputManager �� Horizontal �ɓo�^���Ă���L�[�����͂��ꂽ��A����(��)�����̓��͒l�Ƃ��đ��
        horizontal = Input.GetAxis("Horizontal");

        // InputManager �� Vertical �ɓo�^���Ă���L�[�����͂��ꂽ��A����(��)�����̓��͒l�Ƃ��đ��
        vertical = Input.GetAxis("Vertical");

        // �L�����̌����Ă�������ƈړ��A�j���̓���
        SyncMoveAnimation();
    }

    private void FixedUpdate()
    {
        // �ړ�
        Move();
    }

    /// <summary>
    /// �ړ�
    /// </summary>
    private void Move()
    {
        // �΂߈ړ��̋����������Ȃ��悤�ɐ��K���������s���A�P�ʃx�N�g���Ƃ���(�����̏��͎����A�����ɂ�鑬�x�����Ȃ����Ĉ��l�ɂ���)
        Vector3 dir = new Vector3(horizontal, vertical, 0).normalized;

        // velocity(���x)�ɐV�����l�������āA�Q�[���I�u�W�F�N�g���ړ�������
        rd.velocity = dir * moveSpeed;
    }

    // �L�����̌����Ă�������ƈړ��A�j���̓���
    private void SyncMoveAnimation()
    {
        // �ړ��̃L�[���͒l����
        Vector2 move = new Vector2(horizontal, vertical);

        // �����ꂩ�̃L�[���͂����邩�m�F
        if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f));
        {

        // �����Ă���������X�V
        lookDirection.Set(move.x, move.y);

         // ���K��
         lookDirection.Normalize();

        // �L�[���͂̒l�� Blend Tree �Őݒ肵���ړ��A�j���p�̒l���m�F���A�ړ��A�j�����Đ�
        anim.SetFloat("Look X", lookDirection.x);
        anim.SetFloat("Look Y", lookDirection.y);
        }

        // ��~�A�j���[�V�����p
        anim.SetFloat("Speed", move.magnitude);
     }
}




