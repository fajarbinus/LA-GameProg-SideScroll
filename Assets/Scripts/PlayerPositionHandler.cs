using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionHandler : MonoBehaviour
{
    Vector2 playerCurrentPosition;

    Vector2 currentCheckpointPosition;
   
    void Start()
    {
      //GameManager.instance.CheckSaveFile();
    }

    #region Condition
        public void OnCheckpoint(GameObject col)
        {
            Vector2 newCheckpointPosition = col.transform.position;
            currentCheckpointPosition = newCheckpointPosition;
            SavePosition(currentCheckpointPosition);
        }
        public void OnEnemy()
        {
            ChangePlayerPosition(currentCheckpointPosition);
        }

        public void OnFinish()
        {
            GameManager.instance.ChangeLevel(1);
            GameManager.instance.ChangeScene(0);
        }
    #endregion



    #region SaveLoad
        public TransformData playerPostitionData;
        private void LoadPosition()
        {
            transform.position = playerPostitionData.position;
        }

        private void SavePosition(Vector2 newPosition)
        {
            playerPostitionData.position = newPosition;
        }
    #endregion


    #region Instruction
        private void ChangePlayerPosition(Vector2 newPosition)
        {
            transform.position = newPosition;
        }
            
    #endregion
  


}
