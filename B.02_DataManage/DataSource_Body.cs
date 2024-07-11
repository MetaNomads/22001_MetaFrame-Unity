using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Oculus.Interaction.Input;


namespace MetaFrame.Data
{
    public class DataSource_Body : MonoBehaviour
    {
        public DataSourceManager _dataSourceManager;
        [SerializeField] internal OVRSkeleton _fullBodySkeleton;
        [SerializeField] internal Hmd _OVRHmd;
            
        /*=========================================================================================================================*/
        /// <summary>
        /// Body Data
        /// </summary>
        [Flags]
        public enum BodyEnum
        {
            HeadPosition = (1 << 1), // Vector3?
            HeadForward = (1 << 2), // Vector3?
            ChestForward = (1 << 3), // Vector3?
            ChestWorldRotation = (1 << 4), // List<float?>[right, up, forward]
        }
        /*-------------------------------------------------------------------------------------------------------------------------*/
        private List<BodyEnum> dataBodySelection = new List<BodyEnum>();

        public void GetSelection(BodyEnum selection, out List<BodyEnum> list)
        {
            if (selection.ToString() == "0") {list = new List<BodyEnum>();}
            else 
            {
                list = selection.ToString().Split(',').Select(i => (BodyEnum)Enum.Parse(typeof(BodyEnum), i)).ToList();
            }
        }   

        public string GetSelectionName(BodyEnum input) { return input.ToString();}

        public object? GetSelectionValue(BodyEnum input)
        {
            switch(input)
            {
                case BodyEnum.HeadPosition:
                    return HeadPosition();
                case BodyEnum.HeadForward:
                    return HeadForward();
                case BodyEnum.ChestForward:
                    return ChestForward();
                default:
                    return null;
            }
        }      
        /*-------------------------------------------------------------------------------------------------------------------------*/     
        // HeadPosition   
        public Transform? HeadPose()
        {
            switch (_fullBodySkeleton.GetSkeletonType())
            {
                case OVRSkeleton.SkeletonType.Body:
                    return _fullBodySkeleton.Bones[(int)OVRSkeleton.BoneId.Body_Head].Transform;

                case OVRSkeleton.SkeletonType.FullBody:
                    return _fullBodySkeleton.Bones[(int)OVRSkeleton.BoneId.FullBody_Head].Transform;

                default:
                    return null;
            }
        }

        public Vector3? HeadPosition()
        {
            return ((Transform)HeadPose()).position;
        }
        /*-------------------------------------------------------------------------------------------------------------------------*/
        // HeadForward
        public Vector3? HeadForward()
        {
            return ((Transform)HeadPose()).forward;
        }
        /*-------------------------------------------------------------------------------------------------------------------------*/
        // ChestForward
        public Transform? ChestPose()
        {
            switch (_fullBodySkeleton.GetSkeletonType())
            {
                case OVRSkeleton.SkeletonType.Body:
                    return _fullBodySkeleton.Bones[(int)OVRSkeleton.BoneId.Body_Chest].Transform;

                case OVRSkeleton.SkeletonType.FullBody:
                    return _fullBodySkeleton.Bones[(int)OVRSkeleton.BoneId.FullBody_Chest].Transform;

                default:
                    return null;
            }
        }

        public Vector3? ChestForward()
        {
            return ((Transform)ChestPose()).forward;
        }  
        /*-------------------------------------------------------------------------------------------------------------------------*/
        // ChestWorldRotation
        public List<float?> ChestWorldRotation()
        {
            List<float?> temp = new List<float?>();
            temp.Add((float?)Vector3.Angle(((Transform)ChestPose()).right, _dataSourceManager.targetVerticalVector));
            temp.Add((float?)Vector3.Angle(((Transform)ChestPose()).up, _dataSourceManager.targetVerticalVector));
            temp.Add((float?)Vector3.Angle(((Transform)ChestPose()).forward, _dataSourceManager.targetVerticalVector));
            return temp;                    
        }
        /*-------------------------------------------------------------------------------------------------------------------------*/
        // SpineLower Pose
        public Transform? SpineLowerPose()
        {
            switch (_fullBodySkeleton.GetSkeletonType())
            {
                case OVRSkeleton.SkeletonType.Body:
                    return _fullBodySkeleton.Bones[(int)OVRSkeleton.BoneId.Body_SpineLower].Transform;

                case OVRSkeleton.SkeletonType.FullBody:
                    return _fullBodySkeleton.Bones[(int)OVRSkeleton.BoneId.FullBody_SpineLower].Transform;

                default:
                    return null;
            }                   
        }
        /*=========================================================================================================================*/
    }
}
