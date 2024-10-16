//
//  EMTypes.h
//  em_st_artifacts
//
//  Created by Aseatari on 30.11.2023.
//

#ifndef EMTypes_h
#define EMTypes_h

#include <Foundation/Foundation.h>

@interface EMMathLibSetting : NSObject
@property (nonatomic) UInt32 samplingRate;
@property (nonatomic) UInt32 processWinFreq;
@property (nonatomic) UInt32 fftWindow;
@property (nonatomic) UInt32 nFirstSecSkipped;
@property (nonatomic) BOOL bipolarMode;
@property (nonatomic) BOOL squaredSpectrum;
@property (nonatomic) UInt32 channelsNumber;
@property (nonatomic) UInt32 channelForAnalysis;

-(id)initWithSamplingRate:(UInt32) samplingRate andProcessWinFreq:(UInt32)processWinFreq andFftWindow:(UInt32)fftWindow andNFirstSecSkipped:(UInt32)nFirstSecSkipped andBipolarMode:(BOOL)bipolarMode andSquaredSpectrum:(BOOL)squaredSpectrum andChannelsNumber:(UInt32)channelsNumber andChannelForAnalysis:(UInt32)channelForAnalysis;

@end

@interface EMArtifactDetectSetting : NSObject
@property (nonatomic) UInt32 artBord;
@property (nonatomic) UInt32 allowedPercentArtpoints;
@property (nonatomic) UInt32 rawBetapLimit;
@property (nonatomic) UInt32 totalPowBorder;
@property (nonatomic) UInt32 globalArtwinSec;
@property (nonatomic) BOOL spectArtByTotalp;
@property (nonatomic) BOOL hanningWinSpectrum;
@property (nonatomic) BOOL hammingWinSpectrum;
@property (nonatomic) UInt32 numWinsForQualityAvg;

-(id)initWithArtBord:(UInt32)artBord andAllowedPercentArtpoints:(UInt32)allowedPercentArtpoints andRawBetapLimit:(UInt32)rawBetapLimit andTotalPowBorder:(UInt32)totalPowBorder andGlobalArtwinSec:(UInt32)globalArtwinSec andSpectArtByTotalp:(BOOL)spectArtByTotalp andHanningWinSpectrum:(BOOL)hanningWinSpectrum andHammingWinSpectrum:(BOOL)hammingWinSpectrum andNumWinsForQualityAvg:(UInt32)numWinsForQualityAvg;

@end

typedef NS_ENUM (UInt8, EMSideType) {
    EMSideTypeLeft =0,
    EMSideTypeRight = 1,
    EMSideTypeNone = 2
};

@interface EMMindData : NSObject

@property (nonatomic) double relAttention;
@property (nonatomic) double relRelaxation;
@property (nonatomic) double instAttention;
@property (nonatomic) double instRelaxation;

-(id) initWithRelAttention:(double) relAttention andRelRelax:(double) relRelax andInstAttention: (double) instAttention andInstRelax:(double) instRelax;
@end

@interface EMRawChannels : NSObject
@property (nonatomic) double leftBipolar;
@property (nonatomic) double rightBipolar;

-(id) initWithLeftBipolar:(double) left andRightBipolar:(double) right;
@end

@interface EMRawSpectVals: NSObject
@property (nonatomic) double alpha;
@property (nonatomic) double beta;

-(id) initWithAlpha:(double) alpha andBeta:(double) beta;
@end

@interface EMSpectralDataPercents : NSObject
@property (nonatomic) double Delta;
@property (nonatomic) double Theta;
@property (nonatomic) double Alpha;
@property (nonatomic) double Beta;
@property (nonatomic) double Gamma;

-(id) initWithDelta:(double) delta andTheta:(double) theta andAlpha:(double) alpha andBeta:(double) beta andGamma:(double) gamma;
@end



#endif /* EMTypes_h */
