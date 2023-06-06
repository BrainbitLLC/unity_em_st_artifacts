using System;
using System.Runtime.InteropServices;

namespace SignalMath
{
    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    public struct MathLibSetting
    {
        public int sampling_rate;
        public int process_win_freq;
        public int fft_window;
        public int n_first_sec_skipped;
        public bool bipolar_mode;
        public int channels_number;
        public int channel_for_analysis;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    public struct ArtifactDetectSetting
    {
        public int art_bord;
        public int allowed_percent_artpoints;
        public int raw_betap_limit;
        public int total_pow_border;
        public int global_artwin_sec;
        public bool spect_art_by_totalp;
        public bool hanning_win_spectrum;
        public bool hamming_win_spectrum;
        public int num_wins_for_quality_avg;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    public struct ShortArtifactDetectSetting
    {
        public int ampl_art_detect_win_size;
        public int ampl_art_zerod_area;
        public int ampl_art_extremum_border;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
    public struct MentalAndSpectralSetting
    {
        public int n_sec_for_instant_estimation;
        public int n_sec_for_averaging;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct OpStatus
    {
        [MarshalAs(UnmanagedType.I1)]
        public bool Success;
        [MarshalAs(UnmanagedType.U4)]
        public uint Error;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
        public string ErrorMsg;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct RawChannels
    {
        public double LeftBipolar;
        public double RightBipolar;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct MindData
    {
        public double RelAttention;
        public double RelRelaxation;
        public double InstAttention;
        public double InstRelaxation;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct RawSpectVals
    {
        public double Alpha;
        public double Beta;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct SpectralDataPercents
    {
        public double Delta;
        public double Theta;
        public double Alpha;
        public double Beta;
        public double Gamma;
    }

    public enum SideType
    {
        LEFT,
        RIGHT,
        NONE
    }

    public struct RawChannelsArray
    {
        public double[] channels;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct RawChannelsArrayMarshal
    {
        public IntPtr channels;
    }

    /// <summary>
    /// this marshaller doesn't support native-managed converting
    /// it means if some data changed in native part, it will not affect mannaged type
    /// </summary>
    public class RawChannelsArrayMarshaller : ICustomMarshaler
    {
        public void CleanUpManagedData(object ManagedObj)
        {
        }

        public void CleanUpNativeData(IntPtr pNativeData)
        {
            if (pNativeData != IntPtr.Zero)
            {
                IntPtr channelsDataBasePtr = Marshal.ReadIntPtr(pNativeData);

                Marshal.FreeHGlobal(channelsDataBasePtr);
                Marshal.FreeHGlobal(pNativeData);
            }
        }

        public int GetNativeDataSize()
        {
            return IntPtr.Size;         // RawSample* = ptr size;
        }

        public IntPtr MarshalManagedToNative(object ManagedObj)
        {
            var samples = ManagedObj as RawChannelsArray[];
            if (samples == null)
                return IntPtr.Zero;
            int totalSize = 0;
            foreach ( var ch in samples ) { totalSize += ch.channels.Length; }  // total channel's sample count
            int totalByte = sizeof(double) * totalSize;
            int sampleCount = samples.Length;
            var basePtr = Marshal.AllocHGlobal(totalByte);
            IntPtr baseArrPtr = basePtr;
            IntPtr[] resultArray = new IntPtr[sampleCount];
            for (int i = 0; i < sampleCount; i++)
            {
                Marshal.Copy(samples[i].channels, 0, baseArrPtr, samples[i].channels.Length);
                resultArray[i] = baseArrPtr;
                baseArrPtr += sizeof(double) * samples[i].channels.Length;
            }

            var resPtr = Marshal.AllocHGlobal(IntPtr.Size * samples.Length);
            Marshal.Copy(resultArray, 0, resPtr, samples.Length);
            return resPtr;
        }

        public object MarshalNativeToManaged(IntPtr pNativeData)
        {
            return null;
        }

        private static RawChannelsArrayMarshaller _instance = null;
        public static ICustomMarshaler GetInstance(string pstrCookie)
        {
            if (_instance == null)
                _instance = new RawChannelsArrayMarshaller();
            return _instance;
        }

    }
}
