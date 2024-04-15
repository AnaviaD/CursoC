using System.Timers;

namespace StopWatch
{
    public partial class Form1 : Form
    {

        System.Timers.Timer timer;
        int h, m, s, ms;


        public Form1()
        {
            InitializeComponent();
            //Desabilitamos el btn de stop
            stopBtn.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer = new System.Timers.Timer();
            timer.Interval = 1;
            timer.Elapsed += OnTimeEvent;
        }

        private void OnTimeEvent(object? sender, ElapsedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                ms += 1;
                if (ms == 100)
                {
                    ms = 0;
                    s += 1;
                }
                if (s == 60)
                {
                    s = 0;
                    m += 1;
                }
                if (m == 60)
                {
                    m = 0;
                    h += 1;
                }

                textScreen.Text = string.Format("{0}:{1}:{2}:{3}", h.ToString().PadLeft(2, '0'), m.ToString().PadLeft(2, '0'), s.ToString().PadLeft(2, '0'), ms.ToString().PadLeft(2, '0'));

            }));
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            timer.Start();
            //Damos estado a los botones
            startBtn.Enabled = false;
            resetBtn.Enabled = false;
            stopBtn.Enabled = true;

        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            timer.Stop();
            //Damos estado a los botones
            startBtn.Enabled = true;
            resetBtn.Enabled = true;
            stopBtn.Enabled = false;
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            timer.Stop();
            h = 0;
            m = 0;
            s = 0;
            ms = 0;
            textScreen.Text = "00:00:00:00";
        }

        private void lb_mainAction_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void cb_mainAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cb_mainAction.Items.Add(".Net");
            //cb_mainAction.Items.Add("Angular");
            //cb_mainAction.Items.Add("Azure");
            //cb_mainAction.Items.Add("HackerRank");
            //cb_mainAction.Items.Add("Search Job");
        }
    }
}
