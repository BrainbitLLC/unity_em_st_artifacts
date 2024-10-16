using NativeLibSourceGeneratorShared;
using System;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;

namespace SignalMath
{
    internal static class EmStLibNamePropvider
    {
        public const string LibName = "em_st_artifacts";
        public const string LibNameiOS = "__Internal";
        public const string LibNameMacOS = "__Internal";
        public const string LibNameWin32 = LibName + "-x86";
        public const string LibNameWin64 = LibName + "-x64";
        public const string LibNameWinArm = LibName + "-arm";
        public const string LibNameWinArm64 = LibName + "-arm64";
    }

    [NativeLib(EmStLibNamePropvider.LibName, NativePlatformType.Default)]
    [NativeLib(EmStLibNamePropvider.LibNameWin32, NativePlatformType.WinX86)]
    [NativeLib(EmStLibNamePropvider.LibNameWin64, NativePlatformType.WinX64)]
    [NativeLib(EmStLibNamePropvider.LibNameWinArm, NativePlatformType.WinArm)]
    [NativeLib(EmStLibNamePropvider.LibNameWinArm64, NativePlatformType.WinArm64)]
    [NativeLib(EmStLibNamePropvider.LibNameiOS, NativePlatformType.iOS)]
    [NativeLib(EmStLibNamePropvider.LibName, NativePlatformType.AndroidARMv7,
        NativePlatformType.AndroidARMv8,
        NativePlatformType.AndroidX86,
        NativePlatformType.AndroidX64,
        NativePlatformType.OSX,
        NativePlatformType.LinuxX64,
        NativePlatformType.LinuxX86)]
    public interface IEmotionalMathSDKApi
    {
       IntPtr createMathLib(MathLibSetting lib_setting, ArtifactDetectSetting art_setting, ShortArtifactDetectSetting short_art_setting, MentalAndSpectralSetting mental_spectral_setting,  ref OpStatus opResult);
       byte freeMathLib(IntPtr mathLibPtr,  ref  OpStatus opResult);

       byte MathLibSetMentalEstimationMode(IntPtr mathLibPtr, bool independent,  ref  OpStatus opResult);
       byte MathLibSetHanningWinSpect(IntPtr mathLibPtr,  ref  OpStatus opResult);
       byte MathLibSetHammingWinSpect(IntPtr mathLibPtr,  ref  OpStatus opResult);
       byte MathLibSetCallibrationLength(IntPtr mathLibPtr, int s,  ref  OpStatus opResult);
       byte MathLibSetSkipWinsAfterArtifact(IntPtr mathLibPtr, int nwins,  ref  OpStatus opResult);

       byte MathLibPushData(IntPtr mathLibPtr,[In] RawChannels[] samples, int samplesCount, ref  OpStatus opResult);
       byte MathLibPushDataArr(IntPtr mathLibPtr, [In,Out][MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef =typeof(RawChannelsArrayMarshaller))] RawChannelsArray[] samples, int samplesCount,  ref  OpStatus opResult);
       byte MathLibProcessWindow(IntPtr mathLibPtr,  ref  OpStatus opResult);
       byte MathLibProcessData(IntPtr mathLibPtr, SideType side,  ref  OpStatus opResult);
       byte MathLibProcessDataArr(IntPtr mathLibPtr,  ref  OpStatus opResult);

       byte MathLibSetPrioritySide(IntPtr mathLibPtr, SideType side,  ref  OpStatus opResult);
       byte MathLibStartCalibration(IntPtr mathLibPtr,  ref  OpStatus opResult);
       byte MathLibCalibrationFinished(IntPtr mathLibPtr, ref  bool result,  ref OpStatus opResult);

       byte MathLibIsArtifactedWin(IntPtr mathLibPtr, SideType side, bool print_info, ref  bool result,  ref OpStatus opResult);
       byte MathLibIsArtifactedSequence(IntPtr mathLibPtr, ref  bool result,  ref OpStatus opResult);
       byte MathLibIsBothSidesArtifacted(IntPtr mathLibPtr, ref  bool result,  ref OpStatus opResult);

       byte MathLibReadMentalDataArrSize(IntPtr mathLibPtr, ref  int arr_size,  ref OpStatus opResult);
       byte MathLibReadMentalDataArr(IntPtr mathLibPtr, [In,Out] MindData[] mindd, ref  int arr_size,  ref OpStatus opResult);

       byte MathLibReadAverageMentalData(IntPtr mathLibPtr, int n_lastwins_toaverage, ref  MindData minddatavals, ref OpStatus opResult);

       byte MathLibReadSpectralDataPercentsArrSize(IntPtr mathLibPtr, ref  int arr_size, ref OpStatus opResult);
       byte MathLibReadSpectralDataPercentsArr(IntPtr mathLibPtr, SpectralDataPercents[] spectraldata_arr, ref  int arr_size, ref OpStatus opResult);
       byte MathLibReadRawSpectralVals(IntPtr mathLibPtr, ref  RawSpectVals raw_spectral_vals,  ref OpStatus opResult);

       byte MathLibSetZeroSpectWaves(IntPtr mathLibPtr, bool active, int delta, int theta, int alpha, int beta, int gamma,  ref  OpStatus opResult);
       byte MathLibSetWeightsForSpectra(IntPtr mathLibPtr, double delta_c, double theta_c, double alpha_c, double beta_c, double gamma_c,  ref  OpStatus opResult);
       byte MathLibSetSpectNormalizationByBandsWidth(IntPtr mathLibPtr, bool fl,  ref  OpStatus opResult);
       byte MathLibSetSpectNormalizationByCoeffs(IntPtr mathLibPtr, bool fl,  ref  OpStatus opResult);
       byte MathLibGetCallibrationPercents(IntPtr mathLibPtr, ref  int outPercents,  ref OpStatus opResult);
    }
}
