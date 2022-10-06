using DPFP;
using DPFP.Capture;
using NadraBioVeriSys.Properties;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace NadraBioVeriSys
{
    public partial class Verification : Form, DPFP.Capture.EventHandler
    {
        private DPFP.Verification.Verification verification;
        private DPFP.Capture.Capture capture;
        private DPFP.Template template;

        public Verification()
        {
            InitializeComponent();
        }

        private void Verification_Load(object sender, EventArgs e)
        {
            ddlFingerIndex.SelectedIndex = 0;
        }

        #region Button Click Events

        private void btnScan_Click(object sender, EventArgs e)
        {
            Init();
            InitCapture();
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            StopCapture();

            try
            {
                if (txtCNIC != null && txtCell != null && ddlFingerIndex.SelectedIndex > -1)
                {
                    ImageConverter imgConverter = new ImageConverter();

                    Customers obj = new Customers()
                    {
                        CustCNIC = txtCNIC.Text.Replace("-", ""),
                        CustCell = txtCell.Text,
                        FingerIndex = ddlFingerIndex.SelectedIndex + 1,
                        FingerImage = (System.Byte[])imgConverter.ConvertTo(pbFingerprint.Image, Type.GetType("System.Byte[]")),
                        AppUserID = Shared.loggedInUserID,
                        AppUserAccessToken = Shared.Access_token
                    };

                    string postData = "postData=" + new Cryptography().Encrypt(JsonConvert.SerializeObject(obj));

                    string URL = Shared.API_URL + @"Customer/CustomerVerification";
                    var data = new WebService().webPostMethod(postData, URL);
                    var response = JObject.Parse(data);

                    string responseMessage = response["meta"]["message"].ToString() == "successful" ? "Fingerprint Verified Successfully againt provided CNIC." : response["meta"]["message"].ToString();

                    Shared.ResponseCode = response["response"]["VerificationResponse"]["ResponseCode"] != null ? Convert.ToInt32(response["response"]["VerificationResponse"]["ResponseCode"]) : 0;
                    Shared.ResponseMessage = response["response"]["VerificationResponse"]["ResponseMessage"].ToString() ?? string.Empty;
                    Shared.SessionID = response["response"]["VerificationResponse"]["SessionID"].ToString() ?? string.Empty;
                    Shared.RequestedOn = Convert.ToDateTime(response["response"]["VerificationResponse"]["RequestedOn"]);
                    Shared.CitizenNumber = response["response"]["VerificationResponse"]["CitizenNumber"].ToString() ?? string.Empty;
                    Shared.TransactionID = response["response"]["VerificationResponse"]["TransactionID"].ToString() ?? string.Empty;

                    JArray arr = response["response"]["VerificationResponse"]["SuggestedFingers"].ToObject<JArray>();

                    if (arr != null)
                    {
                        responseMessage += @"Try again with Below Listed Fingers" + Environment.NewLine;

                        Shared.SuggestedFingers = new int[arr.Count];

                        for (int i = 0; i < Shared.SuggestedFingers.Length; i++)
                        {
                            Shared.SuggestedFingers[i] = (int)arr[i];
                            responseMessage += ((Fingers)(int)arr[i]).ToString().Replace("_", " ") + Environment.NewLine;
                        }
                    }

                    lblResponse.Text = responseMessage;

                }
                else { lblResponse.Text = "Please enter required Information and try again!"; }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            StopCapture();
            txtCNIC.Clear();
            txtCell.Clear();
            ddlFingerIndex.SelectedIndex = -1;
            pbFingerprint.Image = Resources.pawprint;
            txtCNIC.Focus();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Other Functions

        public void Init()
        {
            try
            {
                capture = new DPFP.Capture.Capture();

                if (capture != null)
                {
                    capture.EventHandler = this;
                    template = new DPFP.Template();
                    verification = new DPFP.Verification.Verification();
                }
                else
                {
                    MessageBox.Show("ERROR AL INICIAR DIGITAL-PERSONA");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR AL INICIAR DIGITAL-PERSONA");
                Debug.Write(e);
            }
        }

        public void InitCapture()
        {
            if (capture != null)
            {
                try
                {
                    capture.StartCapture();
                }
                catch (Exception e)
                {
                    Debug.Write(e);
                    MessageBox.Show("ERROR AL INICIAR LA CAPTURA CON DIGITAL-PERSONA");
                }
            }
        }

        public void StopCapture()
        {
            if (capture != null)
            {
                try
                {
                    capture.StopCapture();
                }
                catch (Exception e)
                {
                    MessageBox.Show("ERROR AL DETENER DIGITAL-PERSONA");
                }
            }
        }

        public void SetImagePawprint(DPFP.Sample sample)
        {
            DPFP.Capture.SampleConversion converter = new DPFP.Capture.SampleConversion();
            Bitmap bitMap = null;

            converter.ConvertToPicture(sample, ref bitMap);
            pbFingerprint.SizeMode = PictureBoxSizeMode.StretchImage;
            pbFingerprint.Image = bitMap;
        }

        #endregion

        #region Event Handler Functions

        void DPFP.Capture.EventHandler.OnComplete(object Capture, string ReaderSerialNumber, Sample Sample)
        {
            SetImagePawprint(Sample);
        }

        void DPFP.Capture.EventHandler.OnFingerGone(object Capture, string ReaderSerialNumber)
        {

        }

        void DPFP.Capture.EventHandler.OnFingerTouch(object Capture, string ReaderSerialNumber)
        {

        }

        void DPFP.Capture.EventHandler.OnReaderConnect(object Capture, string ReaderSerialNumber)
        {

        }

        void DPFP.Capture.EventHandler.OnReaderDisconnect(object Capture, string ReaderSerialNumber)
        {

        }

        void DPFP.Capture.EventHandler.OnSampleQuality(object Capture, string ReaderSerialNumber, CaptureFeedback CaptureFeedback)
        {

        }

        #endregion
    }
}



