using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoCrossCorrelation.Logic
{
    class LogicResult
    {
        private readonly bool _success;
        private readonly double _delay;
        private readonly string _mergedAudioFile;
        private readonly string _errorMessage;

        private LogicResult(bool success, double delay, string mergedAudioFile, string errorMessage)
        {
            _success = success;
            _delay = delay;
            _mergedAudioFile = mergedAudioFile;
            _errorMessage = errorMessage;
        }

        public static LogicResult SuccessLogicResult(double delay, string mergedAudioFile)
        {
            return new LogicResult(true, delay, mergedAudioFile, null);
        }

        public static LogicResult FailLogicResult(string errorMessage)
        {
            return new LogicResult(false, 0, null, errorMessage);
        }
        
        public bool Success => _success;
        public double Delay => _delay;
        public string MergedAudioFile => _mergedAudioFile;
        public string ErrorMessage => _errorMessage;
    }
}