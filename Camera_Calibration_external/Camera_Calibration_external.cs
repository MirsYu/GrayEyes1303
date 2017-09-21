using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Camera_Calibration_external
{
    public class Camera_Calibration_external
    {
        private static void dev_close_window()
        {
            if (HDevWindowStack.IsOpen())
            {
                HOperatorSet.CloseWindow(HDevWindowStack.Pop());
            }
        }

        private static void dev_open_window(int Row,int Column, int Width,int Height,string Background,out HTuple WindowHandle)
        {
            HOperatorSet.SetWindowAttr("background_color", Background);
            HOperatorSet.OpenWindow(Row, Column, Width, Height, 0, "", "", out WindowHandle);
            HDevWindowStack.Push(WindowHandle);
        }

        private static void dev_set_draw(string DrawMode)
        {
            if (HDevWindowStack.IsOpen())
            {
                HOperatorSet.SetDraw(HDevWindowStack.GetActive(), DrawMode);
            }
        }

        private static void dev_set_line_width(int LineWidth)
        {
            if (HDevWindowStack.IsOpen())
            {
                HOperatorSet.SetLineWidth(HDevWindowStack.GetActive(), LineWidth);
            }
        }

        private static void dev_display(HObject Object)
        {
            if (HDevWindowStack.IsOpen())
            {
                HOperatorSet.DispObj(Object, HDevWindowStack.GetActive());
            }
        }

        private static void dev_set_color(string ColorName)
        {
            if (HDevWindowStack.IsOpen())
            {
                HOperatorSet.SetColor(HDevWindowStack.GetActive(), ColorName);
            }
        }

        private static void disp_cross(HTuple WindowHandle, HTuple Row, HTuple Column, double Size, double Angle)
        {
            HOperatorSet.DispCross(WindowHandle, Row, Column, Size, Angle);
        }

        private static void disp_message(HTuple WindowHandle,string String,string CoordSystem,int Row,int Column,string Color,string Box)
        {
            disp_message(WindowHandle, String, CoordSystem,
                Row, Column, Color, Box);
        }

        private static void set_display_font(HTuple WindowHandle, int Size, string Font, string Bold, string Slant)
        {
            set_display_font_private(WindowHandle, Size, Font, Bold, Slant);
        }

        private static void set_display_font_private(HTuple hv_WindowHandle, HTuple hv_Size, HTuple hv_Font,
                HTuple hv_Bold, HTuple hv_Slant)
        {



            // Local iconic variables 

            // Local control variables 

            HTuple hv_OS = null, hv_BufferWindowHandle = new HTuple();
            HTuple hv_Ascent = new HTuple(), hv_Descent = new HTuple();
            HTuple hv_Width = new HTuple(), hv_Height = new HTuple();
            HTuple hv_Scale = new HTuple(), hv_Exception = new HTuple();
            HTuple hv_SubFamily = new HTuple(), hv_Fonts = new HTuple();
            HTuple hv_SystemFonts = new HTuple(), hv_Guess = new HTuple();
            HTuple hv_I = new HTuple(), hv_Index = new HTuple(), hv_AllowedFontSizes = new HTuple();
            HTuple hv_Distances = new HTuple(), hv_Indices = new HTuple();
            HTuple hv_FontSelRegexp = new HTuple(), hv_FontsCourier = new HTuple();
            HTuple hv_Bold_COPY_INP_TMP = hv_Bold.Clone();
            HTuple hv_Font_COPY_INP_TMP = hv_Font.Clone();
            HTuple hv_Size_COPY_INP_TMP = hv_Size.Clone();
            HTuple hv_Slant_COPY_INP_TMP = hv_Slant.Clone();

            // Initialize local and output iconic variables 
            //This procedure sets the text font of the current window with
            //the specified attributes.
            //It is assumed that following fonts are installed on the system:
            //Windows: Courier New, Arial Times New Roman
            //Mac OS X: CourierNewPS, Arial, TimesNewRomanPS
            //Linux: courier, helvetica, times
            //Because fonts are displayed smaller on Linux than on Windows,
            //a scaling factor of 1.25 is used the get comparable results.
            //For Linux, only a limited number of font sizes is supported,
            //to get comparable results, it is recommended to use one of the
            //following sizes: 9, 11, 14, 16, 20, 27
            //(which will be mapped internally on Linux systems to 11, 14, 17, 20, 25, 34)
            //
            //Input parameters:
            //WindowHandle: The graphics window for which the font will be set
            //Size: The font size. If Size=-1, the default of 16 is used.
            //Bold: If set to 'true', a bold font is used
            //Slant: If set to 'true', a slanted font is used
            //
            HOperatorSet.GetSystem("operating_system", out hv_OS);
            // dev_get_preferences(...); only in hdevelop
            // dev_set_preferences(...); only in hdevelop
            if ((int)((new HTuple(hv_Size_COPY_INP_TMP.TupleEqual(new HTuple()))).TupleOr(
                new HTuple(hv_Size_COPY_INP_TMP.TupleEqual(-1)))) != 0)
            {
                hv_Size_COPY_INP_TMP = 16;
            }
            if ((int)(new HTuple(((hv_OS.TupleSubstr(0, 2))).TupleEqual("Win"))) != 0)
            {
                //Set font on Windows systems
                try
                {
                    //Check, if font scaling is switched on
                    HOperatorSet.OpenWindow(0, 0, 256, 256, 0, "buffer", "", out hv_BufferWindowHandle);
                    HOperatorSet.SetFont(hv_BufferWindowHandle, "-Consolas-16-*-0-*-*-1-");
                    HOperatorSet.GetStringExtents(hv_BufferWindowHandle, "test_string", out hv_Ascent,
                        out hv_Descent, out hv_Width, out hv_Height);
                    //Expected width is 110
                    hv_Scale = 110.0 / hv_Width;
                    hv_Size_COPY_INP_TMP = ((hv_Size_COPY_INP_TMP * hv_Scale)).TupleInt();
                    HOperatorSet.CloseWindow(hv_BufferWindowHandle);
                }
                // catch (Exception) 
                catch (HalconException HDevExpDefaultException1)
                {
                    HDevExpDefaultException1.ToHTuple(out hv_Exception);
                    //throw (Exception)
                }
                if ((int)((new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("Courier"))).TupleOr(
                    new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("courier")))) != 0)
                {
                    hv_Font_COPY_INP_TMP = "Courier New";
                }
                else if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("mono"))) != 0)
                {
                    hv_Font_COPY_INP_TMP = "Consolas";
                }
                else if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("sans"))) != 0)
                {
                    hv_Font_COPY_INP_TMP = "Arial";
                }
                else if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("serif"))) != 0)
                {
                    hv_Font_COPY_INP_TMP = "Times New Roman";
                }
                if ((int)(new HTuple(hv_Bold_COPY_INP_TMP.TupleEqual("true"))) != 0)
                {
                    hv_Bold_COPY_INP_TMP = 1;
                }
                else if ((int)(new HTuple(hv_Bold_COPY_INP_TMP.TupleEqual("false"))) != 0)
                {
                    hv_Bold_COPY_INP_TMP = 0;
                }
                else
                {
                    hv_Exception = "Wrong value of control parameter Bold";
                    throw new HalconException(hv_Exception);
                }
                if ((int)(new HTuple(hv_Slant_COPY_INP_TMP.TupleEqual("true"))) != 0)
                {
                    hv_Slant_COPY_INP_TMP = 1;
                }
                else if ((int)(new HTuple(hv_Slant_COPY_INP_TMP.TupleEqual("false"))) != 0)
                {
                    hv_Slant_COPY_INP_TMP = 0;
                }
                else
                {
                    hv_Exception = "Wrong value of control parameter Slant";
                    throw new HalconException(hv_Exception);
                }
                try
                {
                    HOperatorSet.SetFont(hv_WindowHandle, ((((((("-" + hv_Font_COPY_INP_TMP) + "-") + hv_Size_COPY_INP_TMP) + "-*-") + hv_Slant_COPY_INP_TMP) + "-*-*-") + hv_Bold_COPY_INP_TMP) + "-");
                }
                // catch (Exception) 
                catch (HalconException HDevExpDefaultException1)
                {
                    HDevExpDefaultException1.ToHTuple(out hv_Exception);
                    //throw (Exception)
                }
            }
            else if ((int)(new HTuple(((hv_OS.TupleSubstr(0, 2))).TupleEqual("Dar"))) != 0)
            {
                //Set font on Mac OS X systems. Since OS X does not have a strict naming
                //scheme for font attributes, we use tables to determine the correct font
                //name.
                hv_SubFamily = 0;
                if ((int)(new HTuple(hv_Slant_COPY_INP_TMP.TupleEqual("true"))) != 0)
                {
                    hv_SubFamily = hv_SubFamily.TupleBor(1);
                }
                else if ((int)(new HTuple(hv_Slant_COPY_INP_TMP.TupleNotEqual("false"))) != 0)
                {
                    hv_Exception = "Wrong value of control parameter Slant";
                    throw new HalconException(hv_Exception);
                }
                if ((int)(new HTuple(hv_Bold_COPY_INP_TMP.TupleEqual("true"))) != 0)
                {
                    hv_SubFamily = hv_SubFamily.TupleBor(2);
                }
                else if ((int)(new HTuple(hv_Bold_COPY_INP_TMP.TupleNotEqual("false"))) != 0)
                {
                    hv_Exception = "Wrong value of control parameter Bold";
                    throw new HalconException(hv_Exception);
                }
                if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("mono"))) != 0)
                {
                    hv_Fonts = new HTuple();
                    hv_Fonts[0] = "Menlo-Regular";
                    hv_Fonts[1] = "Menlo-Italic";
                    hv_Fonts[2] = "Menlo-Bold";
                    hv_Fonts[3] = "Menlo-BoldItalic";
                }
                else if ((int)((new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("Courier"))).TupleOr(
                    new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("courier")))) != 0)
                {
                    hv_Fonts = new HTuple();
                    hv_Fonts[0] = "CourierNewPSMT";
                    hv_Fonts[1] = "CourierNewPS-ItalicMT";
                    hv_Fonts[2] = "CourierNewPS-BoldMT";
                    hv_Fonts[3] = "CourierNewPS-BoldItalicMT";
                }
                else if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("sans"))) != 0)
                {
                    hv_Fonts = new HTuple();
                    hv_Fonts[0] = "ArialMT";
                    hv_Fonts[1] = "Arial-ItalicMT";
                    hv_Fonts[2] = "Arial-BoldMT";
                    hv_Fonts[3] = "Arial-BoldItalicMT";
                }
                else if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("serif"))) != 0)
                {
                    hv_Fonts = new HTuple();
                    hv_Fonts[0] = "TimesNewRomanPSMT";
                    hv_Fonts[1] = "TimesNewRomanPS-ItalicMT";
                    hv_Fonts[2] = "TimesNewRomanPS-BoldMT";
                    hv_Fonts[3] = "TimesNewRomanPS-BoldItalicMT";
                }
                else
                {
                    //Attempt to figure out which of the fonts installed on the system
                    //the user could have meant.
                    HOperatorSet.QueryFont(hv_WindowHandle, out hv_SystemFonts);
                    hv_Fonts = new HTuple();
                    hv_Fonts = hv_Fonts.TupleConcat(hv_Font_COPY_INP_TMP);
                    hv_Fonts = hv_Fonts.TupleConcat(hv_Font_COPY_INP_TMP);
                    hv_Fonts = hv_Fonts.TupleConcat(hv_Font_COPY_INP_TMP);
                    hv_Fonts = hv_Fonts.TupleConcat(hv_Font_COPY_INP_TMP);
                    hv_Guess = new HTuple();
                    hv_Guess = hv_Guess.TupleConcat(hv_Font_COPY_INP_TMP);
                    hv_Guess = hv_Guess.TupleConcat(hv_Font_COPY_INP_TMP + "-Regular");
                    hv_Guess = hv_Guess.TupleConcat(hv_Font_COPY_INP_TMP + "MT");
                    for (hv_I = 0; (int)hv_I <= (int)((new HTuple(hv_Guess.TupleLength())) - 1); hv_I = (int)hv_I + 1)
                    {
                        HOperatorSet.TupleFind(hv_SystemFonts, hv_Guess.TupleSelect(hv_I), out hv_Index);
                        if ((int)(new HTuple(hv_Index.TupleNotEqual(-1))) != 0)
                        {
                            if (hv_Fonts == null)
                                hv_Fonts = new HTuple();
                            hv_Fonts[0] = hv_Guess.TupleSelect(hv_I);
                            break;
                        }
                    }
                    //Guess name of slanted font
                    hv_Guess = new HTuple();
                    hv_Guess = hv_Guess.TupleConcat(hv_Font_COPY_INP_TMP + "-Italic");
                    hv_Guess = hv_Guess.TupleConcat(hv_Font_COPY_INP_TMP + "-ItalicMT");
                    hv_Guess = hv_Guess.TupleConcat(hv_Font_COPY_INP_TMP + "-Oblique");
                    for (hv_I = 0; (int)hv_I <= (int)((new HTuple(hv_Guess.TupleLength())) - 1); hv_I = (int)hv_I + 1)
                    {
                        HOperatorSet.TupleFind(hv_SystemFonts, hv_Guess.TupleSelect(hv_I), out hv_Index);
                        if ((int)(new HTuple(hv_Index.TupleNotEqual(-1))) != 0)
                        {
                            if (hv_Fonts == null)
                                hv_Fonts = new HTuple();
                            hv_Fonts[1] = hv_Guess.TupleSelect(hv_I);
                            break;
                        }
                    }
                    //Guess name of bold font
                    hv_Guess = new HTuple();
                    hv_Guess = hv_Guess.TupleConcat(hv_Font_COPY_INP_TMP + "-Bold");
                    hv_Guess = hv_Guess.TupleConcat(hv_Font_COPY_INP_TMP + "-BoldMT");
                    for (hv_I = 0; (int)hv_I <= (int)((new HTuple(hv_Guess.TupleLength())) - 1); hv_I = (int)hv_I + 1)
                    {
                        HOperatorSet.TupleFind(hv_SystemFonts, hv_Guess.TupleSelect(hv_I), out hv_Index);
                        if ((int)(new HTuple(hv_Index.TupleNotEqual(-1))) != 0)
                        {
                            if (hv_Fonts == null)
                                hv_Fonts = new HTuple();
                            hv_Fonts[2] = hv_Guess.TupleSelect(hv_I);
                            break;
                        }
                    }
                    //Guess name of bold slanted font
                    hv_Guess = new HTuple();
                    hv_Guess = hv_Guess.TupleConcat(hv_Font_COPY_INP_TMP + "-BoldItalic");
                    hv_Guess = hv_Guess.TupleConcat(hv_Font_COPY_INP_TMP + "-BoldItalicMT");
                    hv_Guess = hv_Guess.TupleConcat(hv_Font_COPY_INP_TMP + "-BoldOblique");
                    for (hv_I = 0; (int)hv_I <= (int)((new HTuple(hv_Guess.TupleLength())) - 1); hv_I = (int)hv_I + 1)
                    {
                        HOperatorSet.TupleFind(hv_SystemFonts, hv_Guess.TupleSelect(hv_I), out hv_Index);
                        if ((int)(new HTuple(hv_Index.TupleNotEqual(-1))) != 0)
                        {
                            if (hv_Fonts == null)
                                hv_Fonts = new HTuple();
                            hv_Fonts[3] = hv_Guess.TupleSelect(hv_I);
                            break;
                        }
                    }
                }
                hv_Font_COPY_INP_TMP = hv_Fonts.TupleSelect(hv_SubFamily);
                try
                {
                    HOperatorSet.SetFont(hv_WindowHandle, (hv_Font_COPY_INP_TMP + "-") + hv_Size_COPY_INP_TMP);
                }
                // catch (Exception) 
                catch (HalconException HDevExpDefaultException1)
                {
                    HDevExpDefaultException1.ToHTuple(out hv_Exception);
                    //throw (Exception)
                }
            }
            else
            {
                //Set font for UNIX systems
                hv_Size_COPY_INP_TMP = hv_Size_COPY_INP_TMP * 1.25;
                hv_AllowedFontSizes = new HTuple();
                hv_AllowedFontSizes[0] = 11;
                hv_AllowedFontSizes[1] = 14;
                hv_AllowedFontSizes[2] = 17;
                hv_AllowedFontSizes[3] = 20;
                hv_AllowedFontSizes[4] = 25;
                hv_AllowedFontSizes[5] = 34;
                if ((int)(new HTuple(((hv_AllowedFontSizes.TupleFind(hv_Size_COPY_INP_TMP))).TupleEqual(
                    -1))) != 0)
                {
                    hv_Distances = ((hv_AllowedFontSizes - hv_Size_COPY_INP_TMP)).TupleAbs();
                    HOperatorSet.TupleSortIndex(hv_Distances, out hv_Indices);
                    hv_Size_COPY_INP_TMP = hv_AllowedFontSizes.TupleSelect(hv_Indices.TupleSelect(
                        0));
                }
                if ((int)((new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("mono"))).TupleOr(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual(
                    "Courier")))) != 0)
                {
                    hv_Font_COPY_INP_TMP = "courier";
                }
                else if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("sans"))) != 0)
                {
                    hv_Font_COPY_INP_TMP = "helvetica";
                }
                else if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("serif"))) != 0)
                {
                    hv_Font_COPY_INP_TMP = "times";
                }
                if ((int)(new HTuple(hv_Bold_COPY_INP_TMP.TupleEqual("true"))) != 0)
                {
                    hv_Bold_COPY_INP_TMP = "bold";
                }
                else if ((int)(new HTuple(hv_Bold_COPY_INP_TMP.TupleEqual("false"))) != 0)
                {
                    hv_Bold_COPY_INP_TMP = "medium";
                }
                else
                {
                    hv_Exception = "Wrong value of control parameter Bold";
                    throw new HalconException(hv_Exception);
                }
                if ((int)(new HTuple(hv_Slant_COPY_INP_TMP.TupleEqual("true"))) != 0)
                {
                    if ((int)(new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("times"))) != 0)
                    {
                        hv_Slant_COPY_INP_TMP = "i";
                    }
                    else
                    {
                        hv_Slant_COPY_INP_TMP = "o";
                    }
                }
                else if ((int)(new HTuple(hv_Slant_COPY_INP_TMP.TupleEqual("false"))) != 0)
                {
                    hv_Slant_COPY_INP_TMP = "r";
                }
                else
                {
                    hv_Exception = "Wrong value of control parameter Slant";
                    throw new HalconException(hv_Exception);
                }
                try
                {
                    HOperatorSet.SetFont(hv_WindowHandle, ((((((("-adobe-" + hv_Font_COPY_INP_TMP) + "-") + hv_Bold_COPY_INP_TMP) + "-") + hv_Slant_COPY_INP_TMP) + "-normal-*-") + hv_Size_COPY_INP_TMP) + "-*-*-*-*-*-*-*");
                }
                // catch (Exception) 
                catch (HalconException HDevExpDefaultException1)
                {
                    HDevExpDefaultException1.ToHTuple(out hv_Exception);
                    if ((int)((new HTuple(((hv_OS.TupleSubstr(0, 4))).TupleEqual("Linux"))).TupleAnd(
                        new HTuple(hv_Font_COPY_INP_TMP.TupleEqual("courier")))) != 0)
                    {
                        HOperatorSet.QueryFont(hv_WindowHandle, out hv_Fonts);
                        hv_FontSelRegexp = (("^-[^-]*-[^-]*[Cc]ourier[^-]*-" + hv_Bold_COPY_INP_TMP) + "-") + hv_Slant_COPY_INP_TMP;
                        hv_FontsCourier = ((hv_Fonts.TupleRegexpSelect(hv_FontSelRegexp))).TupleRegexpMatch(
                            hv_FontSelRegexp);
                        if ((int)(new HTuple((new HTuple(hv_FontsCourier.TupleLength())).TupleEqual(
                            0))) != 0)
                        {
                            hv_Exception = "Wrong font name";
                            //throw (Exception)
                        }
                        else
                        {
                            try
                            {
                                HOperatorSet.SetFont(hv_WindowHandle, (((hv_FontsCourier.TupleSelect(
                                    0)) + "-normal-*-") + hv_Size_COPY_INP_TMP) + "-*-*-*-*-*-*-*");
                            }
                            // catch (Exception) 
                            catch (HalconException HDevExpDefaultException2)
                            {
                                HDevExpDefaultException2.ToHTuple(out hv_Exception);
                                //throw (Exception)
                            }
                        }
                    }
                    //throw (Exception)
                }
            }
            // dev_set_preferences(...); only in hdevelop

            return;
        }
        private static void read_cam_par(string CamParFile,out HTuple CameraParam)
        {
            HTuple hv_Exception = null;
            try
            {
                HOperatorSet.ReadCamPar(CamParFile, out CameraParam);
            }
            catch (HalconException HDevExpDefaultException1)
            {
                CameraParam = null;
                HDevExpDefaultException1.ToHTuple(out hv_Exception);
            }
        }

        private static void read_image(out HObject Image,string FileName)
        {
            HOperatorSet.GenEmptyObj(out Image);
            Image.Dispose();
            HOperatorSet.ReadImage(out Image, FileName);
        }

        private static void create_calib_data(string CalibSetup,HTuple NumCameras,int NumCalibObject,out HTuple CalibDataID)
        {
            HOperatorSet.CreateCalibData(CalibSetup, NumCameras, NumCalibObject, out CalibDataID);
        }

        private static void set_calib_data_cam_param(HTuple CalibDataID, int CameraIdx,string CameraType,HTuple CamParam)
        {
            HOperatorSet.SetCalibDataCamParam(CalibDataID, CameraIdx, CameraType, CamParam);
        }

        private static void set_calib_data_calib_object(HTuple CalibDataID,int CalibObjIdx,string CalibObjDescr)
        {
            HOperatorSet.SetCalibDataCalibObject(CalibDataID, CalibObjIdx, CalibObjDescr);
        }

        private static void find_calib_object(HObject Image,HTuple CalibDataID,int CameraIdx,int CalibObjIdx,int CalibObjPoseIdx,HTuple GenParamName, HTuple GenParamValue)
        {
            HOperatorSet.FindCalibObject(Image, CalibDataID, CameraIdx, CalibObjIdx, CalibObjPoseIdx, GenParamName, GenParamValue);
        }

        private static void get_calib_data_observ_contours(out HObject Contours,HTuple CalibDataID,string ContourName,int CameraIdx,int CalibObjIdx,int CalibObjPoseIdx)
        {
            HOperatorSet.GenEmptyObj(out Contours);
            Contours.Dispose();
            HOperatorSet.GetCalibDataObservContours(out Contours, CalibDataID, ContourName, CameraIdx, CalibObjIdx, CalibObjPoseIdx);
        }

        private static void get_calib_data_observ_points(HTuple CalibDataID, int CameraIdx, int CalibObjIdx, int CalibObjPoseIdx,
            out HTuple Row, out HTuple Column, out HTuple Index, out HTuple Pose)
        {
            HOperatorSet.GetCalibDataObservPoints(CalibDataID, CameraIdx, CalibObjIdx, CalibObjPoseIdx, out Row,
                out Column, out Index, out Pose);
        }

        private static void disp_caltab(HTuple WindowHandle,string CalPlateDescr,HTuple CameraParam,HTuple CalPlatePose,double ScaleFac)
        {
            HOperatorSet.DispCaltab(WindowHandle, CalPlateDescr, CameraParam, CalPlatePose, ScaleFac);
        }

        private static void disp_circle(HTuple WindowHandle,HTuple Row, HTuple Column, HTuple Radius)
        {
            HOperatorSet.DispCircle(WindowHandle, Row, Column, Radius);
        }

        private static void tuple_gen_const(HTuple Length,double Const,out HTuple newtuple)
        {
            HOperatorSet.TupleGenConst(Length, Const, out newtuple);
        }

        private static void tuple_length(HTuple Tuple,out HTuple Length)
        {
            HOperatorSet.TupleLength(Tuple, out Length);
        }

        private static void set_origin_pose(HTuple PoseIn,double DX,double DY,double DZ,out HTuple PoseNewOrigin)
        {
            HOperatorSet.SetOriginPose(PoseIn, DX, DY, DZ, out PoseNewOrigin);
        }

        private static void clear_calib_data(HTuple CalibDataID)
        {
            HOperatorSet.ClearCalibData(CalibDataID);
        }

        private static void tuple_Arr_int(int[] Input,out HTuple Result)
        {
            Result = new HTuple(Input);
        }

        private static void vector_to_pose(HTuple WorldX,HTuple WorldY,HTuple WorldZ,HTuple ImageRow,HTuple ImageColumn,HTuple CameraParam,
            string Method,string QualityType,out HTuple Pose,out HTuple Quality)
        {
            HOperatorSet.VectorToPose(WorldX, WorldY, WorldZ, ImageRow, ImageColumn, CameraParam,
                 Method, QualityType, out Pose, out Quality);
        }

        private static void write_pose(HTuple Pose,string PoseFile)
        {
            HOperatorSet.WritePose(Pose, PoseFile);
        }

        private static void get_mbutton(HTuple WindowHandle,out HTuple Row,out HTuple Column,out HTuple Button)
        {
            HOperatorSet.GetMbutton(WindowHandle, out Row, out Column, out Button);
        }

        private static void tuple_equal(HTuple t1, HTuple t2,out int equal)
        {
            HTuple hTuple = new HTuple();
            HOperatorSet.TupleEqual(t1, t2, out hTuple);
            equal = (int)hTuple;
        }

        private static void image_points_to_world_plane(HTuple CamParam, HTuple WorldPose, HTuple Row, HTuple Column, string Scale,
            out HTuple X, out HTuple Y)
        {
            HOperatorSet.ImagePointsToWorldPlane(CamParam, WorldPose, Row, Column,
                Scale, out X, out Y);
        }


        public static void action(HWindow hv_WindowHandle, string FileName, string CamParFile, string CalibObjDescr,
            int NumCameras =1, int NumCalibObjects =1,
            int CameraIdx = 0, int CalibObjIdx = 0, int CalibObjPoseIdx = 1, int LineWidth = 3, 
            double Const = 1.5,double ScaleFac = 1,double DX = 0,double DY = 0,double DZ = 0.00075,
            string CameraType = "area_scan_division",string ContourName = "caltab")
        {
            HTuple WindowHandle = hv_WindowHandle;
            HTuple CameraParam = new HTuple();
            HObject Image = new HObject();
            HTuple CalibDataID = new HTuple();
            HTuple GenParamName = new HTuple();
            HTuple GenParamValue = new HTuple();
            HObject Contours = new HObject();
            HTuple Row = new HTuple();
            HTuple Column = new HTuple();
            HTuple Index = new HTuple();
            HTuple Pose = new HTuple();
            HTuple Length = new HTuple();
            HTuple newtuple = new HTuple();

            read_cam_par(CamParFile, out CameraParam);
            read_image(out Image, FileName);
            dev_display(Image);
            
            create_calib_data("calibration_object", NumCameras, NumCalibObjects, out CalibDataID);
            set_calib_data_cam_param(CalibDataID, CameraIdx, CameraType, CameraParam);
            set_calib_data_calib_object(CalibDataID, CalibObjIdx, CalibObjDescr);
            find_calib_object(Image, CalibDataID, CameraIdx, CalibObjIdx, CalibObjPoseIdx, GenParamName, GenParamValue);
            get_calib_data_observ_contours(out Contours, CalibDataID, ContourName, CameraIdx, CalibObjIdx, CalibObjPoseIdx);
            get_calib_data_observ_points(CalibDataID, CameraIdx, CalibObjIdx, CalibObjPoseIdx, out Row, out Column, out Index, out Pose);
            dev_set_color("green");
            dev_display(Contours);
            dev_set_color("red");
            disp_caltab(WindowHandle, CalibObjDescr, CameraParam, Pose, ScaleFac);
            dev_set_line_width(LineWidth);
            tuple_length(Row, out Length);
            tuple_gen_const(Length, Const, out newtuple);
            disp_circle(WindowHandle, Row, Column, newtuple);
            set_origin_pose(Pose, DX, DY, DZ, out Pose);
            clear_calib_data(CalibDataID);
        }
   
    }
}
