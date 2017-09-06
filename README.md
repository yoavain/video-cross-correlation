![](https://raw.githubusercontent.com/yoavain/video-cross-correlation/master/VideoCrossCorrelation/VideoCrossCorrelation/Resources/128x128.bmp)
# video-cross-correlation 

### Calculate delay between 2 video files using cross-correlation calculation of their audio

### Features:
* Compare audio from 2 video files to find the dalay
* Support stream selection for video with multiple audio streams
* Configurable start-time and duration for the extracted audio
* Normalizes audio streams before comparing them
* Play audio after fixing delay, as stereo. One stream in the left channel the other in the right channel
* Visual waveform of the fixed audio. See both channels one over the other
* Configurable UI theme & color

### Use-Case:
You have 2 video files:
1. HD with language #1
2. SD with language #2

You want to merge them into a single HD video with 2 audio streams.

### What this tool give you:
This calculator will tell you exactly how much video #2 delays comparing to video #1 (in milliseconds precision)

### What this tool doesn't do:
This tool does not merge the video files.
For that, you have [MKVToolNix](https://mkvtoolnix.download).

### Screenshot:
![logo](https://raw.githubusercontent.com/yoavain/video-cross-correlation/master/VideoCrossCorrelation/VideoCrossCorrelation/Resources/Screenshot_1.PNG)


#### Credits:
* [AudioCross](https://github.com/gautambabbar/AudioCross) by [gautambabbar](https://github.com/gautambabbar)
* [FFmpeg](https://ffmpeg.org/)
