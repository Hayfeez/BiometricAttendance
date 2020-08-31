
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Drawing;
    using DPFP;
    using System.Diagnostics;
    using System.IO;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Windows.Forms;


    using DPFP.Processing;
    using DigitalPersona.Standards;

    using DPFP.Capture;
    using System.Runtime.InteropServices;

    using AttendanceLibrary.Model;

    using AttendanceUI.Forms;

    namespace AttendanceUI.BaseClass
    {
        internal delegate void FunctionCall(dynamic param);

        public class DigitalPersonaLibrary : DPFP.Capture.EventHandler, IDisposable
        {
            public System.ComponentModel.ISynchronizeInvoke Obj;
            public byte[] BmpByte;
            public System.Drawing.Bitmap Resultbmp;
            public System.Drawing.Bitmap Derivedbmp;
            private FileStream _imageStream;

            private readonly bool _isEnrollment;
            public List<Bitmap> FingerBitmaps;  //used for enrollment
            public Bitmap FingerBitmap;  //used for signing in

            private readonly List<StudentFinger> _studentFingers;
            private readonly List<StaffFinger> _staffFingers;
            
        // '---------------------------
            public DPFP.Capture.Capture Capturer;
            public DPFP.Processing.Enrollment Enroller;
            public DPFP.Verification.Verification Verificator;
            public DPFP.Template Template;

            public event OnTemplateEventHandler OnTemplate;

            public delegate void OnTemplateEventHandler(object template);

            private string _message = "";
            private Bitmap _trueBitmap = null /* TODO Change to default(_) if this is not a reference type */;
            private int _dpi = 700;
            private byte[] _inputData = null;
            private DigitalPersona.Standards.InputParameterForRaw _inpRaw = null;
            private DPFP.Sample _dPsample;
            private DPFP.FeatureSet _dpFeatures;
            private DPFP.Template _dpTemplate;
            private byte[] _isofmd;
            private bool _disposedValue;
            private bool _isConnected;

            private readonly Form _form;
            private readonly TextBox _txtLog;

            private PictureBox _derivedPic;

            private Label _fingerCount;

            // to enroll
            public DigitalPersonaLibrary(TextBox txtLog, PictureBox derivedPic, Label fingerCount)
            {
                _isEnrollment = true;
                FingerBitmaps = new List<Bitmap>();
                _txtLog = txtLog;
                _derivedPic = derivedPic;
                _fingerCount = fingerCount;

                Capturer = new DPFP.Capture.Capture();
                Capturer.EventHandler = this;

                Enroller = new DPFP.Processing.Enrollment(); // Create an enrollment.
                Verificator = new DPFP.Verification.Verification(); // Create a verification.

                Application.DoEvents();
            }

            // to sign attendance
            public DigitalPersonaLibrary(TextBox txtLog, PictureBox derivedPic, List<StudentFinger> fingers)
            {
                _isEnrollment = false;
                FingerBitmap = null;
                _studentFingers = fingers;
                _txtLog = txtLog;
                _derivedPic = derivedPic;

                Capturer = new DPFP.Capture.Capture();
                Capturer.EventHandler = this;

                Enroller = new DPFP.Processing.Enrollment(); // Create an enrollment.
                Verificator = new DPFP.Verification.Verification(); // Create a verification.

                Application.DoEvents();
            }

            // to login
            public DigitalPersonaLibrary(TextBox txtLog, PictureBox derivedPic, List<StaffFinger> fingers)
            {
                _isEnrollment = false;
                FingerBitmap = null;
                _staffFingers = fingers;
                _txtLog = txtLog;
                _derivedPic = derivedPic;

                Capturer = new DPFP.Capture.Capture();
                Capturer.EventHandler = this;

                Enroller = new DPFP.Processing.Enrollment(); // Create an enrollment.
                Verificator = new DPFP.Verification.Verification(); // Create a verification.

                Application.DoEvents();
            }

        #region bitmaps

        public bool NonUnique(ref Bitmap leftFinger, ref Bitmap rightFinger)
            {
                try
                {
                    // convert the leftfinger to sample
                    Sample leftSample = ConvertRawBmpAsSample(leftFinger);

                    // convert the right finger as template
                    Template rightTemplate = ConvertRawBmpAsTemplate(rightFinger, DataPurpose.Verification);

                    // Process the sample and create a feature set for the enrollment purpose.
                    DPFP.FeatureSet features = ExtractFeatures(leftSample, DPFP.Processing.DataPurpose.Verification);

                    Stopwatch sw = new Stopwatch();

                    // Check quality of the sample and start verification if it's good
                    if (features != null & rightTemplate != null)
                    {
                        // loads the collection

                        DPFP.Verification.Verification.Result result = new DPFP.Verification.Verification.Result();

                        // timer for current comparison 
                        sw.Start();

                        result = DPFP.Verification.Verification.Verify(features, rightTemplate, 0x7FFFFFFF / 100000);

                        sw.Stop();
                        return result.Verified;
                    }

                    else
                        throw new Exception("Fingerprint is of low quality");
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

        public VerifiedData VerifyStudentFinger(ref Bitmap signInFinger)
        {
            try
            {
                foreach (var finger in _studentFingers)
                {
                    var fingerPrint = BytesToBitmap(finger.FingerTemplate);
                    Sample sample = ConvertRawBmpAsSample(fingerPrint);
                    Template newFinger = ConvertRawBmpAsTemplate(signInFinger, DataPurpose.Verification);

                    // Process the sample and create a feature set for the enrollment purpose.
                    DPFP.FeatureSet features = ExtractFeatures(sample, DPFP.Processing.DataPurpose.Verification);

                    Stopwatch sw = new Stopwatch();

                    // Check quality of the sample and start verification if it's good
                    if (features != null && newFinger != null)
                    {
                        // loads the collection
                        DPFP.Verification.Verification.Result result = new DPFP.Verification.Verification.Result();

                        // timer for current comparison 
                        sw.Start();
                        result = DPFP.Verification.Verification.Verify(features, newFinger, 0x7FFFFFFF / 100000);
                        sw.Stop();
                        if (result.Verified)
                        {
                            return new VerifiedData
                            {
                                Id = finger.StudentId,
                                Number = finger.MatricNo,
                                Time = TimeToString(sw.Elapsed)
                            };
                        }
                    }
                }

                return null;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public VerifiedData VerifyStaffFinger(ref Bitmap signInFinger)
        {
            try
            {
                foreach (var finger in _staffFingers)
                {
                    var fingerPrint = BytesToBitmap(finger.Fingerprint);
                    Sample sample = ConvertRawBmpAsSample(fingerPrint);
                    Template newFinger = ConvertRawBmpAsTemplate(signInFinger, DataPurpose.Verification);

                    // Process the sample and create a feature set for the enrollment purpose.
                    DPFP.FeatureSet features = ExtractFeatures(sample, DPFP.Processing.DataPurpose.Verification);

                    Stopwatch sw = new Stopwatch();

                    // Check quality of the sample and start verification if it's good
                    if (features != null && newFinger != null)
                    {
                        // loads the collection
                        DPFP.Verification.Verification.Result result = new DPFP.Verification.Verification.Result();

                        // timer for current comparison 
                        sw.Start();
                        result = DPFP.Verification.Verification.Verify(features, newFinger, 0x7FFFFFFF / 100000);
                        sw.Stop();
                        if (result.Verified)
                        {
                            return new VerifiedData
                            {
                                Id = finger.StaffId,
                                Number = finger.StaffId,
                                Time = TimeToString(sw.Elapsed)
                            };
                        }
                    }
                }

                return null;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public bool IsUnique(ref List<Bitmap> capturedFingers, ref Sample newSample)
        //    {
        //        try
        //        {
        //            DPFP.Capture.SampleConversion convertor = new DPFP.Capture.SampleConversion();

        //            foreach (var finger in capturedFingers)
        //            {
        //                Sample capturedSample = ConvertRawBmpAsSample(finger);
        //                Bitmap newFingerBitmap = null;
        //                convertor.ConvertToPicture(newSample, ref newFingerBitmap);
        //                Template newTemplate = ConvertRawBmpAsTemplate(newFingerBitmap, DataPurpose.Verification);

        //                // Process the sample and create a feature set for the enrollment purpose.
        //                DPFP.FeatureSet features = ExtractFeatures(capturedSample, DPFP.Processing.DataPurpose.Verification);

        //                if (features != null && newTemplate != null)
        //                {
        //                    // loads the collection
        //                    DPFP.Verification.Verification.Result result = new DPFP.Verification.Verification.Result();


        //                    result = DPFP.Verification.Verification.Verify(features, newTemplate, 0x7FFFFFFF / 100000);
        //                    if (result.Verified)
        //                    {
        //                        // break;
        //                        return false;
        //                    }
        //                }
        //                else
        //                {
        //                    throw new Exception("Fingerprint is of low quality");
        //                }
        //            }

        //            return true;

        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }

        //    }

        public bool IsUnique(ref Bitmap newFinger)
        {
            try
            {
                foreach (var finger in FingerBitmaps)
                {
                    Sample capturedSample = ConvertRawBmpAsSample(finger);
                    Template newTemplate = ConvertRawBmpAsTemplate(newFinger, DataPurpose.Verification);

                    // Process the sample and create a feature set for the enrollment purpose.
                    DPFP.FeatureSet features = ExtractFeatures(capturedSample, DPFP.Processing.DataPurpose.Verification);

                    if (features != null && newTemplate != null)
                    {
                        // loads the collection
                        DPFP.Verification.Verification.Result result = new DPFP.Verification.Verification.Result();


                        result = DPFP.Verification.Verification.Verify(features, newTemplate, 0x7FFFFFFF / 100000);
                        if (result.Verified)
                        {
                            // break;
                            return false;
                        }
                    }
                    else
                    {
                        throw new Exception("Fingerprint is of low quality");
                    }
                }

                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DPFP.Template ConvertRawBmpAsTemplate(Bitmap rawBmp, DataPurpose processPurpose = DataPurpose.Enrollment, short vertDpi = 700, short horDpi = 700)
            {
                VariantConverter vConverter;
                Enroller = new DPFP.Processing.Enrollment();
                rawBmp = EncodeBitmap(rawBmp, vertDpi, horDpi);
                try
                {
                    // converts raw image to dpSample using DFC 2.0---------------------------------------
                    // encode the bmp variable using the bitmap Loader
                    BitmapLoader bmpLoader = new BitmapLoader(rawBmp, (int) rawBmp.HorizontalResolution, (int) rawBmp.VerticalResolution);
                    bmpLoader.ProcessBitmap();

                    // return the required result
                    _inputData = bmpLoader.RawData;
                    _inpRaw = bmpLoader.DpInputParam;

                    // dispose the object
                    bmpLoader.Dispose();

                    // start the conversion process
                    vConverter = new VariantConverter(VariantConverter.OutputType.dp_sample, DataType.RawSample, _inpRaw, _inputData, false);
                    MemoryStream dStream = new MemoryStream(vConverter.Convert());
                    _dPsample = new DPFP.Sample(dStream);

                    // DPsample = DirectCast(VConverter.Convert(), DPFP.Sample)

                    // converts dpSample to DPFeatures using the OTW'''''''''''''''''''''''''''''''''''''''
                    _dpFeatures = ExtractFeatures(_dPsample, processPurpose);

                    // convert DPfeatures to ISO FMD using the DFC 2.0'''''''''''''''''''''''''''''''''''''''  
                    byte[] serializedFeatures = null;
                    _dpFeatures.Serialize(ref serializedFeatures); // serialized features into the array of bytes
                    _isofmd = DigitalPersona.Standards.Converter.Convert(serializedFeatures, DigitalPersona.Standards.DataType.DPFeatureSet, DataType.ISOFeatureSet);

                    // convert ISO FMD to DPTemplate using DFC 2.0'''''''''''''''''''''''''''''''''''''''
                    byte[] dpTemplateData = DigitalPersona.Standards.Converter.Convert(_isofmd, DigitalPersona.Standards.DataType.ISOTemplate, DataType.DPTemplate);

                    // deserialize data to Template
                    _dpTemplate = new DPFP.Template();
                    _dpTemplate.DeSerialize(dpTemplateData); // required for database purpose

                    // ============================================================================ 
                    dStream.Close();
                    return _dpTemplate;
                }
                catch (Exception ex)
                {
                    return null /* TODO Change to default(_) if this is not a reference type */;
                }
            }

            public Sample ConvertRawBmpAsSample(Bitmap rawBmp, short vertDpi = 700, short horDpi = 700)
            {
                VariantConverter vConverter;
                Enroller = new DPFP.Processing.Enrollment();
                rawBmp = EncodeBitmap(rawBmp, vertDpi, horDpi);
                try
                {
                    // converts raw image to dpSample using DFC 2.0---------------------------------------
                    // encode the bmp variable using the bitmap Loader
                    BitmapLoader bmpLoader = new BitmapLoader(rawBmp, (int) rawBmp.HorizontalResolution, (int) rawBmp.VerticalResolution);
                    bmpLoader.ProcessBitmap();

                    // return the required result
                    _inputData = bmpLoader.RawData;
                    _inpRaw = bmpLoader.DpInputParam;

                    // dispose the object
                    bmpLoader.Dispose();

                    // start the conversion process
                    vConverter = new VariantConverter(VariantConverter.OutputType.dp_sample, DataType.RawSample, _inpRaw, _inputData, false);
                    MemoryStream dStream = new MemoryStream(vConverter.Convert());
                    _dPsample = new DPFP.Sample(dStream);
                    return _dPsample;
                }
                catch (Exception ex)
                {
                    return null /* TODO Change to default(_) if this is not a reference type */;
                }
            }

            protected DPFP.FeatureSet ExtractFeatures(DPFP.Sample sample, DPFP.Processing.DataPurpose purpose)
            {
                try
                {
                    DPFP.Processing.FeatureExtraction extractor = new DPFP.Processing.FeatureExtraction(); // Create a feature extractor
                    DPFP.Capture.CaptureFeedback feedback = DPFP.Capture.CaptureFeedback.None;
                    DPFP.FeatureSet features = new DPFP.FeatureSet();
                    extractor.CreateFeatureSet(sample, purpose, ref feedback, ref features); // TODO: return features as a result?
                    if ((feedback == DPFP.Capture.CaptureFeedback.Good))
                        return features;
                    else
                        return null /* TODO Change to default(_) if this is not a reference type */;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error Extracting Features");
                }
            }

            public static Bitmap EncodeBitmap(Bitmap bmp, Int16 horResolution = 500, Int16 vertResolution = 500)
            {
                try
                {
                    Bitmap outputBmp;
                    if (bmp != null)
                    {
                        outputBmp = bmp;
                        outputBmp.SetResolution(horResolution, vertResolution);
                        return outputBmp;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                return null /* TODO Change to default(_) if this is not a reference type */;
            }

            public static Bitmap BytesToBitmap(byte[] byteArray)
            {
                try
                {
                    byte[] bytes = { 3, 10, 8, 25 };
                    using (MemoryStream ms = new MemoryStream(byteArray))
                    {
                        ms.Position = 0;
                        dynamic t = byteArray;
                        Bitmap bmpfromDB = new Bitmap(ms);//new Bitmap( Image.FromStream(ms));
                        Image img = Image.FromStream(ms);
                        return bmpfromDB;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        #endregion

        #region processing

        public static string TimeToString(TimeSpan time)
            {
                long t = time.Ticks / 10;
                string value;
                long remm;
                t = Math.DivRem(t, 1000, out remm);
                value = remm.ToString() + " mks";
                if (t != 0)
                {
                    t = Math.DivRem(t, 1000, out remm);
                    value = remm.ToString() + " ms " + value;
                    if (t != 0)
                    {
                        t = Math.DivRem(t, 60, out remm);
                        value = remm.ToString() + " s " + value;
                        if (t != 0)
                        {
                            t = Math.DivRem(t, 60, out remm);
                            value = remm.ToString() + " m " + value;
                            if (t != 0)
                            {
                                t = Math.DivRem(t, 24, out remm);
                                value = remm.ToString() + " h " + value;
                                if (t != 0)
                                    value = t + " d " + value;
                            }
                        }
                    }
                }

                return value;
            }


        //protected virtual void Process(DPFP.Sample sample)
        //{
        //    try
        //    {
        //        DPFP.Capture.SampleConversion convertor = new DPFP.Capture.SampleConversion();
        //        Bitmap bitmap = null /* TODO Change to default(_) if this is not a reference type */;
        //        convertor.ConvertToPicture(sample, ref bitmap);
        //        DrawPicture(bitmap);
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}

        protected virtual void Process(Bitmap bitmap)
        {
            try
            {
                DrawPicture(bitmap);
            }
            catch (Exception ex)
            {
            }
        }

        #endregion

        #region overriden methods

        public void OnComplete(object capture, string readerSerialNumber, Sample sample)
        {
            _message = null;
            DPFP.Capture.SampleConversion convertor = new DPFP.Capture.SampleConversion();
            Bitmap newFingerBitmap = null;
            convertor.ConvertToPicture(sample, ref newFingerBitmap);

            if (_isEnrollment)
            {
                //  if (IsUnique(ref FingerBitmaps, ref sample))
                if (IsUnique(ref newFingerBitmap))
                {
                    _txtLog.Invoke((MethodInvoker) delegate { MakeReport("The fingerprint was captured. Capture the next finger"); });
                    Process(newFingerBitmap);
                }
                else
                {
                    _txtLog.Invoke((MethodInvoker) delegate { MakeReport("This fingerprint has already been captured. Use another finger"); });
                }
            }
            else
            {
                var verify = _studentFingers != null
                    ? VerifyStudentFinger(ref newFingerBitmap)
                    : VerifyStaffFinger(ref newFingerBitmap);

                if (verify == null)
                {
                    _txtLog.Invoke((MethodInvoker) delegate { MakeReport("Fingerprint could not be identified. Try again"); });
                }
                else
                {
                    if (_studentFingers != null)
                    {
                        _txtLog.Invoke((MethodInvoker) delegate { MakeReport($"Student {verify.Number} identified in {verify.Time}"); });
                        Process(newFingerBitmap);
                        _txtLog.Invoke((MethodInvoker) delegate { FrmAttendance.SaveAttendance(verify); });
                    }
                }
            }
        }

        public void OnFingerGone(object capture, string readerSerialNumber)
            {
                _txtLog.Invoke((MethodInvoker) delegate { MakeReport("The finger was removed from the fingerprint reader."); });

            }

            public void OnFingerTouch(object capture, string readerSerialNumber)
            {
                _derivedPic.Image = null;
                _txtLog.Invoke((MethodInvoker) delegate
                {
                    // Running on the UI thread
                    MakeReport("The fingerprint reader was touched.");
                });

            }

            public void OnReaderConnect(object capture, string readerSerialNumber)
            {
                _txtLog.Invoke((MethodInvoker) delegate { MakeReport("The fingerprint reader was connected and started."); });

                _isConnected = true;
            }

            public void OnReaderDisconnect(object capture, string readerSerialNumber)
            {
                _txtLog.Invoke((MethodInvoker) delegate { MakeReport("The fingerprint reader was disconnected."); });

                _isConnected = false;
                FingerBitmaps = new List<Bitmap>();
                FingerBitmap = null;
            }

            public void OnSampleQuality(object capture, string readerSerialNumber, DPFP.Capture.CaptureFeedback captureFeedback)
            {
                string txt;
                if (captureFeedback == CaptureFeedback.Good)
                {

                    txt = "The quality of the fingerprint sample is good.";
                }
                else
                {
                    txt = "The quality of the fingerprint sample is poor.";
                }

                _txtLog.Invoke((MethodInvoker) delegate { MakeReport(txt); });

            }

            #endregion

            #region MyRegion

            public bool IsScannerConnected()
            {
                return _isConnected;
            }

            public void StartCapture()
            {
                if (Capturer != null)
                {
                    try
                    {
                        Capturer.StartCapture();
                        _txtLog.Invoke((MethodInvoker) delegate { MakeReport("Using the fingerprint reader, scan your fingerprint"); });

                    }
                    catch (Exception e)
                    {
                        Base.logger.WriteLog(e);
                        _txtLog.Invoke((MethodInvoker) delegate { SetPrompt("Cannot initiate capture!"); });

                    }

                }
            }

            public void StopCapture()
            {
                if (Capturer != null)
                {
                    try
                    {
                        Capturer.StopCapture();
                        _txtLog.Invoke((MethodInvoker) delegate { MakeReport("The fingerprint reader was stopped"); });

                    }
                    catch (Exception e)
                    {
                        Base.logger.WriteLog(e);
                        _txtLog.Invoke((MethodInvoker) delegate { SetPrompt("Cannot stop capture!"); });

                    }

                }
            }

            protected void MakeReport(string status)
            {
                try
                {
                    _txtLog?.AppendText(status + Environment.NewLine);
                }
                catch (Exception ex)
                {
                    //logger.WriteLog(ex);
                }
            }

            public void SetPrompt(string text)
            {
                try
                {
                    _txtLog.Text = (string) text;
                }
                catch (Exception ex)
                {
                }
            }

            protected void DrawPicture(Image bmp)
            {
                try
                {
                    _derivedPic.Image = new Bitmap(bmp, _derivedPic.Size);
                    if (_isEnrollment)
                    {
                        FingerBitmaps.Add((System.Drawing.Bitmap) bmp);

                        _fingerCount.Invoke((MethodInvoker) delegate { _fingerCount.Text = FingerBitmaps.Count.ToString(); });
                    }
                    else
                    {
                        FingerBitmap = (Bitmap) bmp;
                    }
                }
                catch (Exception ex)
                {

                }
            }

            //private delegate void SetPropertyThreadSafeDelegate<TResult>(
            //    Control @this,
            //    Expression<Func<TResult>> property,
            //    TResult value);

            //public static void SetPropertyThreadSafe<TResult>(
            //    this Control @this,
            //    Expression<Func<TResult>> property,
            //    TResult value)
            //{
            //    var propertyInfo = (property.Body as MemberExpression).Member
            //        as PropertyInfo;

            //    if (propertyInfo == null ||
            //        !@this.GetType().IsSubclassOf(propertyInfo.ReflectedType) ||
            //        @this.GetType().GetProperty(
            //            propertyInfo.Name,
            //            propertyInfo.PropertyType) == null)
            //    {
            //        throw new ArgumentException("The lambda expression 'property' must reference a valid property on this Control.");
            //    }
            //    if (@this.InvokeRequired)
            //    {
            //        @this.Invoke(new SetPropertyThreadSafeDelegate<TResult>
            //                (SetPropertyThreadSafe),
            //            new object[] { @this, property, value });
            //    }
            //    else
            //    {
            //        @this.GetType().InvokeMember(
            //            propertyInfo.Name,
            //            BindingFlags.SetProperty,
            //            null,
            //            @this,
            //            new object[] { value });
            //    }
            //}

            // myLabel.SetPropertyThreadSafe(() => myLabel.Text, status);

            #endregion

            #region Dispose

            protected virtual void Dispose(bool disposing)
            {
                if (!_disposedValue)
                {
                    if (disposing)
                    {
                        // TODO: dispose managed state (managed objects)
                        StopCapture();
                        _derivedPic = null;
                    }

                    // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                    // TODO: set large fields to null
                    _disposedValue = true;
                }
            }

            // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
            // ~DigitalPersonaClass()
            // {
            //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            //     Dispose(disposing: false);
            // }

            public void Dispose()
            {
                // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
                Dispose(disposing: true);
                GC.SuppressFinalize(this);
            }

            #endregion
        }


        public class VerifiedData
        {
            public string Id { get; set; }
            public string Number { get; set; }
            public string Time { get; set; }
        }

        public class VariantConverter
        {
            private DPFP.Capture.ReadersCollection _dpSensorCollection = null/* TODO Change to default(_) if this is not a reference type */;
            private DPFP.Capture.Capture _dpSensorCapturer = null/* TODO Change to default(_) if this is not a reference type */;
            private DPFP.Capture.SampleConversion _dpImageConverter = null/* TODO Change to default(_) if this is not a reference type */;
            private DPFP.Processing.FeatureExtraction _dpFtrExtractor = null/* TODO Change to default(_) if this is not a reference type */;
            private DPFP.Processing.Enrollment _dpFtrEnroller = null/* TODO Change to default(_) if this is not a reference type */;
            private DPFP.Template _dpTemplate = null/* TODO Change to default(_) if this is not a reference type */;
            private DPFP.FeatureSet _dpFeatureSet = null/* TODO Change to default(_) if this is not a reference type */;
            private Byte[] _inputData = null;
            private DigitalPersona.Standards.InputParameterForRaw _inpRaw = null/* TODO Change to default(_) if this is not a reference type */;
            private DigitalPersona.Standards.DataType _dataType = DigitalPersona.Standards.DataType.DPTemplate;
            private OutputType _cbOutputType;
            private bool _writeOutputToFile;
            public enum OutputType
            {
                dp_sample,
                dp_tmpl,
                dp_ftr,
                ansi_sample,
                ansi_ftr,
                ansi_tmplX,
                iso_sample,
                iso_ftr,
                iso_tmpl,
                iso_tmplX
            }

            public VariantConverter(OutputType output, DigitalPersona.Standards.DataType dataType, DigitalPersona.Standards.InputParameterForRaw inpRaw, byte[] inputData, bool writeOutputToFile = false)
            {
                try
                {
                    _cbOutputType = output;
                    this._dataType = dataType;
                    this._inpRaw = inpRaw;
                    this._inputData = inputData;
                    _writeOutputToFile = writeOutputToFile;
                }
                catch (Exception ex)
                {
                    try
                    {
                        Base.logger.WriteLog(ex);
                    }
                    catch (Exception exx)
                    {
                    }
                }
            }

            public byte[] Convert()
            {
                string ext = null;
                // holds the file extension
                DigitalPersona.Standards.DataType outputType = DigitalPersona.Standards.DataType.DPTemplate;
                switch (_cbOutputType)
                {
                    case VariantConverter.OutputType.dp_sample:
                        {
                            // DP Sample
                            ext = "dp_sample";
                            outputType = DigitalPersona.Standards.DataType.DpSample;
                            break;
                        }

                    case VariantConverter.OutputType.dp_tmpl:
                        {
                            // DP Template
                            ext = "dp_tmpl";
                            outputType = DigitalPersona.Standards.DataType.DPTemplate;
                            break;
                        }

                    case VariantConverter.OutputType.dp_ftr:
                        {
                            // DP Feature Set
                            ext = "dp_ftr";
                            outputType = DigitalPersona.Standards.DataType.DPFeatureSet;
                            break;
                        }

                    case VariantConverter.OutputType.ansi_sample:
                        {
                            // ANSI Sample
                            ext = "ansi_sample";
                            outputType = DigitalPersona.Standards.DataType.ANSISample;
                            break;
                        }

                    case VariantConverter.OutputType.ansi_ftr:
                        {
                            // ANSI Feature Set
                            ext = "ansi_ftr";
                            outputType = DigitalPersona.Standards.DataType.ANSIFeatureSet;
                            break;
                        }

                    //case VariantConverter.OutputType.ansi:
                    //    {
                    //        // ANSI Template
                    //        ext = "ansi_tmpl";
                    //        outputType = DigitalPersona.Standards.DataType.ANSITemplate;
                    //        break;
                    //    }

                    case VariantConverter.OutputType.ansi_tmplX:
                        {
                            // ANSI Template Extended
                            ext = "ansi_tmplX";
                            outputType = DigitalPersona.Standards.DataType.ANSITemplateWithExtendedData;
                            break;
                        }

                    case VariantConverter.OutputType.iso_sample:
                        {
                            // ISO Sample
                            ext = "iso_sample";
                            outputType = DigitalPersona.Standards.DataType.ISOSample;
                            break;
                        }

                    case VariantConverter.OutputType.iso_ftr:
                        {
                            // ISO Feature Set
                            ext = "iso_ftr";
                            outputType = DigitalPersona.Standards.DataType.ISOFeatureSet;
                            break;
                        }

                    case VariantConverter.OutputType.iso_tmpl:
                        {
                            // ISO Template
                            ext = "iso_tmpl";
                            outputType = DigitalPersona.Standards.DataType.ISOTemplate;
                            break;
                        }

                    case VariantConverter.OutputType.iso_tmplX:
                        {
                            // ISO Template Extended
                            ext = "iso_tmplX";
                            outputType = DigitalPersona.Standards.DataType.ISOTemplateWithExtendedData;
                            break;
                        }
                }

                byte[] dataToFile = null;

                try
                {
                    if (_dataType == DigitalPersona.Standards.DataType.RawSample)
                    {
                        if (outputType != DigitalPersona.Standards.DataType.ISOSample && outputType != DigitalPersona.Standards.DataType.ANSISample && outputType != DigitalPersona.Standards.DataType.DpSample)
                        {
                            MessageBox.Show("You can only convert a raw sample to another sample format.  Please select an appropriate output type.");
                            return null;
                        }
                        Object outParameter = null;

                        dataToFile = DigitalPersona.Standards.Converter.Convert(_inputData, _dataType, _inpRaw, outputType, outParameter);
                    }
                    else
                        dataToFile = DigitalPersona.Standards.Converter.Convert(_inputData, _dataType, outputType);
                }
                catch (Exception ex)
                {
                    try
                    {
                       Base.logger.WriteLog(ex);
                    }
                    catch (Exception exx)
                    {
                    }
                    MessageBox.Show(ex.Message + " inner: " + ex.InnerException.Message);
                    return null;
                }

                if (_writeOutputToFile)
                {
                    SaveFileDialog dlgSave = new SaveFileDialog();

                    dlgSave.Filter = "Biometric File| *." + ext;
                    dlgSave.Title = "Save Biometric Data";

                    if (dlgSave.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                        return null;

                    String fileName = dlgSave.FileName;

                    FileStream fsOut = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                    BinaryWriter writer = new BinaryWriter(fsOut);
                    writer.Write(dataToFile);
                    writer.Close();
                    fsOut.Close();
                    MessageBox.Show("Successfully Saved File "  + dlgSave.FileName);
                }

                return dataToFile;
            }
        }

        public class BitmapLoader : Form
        {
            private DigitalPersona.Standards.InputParameterForRaw _inpRaw;
            private byte[] _mRawData;
            private String _filename;
            private Bitmap _bmp = null/* TODO Change to default(_) if this is not a reference type */;
            private PictureBox _pbBitmap = new PictureBox();
            private int _tbXdpi, _tbYdpi;

            public BitmapLoader(Bitmap rawbmp, int tbXdpi, int tbYdpi)
            {
                try
                {
                    _bmp = rawbmp;
                    _pbBitmap = new PictureBox();
                    _pbBitmap.Size = new Size(152, 200);
                    this._tbXdpi = tbXdpi;
                    this._tbYdpi = tbYdpi;
                }
                catch (Exception ex)
                {
                    try
                    {
                       Base.logger.WriteLog(ex);
                    }
                    catch (Exception exx)
                    {
                    }
                    MessageBox.Show("Error opening bitmap file: " + ex.Message);
                    return;
                }
                try
                {
                    Bitmap resizedBmp = new Bitmap(_pbBitmap.Width, _pbBitmap.Height);
                    Graphics g = Graphics.FromImage((Image)resizedBmp);
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bicubic;
                    g.DrawImage(_bmp, 0, 0, resizedBmp.Width, resizedBmp.Height);
                    _pbBitmap.Image = resizedBmp;
                    g.Dispose();
                }
                catch (Exception ex)
                {
                    try
                    {
                       Base.logger.WriteLog(ex);
                    }
                    catch (Exception exx)
                    {
                    }
                    throw ex;
                }
            }

            public byte[] RawData
            {
                get
                {
                    return _mRawData;
                }
            }

            public DigitalPersona.Standards.InputParameterForRaw DpInputParam
            {
                get
                {
                    return _inpRaw;
                }
            }

            public void ProcessBitmap()
            {
                int width = 0;
                int height = 0;
                int dpiX = 0;
                int dpiY = 0;
                int bpp = 0;


                try
                {
                    dpiX = Convert.ToInt32(_tbXdpi);
                    dpiY = Convert.ToInt32(_tbYdpi);

                    width = _bmp.Width;
                    height = _bmp.Height;
                    System.Drawing.Imaging.BitmapData bmpData;

                    Rectangle rect = new Rectangle(0, 0, width, height);

                    switch (_bmp.PixelFormat)
                    {
                        case System.Drawing.Imaging.PixelFormat.Format8bppIndexed:
                            {
                                _mRawData = new byte[width * height - 1 + 1];
                                // what about padding?
                                bmpData = _bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, _bmp.PixelFormat);
                                Marshal.Copy(bmpData.Scan0, _mRawData, 0, width * height);
                                _bmp.UnlockBits(bmpData);
                                _inpRaw = new DigitalPersona.Standards.InputParameterForRaw(width, height, dpiX, dpiY, 8);
                                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                                break;
                            }

                        case System.Drawing.Imaging.PixelFormat.Format24bppRgb:
                            {
                                _mRawData = new byte[width * height - 1 + 1];
                                bmpData = _bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, _bmp.PixelFormat);
                                for (int y = 0; y <= height - 1; y++)
                                {
                                    for (int x = 0; x <= width - 1; x++)
                                    {
                                        // Calculate greyscale based on average RGB intensity
                                        int i = x * 3 + y * bmpData.Stride;
                                        int dividend = Marshal.ReadByte(bmpData.Scan0, i);
                                        int dividend2 = Marshal.ReadByte(bmpData.Scan0, i + 1);
                                        int dividend3 = Marshal.ReadByte(bmpData.Scan0, i + 2);

                                        int avgVal = (dividend + dividend2 + dividend3) / 3;
                                        // Convert to byte and save gray scale data
                                        _mRawData[x + y * width] = System.Convert.ToByte(avgVal);
                                    }
                                }
                                // ----------------------------
                                _bmp.UnlockBits(bmpData);
                                _inpRaw = new DigitalPersona.Standards.InputParameterForRaw(width, height, dpiX, dpiY, 8);
                                break;
                            }

                        case System.Drawing.Imaging.PixelFormat.Format32bppArgb:
                        case System.Drawing.Imaging.PixelFormat.Format32bppRgb:
                            {
                                _mRawData = new byte[width * height - 1 + 1];
                                bmpData = _bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly, _bmp.PixelFormat);
                                for (int y = 0; y <= height - 1; y++)
                                {
                                    for (int x = 0; x <= width - 1; x++)
                                    {
                                        // Calculate greyscale based on average RGB intensity
                                        int i = x * 4 + y * bmpData.Stride;
                                        int dividend = Marshal.ReadByte(bmpData.Scan0, i);
                                        int dividend2 = Marshal.ReadByte(bmpData.Scan0, i + 1);
                                        int dividend3 = Marshal.ReadByte(bmpData.Scan0, i + 2);

                                        int avgVal = (dividend + dividend2 + dividend3) / 3;
                                        _mRawData[x + y * width] = System.Convert.ToByte(avgVal);
                                    }
                                }
                                // ----------------------------
                                _bmp.UnlockBits(bmpData);
                                _inpRaw = new DigitalPersona.Standards.InputParameterForRaw(width, height, dpiX, dpiY, 8);
                                break;
                            }

                        default:
                            {
                                MessageBox.Show("Bitmap format not supported.  Please convert to either 8bpp indexed or 24 bpp non-indexed");
                                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                                break;
                            }
                    }
                    this.Close();
                }
                catch (Exception ex)
                {
                    try
                    {
                       Base.logger.WriteLog(ex);
                    }
                    catch (Exception exx)
                    {
                    }
                    MessageBox.Show(ex.Message);
                    return;
                }
            }

            private void BitmapLoader_FormClosing(object sender, FormClosingEventArgs e)
            {
                _bmp.Dispose();
            }

            //private void btnCancel_Click(object sender, EventArgs e)
            //{
            //    this.Close();
            //}
        }
    }
