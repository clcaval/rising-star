//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RISING.STAR.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Acquisitions_Table
    {
        public int Id_Acq { get; set; }
        public System.Guid Guid { get; set; }
        public int FK_Id_Patient { get; set; }
        public System.Guid FK_Guid_Patient { get; set; }
        public System.DateTime DATE { get; set; }
        public System.DateTime HOUR { get; set; }
        public bool OS { get; set; }
        public bool OD { get; set; }
        public string OS_OD { get; set; }
        public Nullable<float> SPH { get; set; }
        public Nullable<float> CYL { get; set; }
        public string AXIS { get; set; }
        public string BCVA { get; set; }
        public string UCVA { get; set; }
        public Nullable<double> REFERENCE_SPH_REFRAC { get; set; }
        public Nullable<short> AP { get; set; }
        public Nullable<double> NP { get; set; }
        public string NOTES { get; set; }
        public Nullable<double> BESTFOCUS { get; set; }
        public Nullable<double> WIDTH_PROFILE_1_2 { get; set; }
        public Nullable<double> WIDTH_PROFILE_1_10 { get; set; }
        public Nullable<double> MTF_CUT_OFF { get; set; }
        public Nullable<double> STREHL_RATIO { get; set; }
        public Nullable<float> VA_100 { get; set; }
        public Nullable<float> VA_20 { get; set; }
        public Nullable<float> VA_9 { get; set; }
        public Nullable<float> OQAS_VALUE_100 { get; set; }
        public Nullable<float> OQAS_VALUE_20 { get; set; }
        public Nullable<float> OQAS_VALUE_9 { get; set; }
        public Nullable<short> Type_Num { get; set; }
        public string Type { get; set; }
        public Nullable<short> Corr_Type_Num { get; set; }
        public string Corr_Type { get; set; }
        public Nullable<short> NImag { get; set; }
        public Nullable<short> NImag_Acc_Each { get; set; }
        public string COMPUTED_IMAGES { get; set; }
        public Nullable<double> OAR { get; set; }
        public Nullable<double> OSI { get; set; }
        public Nullable<int> Refrac_Acc_Per_1 { get; set; }
        public Nullable<int> Refrac_Acc_Per_2 { get; set; }
        public Nullable<double> AR { get; set; }
        public Nullable<double> Time_Each_Image_TearFilm { get; set; }
        public string TearFilm_Time { get; set; }
        public string TearFilm_OSI { get; set; }
        public string TearFilm_Central_Energy { get; set; }
        public string TearFilm_Peripheral_Energy { get; set; }
        public string TearFilm_VA { get; set; }
        public string TearFilm_MTFCutoff { get; set; }
        public Nullable<float> TearFilm_MeanOSI { get; set; }
        public Nullable<float> TearFilm_StdevOSI { get; set; }
        public Nullable<bool> RotatedCamera { get; set; }
        public Nullable<bool> PKJ_IsPreOperation { get; set; }
        public Nullable<double> PKJ_MicrasPerPixel { get; set; }
        public Nullable<double> PKJ_PupilDiameter { get; set; }
        public Nullable<int> PKJ_PkjVsPupil_Length { get; set; }
        public Nullable<int> PKJ_PkjVsPupil_Angle { get; set; }
        public Nullable<int> PKJ_PkjVsPupil_X { get; set; }
        public Nullable<int> PKJ_PkjVsPupil_Y { get; set; }
        public Nullable<int> PKJ_InlayVsPupil_X { get; set; }
        public Nullable<int> PKJ_InlayVsPupil_Y { get; set; }
        public Nullable<int> PKJ_InlayVsPkj_X { get; set; }
        public Nullable<int> PKJ_InlayVsPkj_Y { get; set; }
        public Nullable<double> PKJ_Pupil_PixelCentroX { get; set; }
        public Nullable<double> PKJ_Pupil_PixelCentroY { get; set; }
        public Nullable<double> PKJ_Pupil_PixelRadio { get; set; }
        public Nullable<double> PKJ_Laser_PixelCentroX { get; set; }
        public Nullable<double> PKJ_Laser_PixelCentroY { get; set; }
        public Nullable<double> PKJ_Inlay_PixelCentroX { get; set; }
        public Nullable<double> PKJ_Inlay_PixelCentroY { get; set; }
        public Nullable<double> PKJ_Inlay_PixelRadio { get; set; }
    
        public virtual ExamType ExamType { get; set; }
        public virtual Patients_Table Patients_Table { get; set; }
    }
}
