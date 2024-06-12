using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionHandler : MonoBehaviour
{
    Vector2 playerCurrentPosition;
    Vector2 playerStartPosition;
    Vector2 currentCheckpointPosition;
   
    void Start()
    {
        playerStartPosition = new Vector2(-14,0);
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
