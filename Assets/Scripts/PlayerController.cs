using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("�ړ����x")]
    public float moveSpeed;

    private Rigidbody2D rd; // �R���|�[�l���g�̎擾�p

    private float horizontal;  // x ��(�����E��)�����̓��͂̒l�̑���p
    private float vertical; //y ��(�����E�c)�����̓��͂̒l�̑���p


    // Start is called before the first frame update
    void Start()
    {
        // ���̃X�N���v�g���A�^�b�`����Ă���Q�[���I�u�W�F�N�g�ɃA�^�b�`����Ă���R���|�[�l���g�̒�����A<�w��>�����R���|�[�l���g�̏����擾���āA���ӂɗp�ӂ����ϐ��ɑ��
        rd = GetComponent<Rigidbody2D>(); // ���邢�́ATryGeyComponent(out rb);�@�ł���
    }

    // Update is called once per frame
    void Update()
    {
        // InputManager �� Horizontal �ɓo�^���Ă���L�[�����͂��ꂽ��A����(��)�����̓��͒l�Ƃ��đ��
        horizontal = Input.GetAxis("Horizontal");

        // InputManager �� Vertical �ɓo�^���Ă���L�[�����͂��ꂽ��A����(��)�����̓��͒l�Ƃ��đ��
        vertical = Input.GetAxis("Vertical");
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
        Vector3 dir = new Vector3 (horizontal, vertical, 0).normalized;

        // velocity(���x)�ɐV�����l�������āA�Q�[���I�u�W�F�N�g���ړ�������
        rd.velocity = dir * moveSpeed;
    }
}
