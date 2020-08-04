using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Michsky.UI.ModernUIPack;
using Base;

public class FocusConfirmationDialog : MonoBehaviour
{
    public string RobotName, EndEffectorId, OrientationId, JointsId, OrientationName, ActionPointId, ActionPointName;
    public bool UpdatePosition;
    public TMPro.TMP_Text SettingsText;
    public ModalWindowManager WindowManager;

    private string RobotId;

    public bool Init() {
        try {
            RobotId = SceneManager.Instance.RobotNameToId(RobotName);
        } catch (ItemNotFoundException ex) {
            Debug.LogError(ex);
            Notifications.Instance.ShowNotification("Failed to load end effectors", "");
            return false;
        }

        SettingsText.text = "Robot: " + RobotName +
            "\nEnd effector: " + EndEffectorId +
            "\nOrientation: " + OrientationName +
            "\nAction point: " + ActionPointName +
            "\nUpdate position: " + UpdatePosition.ToString();
        return true;
    }

    public async void UpdatePositionOrientation() {
        try {
           if (UpdatePosition)
                Base.GameManager.Instance.UpdateActionPointPositionUsingRobot(ActionPointId, RobotId, EndEffectorId);

            await WebsocketManager.Instance.UpdateActionPointOrientationUsingRobot(ActionPointId, RobotId, EndEffectorId, OrientationId);
            await WebsocketManager.Instance.UpdateActionPointJoints(RobotId, JointsId);
            
            GetComponent<ModalWindowManager>().CloseWindow();
        } catch (Base.RequestFailedException ex) {
            Base.NotificationsModernUI.Instance.ShowNotification("Failed to update", ex.Message);
        }
    }
}
