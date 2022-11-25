using UnityEngine;
using UnityEngine.EventSystems;

class MouseClickStop : StandaloneInputModule
{
    //����Ă��邱�Ɓi�����j
    //
    //StandaloneInputModule�̃}�E�X�N���b�N�ɂ��ύX�ȊO�̏��������󂯕t����悤�ɂ��Ă���
    //                                     ������
    //                             ProcessMouseEvent();

    public override void Process()
    {
        //=======move�C�x���g�Ƃ�=======
        // Update �̓x�ɃC�x���g�V�X�e���͌Ăяo�����󂯎��A���̓��W���[���������B
        //�ǂ̓��̓��W���[��������̍X�V�Ŏg�p���邩�����肵�܂��B�����ď��������W���[���ɈϏ�����B


        //�߂�l => update �C�x���g���I�������I�u�W�F�N�g�ɂ���Ďg�p���ꂽ�ꍇ
        //�I������Ă���I�u�W�F�N�g�� update �C�x���g�𑗐M
        bool usedEvent = SendUpdateEventToSelectedObject();


        //EventSystem�̓i�r�Q�[�V�����C�x���g��L���ɂ��ׂ����i�ړ��A���M�A�L�����Z���j
        if (eventSystem.sendNavigationEvents)
        {
            if (!usedEvent)
            {
                //=======move�C�x���g�Ƃ�=======
                //����Selectable �I�u�W�F�N�g������������� 4 �̈ړ��������猈�肷����


                //�߂�l => move �C�x���g���I�������I�u�W�F�N�g�ɂ���Ďg�p���ꂽ�ꍇ
                //�I������Ă���I�u�W�F�N�g�� move �C�x���g�𑗐M
                usedEvent |= SendMoveEventToSelectedObject();

                // �� |= �� ����|�E�ӂ̌��ʂ�������
            }

            if (!usedEvent)
            {
                //=======submit�C�x���g�Ƃ�=======
                //submit�L�[�������ꂽ�Ƃ��ɌĂ΂��C�x���g


                //�߂�l => submit �C�x���g���I�������I�u�W�F�N�g�ɂ���Ďg�p���ꂽ�ꍇ
                //�I������Ă���I�u�W�F�N�g�� submit �C�x���g�𑗐M
                SendSubmitEventToSelectedObject();
            }
        }
    }
}
