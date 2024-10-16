#ifndef EMHelpers_h
#define EMHelpers_h

#include "common_api.h"
#include <EMTypes.h>

MathLibSetting libSettingsFromObjc(EMMathLibSetting*);
ArtifactDetectSetting artifactSettingsFromObjc(EMArtifactDetectSetting*);

EMMindData* mindDataFromNative(MindData& data);
EMSpectralDataPercents* spectralPercentsFromNative(SpectralDataPercents& data);
EMRawSpectVals* rawSpectValsFromNative(RawSpectVals& data);
#endif /* EMHelpers_h */
