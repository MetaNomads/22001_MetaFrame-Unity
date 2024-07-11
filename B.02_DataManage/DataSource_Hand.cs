using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Oculus.Interaction;
using Oculus.Interaction.Input;
using Oculus.Interaction.PoseDetection;

using MetaFrame.Interaction;


namespace MetaFrame.Data
{
    public class DataSource_Hand : MonoBehaviour
    {
        public DataSourceManager _dataSourceManager;
        /*=========================================================================================================================*/
        /// <summary>
        /// Hand Data
        /// </summary>                
        private Vector3? FeatureVec = null;
        private Vector3? WristPos = null;

        [Flags]
        public enum HandEnum
        {
            PalmPosition = (1 << 0), // Vector3?
            PalmRotation = (1 << 1), // List<float?>[FingersUp, WristUp, PalmUp, PalmTowardsFace]
            Thumb = (1 << 2), // List<float?>[Curl, Flexion, Abduction, Opposition]
            Index = (1 << 3), // List<float?>[Curl, Flexion, Abduction, Opposition]
            Middle = (1 << 4), // List<float?>[Curl, Flexion, Abduction, Opposition]
            Ring = (1 << 5), // List<float?>[Curl, Flexion, Abduction, Opposition]
            Pinky = (1 << 6), // List<float?>[Curl, Flexion, Abduction, Opposition]
        } 
        /*-------------------------------------------------------------------------------------------------------------------------*/
        private List<HandEnum> dataLeftHandList = new List<HandEnum>();

        public void GetSelection(HandEnum selection, out List<HandEnum> list)
        {
            if (selection.ToString() == "0") {list = new List<HandEnum>();}
            else 
            {
                list = selection.ToString().Split(',').Select(i => (HandEnum)Enum.Parse(typeof(HandEnum), i)).ToList();
            }
        }   

        public string GetSelectionName(HandEnum input) { return input.ToString();}

        public object? GetSelectionValue(HandEnum input, TransformFeatureStateProvider transformFeature, FingerFeatureStateProvider fingerFeature)
        {
            switch(input)
            {
                case HandEnum.PalmPosition:
                    return PalmPosition(transformFeature);
                case HandEnum.PalmRotation:
                    return PalmRotation(transformFeature);
                case HandEnum.Thumb:
                    return Thumb(fingerFeature);
                case HandEnum.Index:
                    return Index(fingerFeature);
                case HandEnum.Middle:
                    return Middle(fingerFeature);
                case HandEnum.Ring:
                    return Ring(fingerFeature);
                case HandEnum.Pinky:
                    return Pinky(fingerFeature);
                default:
                    return null;
            }
        }
        /*-------------------------------------------------------------------------------------------------------------------------*/
        // PalmPosition         
        public List<float?> PalmPosition(TransformFeatureStateProvider input)
        {
            List<float?> temp = new List<float?>();
            input.GetFeatureVectorAndWristPos(_dataSourceManager._config,TransformFeature.WristUp, true, ref FeatureVec, ref WristPos);
            temp.Add(((Vector3)WristPos).x); temp.Add(((Vector3)WristPos).z); temp.Add(((Vector3)WristPos).y); 
            return temp;
        }
        /*-------------------------------------------------------------------------------------------------------------------------*/
        // PalmRotation
        public List<float?> PalmRotation(TransformFeatureStateProvider input)
        {
            List<float?> temp = new List<float?>();
            temp.Add((float?)input.GetFeatureValue(_dataSourceManager._config,TransformFeature.FingersUp));
            temp.Add((float?)input.GetFeatureValue(_dataSourceManager._config,TransformFeature.WristUp));
            temp.Add((float?)input.GetFeatureValue(_dataSourceManager._config,TransformFeature.PalmUp));
            temp.Add((float?)input.GetFeatureValue(_dataSourceManager._config,TransformFeature.PalmTowardsFace));
            return temp;
        }
        /*-------------------------------------------------------------------------------------------------------------------------*/
        // Thumb
        public List<float?> Thumb(FingerFeatureStateProvider input)
        {
            List<float?> temp = new List<float?>();
            temp.Add((float?)input.GetFeatureValue(HandFinger.Thumb,FingerFeature.Curl));
            temp.Add((float?)input.GetFeatureValue(HandFinger.Thumb,FingerFeature.Flexion));
            temp.Add((float?)input.GetFeatureValue(HandFinger.Thumb,FingerFeature.Abduction));
            temp.Add((float?)input.GetFeatureValue(HandFinger.Thumb,FingerFeature.Opposition));
            return temp;
        }
        /*-------------------------------------------------------------------------------------------------------------------------*/
        // Index
        public List<float?> Index(FingerFeatureStateProvider input)
        {
            List<float?> temp = new List<float?>();
            temp.Add((float?)input.GetFeatureValue(HandFinger.Index,FingerFeature.Curl));
            temp.Add((float?)input.GetFeatureValue(HandFinger.Index,FingerFeature.Flexion));
            temp.Add((float?)input.GetFeatureValue(HandFinger.Index,FingerFeature.Abduction));
            temp.Add((float?)input.GetFeatureValue(HandFinger.Index,FingerFeature.Opposition));
            return temp;
        }
        /*-------------------------------------------------------------------------------------------------------------------------*/
        // Middle
        public List<float?> Middle(FingerFeatureStateProvider input)
        {
            List<float?> temp = new List<float?>();
            temp.Add((float?)input.GetFeatureValue(HandFinger.Middle,FingerFeature.Curl));
            temp.Add((float?)input.GetFeatureValue(HandFinger.Middle,FingerFeature.Flexion));
            temp.Add((float?)input.GetFeatureValue(HandFinger.Middle,FingerFeature.Abduction));
            temp.Add((float?)input.GetFeatureValue(HandFinger.Middle,FingerFeature.Opposition));
            return temp;
        }
        /*-------------------------------------------------------------------------------------------------------------------------*/
        // Ring
        public List<float?> Ring(FingerFeatureStateProvider input)
        {
            List<float?> temp = new List<float?>();
            temp.Add((float?)input.GetFeatureValue(HandFinger.Ring,FingerFeature.Curl));
            temp.Add((float?)input.GetFeatureValue(HandFinger.Ring,FingerFeature.Flexion));
            temp.Add((float?)input.GetFeatureValue(HandFinger.Ring,FingerFeature.Abduction));
            temp.Add((float?)input.GetFeatureValue(HandFinger.Ring,FingerFeature.Opposition));
            return temp;
        }
        /*-------------------------------------------------------------------------------------------------------------------------*/
        // Pinky
        public List<float?> Pinky(FingerFeatureStateProvider input)
        {
            List<float?> temp = new List<float?>();
            temp.Add((float?)input.GetFeatureValue(HandFinger.Pinky,FingerFeature.Curl));
            temp.Add((float?)input.GetFeatureValue(HandFinger.Pinky,FingerFeature.Flexion));
            temp.Add((float?)input.GetFeatureValue(HandFinger.Pinky,FingerFeature.Abduction));
            temp.Add((float?)input.GetFeatureValue(HandFinger.Pinky,FingerFeature.Opposition));
            return temp;
        }
        /*=========================================================================================================================*/
    }
}
