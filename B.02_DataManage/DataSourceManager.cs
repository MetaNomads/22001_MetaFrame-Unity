using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Sirenix.OdinInspector;
using Sirenix.Utilities;

using Oculus.Interaction;
using Oculus.Interaction.Input;
using static Oculus.Interaction.Input.TrackingToWorldTransformerOVR;
using Oculus.Interaction.PoseDetection;
using static OVRSkeleton;
using static OVRFaceExpressions;

using MetaFrame.Interaction;

/// <summary>
/// a collection of functions to read data and configure data source in the inspector
/// </summary>

namespace MetaFrame.Data
{
    public class DataSourceManager : MonoBehaviour
    {
        [SerializeField] internal TransformConfig _config;
        [SerializeField] private TrackingToWorldTransformerOVR _trackingToWorldTransformer;


        internal Vector3 targetVerticalVector;

        protected virtual void Start()
        {
            targetVerticalVector = OffsetVectorWithRotation(GetVerticalVector());

            initilizeFACSSeletion();
            initilizeBodySeletion();
            initilizeLeftHandSeletion();
            initilizeRightHandSeletion();
        }    

        /*=========================================================================================================================*/

        /*=========================================================================================================================*/
        /// <summary>
        /// FACS Data
        /// </summary>
        [FoldoutGroup("FACS")] [SerializeField] public DataSource_FACS _facsDataSource;
            [FoldoutGroup("FACS")][Indent(2)][Title("Upper Face AUs", bold: true)][EnumMask] [SerializeField] public DataSource_FACS.FACS_UpperFace _upperFaceEnum;
            [FoldoutGroup("FACS")][Indent(2)][Title("Lower Face AUs", bold: true)][EnumMask] [SerializeField] public DataSource_FACS.FACS_LowerFace _lowerFaceEnum;
            [FoldoutGroup("FACS")][Indent(2)][Title("Head Positions", bold: true)][EnumMask] [SerializeField] public DataSource_FACS.FACS_Head _headEnum;
            [FoldoutGroup("FACS")][Indent(2)][Title("Eye Positions", bold: true)][EnumMask] [SerializeField] public DataSource_FACS.FACS_Eye _eyeEnum;
            [FoldoutGroup("FACS")][Indent(2)][Title("Lip Parting and Jaw Opening", bold: true)][EnumMask] [SerializeField] public DataSource_FACS.FACS_LipJaw _lipJawEnum;
            [FoldoutGroup("FACS")][Indent(2)][Title("Miscellaneous AUs", bold: true)][EnumMask] [SerializeField] public DataSource_FACS.FACS_Miscellaneous _miscellaneousEnum;

            /*-------------------------------------------------------------------------------------------------------------------------*/
            private List<DataSource_FACS.FACS_UpperFace> upperFaceSelection = new List<DataSource_FACS.FACS_UpperFace>();
            private List<DataSource_FACS.FACS_LowerFace> lowerFaceSelection = new List<DataSource_FACS.FACS_LowerFace>();
            private List<DataSource_FACS.FACS_Head> headSelection = new List<DataSource_FACS.FACS_Head>();
            private List<DataSource_FACS.FACS_Eye> eyeSelection = new List<DataSource_FACS.FACS_Eye>();
            private List<DataSource_FACS.FACS_LipJaw> lipJawSelection = new List<DataSource_FACS.FACS_LipJaw>();
            private List<DataSource_FACS.FACS_Miscellaneous> miscellaneousSelection = new List<DataSource_FACS.FACS_Miscellaneous>();
            
            private void initilizeFACSSeletion()
            {
                _facsDataSource.GetSelection(_upperFaceEnum, out upperFaceSelection);
                _facsDataSource.GetSelection(_lowerFaceEnum, out lowerFaceSelection);
                _facsDataSource.GetSelection(_headEnum, out headSelection);
                _facsDataSource.GetSelection(_eyeEnum, out eyeSelection);
                _facsDataSource.GetSelection(_lipJawEnum, out lipJawSelection);
                _facsDataSource.GetSelection(_miscellaneousEnum, out miscellaneousSelection);
            }
            
            public List<string>? FACSNameList()
            {
                List<string> temp = new List<string>();

                foreach (var i in upperFaceSelection){temp.Add(_facsDataSource.GetSelectionName(i));}
                foreach (var i in lowerFaceSelection){temp.Add(_facsDataSource.GetSelectionName(i));}
                foreach (var i in headSelection){temp.Add(_facsDataSource.GetSelectionName(i));}
                foreach (var i in eyeSelection){temp.Add(_facsDataSource.GetSelectionName(i));} 
                foreach (var i in lipJawSelection){temp.Add(_facsDataSource.GetSelectionName(i));}
                foreach (var i in miscellaneousSelection){temp.Add(_facsDataSource.GetSelectionName(i));}

                if (temp.Count != 0) {return temp;}
                else {return null;}
            }

            public List<object>? FACSValueList()
            {
                List<object> temp = new List<object>();

                foreach (var i in upperFaceSelection){temp.Add(_facsDataSource.GetSelectionValue(i));}
                foreach (var i in lowerFaceSelection){temp.Add(_facsDataSource.GetSelectionValue(i));}
                foreach (var i in headSelection){temp.Add(_facsDataSource.GetSelectionValue(i));}
                foreach (var i in eyeSelection){temp.Add(_facsDataSource.GetSelectionValue(i));} 
                foreach (var i in lipJawSelection){temp.Add(_facsDataSource.GetSelectionValue(i));}
                foreach (var i in miscellaneousSelection){temp.Add(_facsDataSource.GetSelectionValue(i));}

                if (temp.Count != 0) {return temp;}
                else {return null;}
            }
        /*=========================================================================================================================*/

        /*=========================================================================================================================*/
        /// <summary>
        /// Body Data
        /// </summary>
        [FoldoutGroup("Body")] [SerializeField] internal DataSource_Body _bodyDataSource;
            [FoldoutGroup("Body")][Indent(2)][EnumMask] [SerializeField] public DataSource_Body.BodyEnum _BodyEnum;
            private List< DataSource_Body.BodyEnum> bodySelection = new List< DataSource_Body.BodyEnum>();

            private void initilizeBodySeletion() {_bodyDataSource.GetSelection(_BodyEnum, out bodySelection);}
                
            public List<string>? BodyNameList()
            {
                List<string> temp = new List<string>();
                foreach (var i in bodySelection){temp.Add(_bodyDataSource.GetSelectionName(i));}
                if (temp.Count != 0) {return temp;}
                else {return null;}
            }

            public List<object>? BodyValueList()
            {
                List<object> temp = new List<object>();
                foreach (var i in bodySelection){temp.Add(_bodyDataSource.GetSelectionValue(i));}
                if (temp.Count != 0) {return temp;}
                else {return null;}
            }

        /*=========================================================================================================================*/

        /*=========================================================================================================================*/
        /// <summary>
        /// Left Hand Data
        /// </summary>  
        [FoldoutGroup("Left Hand")] [SerializeField] internal DataSource_Hand _handDataSource;
        [FoldoutGroup("Left Hand")] [SerializeField] protected TransformFeatureStateProvider _leftTransformFeatureStateProvider;
        [FoldoutGroup("Left Hand")] [SerializeField] protected FingerFeatureStateProvider _leftFingerFeatureStateProvider;
            [FoldoutGroup("Left Hand")][Indent(2)][EnumMask] [SerializeField] public DataSource_Hand.HandEnum _LeftHandEnum;
            private List<DataSource_Hand.HandEnum> leftHandSelection = new List<DataSource_Hand.HandEnum>();

            private void initilizeLeftHandSeletion() {_handDataSource.GetSelection(_LeftHandEnum, out leftHandSelection);}
                
            public List<string>? LeftHandNameList()
            {
                List<string> temp = new List<string>();
                foreach (var i in leftHandSelection){temp.Add(_handDataSource.GetSelectionName(i));}
                if (temp.Count != 0) {return temp;}
                else {return null;}
            }

            public List<object>? LeftHandValueList()
            {
                List<object> temp = new List<object>();
                foreach (var i in leftHandSelection){temp.Add(_handDataSource.GetSelectionValue(i, _leftTransformFeatureStateProvider, _leftFingerFeatureStateProvider));}
                if (temp.Count != 0) {return temp;}
                else {return null;}
            }  
        /*=========================================================================================================================*/

        /*=========================================================================================================================*/
        /// <summary>
        /// Right Hand Data
        /// </summary>      
        [FoldoutGroup("Right Hand")] [SerializeField] protected TransformFeatureStateProvider _rightTransformFeatureStateProvider;
        [FoldoutGroup("Right Hand")] [SerializeField] protected FingerFeatureStateProvider _rightFingerFeatureStateProvider;
            [FoldoutGroup("Right Hand")][Indent(2)][EnumMask] [SerializeField] public DataSource_Hand.HandEnum _rightHandEnum;
            private List<DataSource_Hand.HandEnum> rightHandSelection = new List<DataSource_Hand.HandEnum>();

            private void initilizeRightHandSeletion() {_handDataSource.GetSelection(_rightHandEnum, out rightHandSelection);}
                
            public List<string>? RightHandNameList()
            {
                List<string> temp = new List<string>();
                foreach (var i in rightHandSelection){temp.Add(_handDataSource.GetSelectionName(i));}
                if (temp.Count != 0) {return temp;}
                else {return null;}
            }

            public List<object>? RightHandValueList()
            {
                List<object> temp = new List<object>();
                foreach (var i in rightHandSelection){temp.Add(_handDataSource.GetSelectionValue(i, _rightTransformFeatureStateProvider, _rightFingerFeatureStateProvider));}
                if (temp.Count != 0) {return temp;}
                else {return null;}
            } 
        /*=========================================================================================================================*/

        /*=========================================================================================================================*/
        /// <summary>
        /// Utility Functions
        /// </summary> 

        //UTILITY - calculate the target vectors with "offset" and "Up Vector Type" in _config
        private Vector3 OffsetVectorWithRotation( Vector3 originalVector)
        {
            Pose _hmdPose;
            Pose _trackingPose;
            Quaternion baseRotation;
            switch (_config.UpVectorType)
            {
                case UpVectorType.Head:
                    _bodyDataSource._OVRHmd.TryGetRootPose(out _hmdPose);
                    baseRotation = _hmdPose.rotation;
                    break;
                case UpVectorType.Tracking:
                    Pose p = new Pose(_trackingToWorldTransformer.Transform.position,_trackingToWorldTransformer.Transform.rotation);
                    _trackingPose = _trackingToWorldTransformer.ToTrackingPose(in p);
                    baseRotation = Quaternion.LookRotation(_trackingPose.forward,_trackingPose.up);
                    break;
                case UpVectorType.World:
                default:
                    baseRotation = Quaternion.identity;
                    break;
            }
            Quaternion offset = Quaternion.Euler(_config.RotationOffset);
            return baseRotation * offset * Quaternion.Inverse(baseRotation) * originalVector;
        }

        //UTILITY - calculate the target vertical vectors
        private Vector3 GetVerticalVector()
        {
            Vector3 verticalVector;
            Pose _hmdPose;
            Pose _trackingPose;
            switch (_config.UpVectorType)
            {
                case UpVectorType.Head:
                    _bodyDataSource._OVRHmd.TryGetRootPose(out _hmdPose);
                    verticalVector = _hmdPose.up;
                    break;
                case UpVectorType.Tracking:
                    Pose p = new Pose(_trackingToWorldTransformer.Transform.position,_trackingToWorldTransformer.Transform.rotation);
                    _trackingPose = _trackingToWorldTransformer.ToTrackingPose(in p);                            
                    verticalVector = _trackingPose.up;
                    break;
                case UpVectorType.World:
                default:
                    verticalVector = Vector3.up;
                    break;
            }
            return verticalVector;

        }


        
    }
}

