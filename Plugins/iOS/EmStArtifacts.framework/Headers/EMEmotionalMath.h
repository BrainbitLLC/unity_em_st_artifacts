#ifndef EMEmotionalMath_h
#define EMEmotionalMath_h

#include <Foundation/Foundation.h>
#include <Foundation/NSArray.h>
#include "common_api.h"
#include "EMTypes.h"

@interface EMEmotionalMath : NSObject{
    MathLib* mathPtr;
}

-(id) initWithLibSettings: (EMMathLibSetting*) settings andArtifactDetetectSettings: (EMArtifactDetectSetting*) artifactSettings andShortArtifactDetectSettigns:(ShortArtifactDetectSetting) shortArtifactSettings andMentalAndSpectralSettings: (MentalAndSpectralSetting) mentalAndSpectral;
-(void) setMentalEstimationMode:(bool) independent;
-(void) setHanningWinSpect;
-(void) setHammingWinSpect;
-(void) setCallibrationLength:(int) len;
-(void) setSkipWinsAfterArtifact:(int) nwins;


-(void) pushData:(NSArray<EMRawChannels*>*) samples;
-(void) pushDataArr:(NSArray<NSArray<NSNumber*>*>*) samples;

-(void) processWindow;
-(void) processDataWithSideType:(EMSideType) side;
-(void) processDataArr;


-(void) setPrioritySide: (EMSideType) side;
-(void) startCalibration;
-(BOOL) calibrationFinished;
 

-(BOOL) isArtifactedWinOnSide:(EMSideType) side andIsPrintInfo:(bool) print_info;
-(BOOL) isArtifactedSequence;
-(BOOL) isBothSidesArtifacted;

-(NSArray<EMMindData*>*) readMentalDataArr;

-(EMMindData*) readAverageMentalData:(int) n_lastwins_toaverage;

-(NSArray<EMSpectralDataPercents*>*) MathLibReadSpectralDataPercentsArr;

-(EMRawSpectVals*) readRawSpectralVals;

-(void) setZeroSpectWavesWithActive:(BOOL) active andDelta:(UInt32) delta andTheta:(UInt32) theta andAlpha:(UInt32) alpha andBeta:(UInt32) beta andGamma:(UInt32) gamma;

-(void) setWeightsForSpectraWithDelta:(double) delta_c andTheta:(double) theta_c andAlpha:(double) alpha_c andBeta:(double) beta_c andGamma:(double) gamma_c;
-(void) setSpectNormalizationByBandsWidth:(BOOL) fl;
-(void) setSpectNormalizationByCoeffs:(BOOL) fl;

-(UInt32) getCallibrationPercents;

 @end

#endif /* EMEmotionalMath_h */
