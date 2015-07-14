using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Globalization;
using System.IO;
using DBF_Exporter.Model;
using DBF_Exporter.MiscClass;
using WebAPI;
using WebAPI.ApiResult;
using Newtonsoft.Json;

namespace DBF_Exporter
{
    public partial class Form1 : Form
    {
        private BackgroundWorker workerDealer = null;
        private BackgroundWorker workerProblem = null;
        private BackgroundWorker workerSerial = null;
        private CultureInfo cinfo = new CultureInfo("en-US");

        public Form1()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.txtPath.Text = this.openFileDialog1.FileName;
                this.radioDealer.Enabled = true;
                this.radioProblem.Enabled = true;
                this.radioSerial.Enabled = true;

                switch (this.openFileDialog1.SafeFileName.ToLower())
                {
                    case "dealer.dbf":
                        this.radioDealer.Checked = true;
                        this.radioProblem.Checked = false;
                        this.radioSerial.Checked = false;
                        break;

                    case "problem.dbf":
                        this.radioDealer.Checked = false;
                        this.radioProblem.Checked = true;
                        this.radioSerial.Checked = false;
                        break;

                    case "serial.dbf":
                        this.radioDealer.Checked = false;
                        this.radioProblem.Checked = false;
                        this.radioSerial.Checked = true;
                        break;

                    default:
                        break;
                }
            }
        }

        #region GetDataList
        private List<Serial> getSerialList(string file_path)
        {
            List<Serial> serials = new List<Serial>();

            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = "Provider=vfpoledb;Data Source=" + file_path + ";Collating Sequence=machine;";

            conn.Open();

            OleDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = @"Select * from " + file_path;

            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            conn.Close();

            DateTimeFormatInfo dtinfo = this.cinfo.DateTimeFormat;

            foreach (DataRow dr in dt.Rows)
            {
                string sernum = dr["sernum"].ToString();
                string oldnum = dr["oldnum"].ToString();
                string version = dr["version"].ToString();
                string contact = dr["contact"].ToString();
                string position = dr["position"].ToString();
                string prenam = dr["prenam"].ToString();
                string compnam = dr["compnam"].ToString();
                string addr01 = dr["addr01"].ToString();
                string addr02 = dr["addr02"].ToString();
                string addr03 = dr["addr03"].ToString();
                string zipcod = dr["zipcod"].ToString();
                string telnum = dr["telnum"].ToString();
                string busityp = dr["busityp"].ToString();
                string busides = dr["busides"].ToString();
                DateTime _purdat = (DateTime)dr["purdat"];
                string purdat = (_purdat.Year == 1899 ? "" : _purdat.ToString("yyyy-MM-dd", dtinfo));
                DateTime _expdat = (DateTime)dr["expdat"];
                string expdat = (_expdat.Year == 1899 ? "" : _expdat.ToString("yyyy-MM-dd", dtinfo));
                string howknown = dr["howknown"].ToString();
                string area = dr["area"].ToString();
                string branch = dr["branch"].ToString();
                DateTime _manual = (DateTime)dr["manual"];
                string manual = (_manual.Year == 1899 ? "" : _manual.ToString("yyyy-MM-dd", dtinfo));
                string upfree = dr["upfree"].ToString();
                string refnum = dr["refnum"].ToString();
                string remark = dr["remark"].ToString();
                DateTime _chgdat = (DateTime)dr["chgdat"];
                string chgdat = (_chgdat.Year == 1899 ? "" : _chgdat.ToString("yyyy-MM-dd", dtinfo));
                string verext = dr["verext"].ToString();
                DateTime _verextdat = (DateTime)dr["verextdat"];
                string verextdat = (_verextdat.Year == 1899 ? "" : _verextdat.ToString("yyyy-MM-dd", dtinfo));
                string users_name = dr["userid"].ToString();
                string dealer_dealer = dr["dealer"].ToString();

                Serial s = new Serial();
                s.sernum = sernum.Trim().cleanString();
                s.oldnum = oldnum.Trim().cleanString();
                s.version = version.Trim().cleanString();
                s.contact = contact.Trim().cleanString();
                s.position = position.Trim().cleanString();
                s.prenam = prenam.Trim().cleanString();
                s.compnam = compnam.Trim().cleanString();
                s.addr01 = addr01.Trim().cleanString();
                s.addr02 = addr02.Trim().cleanString();
                s.addr03 = addr03.Trim().cleanString();
                s.zipcod = zipcod.Trim().cleanString();
                s.telnum = telnum.Trim().cleanString();
                s.busityp = busityp.Trim().cleanString();
                s.busides = busides.Trim().cleanString();
                s.purdat = purdat.Trim().cleanString();
                s.expdat = expdat.Trim().cleanString();
                s.howknown = howknown.Trim().cleanString();
                s.area = area.Trim().cleanString();
                s.branch = branch.Trim().cleanString();
                s.manual = manual.Trim().cleanString();
                s.upfree = upfree.Trim().cleanString();
                s.refnum = refnum.Trim().cleanString();
                s.remark = remark.Trim().cleanString();
                s.chgdat = chgdat.Trim().cleanString();
                s.verext = verext.Trim().cleanString();
                s.verextdat = verextdat.Trim().cleanString();
                s.users_name = users_name.Trim().cleanString();
                s.dealer_dealer = dealer_dealer.Trim().cleanString();

                serials.Add(s);
            }

            return serials;
        }

        private List<Problem> getProblemList(string file_path)
        {
            List<Problem> problems = new List<Problem>();
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = "Provider=vfpoledb;Data Source=" + file_path + ";Collating Sequence=machine;";

            conn.Open();

            OleDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = @"Select * from " + file_path;

            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            conn.Close();

            DateTimeFormatInfo dtinfo = this.cinfo.DateTimeFormat;

            foreach (DataRow dr in dt.Rows)
            {
                string probcod = dr["probcod"].ToString();
                string probdesc = dr["probdesc"].ToString();
                DateTime _date = (DateTime)dr["date"];
                string date = (_date.Year == 1899 ? "" : _date.ToString("yyyy-MM-dd", dtinfo));
                string time = dr["time"].ToString();
                string name = dr["name"].ToString();
                string users_name = dr["userid"].ToString();
                string serial_sernum = dr["sernum"].ToString();

                Problem p = new Problem();
                p.probcod = probcod.Trim().cleanString();
                p.probdesc = probdesc.Trim().cleanString();
                p.date = date.Trim().cleanString();
                p.time = time.Trim().cleanString();
                p.name = name.Trim().cleanString();
                p.users_name = users_name.Trim().cleanString();
                p.serial_sernum = serial_sernum.Trim().cleanString();

                problems.Add(p);
            }

            return problems;
        }

        private List<Dealer> getDealerList(string file_path)
        {
            List<Dealer> dealers = new List<Dealer>();
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = "Provider=vfpoledb;Data Source=" + file_path + ";Collating Sequence=machine;";

            conn.Open();

            OleDbCommand cmd = conn.CreateCommand();
            cmd.CommandText = @"Select * from " + file_path;

            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            conn.Close();

            DateTimeFormatInfo dtinfo = this.cinfo.DateTimeFormat;
            foreach (DataRow dr in dt.Rows)
            {
                string dealer = dr["dealer"].ToString();
                string prenam = dr["prenam"].ToString();
                string compnam = dr["compnam"].ToString();
                string addr01 = dr["addr01"].ToString();
                string addr02 = dr["addr02"].ToString();
                string addr03 = dr["addr03"].ToString();
                string zipcod = dr["zipcod"].ToString();
                string telnum = dr["telnum"].ToString();
                string contact = dr["contact"].ToString();
                string position = dr["position"].ToString();
                string busides = dr["busides"].ToString();
                string area = dr["area"].ToString();
                string remark = dr["remark"].ToString();
                DateTime _chgdat = (DateTime)dr["chgdat"];
                string chgdat = (_chgdat.Year == 1899 ? "" : _chgdat.ToString("yyyy-MM-dd", dtinfo));
                string users_name = dr["userid"].ToString();

                Dealer d = new Dealer();
                d.dealer = dealer.Trim().cleanString();
                d.prenam = prenam.Trim().cleanString();
                d.compnam = compnam.Trim().cleanString();
                d.addr01 = addr01.Trim().cleanString();
                d.addr02 = addr02.Trim().cleanString();
                d.addr03 = addr03.Trim().cleanString();
                d.zipcod = zipcod.Trim().cleanString();
                d.telnum = telnum.Trim().cleanString();
                d.contact = contact.Trim().cleanString();
                d.position = position.Trim().cleanString();
                d.busides = busides.Trim().cleanString();
                d.area = area.Trim().cleanString();
                d.remark = remark.Trim().cleanString();
                d.chgdat = chgdat.Trim().cleanString();
                d.users_name = users_name.Trim().cleanString();

                dealers.Add(d);
            }

            return dealers;
        }
        #endregion GetDataList

        private void txtPath_TextChanged(object sender, EventArgs e)
        {
            if (this.txtPath.Text.Length > 0)
            {
                this.btnStartExport.Enabled = true;
            }
        }

        private void keepLog(string msg)
        {
            using (StreamWriter file = new StreamWriter("Export_log.txt", true))
            {
                file.WriteLine(msg);
            }
        }

        private void btnCancelExport_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("หยุดการทำงาน?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (this.workerDealer != null) 
                {
                    if (this.workerDealer.IsBusy)
                    {
                        this.workerDealer.CancelAsync();
                    }
                }
                if (this.workerProblem != null)
                {
                    if (this.workerProblem.IsBusy)
                    {
                        this.workerProblem.CancelAsync();
                    }
                }
                if (this.workerSerial != null)
                {
                    if (this.workerSerial.IsBusy)
                    {
                        this.workerSerial.CancelAsync();
                    }
                }
                
                this.btnBrowse.Enabled = true;
                this.radioDealer.Enabled = true;
                this.radioProblem.Enabled = true;
                this.radioSerial.Enabled = true;
                this.btnStartExport.Enabled = true;
                this.btnCancelExport.Enabled = false;
            }
        }

        private void btnStartExport_Click(object sender, EventArgs e)
        {
            this.btnBrowse.Enabled = false;
            this.radioDealer.Enabled = false;
            this.radioProblem.Enabled = false;
            this.radioSerial.Enabled = false;
            this.btnStartExport.Enabled = false;
            this.btnCancelExport.Enabled = true;

            if (this.radioDealer.Checked)
            {
                this.progressBar1.Maximum = this.getDealerList(this.txtPath.Text).Count;

                this.workerDealer = new BackgroundWorker();
                this.workerDealer.DoWork += new DoWorkEventHandler(this.workerDealer_DoWork);
                this.workerDealer.ProgressChanged += new ProgressChangedEventHandler(this.workerDealer_ProgressChange);
                this.workerDealer.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.workerDealer_Complete);
                this.workerDealer.WorkerReportsProgress = true;
                this.workerDealer.WorkerSupportsCancellation = true;

                this.workerDealer.RunWorkerAsync();
            }
            else if (this.radioProblem.Checked)
            {
                this.progressBar1.Maximum = this.getProblemList(this.txtPath.Text).Count;

                this.workerProblem = new BackgroundWorker();
                this.workerProblem.DoWork += new DoWorkEventHandler(this.workerProblem_DoWork);
                this.workerProblem.ProgressChanged += new ProgressChangedEventHandler(this.workerProblem_ProgressChange);
                this.workerProblem.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.workerProblem_Complete);
                this.workerProblem.WorkerReportsProgress = true;
                this.workerProblem.WorkerSupportsCancellation = true;

                this.workerProblem.RunWorkerAsync();
            }
            else if (this.radioSerial.Checked)
            {
                this.progressBar1.Maximum = this.getSerialList(this.txtPath.Text).Count;

                this.workerSerial = new BackgroundWorker();
                this.workerSerial.DoWork += new DoWorkEventHandler(this.workerSerial_DoWork);
                this.workerSerial.ProgressChanged += new ProgressChangedEventHandler(this.workerSerial_ProgressChange);
                this.workerSerial.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.workerSerial_Complete);
                this.workerSerial.WorkerReportsProgress = true;
                this.workerSerial.WorkerSupportsCancellation = true;

                this.workerSerial.RunWorkerAsync();
            }
        }

        #region Serial
        private void workerSerial_DoWork(object sender, DoWorkEventArgs e)
        {
            this.keepLog("Start export Serial file at : " + DateTime.Now.ToString());

            List<Serial> serials = this.getSerialList(this.txtPath.Text);

            int err_count = 0;
            int loop_count = 0;
            foreach (Serial s in serials)
            {
                if (this.workerSerial.CancellationPending)
                {
                    e.Cancel = true;
                    this.workerSerial.ReportProgress(loop_count);
                    return;
                }

                loop_count++;
                this.workerSerial.ReportProgress(loop_count);

                try
                {
                    string json_data = "{\"sernum\":\"" + s.sernum + "\",";
                    json_data += "\"oldnum\":\"" + s.oldnum + "\",";
                    json_data += "\"version\":\"" + s.version + "\",";
                    json_data += "\"contact\":\"" + s.contact + "\",";
                    json_data += "\"position\":\"" + s.position + "\",";
                    json_data += "\"prenam\":\"" + s.prenam + "\",";
                    json_data += "\"compnam\":\"" + s.compnam + "\",";
                    json_data += "\"addr01\":\"" + s.addr01 + "\",";
                    json_data += "\"addr02\":\"" + s.addr02 + "\",";
                    json_data += "\"addr03\":\"" + s.addr03 + "\",";
                    json_data += "\"zipcod\":\"" + s.zipcod + "\",";
                    json_data += "\"telnum\":\"" + s.telnum + "\",";
                    json_data += "\"busityp\":\"" + s.busityp + "\",";
                    json_data += "\"busides\":\"" + s.busides + "\",";
                    json_data += "\"purdat\":\"" + s.purdat + "\",";
                    json_data += "\"expdat\":\"" + s.expdat + "\",";
                    json_data += "\"howknown\":\"" + s.howknown + "\",";
                    json_data += "\"area\":\"" + s.area + "\",";
                    json_data += "\"branch\":\"" + s.branch + "\",";
                    json_data += "\"manual\":\"" + s.manual + "\",";
                    json_data += "\"upfree\":\"" + s.upfree + "\",";
                    json_data += "\"refnum\":\"" + s.refnum + "\",";
                    json_data += "\"remark\":\"" + s.remark + "\",";
                    json_data += "\"chgdat\":\"" + s.chgdat + "\",";
                    json_data += "\"verext\":\"" + s.verext + "\",";
                    json_data += "\"verextdat\":\"" + s.verextdat + "\",";
                    json_data += "\"users_name\":\"" + s.users_name + "\",";
                    json_data += "\"dealer_dealer\":\"" + s.dealer_dealer + "\"}";

                    Console.WriteLine("Current S/N : " + s.sernum);

                    CRUDResult post = ApiActions.POST(ApiConfig.API_MAIN_URL + "serial/create", json_data);
                    ServerResult sr = JsonConvert.DeserializeObject<ServerResult>(post.data);
                    if (sr.result != ServerResult.SERVER_RESULT_SUCCESS)
                    {
                        err_count++;
                        this.keepLog("\t" + DateTime.Now.ToString() + "\tExport failed # " + err_count.ToString() + " at row " + loop_count.ToString() + "\tS/N " + s.sernum);
                        continue;
                    }
                }
                catch (Exception)
                {
                    err_count++;
                    this.keepLog("\t" + DateTime.Now.ToString() + "\tExport failed # " + err_count.ToString() + " at row " + loop_count.ToString() + "\tS/N " + s.sernum);
                    continue;
                    throw;
                }
            }
            
            this.workerSerial.ReportProgress(serials.Count);
        }

        private void workerSerial_ProgressChange(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar1.Value = e.ProgressPercentage;
            Console.WriteLine("progressBar1.Value = " + this.progressBar1.Value.ToString() + "/" + this.progressBar1.Maximum.ToString());
            this.lblCounter.Text = e.ProgressPercentage.ToString() + "/" + this.progressBar1.Maximum.ToString();
        }

        private void workerSerial_Complete(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                this.keepLog("Export Serial file canceled at : " + DateTime.Now.ToString() + Environment.NewLine);
                this.lblCounter.Text = "Canceled at : " + this.lblCounter.Text;
            }
            else if(e.Error != null){
                this.keepLog("Export Serial file cannot continue at : " + DateTime.Now.ToString() + Environment.NewLine);
                this.lblCounter.Text = "Error occured while process at : " + this.lblCounter.Text;
            }
            else
            {
                this.keepLog("Export Serial file complete at : " + DateTime.Now.ToString() + Environment.NewLine);
                this.lblCounter.Text = "Process complete, Total row inserted successfully : " + this.lblCounter.Text;
            }
        }
        #endregion Serial

        #region Problem
        private void workerProblem_DoWork(object sender, DoWorkEventArgs e)
        {
            this.keepLog("Start export Problem file at : " + DateTime.Now.ToString());

            List<Problem> problems = this.getProblemList(this.txtPath.Text);

            int err_count = 0;
            int loop_count = 0;
            foreach (Problem p in problems)
            {
                if (this.workerProblem.CancellationPending)
                {
                    e.Cancel = true;
                    this.workerProblem.ReportProgress(loop_count);
                    return;
                }

                loop_count++;
                this.workerProblem.ReportProgress(loop_count);

                try
                {
                    string json_data = "{\"probcod\":\"" + p.probcod + "\",";
                    json_data += "\"probdesc\":\"" + p.probdesc + "\",";
                    json_data += "\"date\":\"" + p.date + "\",";
                    json_data += "\"time\":\"" + p.time + "\",";
                    json_data += "\"name\":\"" + p.name + "\",";
                    json_data += "\"users_name\":\"" + p.users_name + "\",";
                    json_data += "\"serial_sernum\":\"" + p.serial_sernum + "\"}";

                    Console.WriteLine("Current Problem : " + loop_count.ToString() + " " + p.serial_sernum + " ; " + p.probcod);

                    CRUDResult post = ApiActions.POST(ApiConfig.API_MAIN_URL + "problem/create", json_data);
                    ServerResult sr = JsonConvert.DeserializeObject<ServerResult>(post.data);
                    if (sr.result != ServerResult.SERVER_RESULT_SUCCESS)
                    {
                        err_count++;
                        this.keepLog("\t" + DateTime.Now.ToString() + "\tExport failed # " + err_count.ToString() + " at row " + loop_count.ToString() + "\tS/N " + p.serial_sernum);
                        continue;
                    }
                }
                catch (Exception)
                {
                    err_count++;
                    this.keepLog("\t" + DateTime.Now.ToString() + "\tExport failed # " + err_count.ToString() + " at row " + loop_count.ToString() + "\tS/N " + p.serial_sernum);
                    continue;
                    throw;
                }
            }
            
            this.workerProblem.ReportProgress(problems.Count);
        }

        private void workerProblem_ProgressChange(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar1.Value = e.ProgressPercentage;
            Console.WriteLine("progressBar1.Value = " + this.progressBar1.Value.ToString() + "/" + this.progressBar1.Maximum.ToString());
            this.lblCounter.Text = e.ProgressPercentage.ToString() + "/" + this.progressBar1.Maximum.ToString();
        }

        private void workerProblem_Complete(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                this.keepLog("Export Problem file canceled at : " + DateTime.Now.ToString() + Environment.NewLine);
                this.lblCounter.Text = "Canceled at : " + this.lblCounter.Text;
            }
            else if(e.Error != null){
                this.keepLog("Export Problem file cannot continue at : " + DateTime.Now.ToString() + Environment.NewLine);
                this.lblCounter.Text = "Error occured while process at : " + this.lblCounter.Text;
            }
            else
            {
                this.keepLog("Export Problem file complete at : " + DateTime.Now.ToString() + Environment.NewLine);
                this.lblCounter.Text = "Process complete, Total row inserted successfully : " + this.lblCounter.Text;
            }
        }        
        #endregion Problem

        #region Dealer
        private void workerDealer_DoWork(object sender, DoWorkEventArgs e)
        {
            this.keepLog("Start export Dealer file at : " + DateTime.Now.ToString());

            List<Dealer> dealers = this.getDealerList(this.txtPath.Text);

            int err_count = 0;
            int loop_count = 0;
            foreach (Dealer d in dealers)
            {
                if (this.workerDealer.CancellationPending)
                {
                    e.Cancel = true;
                    this.workerDealer.ReportProgress(loop_count);
                    return;
                }

                loop_count++;
                this.workerDealer.ReportProgress(loop_count);

                try
                {
                    string json_data = "{\"dealer\":\"" + d.dealer + "\",";
                    json_data += "\"prenam\":\"" + d.prenam + "\",";
                    json_data += "\"compnam\":\"" + d.compnam + "\",";
                    json_data += "\"addr01\":\"" + d.addr01 + "\",";
                    json_data += "\"addr02\":\"" + d.addr02 + "\",";
                    json_data += "\"addr03\":\"" + d.addr03 + "\",";
                    json_data += "\"zipcod\":\"" + d.zipcod + "\",";
                    json_data += "\"telnum\":\"" + d.telnum + "\",";
                    json_data += "\"contact\":\"" + d.contact + "\",";
                    json_data += "\"position\":\"" + d.position + "\",";
                    json_data += "\"busides\":\"" + d.busides + "\",";
                    json_data += "\"area\":\"" + d.area + "\",";
                    json_data += "\"remark\":\"" + d.remark + "\",";
                    json_data += "\"chgdat\":\"" + d.chgdat + "\",";
                    json_data += "\"users_name\":\"" + d.users_name + "\"}";

                    Console.WriteLine("Current Dealer : " + loop_count.ToString() + " " + d.dealer + " ; " + d.prenam + " " + d.compnam);

                    CRUDResult post = ApiActions.POST(ApiConfig.API_MAIN_URL + "dealer/create", json_data);
                    ServerResult sr = JsonConvert.DeserializeObject<ServerResult>(post.data);
                    if (sr.result != ServerResult.SERVER_RESULT_SUCCESS)
                    {
                        err_count++;
                        this.keepLog("\t" + DateTime.Now.ToString() + "\tExport failed # " + err_count.ToString() + " at row " + loop_count.ToString() + "\tDealer " + d.prenam + " " + d.compnam);
                        continue;
                    }
                }
                catch (Exception)
                {
                    err_count++;
                    this.keepLog("\t" + DateTime.Now.ToString() + "\tExport failed # " + err_count.ToString() + " at row " + loop_count.ToString() + "\tDealer " + d.prenam + " " + d.compnam);
                    continue;
                    throw;
                }
            }

            this.workerDealer.ReportProgress(dealers.Count);
        }

        private void workerDealer_ProgressChange(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar1.Value = e.ProgressPercentage;
            Console.WriteLine("progressBar1.Value = " + this.progressBar1.Value.ToString() + "/" + this.progressBar1.Maximum.ToString());
            this.lblCounter.Text = e.ProgressPercentage.ToString() + "/" + this.progressBar1.Maximum.ToString();
        }

        private void workerDealer_Complete(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                this.keepLog("Export Dealer file canceled at : " + DateTime.Now.ToString() + Environment.NewLine);
                this.lblCounter.Text = "Canceled at : " + this.lblCounter.Text;
            }
            else if (e.Error != null)
            {
                this.keepLog("Export Dealer file cannot continue at : " + DateTime.Now.ToString() + Environment.NewLine);
                this.lblCounter.Text = "Error occured while process at : " + this.lblCounter.Text;
            }
            else
            {
                this.keepLog("Export Dealer file complete at : " + DateTime.Now.ToString() + Environment.NewLine);
                this.lblCounter.Text = "Process complete, Total row inserted successfully : " + this.lblCounter.Text;
            }
        }
        #endregion Dealer
    }
}