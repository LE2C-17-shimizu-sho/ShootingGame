using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // �t�B�[���h�ŃT�C�Y�����邽�߂̕ϐ����쐬����
    private float Left, Right, Top, Bottom;

    // �J�������猩����ʍ����̍��W������ϐ�
    Vector3 LeftBottom;

    // �J�������猩����ʍ���̍��W������ϐ�
    Vector3 RightTop;

    // Start is called before the first frame update
    void Start()
    {
        // �q�I�u�W�F�N�g�̐�������O�Տ������s��
        foreach (Transform child in gameObject.transform)
        {
            // �q�I�u�W�F�N�g�̒��ň�ԉE�̈ʒu�ɂ����Ȃ�
            if (child.localPosition.x >= Right)
            {
                Right = child.transform.localPosition.x;
            }

            // �q�I�u�W�F�N�g�̒��ň�ԉE�̈ʒu�ɂ����Ȃ�
            if (child.localPosition.x <= Left)
            {
                Left = child.transform.localPosition.x;
            }

            // �q�I�u�W�F�N�g�̒��ň�ԉE�̈ʒu�ɂ����Ȃ�
            if (child.localPosition.z >= Top)
            {
                Top = child.transform.localPosition.z;
            }

            // �q�I�u�W�F�N�g�̒��ň�ԉE�̈ʒu�ɂ����Ȃ�
            if (child.localPosition.z <= Bottom)
            {
                Bottom = child.transform.localPosition.z;
            }
        }

        // �J�����ƃv���C���[�̋����𑪂�i�\����ʂ̎l����ݒ肷�邽�߂ɕK�v�j
        var distance = Vector3.Distance(Camera.main.transform.position, transform.position);

        // �X�N���[����ʍ����̈ʒu��ݒ肷��
        LeftBottom = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));

        // �X�N���[����ʍ����̈ʒu��ݒ肷��
        RightTop = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, distance));
    }

    // Update is called once per frame
    void Update()
    {
        // �v���C���[�̃��[���h���W���擾
        Vector3 pos = transform.position;

        // �E���L�[�����͂��ꂽ�Ƃ�
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // �E������0.01����
            pos.x += 0.01f;
        }

        // �����L�[�����͂��ꂽ�Ƃ�
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // ��������0.01����
            pos.x -= 0.01f;
        }

        // ����L�[�����͂��ꂽ�Ƃ�
        if (Input.GetKey(KeyCode.UpArrow))
        {
            // �������0.01����
            pos.z += 0.01f;
        }

        // �����L�[�����͂��ꂽ�Ƃ�
        if (Input.GetKey(KeyCode.DownArrow))
        {
            // ��������0.01����
            pos.z -= 0.01f;
        }
        transform.position = new Vector3(
            Mathf.Clamp(pos.x, LeftBottom.x + transform.localScale.x - Left, RightTop.x - transform.localScale.x - Right),
            pos.y,
            Mathf.Clamp(pos.z, LeftBottom.z + transform.localScale.z - Bottom, RightTop.z - transform.localScale.z - Top)
            );
    }
}
