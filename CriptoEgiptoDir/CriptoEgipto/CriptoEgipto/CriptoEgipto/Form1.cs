using System;
using System.Timers;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CriptoEgipto
{
    public partial class Home : Form
    {

        private System.Timers.Timer minuteTimer;
        private System.Windows.Forms.Timer progressTimer;
        private int progressBarValue;
        private int lapseProgressBarSeg = 30;//30 seg

        public Home()
        {
            InitializeComponent();
            InitializeTimers();
        }

        private void btnGetTest_Click(object sender, EventArgs e)
        {

        }

        private void pbMainProgressBar_Click(object sender, EventArgs e)
        {
            if (progressBarValue < lapseProgressBarSeg)
            {
                progressBarValue++;
                pbMainProgressBar.Value = progressBarValue;
            }
        }

        /*<<<<---------------------------->>>>>*/
        //Funciones no relacionadas con el UI
        /*<<<<---------------------------->>>>>*/

        private void ExecuteFunction()
        {
            // Your function logic here
            Console.WriteLine("Function executed at: " + DateTime.Now);
        }

        private void InitializeTimers()
        {
            // Configure the timer to execute every minute (lapseProgressBarSeg milliseconds)
            minuteTimer = new System.Timers.Timer(30000);
            minuteTimer.Elapsed += OnMinuteTimerElapsed;
            minuteTimer.AutoReset = true;
            minuteTimer.Enabled = true;

            // Configure the progress bar timer to update every second (1000 milliseconds)
            progressTimer = new System.Windows.Forms.Timer();
            progressTimer.Interval = 1000;
            progressTimer.Tick += pbMainProgressBar_Click;
            progressTimer.Start();

            // Initialize the progress bar
            pbMainProgressBar.Minimum = 0;
            pbMainProgressBar.Maximum = lapseProgressBarSeg;
            pbMainProgressBar.Value = 0;
            progressBarValue = 0;
        }

        private void OnMinuteTimerElapsed(object sender, ElapsedEventArgs e)
        {
            // Execute the function you want to run every minute
            ExecuteFunction();

            // Reset the progress bar
            this.Invoke((MethodInvoker)delegate
            {
                pbMainProgressBar.Value = 0;
                progressBarValue = 0;
            });
        }

    }
}
