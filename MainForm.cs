using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NDde.Client;
using System.Threading;

namespace ClientWin
{
    public partial class MainForm : Form
    {
        private DdeClient client;
        int count = 0;
        int write_count = 0;
        volatile string wr = "";
        Int64 dn = 0L;
        Int64 up = 0L;
        volatile string sat = "";
        public MainForm()
        {
            InitializeComponent();

            client = new DdeClient("Orbitron", "Tracking", this);
            client.Advise += client_Advise;
            client.Disconnected += client_Disconnected;
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if(OrbitronDDE_nvx.Properties.Settings.Default._PortName.Length>0)
            try
            {
                tbPortName.Text = OrbitronDDE_nvx.Properties.Settings.Default._PortName;
                tbBaudRate.Text = OrbitronDDE_nvx.Properties.Settings.Default._BaudRate;
                tbWrite.Value = OrbitronDDE_nvx.Properties.Settings.Default._tbWrite;
                cbSN.Checked = OrbitronDDE_nvx.Properties.Settings.Default._cbSN;
                cbAZ.Checked = OrbitronDDE_nvx.Properties.Settings.Default._cbAZ;
                cbEL.Checked = OrbitronDDE_nvx.Properties.Settings.Default._cbEL;
                cbUP.Checked = OrbitronDDE_nvx.Properties.Settings.Default._cbUP;
                cbDN.Checked = OrbitronDDE_nvx.Properties.Settings.Default._cbDN;
                cbDM.Checked = OrbitronDDE_nvx.Properties.Settings.Default._cbDM;
                cbUM.Checked = OrbitronDDE_nvx.Properties.Settings.Default._cbUM;
                cbEL0.Checked = OrbitronDDE_nvx.Properties.Settings.Default._cbEL0;
                cb_180.Checked = OrbitronDDE_nvx.Properties.Settings.Default._cb180;
                if(OrbitronDDE_nvx.Properties.Settings.Default._tbWrite > 0)
                    if (OrbitronDDE_nvx.Properties.Settings.Default._tbWrite < 21)
                    timer.Interval = OrbitronDDE_nvx.Properties.Settings.Default._tbWrite * 1000;
                lbT.Text = tbWrite.Value.ToString() + " [s]";

                if(OrbitronDDE_nvx.Properties.Settings.Default._tbWrite==1)
                    cb_Predict500ms.Checked = OrbitronDDE_nvx.Properties.Settings.Default._cb05s;
                         
                this.Top = OrbitronDDE_nvx.Properties.Settings.Default.WinTop;
                this.Left = OrbitronDDE_nvx.Properties.Settings.Default.WinLeft;
                this.Height = OrbitronDDE_nvx.Properties.Settings.Default.WinHeight;
                this.Width = OrbitronDDE_nvx.Properties.Settings.Default.WinWidth;

                cb_180.Text = OrbitronDDE_nvx.Properties.Settings.Default.cb180Text;

                    // Przywracanie stanu okna (Zminimalizowane/Maksymalizowane/Normalne)
                this.WindowState = (FormWindowState)OrbitronDDE_nvx.Properties.Settings.Default.WinState;
                                        
                }
            catch (Exception ex)
            {
                displayTextBox.Text = "MainForm_Load: " + ex.Message;
            }

            try
            {
                // Connect to the server.  It must be running or an exception will be thrown.
                // MessageBox.Show("Start?");
                client.Connect();

                // Advise Loop
                client.StartAdvise("TrackingData", 1, true, 60000);
            }
            catch (Exception ex)
            {
                displayTextBox.Text = "MainForm_Load: " + ex.Message;
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            displayTextBox.Left = this.DisplayRectangle.Left;
            displayTextBox.Width = this.DisplayRectangle.Width;
            displayTextBox.Top = this.DisplayRectangle.Top;
            displayTextBox.Height = this.DisplayRectangle.Height;
        }

        private string Frame(string inp)
        {
            string outp = "";
            inp += " ";
            int i=0;
            int j=0;
            if (cbSN.Checked)
            {
                i = inp.IndexOf("SN");
                j = inp.IndexOf(" ",i);
                if ( i >= 0)
                {
                    outp += inp.Substring(i, j - i) + " ";
                }
            }
            //AZ
            if (cbAZ.Checked)
            {
                i = inp.IndexOf("AZ");
                j = inp.IndexOf(" ", i);
                if (i >= 0)
                {
                    outp += inp.Substring(i, j - i) + " ";
                }
            }
            //EL
            if (cbEL.Checked)
            {
                i = inp.IndexOf("EL");
                j = inp.IndexOf(" ", i);
                int m = inp.IndexOf("EL-");
                if (i >= 0 && m <= 0) // dodatnia elewacja
                {
                    outp += inp.Substring(i, j - i) + " ";
                }
                if (i >= 0 && m > 0) // ujemna elewacja
                {
                    if(cbEL0.Checked)
                        outp += "EL0.0 ";
                    else outp += inp.Substring(i, j - i) + " ";
                }
            }
            //DN
            if (cbDN.Checked)
            {
                i = inp.IndexOf("DN");
                j = inp.IndexOf(" ", i);
                if (i >= 0)
                {
                    outp += inp.Substring(i, j - i) + " ";
                }
            }
            //UP
            if (cbUP.Checked)
            {
                i = inp.IndexOf("UP");
                j = inp.IndexOf(" ", i);
                if (j <= i) j = inp.Length;
                if (i >= 0)
                {
                    outp += inp.Substring(i, j - i) + " ";
                }
            }
            //DM
            if (cbDM.Checked)
            {
                i = inp.IndexOf("DM");
                try
                {
                    j = inp.IndexOf(" ", i);
                    if (j <= i) j = inp.Length;
                    if (i >= 0)
                    {
                        outp += inp.Substring(i, j - i) + " ";
                    }
                    else outp += "DMNONE" + " ";
                }
                catch { outp += "DMNONE" + " "; }
            }
            //UM
            if (cbUM.Checked)
            {
                i = inp.IndexOf("UM");
                
                if (i >= 0)
                {
                    outp += inp.Substring(i) + " ";
                }
                else outp += "UMNONE" + " "; 
            }

            return outp;
        }
        string reverse180(string input)
        {
            try
            {
                int kk = Convert.ToInt32(cb_180.Text);
                string output = "";
                int i = input.IndexOf("AZ");
                if (i > 1)
                {
                    // AZ123.1 
                    int j = input.IndexOf(" ", i);
                    int k = input.IndexOf(".", i);
                    if (k > i) j = k;
                    if (j > i)
                    {
                        string ss = input.Substring(i + 2, j - (i + 2));
                        double daz = Convert.ToDouble(ss);
                        daz = daz * 10.0;
                        int az = Convert.ToInt32(daz);
                        az += (kk*10);
                        if ((az) >= 3600)
                            az = az - 3600;
                        az = az / 10;
                        output = input.Substring(0, i + 2);
                        output += az.ToString();
                        output += input.Substring(j);
                    }
                }
                return output;
            }catch { return ""; }
        }
        private void client_Advise(object sender, DdeAdviseEventArgs args)
        {
            wr = "";
            displayTextBox.Enabled = false;
            Application.DoEvents();
            displayTextBox.Enabled = true;

            if (write_count == count) return;
            write_count = count;

            // + 180
            string arg = args.Text;
            if (cb_180.Checked) 
                arg = reverse180(args.Text);

            if (arg.Length <= 2) return;

            displayTextBox.Text = "Orbitron data: " + args.Text;

            // Tu sprawdzimy czy zmieniono satelitê bo wtedy wyzerujemy dn i up
            string _sat = sat;
            
            try
            {
                int a = args.Text.IndexOf(" ");
                if (a>0)
                 sat = args.Text.Substring(0, a);

                if (_sat != "")
                {
                    if (String.Compare(_sat, sat, StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        // Nazwy s¹ takie same
                        this.Text = sat;
                    }
                    else { dn = 0L; up = 0L; this.Text = "MyDDE by SP5NVX"; }
                }

            }
            catch { }

            if (cbOpenCOM.Checked)
            {
                timer_500.Enabled = true;
                Application.DoEvents();
                label1.Focus();                
                try
                {
                    if (!COM.IsOpen) COM.Open();
                    cbOpenCOM.BackColor = Color.Chartreuse;
                    cbOpenCOM.Refresh();
                    Application.DoEvents();
                    string argsText = Frame(arg);///args.Text

                    char[] c = new char[1];
                    
                    for (int i = 0; i < argsText.Length - 1; i++)
                    {                        
                        c[0] = argsText[i];

                        if (c[0] != '\0' && c[0] != '\r' && c[0] != '\n')
                        {
                            COM.Write(c, 0, 1);
                            wr += c[0];
                        }
                        
                    }
                    c[0] = '\r';
                    COM.Write(c, 0, 1);
                    c[0] = '\n';
                    COM.Write(c, 0, 1);
                                        
                    info.Text = COM.PortName + " " + wr;
                    btTest.Visible = false;
                    if(tbWrite.Enabled) COM.Close();
                }
                catch { cbOpenCOM.Checked = false; if (COM.IsOpen) COM.Close(); }
                cbOpenCOM.BackColor = SystemColors.Control;
            }                    
            
        }

        private void client_Disconnected(object sender, DdeDisconnectedEventArgs args)
        {
            displayTextBox.Text = 
                "OnDisconnected: " +
                "IsServerInitiated=" + args.IsServerInitiated.ToString() + " " +
                "IsDisposed=" + args.IsDisposed.ToString();
            try
            {
                COM.Close();
            }
            catch { }
        }

        private void tbPortName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                COM.PortName = tbPortName.Text;
            }
            catch { ; }
        }

        private void tbBaudRate_TextChanged(object sender, EventArgs e)
        {
            btTest.Visible = true;
            try
            {
                int br = Convert.ToInt32(tbBaudRate.Text);
                COM.BaudRate = br;
            }
            catch { ; }
        }

        private void btTest_Click(object sender, EventArgs e)
        {
            btTest.Visible = true;
            try
            {
                COM.Open();
                info.Text = COM.PortName.ToString();
                if(tbWrite.Enabled) COM.Close();
                cbOpenCOM.Enabled = true;
                info.Text = "OK";
                cbOpenCOM.Checked = true;
            }
            catch(Exception ex)
            {
                info.Text = "";
                cbOpenCOM.Enabled = false;
                cbOpenCOM.Checked = false;
                MessageBox.Show(ex.Message);
                if (COM.IsOpen) COM.Close();
                if (cb_Predict500ms.Checked) cb_Predict500ms.Checked = false;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            int h = this.Height;
            this.Height = 76;
            try { client.Disconnect(); }
            catch { }
            Application.DoEvents();
            double dd = 1.0;
            for (double d = 0.0; d < 666; d = d + 0.001)
            {
                if (d > 133.0 && d < 135.0) this.Text = "73! Orbitron driver by SP5NVX";
                Application.DoEvents();
                dd = dd * d;
            }
            OrbitronDDE_nvx.Properties.Settings.Default._PortName = tbPortName.Text;
            OrbitronDDE_nvx.Properties.Settings.Default._BaudRate = tbBaudRate.Text;
            OrbitronDDE_nvx.Properties.Settings.Default._tbWrite = tbWrite.Value;
            OrbitronDDE_nvx.Properties.Settings.Default._cbSN = cbSN.Checked;
            OrbitronDDE_nvx.Properties.Settings.Default._cbAZ = cbAZ.Checked;
            OrbitronDDE_nvx.Properties.Settings.Default._cbEL = cbEL.Checked;
            OrbitronDDE_nvx.Properties.Settings.Default._cbDN = cbDN.Checked;
            OrbitronDDE_nvx.Properties.Settings.Default._cbUP = cbUP.Checked;
            OrbitronDDE_nvx.Properties.Settings.Default._cbDM = cbDM.Checked;
            OrbitronDDE_nvx.Properties.Settings.Default._cbUM = cbUM.Checked;
            OrbitronDDE_nvx.Properties.Settings.Default._cbEL0 = cbEL0.Checked;
            OrbitronDDE_nvx.Properties.Settings.Default._cb180 = cb_180.Checked;
            OrbitronDDE_nvx.Properties.Settings.Default._cb05s = cb_Predict500ms.Checked;

            OrbitronDDE_nvx.Properties.Settings.Default.WinTop = this.Top;
            OrbitronDDE_nvx.Properties.Settings.Default.WinLeft = this.Left;
            OrbitronDDE_nvx.Properties.Settings.Default.WinHeight = h;
            OrbitronDDE_nvx.Properties.Settings.Default.WinWidth = this.Width;
            OrbitronDDE_nvx.Properties.Settings.Default.cb180Text = cb_180.Text;

            // Przywracanie stanu okna (Zminimalizowane/Maksymalizowane/Normalne)
            this.WindowState = (FormWindowState)OrbitronDDE_nvx.Properties.Settings.Default.WinState;

            OrbitronDDE_nvx.Properties.Settings.Default.Save();

            try { COM.Close(); }
            catch (Exception ex) { MessageBox.Show(ex.Message); };
        }

        private void tbWrite_ValueChanged(object sender, EventArgs e)
        {
            lbT.Text = tbWrite.Value.ToString()+" [s]";
            
            if (tbWrite.Value >= 1) timer.Interval = tbWrite.Value * 1000;     
            
            if(tbWrite.Value > 1) { cb_Predict500ms.Checked = false; }       
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            count++;
            if (count < 5)
            {
                try { tbWrite.Value = timer.Interval / 1000; }
                catch { }
                if (cbOpenCOM.Checked == false)
                {
                    try { 
                        COM.Open();
                        if (COM.IsOpen)
                            cbOpenCOM.Checked = true;
                        cbOpenCOM.Enabled = true;
                        if (tbWrite.Enabled) COM.Close();
                        count++;
                    }
                    catch { }
                }
            }
        }

        private void displayTextBox_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                // Connect to the server.  It must be running or an exception will be thrown.
                client.Connect();

                // Advise Loop
                client.StartAdvise("TrackingData", 1, true, 60000);
            }
            catch (Exception ex)
            {
                displayTextBox.Text = "MainForm_Load: " + ex.Message;
            }
        }

        private void tbPortName_SelectedItemChanged(object sender, EventArgs e)
        {
            btTest.Visible = true;
            try
            {
                COM.PortName = tbPortName.Text;
            }
            catch { ; }

        }

        private void tbBaudRate_SelectedItemChanged(object sender, EventArgs e)
        {
            btTest.Visible = true;
            try
            {
                int br = Convert.ToInt32(tbBaudRate.Text);
                COM.BaudRate = br;
            }
            catch { ; }
        }

        private void COM_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {

            string c = " ";
            try
            {
                c += COM.ReadExisting();
                if (c.IndexOf("GET") > 0)
                    count++;
            }
            catch { }
        }

        private void cb_WriteOnRead_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_Predict500ms.Checked) { tbWrite.Value = 1; tbWrite.Enabled = false; btTest_Click(this, null); }
            else { tbWrite.Enabled = true; up = 0L; dn = 0L; }
            cbDN.Checked = true;
            cbUP.Checked = true;
        }

        private void timer_500_Tick(object sender, EventArgs e)
        {
            if (cb_Predict500ms.Checked)
            {
                try
                {
                    // String wr zawiera dane, w tym DN8989899 UP5656664 liczymy ich predykcjê liniow¹ na 500ms do przodu
                    
                    Int64 _dn = 0L;
                    Int64 _up = 0L; 
                   
                    // Poprzednio wyliczone podstawiam: 
                    _dn = dn;
                    _up = up;           
                    
                    // Wyci¹gamy dane bie¿¹ce
                    int a = wr.IndexOf("DN");
                    int b = (wr+" ").IndexOf(" ", a);
                    dn = Convert.ToInt64(wr.Substring(a + 2, b - (a + 2)));
                    int cc = wr.IndexOf("UP");
                    int d = (wr+" ").IndexOf(" ", cc);
                    up = Convert.ToInt64(wr.Substring(cc + 2, d - (cc + 2)));
                    // Czy by³y poprzednie?             
                    if (_dn == 0L) { _dn = dn; }
                    if (_up == 0L) { _up = up; }
                    // Obliczam predykcjê DN                   
                    if (_dn < dn) // roœnie
                    ///{ dn = dn + ((dn - _dn) / 2L); }
                    { dn = (long)Math.Round((double)((double)dn + (double)(dn - _dn) / 2L),MidpointRounding.AwayFromZero); }
                    else
                    ///{ dn = dn - ((_dn - dn) / 2L); } // maleje
                    { dn = (long)Math.Round((double)((double)dn - (double)(_dn - dn) / 2L),MidpointRounding.AwayFromZero); }
                    // Obliczam predykcjê UP
                    if (_up < up) // roœnie
                    ///{ up = up + ((up - _up) / 2L); }
                    { up = (long)Math.Round((double)((double)up + (double)(up - _up) / 2L), MidpointRounding.AwayFromZero); }
                    else
                    ///{ up = up - ((_up - up) / 2L); } // maleje
                    { up = (long)Math.Round((double)((double)up - (double)(_up - up) / 2L), MidpointRounding.AwayFromZero); }
                    if (COM.IsOpen)
                    {
                        cbOpenCOM.BackColor = Color.Chartreuse;
                        cbOpenCOM.Refresh();
                        Application.DoEvents();
                        // Zamieniamy long na string
                        string sdn = dn.ToString();
                        string sup = up.ToString();
                        // Wstawiamy do "wr" nowe wartoœci z predykcji (uwaga na rozmiar i spacje)
                        wr = wr.Replace(wr.Substring(a + 2, b - (a + 2)), sdn);
                        wr = wr.Replace(wr.Substring(cc + 2, d - (cc + 2)), sup);


                        char[] c = new char[1];

                        for (int i = 0; i < wr.Length - 1; i++)
                        {
                            c[0] = wr[i];

                            if (c[0] != '\0' && c[0] != '\r' && c[0] != '\n')
                            {
                                COM.Write(c, 0, 1);
                            }

                        }
                        c[0] = '\r';
                        COM.Write(c, 0, 1);
                        c[0] = '\n';
                        COM.Write(c, 0, 1);

                        info.Text = COM.PortName + " " + wr;
                    }

                    cbOpenCOM.BackColor = SystemColors.Control;
                    cbOpenCOM.Refresh();
                    timer_500.Enabled = false;
                }catch { timer_500.Enabled = false; }
            }else timer_500.Enabled = false;
        }

        private void lb_minus_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 p = Convert.ToInt32(cb_180.Text);
                p--;
                if(p>=1 && p<=360)
                    cb_180.Text = p.ToString();
            }
            catch { }
        }

        private void lb_plus_Click(object sender, EventArgs e)
        {
            try
            {
                Int32 p = Convert.ToInt32(cb_180.Text);
                p++;
                if (p >= 1 && p <= 360)
                    cb_180.Text = p.ToString();
            }
            catch { }
        }
    } // class

} // namespace


/*
 * tutaj podrzucê propozycje Darka SP9TTX:

W najnowszej wersji jest w sumie ok, ale jeszcze bym zmienil co nie co.
 
1. Wysylanie 0.0 dla elewacji ujemnej mialo byc wybierane tak jak  SN, AZ, itd.
2. Czas bym dal od 1 sekundy
3. W stringu ktory wysyla na port jest zakonczony 0x0d 0x0a potem jeszcze wysyla nul, spacje i LF ( 0x00, 0x20, 0x0a) - po co? to juz nie potrzebne
4. Klawisz Test i ptaszka Write bym polaczyl i zrobil z tego klawisz Start,  klikniecie na niego sprawdzaloby czy port jest wolny
    jak tak to od razu wysylalbym na port, a klawisz Start zmienilby napis na Stop  - klikniecie na Stop zatrzymuje transmisje i znow rtobi sie Start(em)
   Chyba ze zostawic ptaszka Write ale jak bedzie zapamietany to po uruchomieniu od razu wysyla na RS232 nie pytajac o nic.
5. Mozliwosc uruchamiania drugiego sterownika jest fajna ale nalezy przemyslec czy wskazane jest zamykanie obu na raz, teraz zamkniecie
    jednego powoduje zamkniecie drugiego i co z zapamietywaniem ustawien roznych dla kazdego?
6. Czy wprowadzic wybor innych  foramtow dal wysylanego stringa: GS232, EasyComm1, itd.



 */