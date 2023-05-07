using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;
using System.Security.Cryptography.X509Certificates;

namespace rungame
{
    public partial class Form1 : Form
    {
        public int currentIndex1 = 0;
        public int currentIndex2 = 0;
        public int currentIndex3 = 0;
        public int characterHP = 3;
        bool spikes;
        public string[] arr = { "C:\\Users\\maxke\\OneDrive\\Робочий стіл\\task\\rungame\\rungame\\NewFolder1\\Run (1).png",
            "C:\\Users\\maxke\\OneDrive\\Робочий стіл\\task\\rungame\\rungame\\NewFolder1\\Run (2).png",
        "C:\\Users\\maxke\\OneDrive\\Робочий стіл\\task\\rungame\\rungame\\NewFolder1\\Run (3).png",
        "C:\\Users\\maxke\\OneDrive\\Робочий стіл\\task\\rungame\\rungame\\NewFolder1\\Run (4).png",
        "C:\\Users\\maxke\\OneDrive\\Робочий стіл\\task\\rungame\\rungame\\NewFolder1\\Run (5).png",
        "C:\\Users\\maxke\\OneDrive\\Робочий стіл\\task\\rungame\\rungame\\NewFolder1\\Run (6).png",
        "C:\\Users\\maxke\\OneDrive\\Робочий стіл\\task\\rungame\\rungame\\NewFolder1\\Run (7).png",
        "C:\\Users\\maxke\\OneDrive\\Робочий стіл\\task\\rungame\\rungame\\NewFolder1\\Run (8).png",
        "C:\\Users\\maxke\\OneDrive\\Робочий стіл\\task\\rungame\\rungame\\NewFolder1\\Run (9).png",
        "C:\\Users\\maxke\\OneDrive\\Робочий стіл\\task\\rungame\\rungame\\NewFolder1\\Run (10).png",
        "C:\\Users\\maxke\\OneDrive\\Робочий стіл\\task\\rungame\\rungame\\NewFolder1\\Run (11).png",
        "C:\\Users\\maxke\\OneDrive\\Робочий стіл\\task\\rungame\\rungame\\NewFolder1\\Run (12).png",
        "C:\\Users\\maxke\\OneDrive\\Робочий стіл\\task\\rungame\\rungame\\NewFolder1\\Run (13).png",
        "C:\\Users\\maxke\\OneDrive\\Робочий стіл\\task\\rungame\\rungame\\NewFolder1\\Run (14).png",
        "C:\\Users\\maxke\\OneDrive\\Робочий стіл\\task\\rungame\\rungame\\NewFolder1\\Run (15).png"};
        public string[] spikeArr = { "C:\\Users\\maxke\\OneDrive\\Робочий стіл\\task\\rungame\\rungame\\NewFolder2\\long_wood_spike_01.png",
        "C:\\Users\\maxke\\OneDrive\\Робочий стіл\\task\\rungame\\rungame\\NewFolder2\\long_wood_spike_05.png"};
        Thread t;
        public Form1()
        {

            InitializeComponent();
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);

            character.Image = System.Drawing.Image.FromFile(arr[currentIndex1]);
            timer1.Interval = 100;
            pictureBox1.Image= System.Drawing.Image.FromFile(spikeArr[currentIndex2]);
            
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        
        
        

        

        public void timer1_Tick(object sender, EventArgs e)
        {
            currentIndex1++;
            currentIndex3++;
            if (currentIndex1 == arr.Length)
            {
                currentIndex1 = 0;
            }
            character.Image = System.Drawing.Image.FromFile(arr[currentIndex1]);
            if (currentIndex3 == 15)
            {
                currentIndex2++;
                if (currentIndex2 == 1)
                {
                    spikes = true;
                }
                if (currentIndex2 != 1)
                {
                    spikes=false;
                }
                if (currentIndex2 == spikeArr.Length)
                {
                    currentIndex2 = 0;
                }
                pictureBox1.Image = System.Drawing.Image.FromFile(spikeArr[currentIndex2]);
                currentIndex3 = 0;
            }
        }
       
        public void isCharacterAlive()
        {
            int characterX = character.Left;
            int characterY = character.Top;
            int characterWidth = character.Width;
            int characterHeight = character.Height;
            int spike1X = pictureBox1.Left;
            int spike1Y = pictureBox1.Top;
            int spike1Width = pictureBox1.Width;
            int spike1Height = pictureBox1.Height;
            Rectangle characterRect = new Rectangle(characterX, characterY, characterWidth/2, characterHeight/2);
            Rectangle spike1Rect = new Rectangle(spike1X, spike1Y, spike1Width/2, spike1Height/2);
            if (characterRect.IntersectsWith(spike1Rect))
            {
                if (spikes == true)
                {
                    characterHP--;
                    label1.Text = $"currentHP={characterHP}";
                }
                
                
            }
            if (characterHP == 0)
            {
                this.Close();
                t = new Thread(open);
                t.Start();
            }

        }
        public void open(object sender)
        {
            System.Windows.Forms.Application.Run(new Form2());
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.W)
            {
                character.Top -= 10; // adjust the value to change the speed of movement
            }

           
            if (e.KeyCode == Keys.S)
            {
                character.Top += 10; // adjust the value to change the speed of movement
            }

            
            if (e.KeyCode == Keys.A)
            {
                character.Left -= 10; // adjust the value to change the speed of movement
            }

           
            if (e.KeyCode == Keys.D)
            {
                character.Left += 10; // adjust the value to change the speed of movement
            }
            isCharacterAlive();
        }
    }
}
