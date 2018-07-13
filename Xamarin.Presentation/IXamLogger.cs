using System;

namespace Xamarin.Presentation {
    public interface IXamLogger {
        void Debug(string mess);
        void Warn(string mess);
        void Warn(string format, params object[] _params);
        void Debug(string format, params object[] _params);
        void Error(Exception ex);
        void Error(Exception ex, string message);
        void Trace(string text);
    }

    public class DiagnosticsDebugLogger : IXamLogger {
        public void Debug(string format, params object[] _params) {
            System.Diagnostics.Debug.WriteLine(format, _params);
        }

        public void Debug(string mess) {
            System.Diagnostics.Debug.WriteLine(mess);
        }

        public void Error(Exception ex) {
            System.Diagnostics.Debug.WriteLine(ex.StackTrace);
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
        }

        public void Error(Exception ex, string message) {
            System.Diagnostics.Debug.WriteLine(message);
            System.Diagnostics.Debug.WriteLine(ex.StackTrace);
        }

        public void Trace(string text) {
            System.Diagnostics.Debug.WriteLine(text);
        }

        public void Warn(string format, params object[] _params) {
            System.Diagnostics.Debug.WriteLine(format, _params);
        }

        public void Warn(string mess) {
            System.Diagnostics.Debug.WriteLine(mess);
        }
    }
}
