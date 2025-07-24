using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
namespace SignalMath
{
    public class EegEmotionalMath : IDisposable
    {
        public bool IsDisposed { get; private set; }

        private IntPtr _emStPtr;

        public EegEmotionalMath(MathLibSetting lib_setting, ArtifactDetectSetting art_setting, ShortArtifactDetectSetting short_art_setting, MentalAndSpectralSetting mental_spectral_setting)
        {
            OpStatus op = new OpStatus();
            _emStPtr = EmotionalMathSDKApi.Inst.createMathLib(lib_setting, art_setting, short_art_setting, mental_spectral_setting, ref op);

            ThrowIfError(op);

            EmotionalMathSDKApi.Inst.MathLibSetMentalEstimationMode(_emStPtr, false, ref op);

            EmotionalMathSDKApi.Inst.MathLibSetZeroSpectWaves(_emStPtr, true, 0, 1, 1, 1, 0, ref op);

            EmotionalMathSDKApi.Inst.MathLibSetCallibrationLength(_emStPtr, 6, ref op);
            EmotionalMathSDKApi.Inst.MathLibSetSkipWinsAfterArtifact(_emStPtr, 5, ref op);
        }

        public void SetMentalEstimationMode(bool independent)
        {
            OpStatus op = new OpStatus();
            EmotionalMathSDKApi.Inst.MathLibSetMentalEstimationMode(_emStPtr, independent, ref op);
            ThrowIfError(op);
        }
        public void SetHanningWinSpect()
        {
            OpStatus op = new OpStatus();
            EmotionalMathSDKApi.Inst.MathLibSetHanningWinSpect(_emStPtr, ref op);
            ThrowIfError(op);
        }
        public void SetHammingWinSpect()
        {
            OpStatus op = new OpStatus();
            EmotionalMathSDKApi.Inst.MathLibSetHammingWinSpect(_emStPtr, ref op);
            ThrowIfError(op);
        }
        public void SetCallibrationLength(int s)
        {
            OpStatus op = new OpStatus();
            EmotionalMathSDKApi.Inst.MathLibSetCallibrationLength(_emStPtr, s, ref op);
            ThrowIfError(op);
        }
        public void SetSkipWinsAfterArtifact(int nwins)
        {
            OpStatus op = new OpStatus();
            EmotionalMathSDKApi.Inst.MathLibSetSkipWinsAfterArtifact(_emStPtr, nwins, ref op);
            ThrowIfError(op);
        }

        public void UseInternalFilters(bool use)
        {
            OpStatus op = new OpStatus();
            EmotionalMathSDKApi.Inst.MathLibUseInternalFilters(_emStPtr, use, ref op);
            ThrowIfError(op);
        }

        public void PushData(RawChannels[] samples)
        {
            OpStatus op = new OpStatus();
            EmotionalMathSDKApi.Inst.MathLibPushData(_emStPtr, samples, samples.Length, ref op);
            ThrowIfError(op);
        }

        public void PushDataArr(RawChannelsArray[] samples)
        {
            OpStatus op = new OpStatus();

            EmotionalMathSDKApi.Inst.MathLibPushDataArr(_emStPtr, samples, samples.Length, ref op);
            ThrowIfError(op);
        }

        public void ProcessWindow()
        {
            OpStatus op = new OpStatus();
            EmotionalMathSDKApi.Inst.MathLibProcessWindow(_emStPtr, ref op);
            ThrowIfError(op);
        }
        public void ProcessData(SideType side)
        {
            OpStatus op = new OpStatus();
            EmotionalMathSDKApi.Inst.MathLibProcessData(_emStPtr, side, ref op);
            ThrowIfError(op);
        }
        public void ProcessDataArr()
        {
            OpStatus op = new OpStatus();
            EmotionalMathSDKApi.Inst.MathLibProcessDataArr(_emStPtr, ref op);
            ThrowIfError(op);
        }

        public void SetPrioritySide(SideType side)
        {
            OpStatus op = new OpStatus();
            EmotionalMathSDKApi.Inst.MathLibSetPrioritySide(_emStPtr, side, ref op);
            ThrowIfError(op);
        }
        public void StartCalibration()
        {
            OpStatus op = new OpStatus();
            EmotionalMathSDKApi.Inst.MathLibStartCalibration(_emStPtr, ref op);
            ThrowIfError(op);
        }
        public bool CalibrationFinished()
        {
            OpStatus op = new OpStatus();
            bool result = false;
            EmotionalMathSDKApi.Inst.MathLibCalibrationFinished(_emStPtr, ref result, ref op);
            ThrowIfError(op);
            return result;
        }

        public bool IsArtifactedWin(SideType side, bool print_info)
        {
            OpStatus op = new OpStatus();
            bool result = false;
            EmotionalMathSDKApi.Inst.MathLibIsArtifactedWin(_emStPtr, side, print_info, ref result, ref op);
            ThrowIfError(op);
            return result;
        }
        public bool IsArtifactedSequence()
        {
            OpStatus op = new OpStatus();
            bool result = false;
            EmotionalMathSDKApi.Inst.MathLibIsArtifactedSequence(_emStPtr, ref result, ref op);
            ThrowIfError(op);
            return result;
        }
        public bool IsBothSidesArtifacted()
        {
            OpStatus op = new OpStatus();
            bool result = false;
            EmotionalMathSDKApi.Inst.MathLibIsBothSidesArtifacted(_emStPtr, ref result, ref op);
            ThrowIfError(op);
            return result;
        }
        public bool IsArtifactedLeft()
        {
            OpStatus op = new OpStatus();
            bool result = false;
            EmotionalMathSDKApi.Inst.MathLibIsArtifactedLeft(_emStPtr, ref result, ref op);
            ThrowIfError(op);
            return result;
        }
        public bool IsArtifactedRight()
        {
            OpStatus op = new OpStatus();
            bool result = false;
            EmotionalMathSDKApi.Inst.MathLibIsArtifactedRight(_emStPtr, ref result, ref op);
            ThrowIfError(op);
            return result;
        }

        public MindData[] ReadMentalDataArr()
        {
            int arrSize = 0;
            OpStatus op = new OpStatus();
            EmotionalMathSDKApi.Inst.MathLibReadMentalDataArrSize(_emStPtr, ref arrSize, ref op);
            if (arrSize == 0)
                return new MindData[0];
            MindData[] result = new MindData[arrSize];
            EmotionalMathSDKApi.Inst.MathLibReadMentalDataArr(_emStPtr, result, ref arrSize, ref op);
            ThrowIfError(op);
            return result;
        }

        public MindData ReadAverageMentalData(int n_lastwins_toaverage)
        {
            OpStatus op = new OpStatus();
            MindData result = new MindData();
            EmotionalMathSDKApi.Inst.MathLibReadAverageMentalData(_emStPtr, n_lastwins_toaverage, ref result, ref op);
            ThrowIfError(op);
            return result;
        }

        public SpectralDataPercents[] ReadSpectralDataPercentsArr()
        {
            int arrSize = 0;
            OpStatus op = new OpStatus();
            EmotionalMathSDKApi.Inst.MathLibReadSpectralDataPercentsArrSize(_emStPtr, ref arrSize, ref op);
            if (arrSize == 0)
                return new SpectralDataPercents[0];
            SpectralDataPercents[] result = new SpectralDataPercents[arrSize];
            EmotionalMathSDKApi.Inst.MathLibReadSpectralDataPercentsArr(_emStPtr, result, ref arrSize, ref op);
            ThrowIfError(op);
            return result;
        }
        public RawSpectVals ReadRawSpectralVals()
        {
            OpStatus op = new OpStatus();
            RawSpectVals result = new RawSpectVals();
            EmotionalMathSDKApi.Inst.MathLibReadRawSpectralVals(_emStPtr, ref result, ref op);
            ThrowIfError(op);
            return result;
        }

        public RawSpectVals ReadCalibrationVals()
        {
            OpStatus op = new OpStatus();
            RawSpectVals result = new RawSpectVals();
            EmotionalMathSDKApi.Inst.MathLibReadCalibrationVals(_emStPtr, ref result, ref op);
            ThrowIfError(op);
            return result;
        }
        public TotalPowValues ReadTotalPowFromArtifacts()
        {
            OpStatus op = new OpStatus();
            double left = 0;
            double right = 0;
            EmotionalMathSDKApi.Inst.MathLibReadTotalPowFromArtifacts(_emStPtr, ref left, ref right, ref op);
            ThrowIfError(op);
            return new TotalPowValues()
            {
                left = left,
                right = right,
            };
        }
        public QualityValues GetEEGQuality()
        {
            OpStatus op = new OpStatus();
            int left = 0;
            int right = 0;
            EmotionalMathSDKApi.Inst.MathLibGetEEGQuality(_emStPtr, ref left, ref right, ref op);
            ThrowIfError(op);
            return new QualityValues()
            {
                left = left,
                right = right,
            };
        }

        public void SetZeroSpectWaves(bool active, int delta, int theta, int alpha, int beta, int gamma)
        {
            OpStatus op = new OpStatus();
            EmotionalMathSDKApi.Inst.MathLibSetZeroSpectWaves(_emStPtr, active, delta, theta, alpha, beta, gamma, ref op);
            ThrowIfError(op);
        }
        public void SetWeightsForSpectra(double delta_c, double theta_c, double alpha_c, double beta_c, double gamma_c)
        {
            OpStatus op = new OpStatus();
            EmotionalMathSDKApi.Inst.MathLibSetWeightsForSpectra(_emStPtr, delta_c, theta_c, alpha_c, beta_c, gamma_c, ref op);
            ThrowIfError(op);
        }
        public void SetSpectNormalizationByBandsWidth(bool fl)
        {
            OpStatus op = new OpStatus();
            EmotionalMathSDKApi.Inst.MathLibSetSpectNormalizationByBandsWidth(_emStPtr, fl, ref op);
            ThrowIfError(op);
        }
        public void SetSpectNormalizationByCoeffs(bool fl)
        {
            OpStatus op = new OpStatus();
            EmotionalMathSDKApi.Inst.MathLibSetSpectNormalizationByCoeffs(_emStPtr, fl, ref op);
            ThrowIfError(op);
        }
        public int GetCallibrationPercents()
        {
            OpStatus op = new OpStatus();
            int result = 0;
            EmotionalMathSDKApi.Inst.MathLibGetCallibrationPercents(_emStPtr, ref result, ref op);
            ThrowIfError(op);
            return result;
        }

        ~EegEmotionalMath()
        {
            Dispose(true);
        }
        private void ThrowIfError(OpStatus op)
        {
            if (!op.Success)
            {
                throw new Exception(op.ErrorMsg);
            }
        }
        #region Dispose
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Dispose()
        {
            // Dispose of unmanaged resources.
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if (IsDisposed)
                return;
            IsDisposed = true;
            try
            {
                OpStatus op = new OpStatus();
                EmotionalMathSDKApi.Inst.freeMathLib(_emStPtr, ref op);
                if (!op.Success)
                {
                    throw new Exception(op.ErrorMsg);
                }
                _emStPtr = IntPtr.Zero;
            }
            catch (Exception)
            {
            }
        }
#endregion
    }

}
