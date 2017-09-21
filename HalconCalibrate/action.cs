using HalconDotNet;

public partial class HDevelopExport
{
  private void action(string ImgPath)
  {
    HObject ho_Image1, ho_Image=null, ho_Caltab=null;
    HTuple hv_ImgPath = null, hv_Pointer = null;
    HTuple hv_Type = null, hv_Width = null, hv_Height = null;
    HTuple hv_WindowHandle1 = null, hv_StartCamPar = null;
    HTuple hv_TmpCtrl_FindCalObjParNames = null, hv_TmpCtrl_FindCalObjParValues = null;
    HTuple hv_CalibDataID = null, hv_NumImages = null, hv_I = null;
    HTuple hv_RCoord = new HTuple(), hv_CCoord = new HTuple();
    HTuple hv_Index = null, hv_StartPose = new HTuple(), hv_CaltabName = null;
    HTuple hv_Error = null, hv_CamParam = null, hv_WindowHandle = null;
    HTuple hv_Exception = null, hv_Row = null, hv_Column = null;
    HTuple hv_Pose = null, hv_X = null, hv_Y = null, hv_Z = null;
    HTuple hv_Image_X1 = null, hv_Image_Y1 = null, hv_Distance_XY = null;
    HTuple hv_Image_X2 = null, hv_Image_Y2 = null, hv_World_X1 = null;
    HTuple hv_World_Y1 = null, hv_World_X2 = null, hv_World_Y2 = null;
    HTuple hv_DistanceWorld = null, hv_DistanceImage = null;
    HTuple hv_DistanceOneMilimeter = null, hv_DistanceOnePixel = null;
    HTuple hv_OffSetX = null, hv_OffSetY = null, hv_FinalPose = null;
    HTuple hv_Erros = null, hv_X1 = null, hv_Y1 = null;
    // Initialize local and output iconic variables 
    HOperatorSet.GenEmptyObj(out ho_Image1);
    HOperatorSet.GenEmptyObj(out ho_Image);
    HOperatorSet.GenEmptyObj(out ho_Caltab);
    try
    {
      //相机内部标定(需要很多位置的标定板图像) 黑三角为第三象限
      //图片文件夹
      hv_ImgPath = ImgPath;

      if (HDevWindowStack.IsOpen())
      {
        HOperatorSet.CloseWindow(HDevWindowStack.Pop());
      }
      ho_Image1.Dispose();
      HOperatorSet.ReadImage(out ho_Image1, hv_ImgPath+"calib_01");
      HOperatorSet.GetImagePointer1(ho_Image1, out hv_Pointer, out hv_Type, out hv_Width, 
          out hv_Height);
      HOperatorSet.SetWindowAttr("background_color","black");
      HOperatorSet.OpenWindow(0,0,hv_Width,hv_Height,0,"visible","",out hv_WindowHandle1);
      HDevWindowStack.Push(hv_WindowHandle1);

      //初始相机参数
      hv_StartCamPar = new HTuple();
      hv_StartCamPar[0] = 0;
      hv_StartCamPar[1] = 0;
      hv_StartCamPar[2] = 1.67e-006;
      hv_StartCamPar[3] = 1.67e-006;
      hv_StartCamPar = hv_StartCamPar.TupleConcat(hv_Width/2);
      hv_StartCamPar = hv_StartCamPar.TupleConcat(hv_Height/2);
      hv_StartCamPar = hv_StartCamPar.TupleConcat(hv_Width);
      hv_StartCamPar = hv_StartCamPar.TupleConcat(hv_Height);
      hv_TmpCtrl_FindCalObjParNames = new HTuple();
      hv_TmpCtrl_FindCalObjParNames[0] = "gap_tolerance";
      hv_TmpCtrl_FindCalObjParNames[1] = "alpha";
      hv_TmpCtrl_FindCalObjParNames[2] = "skip_find_caltab";
      hv_TmpCtrl_FindCalObjParValues = new HTuple();
      hv_TmpCtrl_FindCalObjParValues[0] = 1;
      hv_TmpCtrl_FindCalObjParValues[1] = 1;
      hv_TmpCtrl_FindCalObjParValues[2] = "false";
      //生成一个标定数据模型（制定设置中的相机数量和校准对象数量）
      HOperatorSet.CreateCalibData("calibration_object", 1, 1, out hv_CalibDataID);
      //设置相机类型和初始参数（设置相机类型和初始内部相机参数）,只有相同类型的相机可以在单个设置中校准
      HOperatorSet.SetCalibDataCamParam(hv_CalibDataID, 0, "area_scan_telecentric_division", 
          hv_StartCamPar);
      //根据标定板规格生成标定板文件
      HOperatorSet.GenCaltab(7, 7, 0.000625, 0.5, "caltab.descr", "caltab.ps");
      //根据标定板模型创建一个标定对象(描述校准对象)
      HOperatorSet.SetCalibDataCalibObject(hv_CalibDataID, 0, "caltab.descr");
      hv_NumImages = 20;
      HTuple end_val24 = hv_NumImages;
      HTuple step_val24 = 1;
      for (hv_I=1; hv_I.Continue(end_val24, step_val24); hv_I = hv_I.TupleAdd(step_val24))
      {
        ho_Image.Dispose();
        HOperatorSet.ReadImage(out ho_Image, (hv_ImgPath+"calib_")+(hv_I.TupleString(
            "02d")));
        //找到Halcon标定板，并将数据存入校准数据模型中(收集数据)
        //即提取校准对象的mark点的图像坐标以及相机粗略估计姿态
        if (HDevWindowStack.IsOpen())
        {
          HOperatorSet.DispObj(ho_Image, HDevWindowStack.GetActive());
        }
        HOperatorSet.FindCalibObject(ho_Image, hv_CalibDataID, 0, 0, hv_I, hv_TmpCtrl_FindCalObjParNames, 
            hv_TmpCtrl_FindCalObjParValues);
        //从校准数据模型中获取轮廓数据
        ho_Caltab.Dispose();
        HOperatorSet.GetCalibDataObservContours(out ho_Caltab, hv_CalibDataID, "caltab", 
            0, 0, hv_I);
        if (HDevWindowStack.IsOpen())
        {
          HOperatorSet.SetColor(HDevWindowStack.GetActive(), "green");
        }
        if (HDevWindowStack.IsOpen())
        {
          HOperatorSet.DispObj(ho_Caltab, HDevWindowStack.GetActive());
        }
        HOperatorSet.GetCalibDataObservPoints(hv_CalibDataID, 0, 0, hv_I, out hv_RCoord, 
            out hv_CCoord, out hv_Index, out hv_StartPose);
        //find_marks_and_pose (Image, Caltab, CaltabName, StartCamPar, 128, 10, 18, 0.9, 15, 100, RCoord, CCoord, StartPose)
        if (HDevWindowStack.IsOpen())
        {
          HOperatorSet.SetColor(HDevWindowStack.GetActive(), "red");
        }
        HOperatorSet.DispCircle(hv_WindowHandle1, hv_RCoord, hv_CCoord, HTuple.TupleGenConst(
            new HTuple(hv_RCoord.TupleLength()),2.5));
        if (HDevWindowStack.IsOpen())
        {
          HOperatorSet.SetPart(HDevWindowStack.GetActive(), 0, 0, hv_Height-1, hv_Width-1);
        }
        //set_calib_data_observ_points (CalibDataID, 0, 0, i, RCoord, CCoord, 'all', StartPose)
      }

      //执行实际的校准
      //校准相机
      HOperatorSet.CalibrateCameras(hv_CalibDataID, out hv_Error);
      //获得相机参数
      HOperatorSet.GetCalibData(hv_CalibDataID, "camera", 0, "params", out hv_CamParam);
      //保存相机参数
      HOperatorSet.WriteCamPar(hv_CamParam, "camera_parameters.dat");
      HOperatorSet.ClearCalibData(hv_CalibDataID);
      // stop(...); only in hdevelop

      //外部标定(只需要一张标定板图像)
      //即获取相机的姿态
      if (HDevWindowStack.IsOpen())
      {
        HOperatorSet.SetDraw(HDevWindowStack.GetActive(), "margin");
      }
      if (HDevWindowStack.IsOpen())
      {
        HOperatorSet.SetLineWidth(HDevWindowStack.GetActive(), 1);
      }
      if (HDevWindowStack.IsOpen())
      {
        HOperatorSet.CloseWindow(HDevWindowStack.Pop());
      }
      HOperatorSet.SetWindowAttr("background_color","black");
      HOperatorSet.OpenWindow(0,hv_Width+5,hv_Width,hv_Height,0,"visible","",out hv_WindowHandle);
      HDevWindowStack.Push(hv_WindowHandle);

      //读取初始相机参数
      try
      {
        HOperatorSet.ReadCamPar("camera_parameters.dat", out hv_CamParam);
      }
      // catch (Exception) 
      catch (HalconException HDevExpDefaultException1)
      {
        HDevExpDefaultException1.ToHTuple(out hv_Exception);
        // stop(...); only in hdevelop
      }

      //从图像点确定外部摄像机参数和世界坐标
      //当校准板直接放在测量平面上时 可以从图像确定外部摄像机参数
      ho_Image.Dispose();
      HOperatorSet.ReadImage(out ho_Image, hv_ImgPath+"calib_01");
      if (HDevWindowStack.IsOpen())
      {
        HOperatorSet.DispObj(ho_Image, HDevWindowStack.GetActive());
      }
      hv_CaltabName = "caltab.descr";
      hv_TmpCtrl_FindCalObjParNames = new HTuple();
      hv_TmpCtrl_FindCalObjParNames[0] = "gap_tolerance";
      hv_TmpCtrl_FindCalObjParNames[1] = "alpha";
      hv_TmpCtrl_FindCalObjParNames[2] = "skip_find_caltab";
      hv_TmpCtrl_FindCalObjParValues = new HTuple();
      hv_TmpCtrl_FindCalObjParValues[0] = 1;
      hv_TmpCtrl_FindCalObjParValues[1] = 1;
      hv_TmpCtrl_FindCalObjParValues[2] = "false";
      //生产一个标定数据模型
      HOperatorSet.CreateCalibData("calibration_object", 1, 1, out hv_CalibDataID);
      //设置相机类型和初始参数
      HOperatorSet.SetCalibDataCamParam(hv_CalibDataID, 0, "area_scan_telecentric_division", 
          hv_CamParam);
      //定义校准对象
      HOperatorSet.SetCalibDataCalibObject(hv_CalibDataID, 0, hv_CaltabName);
      //找到Halcon标定板，并将数据写入校准数据模型中
      HOperatorSet.FindCalibObject(ho_Image, hv_CalibDataID, 0, 0, 1, hv_TmpCtrl_FindCalObjParNames, 
          hv_TmpCtrl_FindCalObjParValues);
      //获得标定区域轮廓
      ho_Caltab.Dispose();
      HOperatorSet.GetCalibDataObservContours(out ho_Caltab, hv_CalibDataID, "caltab", 
          0, 0, 1);
      //获得标定区域mark点的信息
      HOperatorSet.GetCalibDataObservPoints(hv_CalibDataID, 0, 0, 1, out hv_Row, 
          out hv_Column, out hv_Index, out hv_Pose);
      if (HDevWindowStack.IsOpen())
      {
        HOperatorSet.SetColor(HDevWindowStack.GetActive(), "green");
      }
      if (HDevWindowStack.IsOpen())
      {
        HOperatorSet.DispObj(ho_Caltab, HDevWindowStack.GetActive());
      }
      if (HDevWindowStack.IsOpen())
      {
        HOperatorSet.SetColor(HDevWindowStack.GetActive(), "red");
      }
      //显示标定的结果
      HOperatorSet.DispCaltab(hv_WindowHandle, hv_CaltabName, hv_CamParam, hv_Pose, 
          1);
      if (HDevWindowStack.IsOpen())
      {
        HOperatorSet.SetLineWidth(HDevWindowStack.GetActive(), 3);
      }
      //在mark点中心画点
      HOperatorSet.DispCircle(hv_WindowHandle, hv_Row, hv_Column, HTuple.TupleGenConst(
          new HTuple(hv_Row.TupleLength()),1.5));
      // stop(...); only in hdevelop
      //取得校准文件内的坐标数据
      //caltab_points (CaltabName, X, Y, Z)
      //calibrate_cameras (CalibDataID, Error)

      //考虑标定板厚度进行姿态矫正 3.5mm厚度
      HOperatorSet.SetOriginPose(hv_Pose, 0, 0, 0.0035, out hv_Pose);

      HOperatorSet.ClearCalibData(hv_CalibDataID);
      //图像坐标转世界坐标
      HOperatorSet.ImagePointsToWorldPlane(hv_CamParam, hv_Pose, hv_Row, hv_Column, 
          "mm", out hv_X, out hv_Y);

      hv_Image_X1 = 100;
      hv_Image_Y1 = 100;
      hv_Distance_XY = 500;
      hv_Image_X2 = hv_Image_X1+hv_Distance_XY;
      hv_Image_Y2 = hv_Image_Y1+hv_Distance_XY;
      HOperatorSet.ImagePointsToWorldPlane(hv_CamParam, hv_Pose, hv_Image_Y1, hv_Image_X1, 
          "mm", out hv_World_X1, out hv_World_Y1);
      HOperatorSet.ImagePointsToWorldPlane(hv_CamParam, hv_Pose, hv_Image_Y2, hv_Image_X2, 
          "mm", out hv_World_X2, out hv_World_Y2);
      //计算世界坐标距离?
      HOperatorSet.DistancePp(hv_World_Y1, hv_World_X1, hv_World_Y2, hv_World_X2, 
          out hv_DistanceWorld);
      //计算像素坐标?
      HOperatorSet.DistancePp(hv_Image_X1, hv_Image_Y1, hv_Image_X2, hv_Image_Y2, 
          out hv_DistanceImage);
      //每毫米世界坐标距=距离对应的像素点个数?
      hv_DistanceOneMilimeter = hv_DistanceImage/hv_DistanceWorld;
      //每个像素对应的世界坐标距离?
      hv_DistanceOnePixel = hv_DistanceWorld/hv_DistanceImage;
      //调整世界坐标至中心偏移量?
      hv_OffSetX = (hv_Width/2)*hv_DistanceOnePixel;
      hv_OffSetY = (hv_Height/2)*hv_DistanceOnePixel;

      //
      hv_X = new HTuple();
      hv_X[0] = 0;
      hv_X[1] = 50;
      hv_X[2] = 100;
      hv_X[3] = 80;
      hv_Y = new HTuple();
      hv_Y[0] = 5;
      hv_Y[1] = 0;
      hv_Y[2] = 5;
      hv_Y[3] = 0;
      hv_Z = new HTuple();
      hv_Z[0] = 0;
      hv_Z[1] = 0;
      hv_Z[2] = 0;
      hv_Z[3] = 0;

      hv_RCoord = new HTuple();
      hv_RCoord[0] = 414;
      hv_RCoord[1] = 227;
      hv_RCoord[2] = 85;
      hv_RCoord[3] = 128;
      hv_CCoord = new HTuple();
      hv_CCoord[0] = 119;
      hv_CCoord[1] = 318;
      hv_CCoord[2] = 550;
      hv_CCoord[3] = 448;

      HOperatorSet.VectorToPose(hv_X, hv_Y, hv_Z, hv_RCoord, hv_CCoord, hv_CamParam, 
          "telecentric_planar_robust", "error", out hv_FinalPose, out hv_Erros);
      HOperatorSet.WritePose(hv_FinalPose, "campose.dat");
      HOperatorSet.ImagePointsToWorldPlane(hv_CamParam, hv_FinalPose, hv_Row, hv_Column, 
          1, out hv_X1, out hv_Y1);
    }
    catch (HalconException HDevExpDefaultException)
    {
      ho_Image1.Dispose();
      ho_Image.Dispose();
      ho_Caltab.Dispose();

      throw HDevExpDefaultException;
    }
    ho_Image1.Dispose();
    ho_Image.Dispose();
    ho_Caltab.Dispose();

  }

}

