using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace TransferMate
{
    public partial class Form1 : Form
    {

        private CancellationTokenSource _cancellationTokenSource;
        private CancellationToken _cancellationToken;
        private Task _task;
        public static string _localIp4;
        public bool iste_;
        public int _port;
        public TcpListener listener;
        public Form1()
        {
            InitializeComponent();
            this.Region = System.Drawing.Region.FromHrgn(StaticMethods.FormMethods.Radius.CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            _port = 20;
            iste_ = false;
            GetLocalIPv4();
            IsDocumentExists();
            GetAllDocuments();
            CheckMate();
            IpAdressLbl.Text = "Your Ip Adress: " + _localIp4.ToString();
        }
        public static void IsDocumentExists()
        {
            string folderName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TMate";
            string folderNameDownload = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TMate\\Download";
            string fileName = folderName + "\\MyMate.txt";
            // Klasörü Kontrolü
            if (!Directory.Exists(folderName))
                Directory.CreateDirectory(folderName);
            if (!Directory.Exists(folderNameDownload))
                Directory.CreateDirectory(folderNameDownload);

            if (File.Exists(fileName))
            {
                Console.WriteLine("Dosya mevcut.");
            }
            else
            {
                Console.WriteLine("Dosya mevcut deðil.");
            }

        }

        private void Addmate_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender; // Cast sender to Button type
            textBox1.Text = clickedButton.Text.Split('-')[0];
            textBox2.Text = clickedButton.Text.Split('-')[1];
        }
        public void SetMate(string MateArray)
        {
            var Array = MateArray.Split('$');
            myMatesPanel.Controls.Clear();
            foreach (var item in Array)
            {
                if (item.Trim().Count() > 5)
                {
                    Button button = new Button();
                    button.Text = item.Split('|')[0].Trim() + "-" + item.Split('|')[1].Trim();
                    button.Width = myMatesPanel.Width - 1;
                    button.Height = 28;
                    button.Click += new EventHandler(Addmate_Click);
                    myMatesPanel.Controls.Add(button);
                }
            }
        }
        public void CheckMate()
        {
            string folderName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TMate";
            string fileName = folderName + "\\MyMate.txt";
            if (File.Exists(fileName))
            {
                StreamReader reader = new StreamReader(fileName);
                var mates = reader.ReadToEnd();
                reader.Close();
                if (mates != null)
                    SetMate(mates);


            }
            else
            {
                StreamWriter writer = new StreamWriter(fileName);
                writer.Write(" ");
                writer.Close();
            }
        }
        private void OpenFile_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender; // Cast sender to Button type
            try
            {
                string filePath = (string)clickedButton.Tag;
                string extension = Path.GetExtension(filePath);
                string applicationPath = "";
                switch (extension)
                {
                    case ".txt":
                        applicationPath = "notepad.exe";
                        break;
                    case ".doc":
                    case ".docx":
                        applicationPath = "winword.exe";
                        break;
                    case ".xls":
                    case ".xlsx":
                        applicationPath = "excel.exe";
                        break;
                    case ".ppt":
                    case ".pptx":
                        applicationPath = "powerpnt.exe";
                        break;
                    case ".pdf":
                        applicationPath = "AcroRd32.exe";
                        break;
                    case ".png":
                    case ".bmp":
                    case ".gif":
                    case ".jpeg":
                    case ".jpg":
                        applicationPath = "mspaint.exe";
                        break;
                    default:
                        //Dosya tipi desteklenmiyor
                        return;
                }

                Process.Start(applicationPath, filePath);
            }
            catch (Exception)
            {
                MessageBox.Show(" Not Found ! ");
            }
        }
        public void GetAllDocuments()
        {
            string folderNameDownload = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TMate\\Download";
            dosyalarPaneli.Controls.Clear();
            if (Directory.Exists(folderNameDownload))
            {
                string[] files = Directory.GetFiles(folderNameDownload);
                foreach (string file in files)
                {
                    string fileName = file.Substring(file.LastIndexOf("\\") + 1);
                    Button btn = new Button();
                    btn.Text = fileName;
                    btn.Width = dosyalarPaneli.Width - 1;
                    btn.Height = 28;
                    btn.Tag = file;
                    btn.Click += new EventHandler(OpenFile_Click);
                    dosyalarPaneli.Controls.Add(btn);
                }
            }
        }
        public static void GetLocalIPv4()
        {
            string localIPv4 = "";
            foreach (IPAddress ip in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIPv4 = ip.ToString();
                    break;
                }
            }
            _localIp4 = localIPv4;
        }
        public void ChangeBtnBackGroundColor()
        {
            istedurdurbtn.Text = "Bekliyor";
            istedurdurbtn.BackColor = Color.Tomato;

        }
        private async void button1_Click(object sender, EventArgs e)
        {
            if (!iste_)
            {
                iste_ = true;
                _cancellationTokenSource = new CancellationTokenSource();
                _cancellationToken = _cancellationTokenSource.Token;
                _task = new Task(async () => await FileIsExpected(_cancellationToken), _cancellationToken);
                _task.Start();
                istedurdurbtn.Text = "Durdur";
                istedurdurbtn.BackColor = Color.DarkRed;
            }
            else
            {
                _cancellationTokenSource.Cancel();
                listener.Stop();
                istedurdurbtn.Text = "Ýste";
                istedurdurbtn.BackColor = Color.SteelBlue;
                iste_ = false;
            }
        }
        public async Task FileIsExpected(CancellationToken cancellationToken)
        {
            try
            {

                // Sunucunun IP adresi ve port numarasý
                IPAddress ipAddress = IPAddress.Parse(_localIp4);
                // Sunucu IP adresi ve port numarasý
                int port = _port;
                listener = new TcpListener(ipAddress, port);
                listener.Start();
                TcpClient client = await listener.AcceptTcpClientAsync();
                NetworkStream netStream = client.GetStream();
                // Dosya adý ve boyutu alýnýyor
                byte[] buffer = new byte[sizeof(int)];
                await netStream.ReadAsync(buffer, 0, buffer.Length);
                int fileNameLength = BitConverter.ToInt32(buffer, 0);
                buffer = new byte[fileNameLength];
                await netStream.ReadAsync(buffer, 0, buffer.Length);
                string fileName = Encoding.UTF8.GetString(buffer);
                buffer = new byte[sizeof(long)];
                await netStream.ReadAsync(buffer, 0, buffer.Length);
                long fileSize = BitConverter.ToInt64(buffer, 0);

                // Dosya alýnýyor
                string savePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TMate\\Download", fileName);
                FileStream fileStream = new FileStream(savePath, FileMode.Create);
                buffer = new byte[1024];
                int bytesRead = await netStream.ReadAsync(buffer, 0, buffer.Length);
                while (bytesRead > 0)
                {
                    await fileStream.WriteAsync(buffer, 0, bytesRead);
                    bytesRead = await netStream.ReadAsync(buffer, 0, buffer.Length);
                }
                fileStream.Close();
                // Að akýþlarý kapatýlýyor
                netStream.Close();
                client.Close();

                listener.Stop();
                client.Close();
                cancellationToken.ThrowIfCancellationRequested();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Copy That");
                _cancellationTokenSource.Cancel();
                GetAllDocuments();

            }
        
        }
        private void button4_Click(object sender, EventArgs e)
        {
            bool isitNull = true;
            string ip = textBox1.Text.Trim();
            string person = textBox2.Text.Trim();
            string folderName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TMate";
            string fileName = folderName + "\\MyMate.txt";
            StreamReader reader = new StreamReader(fileName);
            string leftover = reader.ReadToEnd();
            isitNull = leftover.Count() == 0;
            reader.Close();

            if (isitNull)
            {
                StreamWriter writer = new StreamWriter(fileName);
                writer.Write(ip + "|" + person + "$");
                writer.Close();
                CheckMate();
            }
            else
            {
                if (!leftover.Contains(ip))
                {
                    StreamWriter writer = new StreamWriter(fileName);
                    writer.Write(leftover + ip + "|" + person + "$");
                    writer.Close();
                    CheckMate();
                }


            }

            if (textBox1.Text != null && textBox2.Text != null && textBox3.Text != null)
            {
                if (iste_)
                {
                    _cancellationTokenSource.Cancel();
                    listener.Stop();
                    istedurdurbtn.Text = "Ýste";
                    istedurdurbtn.BackColor = Color.SteelBlue;
                    iste_ = false;
                }
                SendToPort();
            }


        }
        public void SendToPort()
        {


            // Gönderilecek dosyanýn yolu kullanýcýdan alýnýyor
            try
            {
                string filePath = textBox3.Text.Trim();
                string fileName = Path.GetFileName(filePath);
                long fileSize = new FileInfo(filePath).Length;
                TcpClient client = new TcpClient(textBox1.Text.Trim(), _port);
                NetworkStream netStream = client.GetStream();
                byte[] buffer = BitConverter.GetBytes(fileName.Length);
                netStream.Write(buffer, 0, buffer.Length);
                buffer = Encoding.UTF8.GetBytes(fileName);
                netStream.Write(buffer, 0, buffer.Length);
                buffer = BitConverter.GetBytes(fileSize);
                netStream.Write(buffer, 0, buffer.Length);
                FileStream fileStream = new FileStream(filePath, FileMode.Open);
                buffer = new byte[1024];
                int bytesRead = fileStream.Read(buffer, 0, buffer.Length);
                while (bytesRead > 0)
                {
                    netStream.Write(buffer, 0, bytesRead);
                    bytesRead = fileStream.Read(buffer, 0, buffer.Length);
                }
                fileStream.Close();
                netStream.Close();
                client.Close();
                MessageBox.Show("Sended");

            }
            catch (Exception)
            {
                MessageBox.Show("There Is No Ip Adress in This Local");

            }


        }
        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = openFileDialog1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        int Mouse_X;
        int Mouse_Y;
        int Movex = 0;

        private void panel1_MouseUp_1(object sender, MouseEventArgs e)
        {
            Movex = 0;
        }
        private void panel1_MouseDown_1(object sender, MouseEventArgs e)
        {
            Movex = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;
        }
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Movex == 1)
            {
                this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);
            }
        }




        private void textBox4_KeyUp(object sender, KeyEventArgs e)
        {
            foreach (Button item in dosyalarPaneli.Controls)
            {

                if (!item.Text.Contains(textBox4.Text))
                {
                    item.Hide();
                }

                if (textBox4.Text == "")
                {
                    item.Show();
                }

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            GetAllDocuments();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string folderNameDownload = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TMate\\Download";
            Process.Start("explorer.exe", folderNameDownload);
        }

      
    }
}