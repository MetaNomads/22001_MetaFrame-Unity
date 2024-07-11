using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static OVRFaceExpressions;

using Unity.Mathematics;

namespace MetaFrame.Data
{
    public class DataSource_FACS : MonoBehaviour
    {
        public OVRFaceExpressions _ovrFaceExpressions;
        public DataSourceManager _dataSourceManager;

        /*=========================================================================================================================*/
        /// <summary>
        /// FACS - Upper Face AUs
        /// </summary>
        [Flags]
        public enum FACS_UpperFace
        {
            AU1_InnerBrowRaiser = (1 << 0),
            AU2_OuterBrowRaiser = (1 << 1),
            AU4_BrowLowerer = (1 << 2),
            AU5_UpperLidRaiser = (1 << 3),
            AU6_CheekRaiser = (1 << 4),
            AU7_LidTightener = (1 << 5),
            AU43_EyesClosed = (1 << 6),
        }

        public void GetSelection(FACS_UpperFace selection, out List<FACS_UpperFace> list)
        {
            if (selection.ToString() == "0") {list = new List<FACS_UpperFace>();}
            else 
            {
                list = selection.ToString().Split(',').Select(i => (FACS_UpperFace)Enum.Parse(typeof(FACS_UpperFace), i)).ToList();
            }
        }

        public string GetSelectionName(FACS_UpperFace input) { return input.ToString();}
        
        public object? GetSelectionValue(FACS_UpperFace input)
        {
            float t1;
            float t2;

            switch(input)
            {
                case FACS_UpperFace.AU1_InnerBrowRaiser:
                    t1 = _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.InnerBrowRaiserL);
                    t2 = _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.InnerBrowRaiserR);
                    return (t1+t2)/2;
                case FACS_UpperFace.AU2_OuterBrowRaiser:
                    t1 = _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.OuterBrowRaiserL);
                    t2 = _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.OuterBrowRaiserR);
                    return (t1+t2)/2;
                case FACS_UpperFace.AU4_BrowLowerer:
                    t1 = _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.BrowLowererL);
                    t2 = _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.BrowLowererR);
                    return (t1+t2)/2;
                case FACS_UpperFace.AU5_UpperLidRaiser:
                    t1 = _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.UpperLidRaiserL);
                    t2 = _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.UpperLidRaiserR);
                    return (t1+t2)/2;
                case FACS_UpperFace.AU6_CheekRaiser:
                    t1 = _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.CheekRaiserL);
                    t2 = _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.CheekRaiserR);
                    return (t1+t2)/2;
                case FACS_UpperFace.AU7_LidTightener:
                    t1 = _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.LidTightenerL);
                    t2 = _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.LidTightenerR);
                    return (t1+t2)/2;
                case FACS_UpperFace.AU43_EyesClosed:
                    t1 = _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.EyesClosedL);
                    t2 = _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.EyesClosedR);
                    return (t1+t2)/2;
                default:
                    return null;
            }
        }
        /*=========================================================================================================================*/

        /*=========================================================================================================================*/
        /// <summary>
        /// FACS - Lower Face AUs
        /// </summary>
        [Flags]
        public enum FACS_LowerFace
        {
            AU9_NoseWrinkler = (1 << 0),
            AU10_UpperLipRaiser = (1 << 1),
            AU12_LipCornerPuller = (1 << 2),
            AU14_Dimpler = (1 << 3),
            AU15_LipCornerDepressor = (1 << 4),
            AU16_LowerLipDepressor = (1 << 5),
            AU17_ChinRaiser = (1 << 6),
            AU18_LipPucker = (1 << 7),
            AU20_LipStretcher = (1 << 8),
            AU22_LipFunneler = (1 << 9),
            AU23_LipTightener = (1 << 10),
            AU24_LipPressor = (1 << 11),
            AU28_LipSuck = (1 << 12),
        }

        public void GetSelection(FACS_LowerFace selection, out List<FACS_LowerFace> list)
        {
            if (selection.ToString() == "0") {list = new List<FACS_LowerFace>();}
            else 
            {
                list = selection.ToString().Split(',').Select(i => (FACS_LowerFace)Enum.Parse(typeof(FACS_LowerFace), i)).ToList();
            }
        }

        public string GetSelectionName(FACS_LowerFace input) { return input.ToString();}

        public object? GetSelectionValue(FACS_LowerFace input)
        {
            float t1;
            float t2;
            float t3;
            float t4;

            switch(input)
            {
                case FACS_LowerFace.AU9_NoseWrinkler:
                    t1 = _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.NoseWrinklerL);
                    t2 = _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.NoseWrinklerR);
                    return (t1+t2)/2;
                case FACS_LowerFace.AU10_UpperLipRaiser:
                    t1 = _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.UpperLipRaiserL);
                    t2 = _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.UpperLipRaiserR);
                    return (t1+t2)/2;
                case FACS_LowerFace.AU12_LipCornerPuller:
                    t1 = _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.LipCornerPullerL);
                    t2 = _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.LipCornerPullerR);
                    return (t1+t2)/2;
                case FACS_LowerFace.AU14_Dimpler:
                    t1 = _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.DimplerL);
                    t2 = _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.DimplerR);
                    return (t1+t2)/2;
                case FACS_LowerFace.AU15_LipCornerDepressor:
                    t1 = _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.LipCornerDepressorL);
                    t2 = _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.LipCornerDepressorR);
                    return (t1+t2)/2;
                case FACS_LowerFace.AU16_LowerLipDepressor:
                    t1 = _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.LowerLipDepressorL);
                    t2 = _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.LowerLipDepressorR);
                    return (t1+t2)/2;
                // Unique
                case FACS_LowerFace.AU17_ChinRaiser:
                    t1 = _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.ChinRaiserB);
                    t2 = _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.ChinRaiserT);
                    return (t1+t2)/2;
                case FACS_LowerFace.AU18_LipPucker:
                    t1 = _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.LipPuckerL);
                    t2 = _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.LipPuckerR);
                    return (t1+t2)/2;
                case FACS_LowerFace.AU20_LipStretcher:
                    t1 = _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.LipStretcherL);
                    t2 = _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.LipStretcherR);
                    return (t1+t2)/2;
                // Unique
                case FACS_LowerFace.AU22_LipFunneler:
                    t1 = _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.LipFunnelerLB);
                    t2 = _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.LipFunnelerLT);
                    t3 = _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.LipFunnelerRB);
                    t4 = _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.LipFunnelerRT);
                    return (t1+t2+t3+t4)/4;
                case FACS_LowerFace.AU23_LipTightener:
                    t1 = _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.LipTightenerL);
                    t2 = _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.LipTightenerR);
                    return (t1+t2)/2;
                case FACS_LowerFace.AU24_LipPressor:
                    t1 = _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.LipPressorL);
                    t2 = _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.LipPressorR);
                    return (t1+t2)/2;
                // Unique
                case FACS_LowerFace.AU28_LipSuck:
                    t1 = _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.LipSuckLB);
                    t2 = _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.LipSuckLT);
                    t3 = _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.LipSuckRB);
                    t4 = _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.LipSuckRT);
                    return (t1+t2+t3+t4)/4;
                default:
                    return null;
            }
        }
        /*=========================================================================================================================*/

        /*=========================================================================================================================*/
        /// <summary>
        /// FACS - Head AUs
        /// </summary>
        [Flags]
        public enum FACS_Head
        {
            AU51_TurnLeft = (1 << 0),
            AU52_TurnRight = (1 << 1),
            AU53_HeadUp = (1 << 2),
            AU54_HeadDown = (1 << 3),
            AU55_TiltLeft = (1 << 4),
            AU56_TiltRight = (1 << 5),
            // AU57_Forward = (1 << 6),
            // AU58_Back = (1 << 7),
        }

        public void GetSelection(FACS_Head selection, out List<FACS_Head> list)
        {
            if (selection.ToString() == "0") {list = new List<FACS_Head>();}
            else 
            {
                list = selection.ToString().Split(',').Select(i => (FACS_Head)Enum.Parse(typeof(FACS_Head), i)).ToList();
            }
        }

        public string GetSelectionName(FACS_Head input) { return input.ToString();}

        public object? GetSelectionValue(FACS_Head input)
        {
            switch(input)
            {
                case FACS_Head.AU51_TurnLeft:
                    return TurnLeft();
                case FACS_Head.AU52_TurnRight:
                    return TurnRight();
                case FACS_Head.AU53_HeadUp:
                    return HeadUp();
                case FACS_Head.AU54_HeadDown:
                    return HeadDown();
                case FACS_Head.AU55_TiltLeft:
                    return TiltLeft();
                case FACS_Head.AU56_TiltRight:
                    return TiltRight();
                default:
                    return null;
            }
        }
        /*-------------------------------------------------------------------------------------------------------------------------*/
        // TurnLeft
        // head rotation in relation to chestForward
        // this is very wired, axis of skeleton bones are rotated so the following calculation are done on the rotated axis. 
        // Watch out for future updates from Meta as these rotation could be fixed.
        public float? TurnLeft()
        {
            float angle = Vector3.SignedAngle(_dataSourceManager._bodyDataSource.HeadPose().up, 
                        Vector3.ProjectOnPlane(_dataSourceManager._bodyDataSource.ChestPose().up, _dataSourceManager._bodyDataSource.HeadPose().right), 
                        _dataSourceManager._bodyDataSource.HeadPose().right*-1f);
            angle = math.remap(0f, 90f, 0f, 1f, angle);
            if (angle < 0) {return null;}
            else {return angle; }
        }  
        /*-------------------------------------------------------------------------------------------------------------------------*/
        // // TurnRight
        // // head rotation in relation to chestForward
        public float? TurnRight()
        {
            float angle = Vector3.SignedAngle(_dataSourceManager._bodyDataSource.HeadPose().up, 
                        Vector3.ProjectOnPlane(_dataSourceManager._bodyDataSource.ChestPose().up, _dataSourceManager._bodyDataSource.HeadPose().right), 
                        _dataSourceManager._bodyDataSource.HeadPose().right);
            angle = math.remap(0f, 90f, 0f, 1f, angle);
            if (angle < 0) {return null;}
            else {return angle; }
        } 
        /*-------------------------------------------------------------------------------------------------------------------------*/ 
        // HeadUp
        // head rotation in relation to chestForward
        public float? HeadUp()
        {
            float angle = Vector3.SignedAngle(_dataSourceManager._bodyDataSource.HeadPose().up, 
                        Vector3.ProjectOnPlane(_dataSourceManager._bodyDataSource.ChestPose().up, _dataSourceManager._bodyDataSource.HeadPose().forward), 
                        _dataSourceManager._bodyDataSource.HeadPose().forward*-1f);
            angle = math.remap(0f, 90f, 0f, 1f, angle);
            if (angle < 0) {return null;}
            else {return angle; }
        }  
        /*-------------------------------------------------------------------------------------------------------------------------*/ 
        // HeadDown
        // head rotation in relation to chestForward
        public float? HeadDown()
        {
            float angle = Vector3.SignedAngle(_dataSourceManager._bodyDataSource.HeadPose().up, 
                        Vector3.ProjectOnPlane(_dataSourceManager._bodyDataSource.ChestPose().up, _dataSourceManager._bodyDataSource.HeadPose().forward), 
                        _dataSourceManager._bodyDataSource.HeadPose().forward);
            angle = math.remap(0f, 90f, 0f, 1f, angle);
            if (angle < 0) {return null;}
            else {return angle; }
        }  
        /*-------------------------------------------------------------------------------------------------------------------------*/ 
        // TiltLeft
        // head rotation in relation to chestRight
        public float? TiltLeft()
        {
            float angle = Vector3.SignedAngle(_dataSourceManager._bodyDataSource.HeadPose().right, 
                        Vector3.ProjectOnPlane(_dataSourceManager._bodyDataSource.ChestPose().right, _dataSourceManager._bodyDataSource.HeadPose().up), 
                        _dataSourceManager._bodyDataSource.HeadPose().up*-1f);
            angle = math.remap(0f, 90f, 0f, 1f, angle);
            if (angle < 0) {return null;}
            else {return angle; }
        }  
        /*-------------------------------------------------------------------------------------------------------------------------*/ 
        // TiltRight
        // head rotation in relation to chestRight
        public float? TiltRight()
        {
            float angle = Vector3.SignedAngle(_dataSourceManager._bodyDataSource.HeadPose().right, 
                        Vector3.ProjectOnPlane(_dataSourceManager._bodyDataSource.ChestPose().right, _dataSourceManager._bodyDataSource.HeadPose().up), 
                        _dataSourceManager._bodyDataSource.HeadPose().up);
            angle = math.remap(0f, 90f, 0f, 1f, angle);
            if (angle < 0) {return null;}
            else {return angle; }
        }  
        /*=========================================================================================================================*/

        /*=========================================================================================================================*/
        /// <summary>
        /// FACS - Eye AUs
        /// </summary>
        [Flags]
        public enum FACS_Eye
        {          
            AU61_EyesLookLeft = (1 << 0),
            AU62_EyesLookRight = (1 << 1),
            AU63_EyesLookUp = (1 << 2),
            AU64_EyesLookDown = (1 << 3),
        }

        public void GetSelection(FACS_Eye selection, out List<FACS_Eye> list)
        {
            if (selection.ToString() == "0") {list = new List<FACS_Eye>();}
            else 
            {
                list = selection.ToString().Split(',').Select(i => (FACS_Eye)Enum.Parse(typeof(FACS_Eye), i)).ToList();
            }
        }

        public string GetSelectionName(FACS_Eye input) { return input.ToString();}

        public object? GetSelectionValue(FACS_Eye input)
        {
            float t1;
            float t2;

            switch(input)
            {
                case FACS_Eye.AU61_EyesLookLeft:
                    t1 = _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.EyesLookLeftL);
                    t2 = _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.EyesLookLeftR);
                    return (t1+t2)/2;
                case FACS_Eye.AU62_EyesLookRight:
                    t1 = _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.EyesLookRightL);
                    t2 = _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.EyesLookRightR);
                    return (t1+t2)/2;
                case FACS_Eye.AU63_EyesLookUp:
                    t1 = _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.EyesLookUpL);
                    t2 = _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.EyesLookUpR);
                    return (t1+t2)/2;
                case FACS_Eye.AU64_EyesLookDown:
                    t1 = _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.EyesLookDownL);
                    t2 = _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.EyesLookDownR);
                    return (t1+t2)/2;
                default:
                    return null;
            }
        }      
        /*=========================================================================================================================*/

        /*=========================================================================================================================*/
        /// <summary>
        /// FACS - Lip and Jaw AUs
        /// </summary>
        [Flags]
        public enum FACS_LipJaw
        {
            AU26_JawDrop = (1 << 0),
        }

        public void GetSelection(FACS_LipJaw selection, out List<FACS_LipJaw> list)
        {
            if (selection.ToString() == "0") {list = new List<FACS_LipJaw>();}
            else 
            {
                list = selection.ToString().Split(',').Select(i => (FACS_LipJaw)Enum.Parse(typeof(FACS_LipJaw), i)).ToList();
            }
        }

        public string GetSelectionName(FACS_LipJaw input) { return input.ToString();}

        public object? GetSelectionValue(FACS_LipJaw input)
        {
            switch(input)
            {
                // Unique
                case FACS_LipJaw.AU26_JawDrop:
                    return _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.JawDrop);
                default:
                    return null;
            }
        }      
        /*=========================================================================================================================*/

        /*=========================================================================================================================*/
        /// <summary>
        /// FACS - Miscellaneous
        /// </summary>
        [Flags]
        public enum FACS_Miscellaneous
        {
            AU8_LipsToward = (1 << 0),
            AU29_JawThrust = (1 << 1),
            AU30_JawSideways = (1 << 2),
            AU34_CheekPuff = (1 << 3),
            AU36_TongueOut = (1 << 4),

            // None FACS
            CheekSuck = (1 << 5),
            Mouth = (1 << 6),
            TongueTipInterdental = (1 << 7),
            TongueTipAlveolar = (1 << 8),
            TongueFrontDorsalPalate = (1 << 9),
            TongueMidDorsalPalate = (1 << 10),
            TongueBackDorsalVelar = (1 << 11),
            TongueRetreat = (1 << 12),
        }

        public void GetSelection(FACS_Miscellaneous selection, out List<FACS_Miscellaneous> list)
        {
            if (selection.ToString() == "0") {list = new List<FACS_Miscellaneous>();}
            else 
            {
                list = selection.ToString().Split(',').Select(i => (FACS_Miscellaneous)Enum.Parse(typeof(FACS_Miscellaneous), i)).ToList();
            }
        }

        public string GetSelectionName(FACS_Miscellaneous input) { return input.ToString();}

        public object? GetSelectionValue(FACS_Miscellaneous input)
        {
            float t1;
            float t2;

            switch(input)
            {                  
                // Unique
                case FACS_Miscellaneous.AU8_LipsToward:
                    return _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.LipsToward);
                // Unique
                case FACS_Miscellaneous.AU29_JawThrust:
                    return _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.JawThrust);
                case FACS_Miscellaneous.AU30_JawSideways:
                    t1 = _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.JawSidewaysLeft);
                    t2 = _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.JawSidewaysRight);
                    return (t1+t2)/2;
                case FACS_Miscellaneous.AU34_CheekPuff:
                    t1 = _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.CheekPuffL);
                    t2 = _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.CheekPuffR);
                    return (t1+t2)/2;
                // Unique
                case FACS_Miscellaneous.AU36_TongueOut:
                    return _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.TongueOut);

                // None FACS
                case FACS_Miscellaneous.CheekSuck:
                    t1 = _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.CheekSuckL);
                    t2 = _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.CheekSuckR);
                    return (t1+t2)/2;
                case FACS_Miscellaneous.Mouth:
                    t1 = _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.MouthLeft);
                    t2 = _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.MouthRight);
                    return (t1+t2)/2;
                case FACS_Miscellaneous.TongueTipInterdental:
                    return _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.TongueTipInterdental);
                case FACS_Miscellaneous.TongueTipAlveolar:
                    return _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.TongueTipAlveolar);
                case FACS_Miscellaneous.TongueFrontDorsalPalate:
                    return _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.TongueFrontDorsalPalate);
                case FACS_Miscellaneous.TongueMidDorsalPalate:
                    return _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.TongueMidDorsalPalate);
                case FACS_Miscellaneous.TongueBackDorsalVelar:
                    return _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.TongueBackDorsalVelar);
                case FACS_Miscellaneous.TongueRetreat:
                    return _ovrFaceExpressions.GetWeight(OVRFaceExpressions.FaceExpression.TongueRetreat);
                default:
                    return null;
            }
        } 
        /*=========================================================================================================================*/
    }
}
