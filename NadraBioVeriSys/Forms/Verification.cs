using DPFP;
using DPFP.Capture;
using NadraBioVeriSys.Properties;
using NadraBioVeriSys.Reports;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace NadraBioVeriSys
{
    public partial class Verification : Form, DPFP.Capture.EventHandler
    {
        private DPFP.Verification.Verification verification;
        private DPFP.Capture.Capture capture;
        private DPFP.Template template;

        private Thread workerThread = null;

        public Verification()
        {
            InitializeComponent();
        }

        private void Verification_Load(object sender, EventArgs e)
        {
            //ddlFingerIndex.SelectedIndex = 0;
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

            if (string.IsNullOrEmpty(txtCNIC.Text) || string.IsNullOrEmpty(txtCell.Text) || ddlBusinessPurpose.SelectedIndex < 0 || ddlFingerIndex.SelectedIndex < 0)
            {
                MessageBox.Show("Please provide all required informations!. All fields with '*' are mandatory.");
                return;
            }

            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.Visible = true;

            btnScan.Enabled = false;
            btnVerify.Enabled = false;

            workerThread = new Thread(verify);
            workerThread.Start();
            timer1.Interval = 100;
            timer1.Start();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            StopCapture();
            txtCNIC.Clear();
            txtCell.Clear();
            lblResponse.Text = "";
            ddlBusinessPurpose.SelectedIndex = -1;
            ddlFingerIndex.SelectedIndex = -1;
            pbFingerprint.Image = Resources.pawprint;
            txtCNIC.Focus();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(lblResponse.Text))
                    return;

                Enum.TryParse(ddlFingerIndex.SelectedIndex + 1.ToString(), out Fingers value);

                DataTable dt = new DataTable();
                dt.Columns.Add("VID", typeof(string));
                dt.Columns.Add("CNIC", typeof(string));
                dt.Columns.Add("CellNO", typeof(string));
                dt.Columns.Add("FingerScanned", typeof(string));
                dt.Columns.Add("Result", typeof(string));
                dt.Columns.Add("VDate", typeof(string));
                dt.Columns.Add("VTime", typeof(string));

                dt.Rows.Add(Shared.SessionID.ToString(), Shared.CitizenNumber.ToString(), txtCell.Text, value.ToString().Replace("_", " "), lblResponse.Text, Shared.RequestedOn.ToLongDateString(), Shared.RequestedOn.ToLongTimeString());

                VerificationReport objReport = new VerificationReport();
                objReport.SetDataSource(dt);
                objReport.SetParameterValue("PrintedBy", Shared.LoggedInUser.Name);

                objReport.PrintToPrinter(1, false, 1, 1);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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
                    MessageBox.Show("ERROR INITIATING BIOMETRIC DEVICE.");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR INITIATING BIOMETRIC DEVICE.");
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
                    MessageBox.Show("ERROR INITIATING FINGER PRINT CAPTURE IN BIOMETRIC DEVICE.");
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
                    MessageBox.Show("ERROR STOPPING FINGER PRINT CAPTURE IN BIOMETRIC DEVICE");
                }
            }
        }

        public void SetImagePawprint(DPFP.Sample sample)
        {
            DPFP.Capture.SampleConversion converter = new DPFP.Capture.SampleConversion();
            Bitmap bitMap = null;

            converter.ConvertToPicture(sample, ref bitMap);
            pbFingerprint.SizeMode = PictureBoxSizeMode.Zoom;
            pbFingerprint.Image = bitMap;
        }

        public void verify()
        {
            try
            {
                if (ddlFingerIndex.InvokeRequired)
                {
                    ddlFingerIndex.Invoke(new Action(verify));
                    return;
                }

                if (txtCNIC != null && txtCell != null && ddlFingerIndex.SelectedIndex > -1)
                {
                    ImageConverter imgConverter = new ImageConverter();

                    Customers obj = new Customers()
                    {
                        CustCNIC = txtCNIC.Text.Replace("-", ""),
                        CustCell = txtCell.Text,
                        BusinessPurpose = ddlBusinessPurpose.SelectedIndex + 1,
                        FingerIndex = ddlFingerIndex.SelectedIndex + 1,
                        FingerImage = (System.Byte[])imgConverter.ConvertTo(pbFingerprint.Image, Type.GetType("System.Byte[]")),
                        AppUserID = Shared.LoggedInUser.ID,
                        AppUserStationID = Shared.LoggedInUser.StationID,
                        AppUserAccessToken = Shared.LoggedInUser.AccessToken
                    };

                    string postData = "postData=" + new Cryptography().Encrypt(JsonConvert.SerializeObject(obj));

                    string URL = Shared.API_URL + @"Customer/CustomerVerification";
                    var data = new WebService().webPostMethod(postData, URL);
                    var response = JObject.Parse(data);
                    string responseMessage = response["meta"]["message"].ToString() == "successful" ? "Fingerprint Verified Successfully againt provided CNIC." : response["meta"]["message"].ToString() + ". ";

                    Shared.ResponseCode = response["response"]["VerificationResponse"]["ResponseCode"] != null ? Convert.ToInt32(response["response"]["VerificationResponse"]["ResponseCode"]) : 0;
                    Shared.ResponseMessage = response["response"]["VerificationResponse"]["ResponseMessage"].ToString() ?? string.Empty;
                    Shared.SessionID = response["response"]["VerificationResponse"]["SessionID"].ToString() ?? string.Empty;
                    Shared.RequestedOn = Convert.ToDateTime(response["response"]["VerificationResponse"]["RequestedOn"]);
                    Shared.CitizenNumber = response["response"]["VerificationResponse"]["CitizenNumber"].ToString() ?? string.Empty;
                    Shared.TransactionID = response["response"]["VerificationResponse"]["TransactionID"].ToString() ?? string.Empty;

                    JArray arr = response["response"]["VerificationResponse"]["SuggestedFingers"].ToObject<JArray>();
                    if (arr != null)
                    {
                        responseMessage += @"Please Try again with Below Listed Fingers" + Environment.NewLine;

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
            finally { }
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (workerThread == null)
            {
                timer1.Stop();
                return;
            }

            // still works: exiting
            if (workerThread.IsAlive)
                return;

            // finished
            btnScan.Enabled = true;
            btnVerify.Enabled = true;
            timer1.Stop();
            progressBar1.Visible = false;
            workerThread = null;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}



